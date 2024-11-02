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

namespace Client
{
    public partial class FileTransfer : Form
    {
        public FileTransfer()
        {
            InitializeComponent();
        }
        private string IP = "127.0.0.1";
        TcpListener listener;
        TcpClient client;
        Socket socketForClient;
        private Thread serverThread;
        private Thread findPC;
        private Thread notification;
        int flag = 0;
        string fileName = "";
        private bool serverRunning = false;
        private bool isConnected = false;
        int x = 9;
        int y = 308;
        int fileReceived = 0;
        string savePath;
        string senderIP;
        string senderMachineName;
        string targetIP;
        string targetName;
        NotificationForm f2;
        private CancellationTokenSource serverCancellationTokenSource;
        private CancellationTokenSource findPCCancellationTokenSource;
        private CancellationTokenSource notificationCancellationTokenSource;


        private void FileTransfer_Load(object sender, EventArgs e)
        {
            notificationTempLabel.Text = ""; // Clear any text
            notificationTempLabel.Visible = false; // Hide it
            notificationLabel.ForeColor = Color.Red;
            notificationLabel.Text = "Application is offline";
        }
        //for starting this program as a server

        void startServer()
        {
            try
            {
                serverRunning = true;
                listener = new TcpListener(IPAddress.Parse(IP), 11000);
                listener.Start();
                serverCancellationTokenSource = new CancellationTokenSource();
                var token = serverCancellationTokenSource.Token;
                serverThread = new Thread(() => serverTasks(token));
                serverThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //thread: waiting for client request and receiving data two times and resets.

        void serverTasks(CancellationToken token)
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
                            fileReceived = 0;
                        }
                        else
                        {
                            fileReceived = 0;
                        }
                    }

                    client = listener.AcceptTcpClient();
                    if (token.IsCancellationRequested)
                    {
                        break;
                    }

                    Invoke((MethodInvoker)delegate
                    {
                        notificationPanel.Visible = true;
                        notificationTempLabel.Text = "File coming..." + "\n" + fileName + "\n" + "From: " + senderIP + " " + senderMachineName;
                        fileNotificationLabel.Text = "File Coming from " + senderIP + " " + senderMachineName;
                    });

                    isConnected = true;
                    NetworkStream stream = client.GetStream();
                    if (flag == 1 && isConnected)
                    {
                        savePath = savePathLabel.Text + "\\" + fileName;
                        using (var output = File.Create(savePath))
                        {
                            var buffer = new byte[1024];
                            int bytesRead;
                            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                if (token.IsCancellationRequested)
                                {
                                    return;
                                }
                                output.Write(buffer, 0, bytesRead);
                            }
                            flag = 0;
                            client.Close();
                            isConnected = false;
                            fileName = "";
                            Invoke((MethodInvoker)delegate
                            {
                                notificationTempLabel.Text = "";
                                notificationPanel.Visible = false;
                                fileNotificationLabel.Text = "";
                            });
                            fileReceived = 1;
                        }
                    }
                    else if (flag == 0 && isConnected)
                    {
                        Byte[] bytes = new Byte[256];
                        String data = null;
                        int i;
                        while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            if (token.IsCancellationRequested)
                            {
                                return;
                            }
                            data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        }
                        string[] msg = data.Split('@');
                        fileName = msg[0];
                        senderIP = msg[1];
                        senderMachineName = msg[2];
                        client.Close();
                        isConnected = false;
                        flag = 1;
                    }
                }
            }
            catch (Exception)
            {
                flag = 0;
                isConnected = false;
                if (client != null)
                    client.Close();
            }
        }


        private void startButton_Click(object sender, EventArgs e)
        {
            ipBox.Text = "";
            onlinePCList.Items.Clear();
            notificationLabel.ForeColor = Color.Green;
            notificationLabel.Text = "Finding...";
            //searchPC();
            try
            {
                findPC = new Thread(new ThreadStart(searchPC));
                findPC.Start();
                while (!findPC.IsAlive) ;
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
                    Invoke((MethodInvoker)delegate
                    {
                        notificationLabel.ForeColor = Color.Red;
                        notificationLabel.Text = "Không thể tìm thấy địa chỉ IPv4 của Wireless LAN.";
                    });
                    return;
                }

                Invoke((MethodInvoker)delegate
                {
                    infoLabel.Text = "IP: " + this.IP;
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

                Invoke((MethodInvoker)delegate
                {
                    notificationLabel.ForeColor = Color.Green;
                    notificationLabel.Text = "Application is Online";
                });

                // Starting this program as a server.
                if (!serverRunning)
                    startServer();
            }
            else
            {
                Invoke((MethodInvoker)delegate
                {
                    notificationLabel.ForeColor = Color.Red;
                    notificationLabel.Text = "Application is Offline";
                });
                MessageBox.Show("Not connected to LAN");
            }
        }
        //for searching online computers

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
                fileNameLabel.Text = openFileDialog1.FileName;  //file path
                fileNameLabel.Tag = openFileDialog1.SafeFileName; //file name only.
            }
            timer1.Start();
        }

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
                    PingReply r;
                    r = p.Send(targetIP);
                    if (!(r.Status == IPStatus.Success))
                    {
                        MessageBox.Show("Target computer is not available.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        notification = new Thread(new ThreadStart(showNotification));
                        notification.Start();
                        fileNotificationLabel.Text = "Please don't do other tasks. File sending to " + targetIP + " " + targetName + "...";

                        // Closing the server properly using CancellationTokenSource
                        serverCancellationTokenSource.Cancel();
                        serverThread.Join(); // Wait for the thread to finish
                        serverRunning = false;

                        // Now making this program a client
                        socketForClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        socketForClient.Connect(new IPEndPoint(IPAddress.Parse(targetIP), 11000));
                        string fileName = fileNameLabel.Tag.ToString();
                        byte[] fileNameData = Encoding.Default.GetBytes(fileName + "@" + this.IP + "@" + Environment.MachineName);
                        socketForClient.Send(fileNameData);
                        socketForClient.Shutdown(SocketShutdown.Both);
                        socketForClient.Close();

                        socketForClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        socketForClient.Connect(new IPEndPoint(IPAddress.Parse(targetIP), 11000));
                        socketForClient.SendFile(fileNameLabel.Text);
                        socketForClient.Shutdown(SocketShutdown.Both);
                        socketForClient.Close();

                        Invoke((MethodInvoker)delegate
                        {
                            f2.Dispose();
                        });
                        MessageBox.Show("File sent to " + targetIP + " " + targetName, "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    if (socketForClient != null)
                    {
                        socketForClient.Shutdown(SocketShutdown.Both);
                        socketForClient.Close();
                    }
                }
                finally
                {
                    for (int i = 0; i < onlinePCList.SelectedIndices.Count; i++)
                    {
                        onlinePCList.Items[this.onlinePCList.SelectedIndices[i]].Selected = false;
                    }
                    fileNotificationLabel.Text = ".";
                    // Again making this program a server
                    startServer();
                }
            }
        }


        void showNotification()
        {
            f2 = new NotificationForm(targetName, targetIP);
            f2.ShowDialog();
        }

        private void FileTransfer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serverRunning)
            {
                if (listener != null)
                {
                    listener.Stop();
                }

                if (serverCancellationTokenSource != null)
                {
                    serverCancellationTokenSource.Cancel();
                }
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (serverRunning)
            {
                serverRunning = false;
                onlinePCList.Items.Clear();

                if (listener != null)
                {
                    listener.Stop();
                }

                if (serverCancellationTokenSource != null)
                {
                    serverCancellationTokenSource.Cancel();
                }

                notificationLabel.ForeColor = Color.Red;
                notificationLabel.Text = "Application is Offline";
                infoLabel.Text = "";
                fileNameLabel.Text = ".";
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            x = x - 5;
            fileNameLabel.Location = new Point(x, y);
            if (x < (fileNameLabel.Text.Length * (-1)))
                x = 545;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            fileNameLabel.Text = ".";
            timer1.Stop();
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
                // Cancel the server tasks
                if (serverCancellationTokenSource != null)
                {
                    serverCancellationTokenSource.Cancel(); // Signal cancellation
                                                            // Wait for the server thread to finish if it's still running
                    if (serverThread != null && serverThread.IsAlive)
                    {
                        serverThread.Join(); // Optionally handle this with a timeout
                    }
                }

                // Stop the listener if it's still running
                if (listener != null)
                {
                    listener.Stop();
                }
            }

            // Dispose of the NotificationForm if it's open
            if (f2 != null)
            {
                f2.Dispose();
            }

            // Hide the current FileTransfer form and show the existing Server form
            this.Hide();
            Form serverForm = Application.OpenForms["Client"];
            if (serverForm != null)
            {
                serverForm.Show();
            }
        }
    }
}
