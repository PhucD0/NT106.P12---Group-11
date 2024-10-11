using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Server : Form
    {
        private IPEndPoint IPE;
        private TcpListener listener;
        public int port = 8000;
        public bool isRunning = true;

        // Dictionary to map usernames to their corresponding client sockets
        private Dictionary<string, Socket> clients = new Dictionary<string, Socket>();

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
                        Task.Run(() => HandleClient(client));  // Handle each client in a separate task/thread
                    }
                    catch (SocketException ex)
                    {
                        MessageBox.Show(ex.Message); // Handle any exceptions that occur
                    }
                }
            });
        }

        // Method to handle communication with each client
        void HandleClient(Socket client)
        {
            try
            {
                byte[] rcv = new byte[1024];
                int bytesRead = client.Receive(rcv); // Get the actual number of bytes received
                string username = Encoding.UTF8.GetString(rcv, 0, bytesRead).Trim(); // Read username
                clients[username] = client; // Add to the clients dictionary
                NotifyConnection(username); // Notify server about the new connection

                while (isRunning && client.Connected)
                {
                    rcv = new byte[1024];
                    bytesRead = client.Receive(rcv); // Get the actual number of bytes received

                    if (bytesRead > 0) // Check if we received any data
                    {
                        string s = Encoding.UTF8.GetString(rcv, 0, bytesRead); // Decode only the received bytes
                        HandlePrivateMessage(s, username); // Handle private message
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
                // Remove client from the dictionary
                var disconnectedUser = clients.FirstOrDefault(x => x.Value == client).Key;
                if (disconnectedUser != null)
                {
                    clients.Remove(disconnectedUser);
                }
            }
        }

        // Notify server about new client connection
        private void NotifyConnection(string username)
        {
            string message = $"{username} connected.";
            AppendToConversation(message);
        }

        // Handle private messages
        private void HandlePrivateMessage(string message, string sender)
        {
            // Expecting message format: "recipient: message"
            var parts = message.Split(new[] { ':' }, 2);
            if (parts.Length < 2)
            {
                return; // Invalid message format
            }

            string recipient = parts[0].Trim();
            string privateMessage = parts[1].Trim();

            // Check if the recipient is connected
            if (clients.ContainsKey(recipient))
            {
                // Send private message to recipient
                byte[] data = Encoding.UTF8.GetBytes($"{sender}: {privateMessage}");
                clients[recipient].Send(data); // Send the message to the specific recipient

                // Echo the message back to the sender
                clients[sender].Send(data); // Send the same message back to the sender

                // Append the message to the server's conversation textbox
                AppendToConversation($"{sender} to {recipient}: {privateMessage}");
            }
            else
            {
                // Optionally notify the sender that the recipient is not connected
                byte[] data = Encoding.UTF8.GetBytes($"User {recipient} is not connected.");
                clients[sender].Send(data);
            }
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
