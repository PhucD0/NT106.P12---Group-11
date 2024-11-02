using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Text;
using System.Configuration;
using System.Net;
//using Client.Properties;


namespace Client
{
    public partial class Client : Form
    {
        // KHAI BAO HERE
        private NetworkStream stream;
        private  TcpClient client;
        private List<(string ip, int port)> savedConnections = new List<(string, int)>();
        private const int maxConnectionAttempts = 5;

        public Client()
        {
            InitializeComponent();

            // Gọi sự kiện khi mouse hover vào textbox IP
            txbIP.MouseHover += TxtIP_MouseHover;

            this.Click += (s, e) => HideValidIPs();


        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectToServer();
        }

        /// <summary>
        /// Xu li ket noi
        /// </summary>

        // Ket noi den server
        private void ConnectToServer()
        {

            // Đảm bảo rằng mọi đối tượng client cũ đều đã được đóng hoàn toàn
            if (client != null && client.Connected)
            {
                client.Close();
            }

            // Khởi tạo một đối tượng TcpClient mới cho mỗi lần kết nối
            client = new TcpClient();

            int port;

            if (!IsValidIP(txbIP.Text) || !int.TryParse(txbPort.Text.Trim(), out port) || !IsValidPort(port))
            {
                MessageBox.Show("Địa chỉ IP hoặc Port không hợp lệ. Vui lòng kiểm tra lại.");
                return;
            }

            int attempts = 0;

                try
                {
                    client.Connect(txbIP.Text, port);  // Kết nối đến server

                    if (client.Connected)
                    {
                        stream = client.GetStream();
                        MessageBox.Show("Kết nối thành công đến server!");

                        // Bắt đầu lắng nghe và hiển thị hình ảnh từ server
                        //ListenAndDisplayImages();

                        return;
                    }
                }
                catch (SocketException ex)
                {
                    attempts++;
                    MessageBox.Show($"Lỗi kết nối đến server: {ex.Message}.");


                }

            MessageBox.Show("Không thể kết nối đến server sau nhiều lần thử. Vui lòng kiểm tra lại kết nối.");
        }

        /// <summary>
        /// Xử lí ảnh
        /// </summary>
        // Lang nghe và hien thi du lieu hình anh bên phía server
        private void ListenAndDisplayImages()
        {
            new Thread(() =>
            {
                try
                {
                    while (client.Connected)
                    {

                        // Đọc header để xác định loại dữ liệu (0 cho hình ảnh)
                        byte[] header = new byte[2];
                        stream.Read(header, 0, header.Length);
                        ushort dataType = BitConverter.ToUInt16(header, 0);

                        // Đọc chiều dài dữ liệu hình ảnh
                        byte[] lengthBytes = new byte[2];
                        stream.Read(lengthBytes, 0, lengthBytes.Length);
                        ushort length = BitConverter.ToUInt16(lengthBytes, 0);

                        // Nếu loại dữ liệu là hình ảnh
                        if (dataType == 0) // 0 là mã loại dữ liệu hình ảnh
                        {
                            byte[] imageData = new byte[length];
                            stream.Read(imageData, 0, length); // Đọc dữ liệu hình ảnh

                            // Chuyển đổi byte array thành hình ảnh và hiển thị
                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                Image image = Image.FromStream(ms);
                                this.Invoke((MethodInvoker)delegate
                                {
                                    pictureBox.Image = image; // Hiển thị hình ảnh lên PictureBox
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Loi lang nghe du lieu tu server: {ex.Message}");
                }
            }).Start();
        }

        /// <summary>
        /// Xu li input va gui toi server
        /// </summary>
        /// <param name="inputData"></param>
        private void SendInputData(byte[] inputData)
        {
            // code something here
        }
        // Ham SendInputDat duoc goi qua cac su kien cua chuot va ban phim

        /// <summary>
        /// Gui file qua server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileTransfer fileTransfer = new FileTransfer();
            fileTransfer.Show();
        }

        /// <summary>
        /// View logs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        // Yeu cau lich su ket noi tu server
        private void requestLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RequestLogs();
        }

        private void RequestLogs()
        {
            byte[] header = BitConverter.GetBytes((ushort)2); // 2 là yêu cầu xem logs
            byte[] length = BitConverter.GetBytes(0); // Không có dữ liệu thêm

            stream.Write(header, 0, header.Length);
            stream.Write(length, 0, length.Length);

            ReceiveLogsFromServer();
        }

        private void ReceiveLogsFromServer()
        {
            byte[] header = BitConverter.GetBytes((ushort)2); // 2 là yêu cầu logs
            stream.Write(header, 0, header.Length);

            byte[] logsBytes = new byte[2048];
            int bytesRead = stream.Read(logsBytes, 0, logsBytes.Length);

            string logs = Encoding.ASCII.GetString(logsBytes, 0, bytesRead);

            // Ghi logs vào một file tạm thời và mở Notepad
            string tempFilePath = Path.GetTempPath() + "connection_logs.txt";
            File.WriteAllText(tempFilePath, logs);
            System.Diagnostics.Process.Start("notepad.exe", tempFilePath);
        }

        /// <summary>
        /// Luu dia chi IP và port
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveIP_Click(object sender, EventArgs e)
        {
            string ip = txbIP.Text.Trim();
            string portText = txbPort.Text.Trim();

            if (IsValidIP(ip) && int.TryParse(portText, out int port) && IsValidPort(port))
            {
                savedConnections.Add((ip, port));
                MessageBox.Show("Địa chỉ IP và Port đã được lưu.");
            }
            else
            {
                MessageBox.Show("Địa chỉ IP hoặc Port không hợp lệ.");
            }
        }

        private void TxtIP_MouseHover(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            foreach (var connection in savedConnections)
            {
                listBox.Items.Add($"{connection.ip}:{connection.port}");
            }

            if (listBox.Items.Count > 0)
            {
                listBox.Visible = true;
            }
            else
            {
                listBox.Visible = false;
            }
        }

        private bool IsValidIP(string ip)
        {
            return IPAddress.TryParse(ip, out _);
        }

        private bool IsValidPort(int port)
        {
            return port > 0 && port <= 65535;
        }

        private void listBox_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                string selected = listBox.SelectedItem.ToString();
                var parts = selected.Split(':');
                txbIP.Text = parts[0];
                txbPort.Text = parts[1];
                listBox.Visible = false;
            }
        }

        private void HideValidIPs()
        {  
            listBox.Visible = false;   
        }
    }
}
