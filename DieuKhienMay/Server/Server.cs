global using global::System;
global using global::System.Collections.Generic;
global using global::System.Drawing;
global using global::System.IO;
global using global::System.Linq;
global using global::System.Net.Http;
global using global::System.Threading;
global using global::System.Threading.Tasks;
global using global::System.Windows.Forms;
using System.Net.Sockets;

namespace Server
{
    public partial class Server : Form
    {
        // KHAI BAO HERE
        private TcpListener listener;
        private TcpClient client;
        private NetworkStream stream;
        private bool isConnected = false;

        public Server()
        {
            InitializeComponent();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopListening();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            StartListening();
        }

        // Bắt đầu lắng nghe từ client
        private void StartListening()
        {
            // có gọi hàm HandleClientInput here
        }

        // Ket thuc ket noi
        private void StopListening()
        {

        }

        // Nhận thông tin điều khiển từ client
        private void HandleClientInput()
        {
            try
            {
                // Xử lí gói tin nhận được từ client
                while(client.Connected)
                {
                    byte[] headerBytesRecv = new byte[6];
                    stream.Read(headerBytesRecv, 0, headerBytesRecv.Length);

                    // Phân loại dữ liệu theo header

                    // 0: dữ liệu ảnh, 1: dữ liệu input
                    int dataType = BitConverter.ToInt32(headerBytesRecv, 0);
                    // độ dài dữ liệu input
                    int dataLength = BitConverter.ToInt32(headerBytesRecv, 2);

                    if(dataType == 0)   // client yêu cầu gửi ảnh màn hình từ server
                    {
                        if(isConnected)
                        {
                            // code something here, co dung ham SendImage()
                        }
                    }
                    else if(dataType == 1) // xử lí dữ liệu input từ client
                    {
                        byte[] dataBytesRecv = new byte[dataLength];
                        stream.Read(dataBytesRecv, 0, dataLength);
                        HandleInputBytes(dataBytesRecv);
                    }
                    else
                    {
                        // Kết nối thất bại
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Exception: {ex.Message}");
            }
        }

        // Xu li du lieu 
        private void HandleInputBytes(byte[] inputBytes)
        {
            // code something here
        }

        // Gui anh
        private void SendImage()
        {

        }

        // Cap nhat trang thai, được gọi bởi StartListening(), StopListening(),...
        private void UpdateStatus(string message)
        {

        }

        // Nhận file từ client
    }
}
