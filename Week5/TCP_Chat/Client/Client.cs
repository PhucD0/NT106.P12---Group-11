using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    public partial class Client : Form
    {
        private TcpClient client;
        private int serverPort = 8000;
        public StreamReader str;
        public StreamWriter stw;
        public string receive;
        public string TextToSend;

        public Client()
        {
            InitializeComponent();
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            // Replace TextboxIP.Text with the IP address of the server
            // and the port number (make sure they match the server's port)
            string ipAddress = TextboxIP.Text; // e.g., "127.0.0.1"

            client = new TcpClient();
            client.Connect(ipAddress, serverPort); // Connect to the server

            str = new StreamReader(client.GetStream());
            stw = new StreamWriter(client.GetStream());
            stw.AutoFlush = true;

            // Start receiving messages in a background thread
            backgroundWorker1.RunWorkerAsync();
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            TextToSend = TextboxMessage.Text; // Assuming textBox1 is where the user types their message
            stw.WriteLine(TextToSend); // Send the message to the server
            TextboxMessage.Clear(); // Clear the input box after sending
        }


        private void ButtonPrivateRoom_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                try
                {
                    receive = str.ReadLine(); // Read incoming message from the server
                    if (receive != null)
                    {
                        // Invoke to update the UI thread
                        this.Invoke((MethodInvoker)delegate
                        {
                            // Assuming you have a TextBox or ListBox to display messages
                            TextboxConversation.AppendText(receive + Environment.NewLine); // Append received message
                        });
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that occur
                    MessageBox.Show(ex.Message);
                    break; // Exit loop on error
                }
            }
        }

    }
}
