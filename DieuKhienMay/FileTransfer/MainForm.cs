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
            //Đưa trạng thái của thanh thông báo về mặc định khi khởi tạo chương trình
            notificationLabel.ForeColor = Color.Red;
            notificationLabel.Text = "Application is offline";
            notificationPanel.Visible = false;
        }
        // khởi động chương trình này như một máy chủ

        void startServer()
        {
            try
            {
                // Dừng bất kì listener đang chạy trước đó nhằm tránh xung đột
                if (listener != null)
                {
                    listener.Stop();
                }

                // server bắt đầu hoạt động
                serverRunning = true;
                listener = new TcpListener(IPAddress.Parse(IP), 11000);

                //  thiết lập cho socket khả năng tái sử dụng địa chỉ và cổng, tránh gặp lỗi "Address already in use"
                listener.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                listener.Start();

                // khởi tạo token nhằm đảm bảo server có thể dừng hoạt động nếu có lệnh hủy từ người dùng
                serverCancellationTokenSource = new CancellationTokenSource();
                var token = serverCancellationTokenSource.Token;

                // tạo 1 task bất đồng bộ để thực thi hàm serverTasks kết hợp với token nhằm dừng chương trình khi cần thiết
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
                // Vòng lặp chạy cho đến khi token phát tín hiệu hủy
                while (!token.IsCancellationRequested)
                {
                    // Đảm bảo việc xử lý file trước đó được hoàn tất
                    if (fileReceived == 1)
                    {
                        if (MessageBox.Show("Save File?", "File received", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            // Xóa file nếu không muốn lưu
                            File.Delete(savePath);
                        }
                        // Đặt lại biến fileReceived bằng 0 để thực hiện nhận file kế tiếp
                        fileReceived = 0;
                    }

                    // Kiểm tra xem yêu cầu hủy tác vụ có xuất hiện hay không. Nếu có thì chương trình dừng tác vụ và thoát khỏi vòng lặp
                    token.ThrowIfCancellationRequested();

                    // Lắng nghe và chấp nhận kết nối từ client một cách bất đồng bộ
                    using (var client = await listener.AcceptTcpClientAsync())
                    {
                        // Đánh dấu có kết nối đang hoạt động

                        isConnected = true;

                        // Luồng nhận dữ liệu từ client và lấy NetworkStream từ client để thực thi
                        using (var stream = client.GetStream())
                        {
                            // Tạo buffer lưu metadata của file nhận được
                            byte[] metadataBuffer = new byte[256];

                            // Đọc metadata từ luồng và lưu vào buffer
                            int metadataLength = await stream.ReadAsync(metadataBuffer, 0, metadataBuffer.Length, token);

                            // Chuyển đổi buffer metadata sang chuỗi ký tự
                            string metadata = Encoding.ASCII.GetString(metadataBuffer, 0, metadataLength);

                            // Tách metadata thành các thành phần dựa trên ký tự @
                            string[] msg = metadata.Split('@');
                            fileName = msg[0];
                            senderIP = msg[1];
                            senderMachineName = msg[2];

                            // Gán đường dẫn lưu file dựa trên vị trí đã chọn cho savePath
                            savePath = Path.Combine(savePathLabel.Text, fileName);

                            // Nhận dữ liệu file
                            // Tạo một file mới tại savePath để lưu dữ liệu
                            using (var output = File.Create(savePath))
                            {
                                byte[] buffer = new byte[1024];
                                int bytesRead;

                                // Đọc dữ liệu từ luồng thành các khối nhỏ trong buffer và lưu vào file cho đến khi hết dữ liệu
                                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, token)) > 0)
                                {
                                    // Ghi dữ liệu từ buffer vào file
                                    output.Write(buffer, 0, bytesRead);
                                }
                            }

                            // Cập nhật lại trạng thái sau khi nhận file thành công
                            isConnected = false;

                            // Cập nhật lại biến khi đã nhận file thành công
                            fileReceived = 1;

                            // Cập nhật lại giao diện khi hoàn tất truyền file
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

            // Xử lý tác vụ bị hủy thông qua CancellationToken
            catch (OperationCanceledException)
            {
                Console.WriteLine("Server task was canceled.");
                listener?.Stop();
            }

            // Xử lý ngoại lệ khác
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
                // Thực hiện tìm kiếm bất đồng bộ
                await Task.Run(() => searchPC());
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        void searchPC()
        {
            // Kiểm tra trạng thái mạng nếu khả dụng thì bắt đầu tìm kiếm
            bool isNetworkUp = NetworkInterface.GetIsNetworkAvailable();
            //Tìm địa chỉ IP của Wireless LAN
            if (isNetworkUp)
            {
                // Duyệt qua các giao diện mạng của máy tính
                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    // Chỉ chọn những giao diện Wireless LAN
                    if (nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 && nic.OperationalStatus == OperationalStatus.Up)
                    {
                        foreach (UnicastIPAddressInformation ip in nic.GetIPProperties().UnicastAddresses)
                        {
                            // Lấy địa chỉ IPv4 của giao diện mạng và lưu lại
                            if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                this.IP = ip.Address.ToString();
                                break;
                            }
                        }
                    }
                }

                // Thông báo lỗi nếu không tìm thấy địa chỉ IP
                if (string.IsNullOrEmpty(this.IP))
                {
                    Invoke((MethodInvoker)delegate {
                        notificationLabel.ForeColor = Color.Red;
                        notificationLabel.Text = "Không thể tìm thấy địa chỉ IPv4 của Wireless LAN.";
                    });
                    return;
                }

                // Hiển thị IP lên giao diện
                Invoke((MethodInvoker)delegate {
                    infoLabel.Text = this.IP;
                });

                //Tách các thành phần nhằm sử dụng 3 lớp đầu tiên và quét lớp cuối từ 100 đến 254 (100 - 255 thuộc dải IP thiết bị người dùng)
                string[] ipRange = IP.Split('.');
                for (int i = 100; i < 255; i++)
                {
                    Ping ping = new Ping();
                    string testIP = ipRange[0] + '.' + ipRange[1] + '.' + ipRange[2] + '.' + i.ToString();
                    if (testIP != this.IP)
                    {
                        // Sử dụng Ping để xác định các máy đang hoạt động trực tuyến

                        // Gán phương thức PingComletedEvenHandler để xử lý sự kiện PingCompleted của đối tượng ping khi quá trình ping hoàn tất
                        ping.PingCompleted += new PingCompletedEventHandler(pingCompletedEvent);

                        // Gửi yêu cầu ping đến địa chỉ một cách bất đồng bộ
                        ping.SendAsync(testIP, 100, testIP);
                    }
                }

                // Cập nhật giao diện
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
                //Xử lý trường hợp ngoại tuyến
                Invoke((MethodInvoker)delegate {
                    notificationLabel.ForeColor = Color.Red;
                    notificationLabel.Text = "Application is Offline";
                });
                MessageBox.Show("Not connected to LAN");
            }
        }

        // tìm thiết bị kết nối cùng mạng LAN
        // Hàm kiểm tra kết quả ping và lấy địa chỉ IP và tên máy để cập nhật danh sách các thiết bị trực tuyến trên màn hình nếu ping thành công
        void pingCompletedEvent(object sender, PingCompletedEventArgs e)
        {
            // UserState được truyền khi gọi ping.SendAsync (chứa địa chỉ IP cần kiểm tra)
            // Lấy IP từ UserState để xác định IP đang được xử lý trong lần gọi sự kiện hiện tại
            string ip = (string)e.UserState;

            // Kiểm tra trạng thái phản hồi
            if (e.Reply.Status == IPStatus.Success)
            {
                string name;
                try
                {
                    // Lấy thông tin máy từ địa chỉ IP
                    IPHostEntry hostEntry = Dns.GetHostEntry(ip);

                    // Lấy tên máy
                    name = hostEntry.HostName ?? "Unknown Host";
                }

                // Xử lý ngoại lệ không lấy được tên máy
                catch (SocketException ex)
                {
                    name = "Unknown Host";
                }

                // Cập nhật lại giao diện
                Invoke((MethodInvoker)delegate
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = ip;
                    item.SubItems.Add(name);
                    onlinePCList.Items.Add(item);
                });
            }
        }

        // Chọn file cần gửi
        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "All Files|*.*";
            openFileDialog1.Title = "Select a File";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn file
                fileNameLabel.Text = openFileDialog1.FileName;

                // Lấy tên file
                fileNameLabel.Tag = openFileDialog1.SafeFileName;
            }
        }

        private void sendFileButton_Click(object sender, EventArgs e)
        {
            // hủy dữ liệu từ lần gửi trước đó
            targetIP = null;
            targetName = null;

            // Điều kiện để gửi file: (IP có trong danh sách hoặc text box) và server hoạt động và file đã được chọn
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

                    // Gửi yêu cầu Ping đến máy đích và phản hồi của yêu cầu được gán cho biến r
                    PingReply r = p.Send(targetIP);

                    // Xử lý nếu không có phản hồi
                    if (r.Status != IPStatus.Success)
                    {
                        MessageBox.Show("Target computer is not available.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Nếu phản hồi thành công, tạo luồng mới để hiển thị thông báo cho người dùng trong quá trình truyền file
                    notification = new Thread(new ThreadStart(showNotification));
                    notification.Start();
                    fileNotificationLabel.Text = $"Please don't do other tasks. File sending to {targetIP} {targetName}...";

                    // CancellationToken gửi tín hiệu hủy cho chương trình 
                    serverCancellationTokenSource?.Cancel();

                    // Dừng một khoảng thời gian nhỏ để đảm bảo server dừng trước khi thực hiện gửi file
                    Task.Delay(200).Wait();

                    // Kết nối với máy đích dưới dạng client

                    // Tạo socket để kết nối đến máy đích
                    using (var socketForClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                    {
                        //Kết nối với máy đích
                        socketForClient.Connect(new IPEndPoint(IPAddress.Parse(targetIP), 11000));

                        // Lấy tên file
                        string fileName = fileNameLabel.Tag.ToString();

                        // Thông tin về file được gửi được chia làm 3 phần: fileName, IP máy gửi và tên máy gửi (nếu có)
                        byte[] fileNameData = Encoding.Default.GetBytes($"{fileName}@{this.IP}@{Environment.MachineName}");

                        // Thông tin về file được gửi đến máy đích trước khi gửi file thực tế để máy đích chuẩn bị lưu file
                        socketForClient.Send(fileNameData);

                        // Gửi dữ liệu của file
                        socketForClient.SendFile(fileNameLabel.Text);
                    }

                    // Cập nhật lại giao diện và thông báo nếu file được gửi thành công
                    Invoke((MethodInvoker)delegate { f2.Dispose(); });
                    MessageBox.Show($"File sent to {targetIP} {targetName}", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Xử lý ngoại lệ nếu có lỗi
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


                finally
                {
                    // Bỏ chọn trong giao diện để chuẩn bị cho lần gửi kế tiếp
                    foreach (int index in onlinePCList.SelectedIndices)
                    {
                        onlinePCList.Items[index].Selected = false;
                    }
                    fileNotificationLabel.Text = ".";

                    // Server tiếp tục lắng nghe sau khi hoàn tất gửi file
                    startServer();
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
