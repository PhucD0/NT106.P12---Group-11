using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    public partial class Server : Form
    {
        private TcpClient client;
        public StreamReader str;
        private int serverPort = 8000;
        public StreamWriter stw;
        public string receive;
        public string TextToSend;
        public Server()
        {
            InitializeComponent();
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    TextboxIP.Text = address.ToString();
            }
        }

        private void ButtonListen_Click(object sender, EventArgs e)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, serverPort);
            listener.Start();
            TextboxConversation.Text = "Start listening";
            client = listener.AcceptTcpClient();    
            str = new StreamReader(client.GetStream());
            stw = new StreamWriter(client.GetStream());
            stw.AutoFlush = true;
            backgroundWorker1.RunWorkerAsync();
            backgroundWorker2.WorkerSupportsCancellation = true;  
        }

    }
}
