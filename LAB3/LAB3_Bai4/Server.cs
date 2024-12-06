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

namespace LAB3_Bai4
{
    public partial class Server : Form
    {
        private IPEndPoint IPE;
        private TcpListener listener;
        public int port = 8000;
        public bool isRunning = false;

        // Dictionary to map usernames to their corresponding client sockets
        private Dictionary<string, Socket> clients = new Dictionary<string, Socket>();
        List<TcpClient> clientsList = new List<TcpClient>();

        public Server()
        {
            InitializeComponent();
        }

        private void buttonListen_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Start listening for incoming connections!");
            buttonListen.Text = "Listening..."; // Change button text to "Listening"
            isRunning = true;

            Thread listenerThread = new Thread(() =>
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
                        Thread clientThread = new Thread(() => HandleClient(client));  // Handle each client in a separate thread
                        clientThread.Start();
                    }
                    catch (SocketException ex)
                    {
                        MessageBox.Show(ex.Message); // Handle any exceptions that occur
                    }
                }
            });

            listenerThread.Start();
        }

        // Method to handle communication with each client
        void HandleClient(Socket client)
        {
            string username = null;
            try
            {
                byte[] rcv = new byte[1024];
                int bytesRead = client.Receive(rcv); // Get the actual number of bytes received
                username = Encoding.UTF8.GetString(rcv, 0, bytesRead).Trim(); // Read username

                // Check if the username is already taken
                if (clients.ContainsKey(username))
                {
                    byte[] data = Encoding.UTF8.GetBytes("Username already taken. Please try again with a different username.");
                    client.Send(data);
                    client.Close();
                    return;
                }

                clients[username] = client; // Add to the clients dictionary
                NotifyConnection(username); // Notify server about the new connection

                while (isRunning && client.Connected)
                {
                    rcv = new byte[1024];
                    bytesRead = client.Receive(rcv); // Get the actual number of bytes received

                    if (bytesRead > 0) // Check if we received any data
                    {
                        string message = Encoding.UTF8.GetString(rcv, 0, bytesRead); // Decode only the received bytes
                        if (message == "/disconnect")
                        {
                            // Handle client disconnection
                            break;
                        }
                        else if (message.StartsWith("/pm"))
                        {
                            HandlePrivateMessage(message, username);
                        }
                        else
                        {
                            BroadcastMessage(message, username); // Broadcast message to all clients
                        }
                    }
                }
            }
            catch (SocketException ex)
            {
                MessageBox.Show($"Client connection error: {ex.Message}");
            }
            finally
            {
                if (username != null)
                {
                    clients.Remove(username); // Remove client from the dictionary
                    BroadcastMessage($"{username} has disconnected.", "Server"); // Notify all clients about the disconnection
                    SendClientList(); // Notify all clients about the updated client list
                }
                client.Close(); // Close the connection when done
            }
        }

        private void HandlePrivateMessage(string message, string sender)
        {
            // Expected format: /pm recipientUsername message
            var splitMessage = message.Split(new[] { ' ' }, 3);
            if (splitMessage.Length < 3)
            {
                // Invalid private message format
                return;
            }

            string recipientUsername = splitMessage[1];
            string privateMessage = splitMessage[2];

            // Check if the recipient is the same as the sender
            if (recipientUsername == sender)
            {
                clients[sender].Send(Encoding.UTF8.GetBytes("You cannot send a private message to yourself."));
                return;
            }

            if (clients.TryGetValue(recipientUsername, out Socket recipientSocket))
            {
                string fullMessage = $"[Private from {sender}]: {privateMessage}";
                byte[] data = Encoding.UTF8.GetBytes(fullMessage);
                recipientSocket.Send(data);

                // Optionally, send a confirmation to the sender
                clients[sender].Send(Encoding.UTF8.GetBytes($"[Private to {recipientUsername}] {privateMessage}"));

                AppendToConversation(fullMessage);
            }
            else
            {
                // Recipient not found, notify the sender
                clients[sender].Send(Encoding.UTF8.GetBytes($"User {recipientUsername} not found."));
            }
        }

        // Notify server about new client connection
        private void NotifyConnection(string username)
        {
            string message = $"{username} just connected.";
            AppendToConversation(message);
            BroadcastMessage(message, "Server");
            SendClientList();
        }

        // Broadcast messages to all connected clients
        private void BroadcastMessage(string message, string sender)
        {
            string fullMessage;
            if (message.StartsWith("/textFile"))
            {
                fullMessage = $"{sender} has sent a text file:\n{message.Substring(9)}";
            }
            else
            {
                fullMessage = $"{sender}: {message}";
            }
            byte[] data = Encoding.UTF8.GetBytes(fullMessage);

            foreach (var client in clients.Values)
            {
                client.Send(data);
            }

            AppendToConversation(fullMessage);
        }

        private void AppendToConversation(string message)
        {
            if (textboxLog.InvokeRequired)
            {
                textboxLog.Invoke(new Action(() => AppendToConversation(message)));
            }
            else
            {
                // Append the received message to the conversation textbox
                textboxLog.Text += message + Environment.NewLine;
            }
        }
        private void SendClientList()
        {
            string clientList = string.Join(",", clients.Keys);
            byte[] data = Encoding.UTF8.GetBytes($"/clients {clientList}");

            foreach (var client in clients.Values)
            {
                client.Send(data);
            }
        }

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            Server server = new Server();
            if (!isRunning)
            {
                server.Close();
            }
            else
            {
                isRunning = false; // Stop the server loop  
                listener.Stop(); // Stop the listener  

                // Close all client connections  
                foreach (var client in clients.Values)
                {
                    client.Shutdown(SocketShutdown.Both);
                    client.Close();
                }
                // Clear the clients dictionary
                clients.Clear();
            }
        }
    }
}
