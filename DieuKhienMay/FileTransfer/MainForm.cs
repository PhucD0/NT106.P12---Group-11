using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Threading;

namespace FileTransfer
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }
        private string IP = "127.0.0.1";
        TcpListener listener;
        TcpClient? client;
        Socket? socketForClient;
        private CancellationTokenSource serverCancellationTokenSource;
        private Thread findPC;
        private Thread notification;
        int flag = 0;
        string fileName = "";
        private bool serverRunning = false;
        private bool isConnected = false;
        int fileReceived = 0;
        string savePath;
        string senderIP;
        string senderMachineName;
        string targetIP;
        string targetName;
        NotificationForm f2;

        private void mainForm_Load(object sender, EventArgs e)
        {
            notificationLabel.ForeColor = Color.Red;
            notificationLabel.Text = "Application is offline";
            notificationPanel.Visible = false;
        }
        // khởi động chương trình này như một máy chủ

        void startServer()
        {
            try
            {
                // Stop any previous listener if running
                if (listener != null)
                {
                    listener.Stop();
                }

                serverRunning = true;
                listener = new TcpListener(IPAddress.Parse(IP), 11000);
                listener.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                listener.Start();

                // Ensure the serverCancellationTokenSource is reinitialized if it was previously canceled
                serverCancellationTokenSource = new CancellationTokenSource();
                var token = serverCancellationTokenSource.Token;

                // Start the server task asynchronously
                Task.Run(() => serverTasks(token), token);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Luồng: chờ yêu cầu từ client và nhận dữ liệu hai lần rồi reset.
        private async Task serverTasks(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    if (fileReceived == 1)
                    {
                        if (MessageBox.Show("Save File?", "File received", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            File.Delete(savePath);
                        }
                        fileReceived = 0;
                    }

                    token.ThrowIfCancellationRequested();

                    // Accept incoming client connection
                    using (var client = await listener.AcceptTcpClientAsync())
                    {
                        isConnected = true;
                        using (var stream = client.GetStream())
                        {
                            // Read metadata
                            byte[] metadataBuffer = new byte[256];
                            int metadataLength = await stream.ReadAsync(metadataBuffer, 0, metadataBuffer.Length, token);
                            string metadata = Encoding.ASCII.GetString(metadataBuffer, 0, metadataLength);

                            string[] msg = metadata.Split('@');
                            fileName = msg[0];
                            senderIP = msg[1];
                            senderMachineName = msg[2];

                            savePath = Path.Combine(savePathLabel.Text, fileName);

                            // Receive the file data
                            using (var output = File.Create(savePath))
                            {
                                byte[] buffer = new byte[1024];
                                int bytesRead;
                                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, token)) > 0)
                                {
                                    output.Write(buffer, 0, bytesRead);
                                }
                            }

                            isConnected = false;
                            fileReceived = 1;
                            Invoke((MethodInvoker)delegate
                            {
                                notificationTempLabel.Text = "";
                                notificationPanel.Visible = false;
                                fileNotificationLabel.Text = "";
                            });
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Server task was canceled.");
                listener?.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                isConnected = false;
            }
        }

        private async void startButton_Click(object sender, EventArgs e)
        {
            // Xóa trạng thái trước đó
            ipBox.Text = "";
            onlinePCList.Items.Clear();
            notificationLabel.ForeColor = Color.Green;
            notificationLabel.Text = "Finding...";

            try
            {
                await Task.Run(() => searchPC());
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        void searchPC()
        {
            bool isNetworkUp = NetworkInterface.GetIsNetworkAvailable();
            if (isNetworkUp)
            {
                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 && nic.OperationalStatus == OperationalStatus.Up)
                    {
                        foreach (UnicastIPAddressInformation ip in nic.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                this.IP = ip.Address.ToString();
                                break;
                            }
                        }
                    }
                }

                if (string.IsNullOrEmpty(this.IP))
                {
                    // Không tìm thấy địa chỉ IPv4 của Wireless LAN
                    Invoke((MethodInvoker)delegate {
                        notificationLabel.ForeColor = Color.Red;
                        notificationLabel.Text = "Không thể tìm thấy địa chỉ IPv4 của Wireless LAN.";
                    });
                    return;
                }

                Invoke((MethodInvoker)delegate {
                    infoLabel.Text = this.IP;
                });

                string[] ipRange = IP.Split('.');
                for (int i = 100; i < 255; i++)
                {
                    Ping ping = new Ping();
                    string testIP = ipRange[0] + '.' + ipRange[1] + '.' + ipRange[2] + '.' + i.ToString();
                    if (testIP != this.IP)
                    {
                        ping.PingCompleted += new PingCompletedEventHandler(pingCompletedEvent);
                        ping.SendAsync(testIP, 100, testIP);
                    }
                }

                Invoke((MethodInvoker)delegate {
                    notificationLabel.ForeColor = Color.Green;
                    notificationLabel.Text = "Application is Online";
                });

                // khởi động chương trình như một máy chủ
                if (!serverRunning)
                    startServer();
            }
            else
            {
                Invoke((MethodInvoker)delegate {
                    notificationLabel.ForeColor = Color.Red;
                    notificationLabel.Text = "Application is Offline";
                });
                MessageBox.Show("Not connected to LAN");
            }
        }
        //tìm thiết bị kết nối cùng mạng LAN
        void pingCompletedEvent(object sender, PingCompletedEventArgs e)
        {
            string ip = (string)e.UserState;
            if (e.Reply.Status == IPStatus.Success)
            {
                string name;
                try
                {
                    IPHostEntry hostEntry = Dns.GetHostEntry(ip);
                    name = hostEntry.HostName;
                }
                catch (SocketException ex)
                {
                    name = ex.Message;
                }
                Invoke((MethodInvoker)delegate
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = ip;
                    item.SubItems.Add(name);
                    onlinePCList.Items.Add(item);
                });
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "All Files|*.*";
            openFileDialog1.Title = "Select a File";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileNameLabel.Text = openFileDialog1.FileName;  //đường dẫn file
                fileNameLabel.Tag = openFileDialog1.SafeFileName; //tên file
            }
        }
        //for sending file

        private void sendFileButton_Click(object sender, EventArgs e)
        {
            targetIP = null;
            targetName = null;

            if ((onlinePCList.SelectedIndices.Count > 0 || ipBox.Text != "") && serverRunning && fileNameLabel.Text != ".")
            {
                if (ipBox.Text != "")
                {
                    targetIP = ipBox.Text;
                    targetName = "";
                }
                else
                {
                    targetIP = onlinePCList.SelectedItems[0].Text;
                    targetName = onlinePCList.SelectedItems[0].SubItems[1].Text;
                }

                try
                {
                    Ping p = new Ping();
                    PingReply r = p.Send(targetIP);
                    if (r.Status != IPStatus.Success)
                    {
                        MessageBox.Show("Target computer is not available.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    notification = new Thread(new ThreadStart(showNotification));
                    notification.Start();
                    fileNotificationLabel.Text = $"Please don't do other tasks. File sending to {targetIP} {targetName}...";

                    // Stop the server with a short delay to ensure it fully stops
                    serverCancellationTokenSource?.Cancel();
                    Task.Delay(200).Wait();  // Give time for the server to stop

                    // Connect to target as client and send metadata and file in one connection
                    using (var socketForClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                    {
                        socketForClient.Connect(new IPEndPoint(IPAddress.Parse(targetIP), 11000));

                        string fileName = fileNameLabel.Tag.ToString();
                        byte[] fileNameData = Encoding.Default.GetBytes($"{fileName}@{this.IP}@{Environment.MachineName}");
                        socketForClient.Send(fileNameData);

                        // Send the file data
                        socketForClient.SendFile(fileNameLabel.Text);
                    }

                    Invoke((MethodInvoker)delegate { f2.Dispose(); });
                    MessageBox.Show($"File sent to {targetIP} {targetName}", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    foreach (int index in onlinePCList.SelectedIndices)
                    {
                        onlinePCList.Items[index].Selected = false;
                    }
                    fileNotificationLabel.Text = ".";
                    startServer(); // Restart server after delay
                }
            }
        }

        void showNotification()
        {
            f2 = new NotificationForm(targetName, targetIP);
            f2.ShowDialog();
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serverRunning)
            {
                serverCancellationTokenSource?.Cancel();
                serverRunning = false;
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (serverRunning)
            {
                serverCancellationTokenSource?.Cancel();
                serverRunning = false;
                onlinePCList.Items.Clear();
                notificationLabel.ForeColor = Color.Red;
                notificationLabel.Text = "Application is Offline";
                infoLabel.Text = "";
                fileNameLabel.Text = ".";
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            fileNameLabel.Text = ".";
        }

        private void changeSaveLocButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browse = new FolderBrowserDialog();
            if (browse.ShowDialog() == DialogResult.OK)
            {
                string savePath = browse.SelectedPath;
                savePathLabel.Text = savePath;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            if (serverRunning)
            {
                serverCancellationTokenSource?.Cancel();
                serverRunning = false;
            }
            // Hide the current FileTransfer form 
            this.Close();
        }
    }
}
