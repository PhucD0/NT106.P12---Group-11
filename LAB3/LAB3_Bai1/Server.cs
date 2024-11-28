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
    public partial class Server : Form
    {
        private UdpClient udpClient;
        private bool isListening = false;
        private int port = 8080;

        public Server()
        {
            InitializeComponent();
        }

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            Bai1 bai1 = new Bai1();
            bai1.Show();
            this.Hide();
        }

        public void serverThread()
        {
            if (listenButton.InvokeRequired)
            {
                listenButton.Invoke(new Action(() => listenButton.Text = "Listening..."));
            }
            else
            {
                listenButton.Text = "Listening...";
            }

            if (udpClient == null)
            {
                udpClient = new UdpClient(port);
            }
            isListening = true;
            while (isListening)
            {
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, port);
                byte[] receiveBytes = udpClient.Receive(ref remoteEP);
                string receiveString = Encoding.UTF8.GetString(receiveBytes);
                string senderInfo = $"[{remoteEP.Address.ToString()}]: {receiveString}";

                if (MessageTextBox.InvokeRequired)
                {
                    MessageTextBox.Invoke(new Action(() => MessageTextBox.AppendText(senderInfo + Environment.NewLine)));
                }
                else
                {
                    MessageTextBox.AppendText(senderInfo + Environment.NewLine);
                }
            }
        }

        private void listenButton_Click(object sender, EventArgs e)
        {
            Thread thdUDPServer = new Thread(new ThreadStart(serverThread)); 
            thdUDPServer.Start();
            MessageBox.Show("Start listening for incoming connections!");
        }
    }
}