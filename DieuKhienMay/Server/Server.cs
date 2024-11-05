using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Data;
using System.Drawing.Imaging;
using System.Timers;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using FileTransfer;

namespace Server
{
    public partial class Server : Form
    {
        // KHAI BAO HERE
        private TcpListener? server;
        private TcpClient? client;
        private Thread? listeningThread;
        private Thread? sendingThread;
        private Thread? controlThread;
        private int port;
        private int pictureBoxWidth;
        private int pictureBoxHeight;
        private bool isConnected = false;
        private SqlConnection? sqlConnection;
        private System.Timers.Timer? timer;
        private bool isListening = false;
        private CancellationTokenSource? cancellationTokenSource;
        // Chuỗi kết nối đến cơ sở dữ liệu
        //private string databaseConnectionString = @"Data Source=localhost;Initial Catalog=RemoteDesktopDB;Integrated Security=true;";     //RemoteDesktopDB có cả status
        private string databaseConnectionString = @"Data Source=localhost;Initial Catalog=RemoteDesktopDB1;Integrated Security=true;";       //RemoteDesktopDB1 chưa có status   

        // Khai báo các hằng số cho hành động chuột và bàn phím
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, uint cButtons, uint dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        private const uint KEYEVENTF_KEYDOWN = 0x0000;
        private const uint KEYEVENTF_KEYUP = 0x0002;

        public Server()
        {
            InitializeComponent();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopListening();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            port = int.Parse(txbPort.Text);
            server = new TcpListener(IPAddress.Parse(txbIP.Text), port);
            cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;

            isListening = true;  // Cập nhật trạng thái
            listeningThread = new Thread(() => StartListening(token));
            listeningThread.Start();
            btnListen.Enabled = false;
            btnStop.Enabled = true;
        }

        /// <summary>
        /// Xu li ket noi
        /// </summary>
        // Bắt đầu lắng nghe từ client (sd bat dong bo)
        private async void StartListening(CancellationToken token)
        {
            try
            {
                server.Start();
                UpdateStatus("Server đang lắng nghe...");

                while (!token.IsCancellationRequested)
                {
                    if (server.Pending())
                    {
                        client = await server.AcceptTcpClientAsync(); // Lắng nghe không đồng bộ
                        UpdateStatus("Client đã kết nối.");

                        LogConnection1(((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString());

                        // Khởi động các luồng gửi và nhận không đồng bộ
                        sendingThread = new Thread(() => SendDesktopImages(token)) { IsBackground = true };
                        sendingThread.Start();

                        controlThread = new Thread(() => ReceiveControlEvents(token)) { IsBackground = true };
                        controlThread.Start();
                    }
                    await Task.Delay(100); // Giảm tải CPU với delay không đồng bộ
                }
            }
            catch (Exception ex)
            {
                HandleError("Error in StartListening", ex);
            }
            finally
            {
                server.Stop();
                UpdateStatus("Server đã dừng lắng nghe.");
            }
        }



        // Ket thuc ket noi
        private void StopListening()
        {
            if (isListening)
            {
                isListening = false;  // Cập nhật trạng thái
                btnListen.Enabled = true;
                btnStop.Enabled = false;

                // Dừng server và luồng trong Task để không làm treo UI
                Task.Run(() =>
                {
                    try
                    {
                        cancellationTokenSource?.Cancel();

                        // Đợi các thread dừng lại với timeout
                        listeningThread?.Join(1000);
                        sendingThread?.Join(1000);
                        controlThread?.Join(1000);

                        client?.Close();
                        server?.Stop();

                        // Cập nhật trạng thái UI sau khi dừng server
                        Invoke(new Action(() => UpdateStatus("Server đã dừng lắng nghe.")));
                    }
                    catch (Exception ex)
                    {
                        Invoke(new Action(() => HandleError("Error stopping the server", ex)));
                    }
                });
            }
        }





        /// <summary>
        /// Nhận thông tin điều khiển từ client
        /// </summary>
        private void ReceiveControlEvents(CancellationToken token)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];

                while (client.Connected && !token.IsCancellationRequested)
                {
                    if (stream.DataAvailable)
                    {
                        int bytesRead = stream.Read(buffer, 0, buffer.Length);
                        if (bytesRead > 0)
                        {
                            string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                            // Kiểm tra lệnh GETLOGS từ client
                            if (message == "GETLOGS")
                            {
                                SendLogs(stream);
                            }
                            else
                            {
                                ProcessControlEvent(message);
                            }
                        }
                    }
                    Thread.Sleep(10); // Nghỉ ngắn để giảm tải CPU khi không có dữ liệu
                }
            }
            catch (Exception ex)
            {
                HandleError("Error in ReceiveControlEvents", ex);
            }
        }


        private void ProcessControlEvent(string message)
        {
            // Phân tách thông điệp để xác định loại sự kiện và chi tiết
            string[] parts = message.Split(':');
            if (parts.Length < 2)
                return;

            string actionType = parts[0];

            // Kiểm tra xem đó là sự kiện chuột hay bàn phím
            if (actionType == "mouse" && parts.Length >= 5)
            {
                PerformMouseAction(parts[1], int.Parse(parts[2]), int.Parse(parts[3]), parts[4]);
            }
            else if (actionType == "keyboard" && parts.Length >= 3)
            {
                PerformKeyboardAction(parts[1], parts[2]);
            }
        }


        private void PerformMouseAction(string action, int x, int y, string button)
        {
            Cursor.Position = new Point(x, y);
            uint downEvent = (button == "left") ? (uint)MOUSEEVENTF_LEFTDOWN : (uint)MOUSEEVENTF_RIGHTDOWN;
            uint upEvent = (button == "left") ? (uint)MOUSEEVENTF_LEFTUP : (uint)MOUSEEVENTF_RIGHTUP;


            if (action == "down") mouse_event(downEvent, x, y, 0, 0);
            else if (action == "up") mouse_event(upEvent, x, y, 0, 0);
        }



        private void PerformKeyboardAction(string action, string key)
        {
            Keys keyValue = (Keys)Enum.Parse(typeof(Keys), key, true);

            if (action == "keydown") keybd_event((byte)keyValue, 0, 0, 0);
            else if (action == "keyup") keybd_event((byte)keyValue, 0, KEYEVENTF_KEYUP, 0);
        }


        /// <summary>
        /// Gui anh
        /// </summary>
        private void SendDesktopImages(CancellationToken token)
        {
            NetworkStream stream = client.GetStream();
            while (client.Connected && !token.IsCancellationRequested)
            {
                try
                {
                    Image desktopImage = CaptureDesktop();

                    using (MemoryStream ms = new MemoryStream())
                    {
                        desktopImage.Save(ms, ImageFormat.Png);
                        byte[] imageBytes = ms.ToArray();
                        byte[] sizeBytes = BitConverter.GetBytes(imageBytes.Length);

                        stream.Write(sizeBytes, 0, sizeBytes.Length);
                        stream.Write(imageBytes, 0, imageBytes.Length);
                    }

                    desktopImage.Dispose();
                    Thread.Sleep(100);
                }
                catch (Exception ex)
                {
                    HandleError("Error sending image", ex);
                    break;
                }
            }
        }


        // Hàm chụp ảnh với độ phân giải thấp và chất lượng JPEG giảm
        private Image CaptureDesktop()
        {
            // Lấy độ rộng và chiều cao tối đa bao gồm tất cả các màn hình
            int totalWidth = Screen.AllScreens.Sum(screen => screen.Bounds.Width);
            int maxHeight = Screen.AllScreens.Max(screen => screen.Bounds.Height);

            // Tạo bitmap với kích thước tổng hợp của tất cả các màn hình
            Bitmap screenshot = new Bitmap(totalWidth, maxHeight, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(screenshot);


            // Vẽ nội dung của từng màn hình lên bitmap
            int offsetX = 0;
            foreach (Screen screen in Screen.AllScreens)
            {
                graphics.CopyFromScreen(screen.Bounds.X, screen.Bounds.Y, offsetX, 0, screen.Bounds.Size, CopyPixelOperation.SourceCopy);
                offsetX += screen.Bounds.Width;
            }

            graphics.Dispose();
            return screenshot;
        }

        // Hàm nén ảnh bằng cách giảm chất lượng JPEG
        /*private Bitmap CompressImage(Bitmap bmp, long quality)
        {
            ImageCodecInfo jpegCodec = ImageCodecInfo.GetImageDecoders()
                                                     .First(codec => codec.FormatID == ImageFormat.Jpeg.Guid);
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);

            using (MemoryStream ms = new MemoryStream())
            {
                bmp.Save(ms, jpegCodec, encoderParams);
                return new Bitmap(ms);
            }
        }*/


        /// <summary>
        /// Cap nhat trang thai, được gọi bởi StartListening(), StopListening(),...
        /// </summary>
        /// <param name="message"></param>
        private void UpdateStatus(string message)
        {
            if (txbStatus.InvokeRequired)
            {
                txbStatus.Invoke(new Action(() => txbStatus.Text = message));
            }
            else
            {
                txbStatus.Text = message;
            }
        }


        /// <summary>
        /// View logs
        /// </summary>
        // Hàm khởi tạo kết nối csdl
        private SqlConnection InitializeDatabase()
        {
            SqlConnection connection = new SqlConnection(databaseConnectionString);
            connection.Open();
            return connection;
        }

        // ghi lại thông tin kết nối bản 1
        private void LogConnection1(string ip)
        {
            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                string query = "INSERT INTO ConnectionLogs (IPAddress, AccessTime) VALUES (@IPAddress, @AccessTime)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IPAddress", ip);
                command.Parameters.AddWithValue("@AccessTime", DateTime.Now);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // ghi lại thông tin kết nối bản 2
        //private void LogConnection1(string status, string ip)
        //{
        //    using (SqlConnection connection = InitializeDatabase())
        //    {
        //        string query = "INSERT INTO LogConnection (IPAddress, ConnectionTime, SessionStatus) VALUES (@IPAddress, @ConnectionTime, @SessionStatus)";
        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@SessionStatus", status);
        //            command.Parameters.AddWithValue("@IPAddress", ip);
        //            //command.Parameters.AddWithValue("@Port", port);
        //            command.Parameters.AddWithValue("@ConnectionTime", DateTime.Now);
        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}

        // Truy cap co so du lieu để lấy lịch sử kết nối
        //private DataTable LoadLogs()
        //{
        //    DataTable logs = new DataTable();
        //    using (SqlConnection connection = InitializeDatabase())
        //    {
        //        string query = "SELECT * FROM LogConnection ORDER BY ConnectionTime DESC";
        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
        //            {
        //                adapter.Fill(logs);
        //            }
        //        }
        //    }
        //    return logs;
        //}

        // Gui logs cho client
        private void SendLogs(NetworkStream stream)
        {
            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                string query = "SELECT IPAddress, AccessTime FROM ConnectionLogs";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                StringBuilder logs = new StringBuilder();

                while (reader.Read())
                {
                    logs.AppendLine($"{reader["IPAddress"]} - {reader["AccessTime"]}");
                }

                byte[] logsBytes = Encoding.ASCII.GetBytes(logs.ToString());
                stream.Write(logsBytes, 0, logsBytes.Length);
            }
        }

        /// <summary>
        /// gui file
        /// </summary>
        private void sendFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm main = new mainForm();
            main.Show();
        }

        private void HandleError(string message, Exception ex)
        {
            Console.WriteLine($"{message}: {ex.Message}");
            UpdateStatus($"{message}: {ex.Message}");
        }

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopListening();

            // Hủy các luồng nếu chúng vẫn đang chạy
            if (listeningThread != null && listeningThread.IsAlive)
            {
                listeningThread.Join();
            }

            if (sendingThread != null && sendingThread.IsAlive)
            {
                sendingThread.Join();
            }

            if (controlThread != null && controlThread.IsAlive)
            {
                controlThread.Join();
            }

            // Đảm bảo client và server đều đã đóng
            if (client != null && client.Connected)
            {
                client.Close();
            }

            if (server != null)
            {
                server.Stop();
            }

            // Hủy token để dừng các thao tác không cần thiết
            cancellationTokenSource?.Cancel();
        }
    }
}
