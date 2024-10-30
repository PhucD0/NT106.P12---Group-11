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

        /// <summary>
        /// Xu li ket noi
        /// </summary>
        
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
        /// Luu dia chi IP và port
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveIP_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Gui file qua server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
            byte[] header = BitConverter.GetBytes((ushort)2); // Gi? s? 2 là lo?i yêu c?u xem logs
            byte[] length = BitConverter.GetBytes(0); // Không có d? li?u thêm, ch? là yêu c?u

            stream.Write(header, 0, header.Length);
            stream.Write(length, 0, length.Length);

            ReceiveLogsFromServer();
        }

        private void ReceiveLogsFromServer()
        {
            byte[] header = BitConverter.GetBytes((ushort)2); // 2 có th? ??i di?n cho yêu c?u logs
            stream.Write(header, 0, header.Length);

            byte[] logsBytes = new byte[2048]; // T?ng kích th??c n?u c?n
            int bytesRead = stream.Read(logsBytes, 0, logsBytes.Length);

            string logs = Encoding.ASCII.GetString(logsBytes, 0, bytesRead);

            // Ghi logs vào m?t file t?m th?i và m? Notepad
            string tempFilePath = Path.GetTempPath() + "connection_logs.txt";
            File.WriteAllText(tempFilePath, logs);
            System.Diagnostics.Process.Start("notepad.exe", tempFilePath);
        }

        /// <summary>
        /// Thêm, xóa dia chi IP và port
        /// </summary>


    }
}
