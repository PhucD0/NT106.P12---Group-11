using System;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public partial class Server : Form
    {
        private IPEndPoint IPE;
        private TcpListener listener;
        public int port = 8000;
        public bool isRunning = true;

        // List to keep track of connected clients
        private List<Socket> clients = new List<Socket>();

        public Server()
        {
            InitializeComponent();
        }

        private void ButtonListen_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Start listening for incoming connections!");

            Task.Run(() =>
            {
                IPE = new IPEndPoint(IPAddress.Any, port);
                listener = new TcpListener(IPE);
                listener.Start(); // Start listening for client connections

                while (isRunning)
                {
                    try
                    {
                        // Accept incoming client connections
                        Socket client = listener.AcceptSocket(); // Blocking call that waits for a connection
                        clients.Add(client); // Add the new client to the list
                        NotifyConnection(client); // Notify server about the new connection
                        Task.Run(() => HandleClient(client));  // Handle each client in a separate task/thread
                    }
                    catch (SocketException ex)
                    {
                        MessageBox.Show(ex.Message); // Handle any exceptions that occur
                    }
                }
            });
        }

        // Notify server about new client connection
        private void NotifyConnection(Socket client)
        {
            string message = $"User connected: {client.RemoteEndPoint.ToString()}";
            AppendToConversation(message);
        }

        // Method to handle communication with each client
        void HandleClient(Socket client)
        {
            try
            {
                while (isRunning && client.Connected)
                {
                    byte[] rcv = new byte[1024];
                    int bytesRead = client.Receive(rcv); // Get the actual number of bytes received

                    if (bytesRead > 0) // Check if we received any data
                    {
                        string s = Encoding.UTF8.GetString(rcv, 0, bytesRead); // Decode only the received bytes
                        BroadcastMessage(s); // Broadcast the message to all clients
                    }
                }
            }
            catch (SocketException ex)
            {
                MessageBox.Show($"Client connection error: {ex.Message}");
            }
            finally
            {
                client.Close(); // Close the connection when done
                clients.Remove(client); // Remove the client from the list
            }
        }

        // Broadcast message to all connected clients
        private void BroadcastMessage(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message); // Convert message to bytes
            foreach (var client in clients)
            {
                if (client.Connected)
                {
                    client.Send(data); // Send message to each connected client
                }
            }
            AppendToConversation(message); // Display message on the server UI
        }

        private void AppendToConversation(string message)
        {
            if (TextboxConversation.InvokeRequired)
            {
                TextboxConversation.Invoke(new Action(() => AppendToConversation(message)));
            }
            else
            {
                // Append the received message to the conversation textbox
                TextboxConversation.Text += message + Environment.NewLine;
            }
        }
    }
}