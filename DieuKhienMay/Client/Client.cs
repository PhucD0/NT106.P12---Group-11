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
using static System.Windows.Forms.DataFormats;
//using Client.Properties;
using FileTransfer;


namespace Client
{
    public partial class Client : Form
    {
        // KHAI BAO HERE
        private NetworkStream? stream;
        private TcpClient? client;
        private int port;
        private List<(string ip, int port)> savedConnections = new List<(string, int)>();
        private const int maxConnectionAttempts = 5;

        private ListBox listBox;


        public Client()
        {
            InitializeComponent();

            // Gọi sự kiện khi mouse hover vào textbox IP
            txbIP.MouseHover += TxtIP_MouseHover;

            CreateListBox();


            this.Click += (s, e) => HideValidIPs();


        }

        private void CreateListBox()
        {
            listBox = new ListBox();
            // Thiết lập chế độ vẽ OwnerDraw
            listBox.DrawMode = DrawMode.OwnerDrawFixed;
            listBox.DrawItem += ListBox_DrawItem;
            listBox.Location = new Point(txbIP.Left, txbIP.Bottom + 5); // Đặt ListBox dưới TextBox txpIP
            listBox.Size = new Size(200, 100); // Đặt kích thước của ListBox
            listBox.Visible = false; // Ẩn ListBox
            this.Controls.Add(listBox); // Thêm ListBox vào form
        }



        // Hàm vẽ từng mục với padding và màu nền khi chọn
        private void ListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index >= 0)
            {
                // Chọn màu nền khi chọn và không chọn
                Color backgroundColor = (e.State & DrawItemState.Selected) == DrawItemState.Selected
                    ? Color.LightBlue : Color.White;

                using (Brush brush = new SolidBrush(backgroundColor))
                {
                    e.Graphics.FillRectangle(brush, e.Bounds);
                }

                // Chọn màu và vẽ văn bản
                e.Graphics.DrawString(listBox.Items[e.Index].ToString(),
                    e.Font, Brushes.Black, e.Bounds.Left + 5, e.Bounds.Top + 2);
            }

            e.DrawFocusRectangle();
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
            port = int.Parse(txbPort.Text);
            client = new TcpClient();

            try
            {
                client.Connect(txbIP.Text, port);
                MessageBox.Show("Connected to server!");

                // Mở Form2 để hiển thị màn hình server
                Form1 displayForm = new Form1(client);
                displayForm.Show();
            }
            catch (Exception ex)
            {
                // Khi kết nối không thành công, gửi tín hiệu thất bại đến server
                SendFailedConnectionSignal();

                MessageBox.Show("Failed to connect: " + ex.Message);
            }
        }

        private void SendFailedConnectionSignal()
        {
            try
            {
                // Sử dụng một cổng tạm thời để gửi tín hiệu "Failed Connection" đến server
                using (TcpClient tempClient = new TcpClient())
                {
                    tempClient.Connect(txbIP.Text, 5002); // Kết nối đến cổng logs của server
                    using (NetworkStream stream = tempClient.GetStream())
                    {
                        // Gửi tín hiệu "FAILED_CONNECTION" qua stream
                        byte[] signal = Encoding.ASCII.GetBytes("FAILED_CONNECTION");
                        stream.Write(signal, 0, signal.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu không thể kết nối với server qua cổng 5001
                MessageBox.Show("Unable to send failed connection signal: " + ex.Message);
            }
        }

        /// <summary>
        /// Xử lí ảnh
        /// </summary>
        // Lang nghe và hien thi du lieu hình anh bên phía server


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
            mainForm main = new mainForm();
            main.Show();
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

        //bản 1
        private void RequestLogs()
        {
            using (TcpClient tempClient = new TcpClient())
            {
                try
                {
                    // Sử dụng cổng logs phụ để tránh ghi nhận là kết nối chính thức
                    int logPort = 5001; // Cổng logs phụ, thêm một TextBox cho port này nếu cần
                    tempClient.Connect(txbIP.Text, logPort); // Kết nối tạm thời đến cổng logs phụ của server
                    NetworkStream stream = tempClient.GetStream();

                    // Gửi yêu cầu "GETLOGS"
                    byte[] requestBytes = Encoding.ASCII.GetBytes("GETLOGS");
                    stream.Write(requestBytes, 0, requestBytes.Length);

                    // Đọc phản hồi chứa log
                    byte[] buffer = new byte[4096];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string logs = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                    // Lưu log vào một tệp tạm thời
                    string tempFilePath = Path.Combine(Path.GetTempPath(), "ConnectionLogs.txt");
                    File.WriteAllText(tempFilePath, logs);

                    // Mở tệp log bằng Notepad
                    System.Diagnostics.Process.Start("notepad.exe", tempFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể lấy log: " + ex.Message);
                }
            }
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
            listBox.BringToFront();

            foreach (var connection in savedConnections)
            {
                listBox.Items.Add($"{connection.ip}:{connection.port}");
            }

            if (listBox.Items.Count > 0)
            {
                listBox.Visible = true;
                listBox.MouseClick += listBox_MouseClick_1;

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
