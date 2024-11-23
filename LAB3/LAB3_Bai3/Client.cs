using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Net.Http;

namespace LAB3_Bai3
{
    public partial class Client : Form
    {
        private TcpClient _tcpClient;
        private NetworkStream networkStream;
        public Client()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            TcpClient tcpClient = new TcpClient();
            IPAddress iPAddress = IPAddress.Parse("192.168.2.17");
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 8081);
            tcpClient.Connect(iPEndPoint);
            networkStream = tcpClient.GetStream();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (networkStream != null && networkStream.CanWrite)
            {
                // Chuyển chuỗi thành mảng byte và gửi
                string msg = textBox1.Text;
                byte[] data = Encoding.UTF8.GetBytes(msg);
                networkStream.Write(data, 0, data.Length);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (networkStream != null)
            {
                Byte[] data = System.Text.Encoding.UTF8.GetBytes("quit\n");
                networkStream.Write(data, 0, data.Length);
                networkStream.Close();
            }

            if (_tcpClient != null)
            {
                _tcpClient.Close();
            }
        }
    }
}
