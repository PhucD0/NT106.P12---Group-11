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

namespace LAB3_Bai1
{
    public partial class Client : Form
    {
        private int port = 8080;
        public Client()
        {
            InitializeComponent();
        }

        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            Bai1 bai1 = new Bai1();
            bai1.Show();
            this.Hide();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            UdpClient udpClient = new UdpClient();
            byte[] sendBytes = Encoding.UTF8.GetBytes(MessageTextBox.Text);
            udpClient.Send(sendBytes, sendBytes.Length, "localhost", port);
            MessageTextBox.Text = string.Empty;
        }
    }
}
