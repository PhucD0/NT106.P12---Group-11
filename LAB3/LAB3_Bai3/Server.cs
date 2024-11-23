using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB3_Bai3
{
    public partial class Server : Form
    {
        private Socket listenerSocket;
        private Thread listeningThread;
        public Server()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }


        private void ListenForClients()
        {
            while (true)
            {
                try
                {
                    // Chấp nhận kết nối từ client
                    Socket clientSocket = listenerSocket.Accept();

                    // Tạo luồng mới để xử lý dữ liệu từ client
                    Thread clientThread = new Thread(() => HandleClient(clientSocket));
                    clientThread.IsBackground = true;
                    clientThread.Start();
                }
                catch (Exception ex)
                {
                    this.Invoke(new Action(() =>
                    {
                        txtMessages.AppendText($"Lỗi lắng nghe: {ex.Message}\r\n");
                    }));
                }
            }
        }

        private void HandleClient(Socket clientSocket)
        {
            try
            {
                byte[] buffer = new byte[1024];
                int receivedBytes;

                // Nhận dữ liệu từ client
                while ((receivedBytes = clientSocket.Receive(buffer)) > 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, receivedBytes);

                    // Hiển thị thông điệp lên form
                    this.Invoke(new Action(() =>
                    {
                        txtMessages.AppendText($"Client: {message}\r\n");
                    }));
                }
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() =>
                {
                    txtMessages.AppendText($"Lỗi client: {ex.Message}\r\n");
                }));
            }
            finally
            {
                clientSocket.Close();
            }
        }

        private void btnListen_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Tạo socket
                listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Bind socket tới địa chỉ và cổng
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 8081);
                listenerSocket.Bind(endPoint);

                // Bắt đầu lắng nghe kết nối
                listenerSocket.Listen(10);
                txtMessages.AppendText("Đang lắng nghe trên cổng 8081...\r\n");

                // Tạo luồng để lắng nghe các client
                listeningThread = new Thread(ListenForClients);
                listeningThread.IsBackground = true;
                listeningThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
    }
}
