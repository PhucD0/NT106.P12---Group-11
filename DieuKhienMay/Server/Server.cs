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

namespace Server
{
    public partial class Server : Form
    {
        // KHAI BAO HERE
        private TcpListener server;
        private TcpClient client;
        private Thread listeningThread;
        private Thread sendingThread;
        private Thread controlThread;
        private int port;
        private int pictureBoxWidth;
        private int pictureBoxHeight;
        private bool isConnected = false;
        private SqlConnection sqlConnection;
        private System.Timers.Timer timer;
        private bool isListening = false;
        // Chuỗi kết nối đến cơ sở dữ liệu
        private string connectionString = "Server=your_server;Database=RemoteDesktopDB;User Id=your_user;Password=your_password;";

        // Khai báo các hằng số cho hành động chuột và bàn phím
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        private const int MOUSEEVENTF_MOVE = 0x0001;
        private const int KEYEVENTF_KEYDOWN = 0x0000;
        private const int KEYEVENTF_KEYUP = 0x0002;

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
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
            server = new TcpListener(IPAddress.Any, port);
            listeningThread = new Thread(StartListening);
            listeningThread.Start();
            btnListen.Enabled = false;
        }

        /// <summary>
        /// Xu li ket noi
        /// </summary>
        // Bắt đầu lắng nghe từ client (sd bat dong bo)
        private void StartListening()
        {
            server.Start();
            client = server.AcceptTcpClient();

            // Bắt đầu gửi hình ảnh sau khi kết nối thành công
            sendingThread = new Thread(SendDesktopImages);
            sendingThread.Start();
            // Bắt đầu nhận và xử lý các sự kiện điều khiển từ client
            controlThread = new Thread(ReceiveControlEvents);
            controlThread.Start();

            // Ghi lại thông tin kết nối
            /*LogConnection("Connected", ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString(),
                ((IPEndPoint)client.Client.RemoteEndPoint).Port);*/
        }



        // Ket thuc ket noi
        private void StopListening()
        {
            
        }


        /// <summary>
        /// Nhận thông tin điều khiển từ client
        /// </summary>
        private void ReceiveControlEvents()
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            while (client.Connected)
            {
                try
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    ProcessControlEvent(message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error receiving control event: " + ex.Message);
                    break;
                }
            }
        }
        private void ProcessControlEvent(string message)
        {
            string[] parts = message.Split(':');

            if (parts[0] == "size")
            {
                // Lưu kích thước PictureBox từ client
                pictureBoxWidth = int.Parse(parts[1]);
                pictureBoxHeight = int.Parse(parts[2]);
            }
            else if (parts[0] == "mouse")
            {
                string action = parts[1];
                int x = int.Parse(parts[2]);
                int y = int.Parse(parts[3]);
                string button = parts[4];

                // Điều chỉnh tọa độ chuột theo tỷ lệ màn hình server
                int adjustedX = x * Screen.PrimaryScreen.Bounds.Width / pictureBoxWidth;
                int adjustedY = y * Screen.PrimaryScreen.Bounds.Height / pictureBoxHeight;

                PerformMouseAction(action, adjustedX, adjustedY, button);
            }
            else if (parts[0] == "keyboard")
            {
                string action = parts[1];
                string key = parts[2];
                PerformKeyboardAction(action, key);
            }
        }

        private void PerformMouseAction(string action, int x, int y, string button)
        {
            // Sử dụng WinAPI hoặc các lệnh điều khiển để thực hiện thao tác chuột
            // Di chuyển chuột đến vị trí mong muốn
            Cursor.Position = new Point(x, y);

            // Thực hiện các hành động nhấp chuột dựa trên yêu cầu từ client
            if (action == "click")
            {
                if (button == "Left")
                {
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, x, y, 0, 0);
                }
                else if (button == "Right")
                {
                    mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, x, y, 0, 0);
                }
            }
            else if (action == "move")
            {
                // Di chuyển chuột
                mouse_event(MOUSEEVENTF_MOVE, x, y, 0, 0);
            }
        }

        private void PerformKeyboardAction(string action, string key)
        {
            // Sử dụng WinAPI hoặc các lệnh điều khiển để thực hiện thao tác bàn phím
            // Chuyển ký tự thành mã phím (Virtual Key Code)
            try
            {
                byte keyCode = (byte)Enum.Parse(typeof(Keys), key);

                if (action == "keydown")
                {
                    keybd_event(keyCode, 0, KEYEVENTF_KEYDOWN, 0);
                }
                else if (action == "keyup")
                {
                    keybd_event(keyCode, 0, KEYEVENTF_KEYUP, 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing keyboard event: " + ex.Message);
            }
        }


        /// <summary>
        /// Xu li du lieu 
        /// </summary>
        /// <param name="inputBytes"></param>
        private void HandleInputBytes(byte[] inputBytes)
        {
            // code something here
        }


        /// <summary>
        /// Gui anh
        /// </summary>
        private void SendDesktopImages()
        {
            NetworkStream stream = client.GetStream();
            while (client.Connected)
            {
                try
                {
                    Image desktopImage = CaptureDesktop();

                    using (MemoryStream ms = new MemoryStream())
                    {
                        // Lưu ảnh dưới dạng PNG vào MemoryStream
                        desktopImage.Save(ms, ImageFormat.Png);
                        byte[] imageBytes = ms.ToArray();

                        // Gửi kích thước của ảnh trước
                        byte[] sizeBytes = BitConverter.GetBytes(imageBytes.Length);
                        stream.Write(sizeBytes, 0, sizeBytes.Length);

                        // Gửi nội dung ảnh
                        stream.Write(imageBytes, 0, imageBytes.Length);
                    }

                    desktopImage.Dispose();
                    Thread.Sleep(100); // Giảm tải cho hệ thống
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error sending image: " + ex.Message);
                    break;
                }
            }
        }

        // Hàm chụp ảnh với độ phân giải thấp và chất lượng JPEG giảm
        private Image CaptureDesktop()
        {
            // Lấy độ rộng và chiều cao tối đa bao gồm tất cả các màn hình
            int totalWidth = 0;
            int maxHeight = 0;
            foreach (Screen screen in Screen.AllScreens)
            {
                totalWidth += screen.Bounds.Width;
                maxHeight = Math.Max(maxHeight, screen.Bounds.Height);
            }

            // Tạo bitmap với kích thước tổng hợp của tất cả các màn hình
            Bitmap screenshot = new Bitmap(totalWidth, maxHeight, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(screenshot);

            // Vẽ nội dung của từng màn hình lên bitmap
            int offsetX = 0;
            foreach (Screen screen in Screen.AllScreens)
            {
                graphics.CopyFromScreen(screen.Bounds.X, screen.Bounds.Y, offsetX, 0, screen.Bounds.Size, CopyPixelOperation.SourceCopy);
                offsetX += screen.Bounds.Width; // Di chuyển đến vị trí kế tiếp cho màn hình tiếp theo
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
       /* private SqlConnection InitializeDatabase()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        // ghi lại thông tin kết nối
        private void LogConnection(string status, string ip, int port)
        {
            using (SqlConnection connection = InitializeDatabase())
            {
                string query = "INSERT INTO ConnectionLogs (Status, IP, Port, Timestamp) VALUES (@Status, @IP, @Port, @Timestamp)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@IP", ip);
                    command.Parameters.AddWithValue("@Port", port);
                    command.Parameters.AddWithValue("@Timestamp", DateTime.Now);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Truy cap co so du lieu để lấy lịch sử kết nối
        private DataTable LoadLogs()
        {
            DataTable logs = new DataTable();
            using (SqlConnection connection = InitializeDatabase())
            {
                string query = "SELECT * FROM ConnectionLogs ORDER BY Timestamp DESC";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(logs);
                    }
                }
            }
            return logs;
        }

        // Gui logs cho client
        private void SendLogs()
        {
            DataTable logs = LoadLogs();
            StringBuilder sb = new StringBuilder();

            foreach (DataRow row in logs.Rows)
            {
                sb.AppendLine($"{row["Timestamp"]} - {row["Status"]} - {row["IP"]}:{row["Port"]}");
            }

            byte[] logData = Encoding.UTF8.GetBytes(sb.ToString());
            byte[] header = BitConverter.GetBytes((ushort)2); // Giả định 2 là loại dữ liệu log
            byte[] length = BitConverter.GetBytes(logData.Length);

            stream.Write(header, 0, header.Length);
            stream.Write(length, 0, length.Length);
            stream.Write(logData, 0, logData.Length);
        }*/

        private void sendFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileTransfer fileTransfer = new FileTransfer();
            fileTransfer.Show();
        }

        /// <summary>
        /// gui file
        /// </summary>

    }
}
