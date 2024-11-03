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


namespace Client
{
    public partial class Client : Form
    {
        // KHAI BAO HERE
        private NetworkStream stream;
        private  TcpClient client;
        private int port;
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
                MessageBox.Show("Failed to connect: " + ex.Message);
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
