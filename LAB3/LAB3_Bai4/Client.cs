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
using System.Threading;

namespace LAB3_Bai4
{
    public partial class Client : Form
    {
        private TcpClient tcpClient;
        private NetworkStream stream;
        private int port = 8000;
        string serverIP = "127.0.0.1"; // Change this to the actual server IP

        public Client()
        {
            InitializeComponent();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(IPAddress.Parse(serverIP), port); // Connect to the server
                stream = tcpClient.GetStream();

                // Send the username immediately after connecting
                string username = textboxYourName.Text.Trim();
                byte[] data = Encoding.UTF8.GetBytes(username);
                stream.Write(data, 0, data.Length); // Send username to the server

                MessageBox.Show("Connected to server!");

                // Start a task to listen for incoming messages from the server
                Thread listenThread = new Thread(ListenForMessages);
                listenThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to server: {ex.Message}");
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (tcpClient == null || !tcpClient.Connected)
                {
                    MessageBox.Show("You need to connect to the server first.");
                    return;
                }

                string message = textboxMessage.Text.Trim();

                if (string.IsNullOrWhiteSpace(message))
                {
                    MessageBox.Show("Please enter a message.");
                    return;
                }

                if (checkboxPrivate.Checked)
                {
                    string recipient = textboxRecipient.Text.Trim();
                    if (string.IsNullOrWhiteSpace(recipient))
                    {
                        MessageBox.Show("Please enter a recipient username for private messages.");
                        return;
                    }

                    message = $"/pm {recipient} {message}";
                }

                byte[] data = Encoding.UTF8.GetBytes(message); // Convert to bytes
                stream.Write(data, 0, data.Length); // Send to server

                textboxMessage.Clear(); // Clear the message input box
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending message: {ex.Message}");
            }
        }

        // Listen for incoming messages from the server
        private void ListenForMessages()
        {
            byte[] buffer = new byte[1024];

            try
            {
                while (tcpClient.Connected)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length); // Read incoming messages
                    if (bytesRead > 0)
                    {
                        string message = Encoding.UTF8.GetString(buffer, 0, bytesRead); // Decode received bytes
                        if (message.StartsWith("/clients"))
                        {
                            UpdateClientList(message.Substring(9)); // Remove "/clients " prefix
                        }
                        else
                        {
                            AppendMessageToChat(message); // Update the UI with the received message
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error receiving message: {ex.Message}");
            }
        }

        // Append received messages to the client's conversation text box
        private void AppendMessageToChat(string message)
        {
            // Check if the message contains the "/clients" prefix
            int clientsIndex = message.IndexOf("/clients");
            if (clientsIndex != -1)
            {
                // Remove the "/clients" prefix and everything after it
                message = message.Substring(0, clientsIndex).Trim();
            }

            if (textboxShowMessage.InvokeRequired)
            {
                textboxShowMessage.Invoke(new Action(() => AppendMessageToChat(message)));
            }
            else
            {
                textboxShowMessage.Text += message + Environment.NewLine; // Display message
            }
        }

        private void ButtonSendFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (tcpClient == null || !tcpClient.Connected)
                {
                    MessageBox.Show("You need to connect to the server first.");
                    return;
                }

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;
                        string fileName = Path.GetFileName(filePath);

                        // Send file request to the server
                        byte[] data = Encoding.UTF8.GetBytes(fileName);
                        stream.Write(data, 0, data.Length);

                        // Send file data to the server
                        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                        {
                            byte[] buffer = new byte[1024];
                            int bytesRead;
                            while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                stream.Write(buffer, 0, bytesRead);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending file: {ex.Message}");
            }
        }
        private void UpdateClientList(string clientList)
        {
            if (listviewParticipant.InvokeRequired)
            {
                listviewParticipant.Invoke(new Action(() => UpdateClientList(clientList)));
            }
            else
            {
                listviewParticipant.Items.Clear();
                var clients = clientList.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var client in clients)
                {
                    listviewParticipant.Items.Add(client);
                }
            }
        }

        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (tcpClient != null && tcpClient.Connected)
                {
                    // Send disconnection message to the server
                    string disconnectMessage = "/disconnect";
                    byte[] data = Encoding.UTF8.GetBytes(disconnectMessage);
                    stream.Write(data, 0, data.Length);

                    stream.Close();
                    tcpClient.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error disconnecting from server: {ex.Message}");
            }
        }

        private void buttonSendFile_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (tcpClient == null || !tcpClient.Connected)
                {
                    MessageBox.Show("You need to connect to the server first.");
                    return;
                }

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;
                        string fileName = Path.GetFileName(filePath);
                        string recipient = textboxRecipient.Text.Trim();

                        // Send file request to the server
                        string fileRequest = checkboxPrivate.Checked ? $"/file {recipient} {fileName}" : $"/file {fileName}";
                        byte[] requestData = Encoding.UTF8.GetBytes(fileRequest);
                        stream.Write(requestData, 0, requestData.Length);

                        // Send file data to the server
                        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                        {
                            byte[] buffer = new byte[1024];
                            int bytesRead;
                            while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                stream.Write(buffer, 0, bytesRead);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending file: {ex.Message}");
            }
        }
    }
}