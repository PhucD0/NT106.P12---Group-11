using System.ComponentModel;
using System;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Client : Form
    {
        private TcpClient tcpClient;
        private NetworkStream stream;
        private const int port = 8000;
        private const string serverIP = "127.0.0.1"; // Change this to the actual server IP


        public Client()
        {
            InitializeComponent();
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(IPAddress.Parse(serverIP), port); // Connect to the server
                stream = tcpClient.GetStream();

                // Send the username immediately after connecting
                string username = TextboxUsername.Text.Trim();
                byte[] data = Encoding.UTF8.GetBytes(username);
                stream.Write(data, 0, data.Length); // Send username to the server

                MessageBox.Show("Connected to server!");

                // Start a task to listen for incoming messages from the server
                Task.Run(() => ListenForMessages());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to server: {ex.Message}");
            }
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (tcpClient == null || !tcpClient.Connected)
                {
                    MessageBox.Show("You need to connect to the server first.");
                    return;
                }

                string username = TextboxUsername.Text.Trim();
                string recipient = TextboxTo.Text.Trim(); // Add TextBox for recipient
                string message = TextboxMessage.Text.Trim();

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(recipient))
                {
                    MessageBox.Show("Please enter both your username and recipient.");
                    return;
                }

                string fullMessage = $"{recipient}: {message}"; // Format for sending private message
                byte[] data = Encoding.UTF8.GetBytes(fullMessage); // Convert to bytes
                stream.Write(data, 0, data.Length); // Send to server

                TextboxMessage.Clear(); // Clear the message input box
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
                        if (message.StartsWith("Incoming file from"))
                        {
                            MessageBox.Show(message); // Display file transfer notification

                            // Start receiving file data
                            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                            {
                                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                                {
                                    string savePath = saveFileDialog.FileName;
                                    using (FileStream fs = new FileStream(savePath, FileMode.Create, FileAccess.Write))
                                    {
                                        int fileBytesRead;
                                        while ((fileBytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                                        {
                                            fs.Write(buffer, 0, fileBytesRead);
                                        }
                                    }
                                }
                            }
                        }
                        AppendMessageToChat(message); // Update the UI with the received message
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
            if (TextboxConversation.InvokeRequired)
            {
                TextboxConversation.Invoke(new Action(() => AppendMessageToChat(message)));
            }
            else
            {
                TextboxConversation.Text += message + Environment.NewLine; // Display message
            }
        }

        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tcpClient != null)
            {
                tcpClient.Close(); // Close the connection
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
                        string recipient = TextboxTo.Text.Trim();

                        if (string.IsNullOrWhiteSpace(recipient))
                        {
                            MessageBox.Show("Please enter the recipient.");
                            return;
                        }

                        // Send file request to the server
                        string fileRequest = $"{recipient}: {fileName}";
                        byte[] data = Encoding.UTF8.GetBytes(fileRequest);
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

    }
}
//Tham khảo tự chatGPT và Bing - Copilot