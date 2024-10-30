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

namespace Client
{
    public partial class Client : Form
    {
        // KHAI BAO HERE
        private NetworkStream stream;
        private TcpClient client;

        public Client()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectToServer();
        }

        // Ket noi den server
        private void ConnectToServer()
        {
            try
            {
                //// code ket noi den server here

                // Bat dau lang nghe tu server
                ListenAndDisplayImages();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ket noi that bai: {ex.Message}");
            }
        }

        // Lang nghe và hien thi du lieu hình anh bên phía server
        private void ListenAndDisplayImages()
        {
            new Thread(() =>
            {
                try
                {
                    while (client.Connected)
                    {

                        // nhan du lieu anh tu server và hien thi lên picturebox
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Loi lang nghe du lieu tu server: {ex.Message}");
                }
            }).Start();
        }

        // Xu li input va gui toi server
        private void SendInputData(byte[] inputData)
        {
            // code something here
        }
        // Ham SendInputDat duoc goi qua cac su kien cua chuot va ban phim

        // Luu dia chi IP và port
        private void btnSaveIP_Click(object sender, EventArgs e)
        {

        }

        // Gui file qua server
        private void sendFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // Yeu cau lich su ket noi tu server
        private void requestLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RequestLogs();
        }

        private void RequestLogs()
        {

        }

        // Thêm, xóa dia chi IP và port
        

    }
}
