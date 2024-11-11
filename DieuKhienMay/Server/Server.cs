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
using RemoteControlServer;
using Newtonsoft.Json;
using Microsoft.VisualBasic.Logging;

namespace Server
{
    public partial class Server : Form
    {
        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);
        [DllImport("user32.dll")]
        static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray), In] Input[] pInputs, int cbSize);
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr GetMessageExtraInfo();

        [StructLayout(LayoutKind.Sequential)]
        public struct Input
        {
            public int type;
            public InputUnion U;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct InputUnion
        {
            [FieldOffset(0)]
            public MouseInput mi;
            [FieldOffset(0)]
            public KeyboardInput ki;
            [FieldOffset(0)]
            public HardwareInput hi;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MouseInput
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct KeyboardInput
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HardwareInput
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }

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
        private string databaseConnectionString = @"Data Source=localhost;Initial Catalog=RemoteDesktopDB;Integrated Security=true;";     //RemoteDesktopDB có cả status


        public Server()
        {
            InitializeComponent();
            txbIP.Text = GetLocalIPAddress();  // Lấy và hiển thị IP của máy server
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopListening();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            port = int.Parse(txbPort.Text);

            // Tự động lấy địa chỉ IP của máy chủ
            //string localIP = GetLocalIPAddress();

            server = new TcpListener(IPAddress.Any, port);
            cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;

            isListening = true;  // Cập nhật trạng thái
            listeningThread = new Thread(() => StartListening(token));
            listeningThread.Start();
            btnListen.Enabled = false;
            btnStop.Enabled = true;

        }

        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        /// <summary>
        /// Xu li ket noi
        /// </summary>
        // Bắt đầu lắng nghe từ client (sd bat dong bo)
        private async void StartListening(CancellationToken token)
        {

            try
            {
                server?.Start();
                UpdateStatus("Server đang lắng nghe...");


                while (!token.IsCancellationRequested)
                {
                    if (server.Pending())
                    {
                        client = await server.AcceptTcpClientAsync(); // Lắng nghe không đồng bộ
                        UpdateStatus("Client đã kết nối.");

                        // Ghi log khi kết nối thành công
                        LogConnection1(((IPEndPoint?)client.Client.RemoteEndPoint).Address.ToString(), "Connected");
                                               
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
                // Dừng cả cổng chính và cổng phụ
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
        private async void ReceiveControlEvents(CancellationToken token)
        {
            NetworkStream stream = client.GetStream();

            try
            {
                byte[] buffer = new byte[24];

                while (client.Connected)
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    var inputEvent = new InputEvent
                    {
                        EventType = BitConverter.ToInt32(buffer, 0),
                        Button = BitConverter.ToInt32(buffer, 4),
                        X = BitConverter.ToInt32(buffer, 8),
                        Y = BitConverter.ToInt32(buffer, 12),
                        Delta = BitConverter.ToInt32(buffer, 16),
                        Key = BitConverter.ToInt32(buffer, 20)
                    };

                    ProcessInputEvent(inputEvent);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

        }


        private void ProcessInputEvent(InputEvent inputEvent)
        {
            switch (inputEvent.EventType)
            {
                case 1: // MouseMove
                    SetCursorPosition(inputEvent.X, inputEvent.Y);
                    break;
                case 2: // MouseDown
                    SimulateMouseEvent(inputEvent.Button, inputEvent.X, inputEvent.Y, true);
                    break;
                case 3: // MouseUp
                    SimulateMouseEvent(inputEvent.Button, inputEvent.X, inputEvent.Y, false);
                    break;
                case 4: // KeyDown
                    SimulateKeyPress(inputEvent.Key);
                    break;
                default:
                    Console.WriteLine("Unknown event type");
                    break;
            }

        }

        private void SimulateMouseEvent(int button, int x, int y, bool isDown)
        {
            uint flag = 0;
            switch (button)
            {
                case (int)MouseButtons.Left:
                    flag = isDown ? 0x0002u : 0x0004u; // MOUSEEVENTF_LEFTDOWN : MOUSEEVENTF_LEFTUP
                    break;
                case (int)MouseButtons.Right:
                    flag = isDown ? 0x0008u : 0x0010u; // MOUSEEVENTF_RIGHTDOWN : MOUSEEVENTF_RIGHTUP
                    break;
                case (int)MouseButtons.Middle:
                    flag = isDown ? 0x0020u : 0x0040u; // MOUSEEVENTF_MIDDLEDOWN : MOUSEEVENTF_MIDDLEUP
                    break;
            }
            mouse_event(flag, (uint)x, (uint)y, 0, UIntPtr.Zero);
        }


        private void SetCursorPosition(int x, int y)
        {
            Cursor.Position = new System.Drawing.Point(x, y);
        }


        private void SimulateKeyPress(int key)
        {
            Input[] inputs = new Input[2];

            inputs[0] = new Input
            {
                type = 1, // Keyboard event
                U = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = (ushort)key,
                        dwFlags = 0,
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            };

            inputs[1] = new Input
            {
                type = 1, // Keyboard event
                U = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = (ushort)key,
                        dwFlags = 2, // Key up
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            };

            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
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
                    // Chụp và nén ảnh desktop
                    Image desktopImage = CaptureDesktop();

                    using (MemoryStream ms = new MemoryStream())
                    {
                        // Nén ảnh với chất lượng JPEG (giá trị chất lượng từ 0 đến 100)
                        ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                        //Encoder qualityEncoder = Encoder.Quality;
                        System.Drawing.Imaging.Encoder qualityEncoder = System.Drawing.Imaging.Encoder.Quality;

                        EncoderParameters encoderParams = new EncoderParameters(1);

                        // Đặt chất lượng nén thành 50 để giảm dung lượng (có thể điều chỉnh)
                        encoderParams.Param[0] = new EncoderParameter(qualityEncoder, 50L);
                        desktopImage.Save(ms, jpgEncoder, encoderParams);

                        byte[] imageBytes = ms.ToArray();
                        byte[] sizeBytes = BitConverter.GetBytes(imageBytes.Length);

                        // Gửi kích thước và dữ liệu ảnh tới client
                        stream.Write(sizeBytes, 0, sizeBytes.Length);
                        stream.Write(imageBytes, 0, imageBytes.Length);
                    }

                    desktopImage.Dispose();
                    Thread.Sleep(100); // Tùy chỉnh thời gian chờ để kiểm soát tần suất gửi ảnh
                }
                catch (Exception ex)
                {
                    HandleError("Error sending image", ex);
                    break;
                }
            }
        }

        // Hàm chụp ảnh màn hình
        private Image CaptureDesktop()
        {
            int totalWidth = Screen.AllScreens.Sum(screen => screen.Bounds.Width);
            int maxHeight = Screen.AllScreens.Max(screen => screen.Bounds.Height);

            Bitmap screenshot = new Bitmap(totalWidth, maxHeight, PixelFormat.Format24bppRgb);
            Graphics graphics = Graphics.FromImage(screenshot);

            int offsetX = 0;
            foreach (Screen screen in Screen.AllScreens)
            {
                graphics.CopyFromScreen(screen.Bounds.X, screen.Bounds.Y, offsetX, 0, screen.Bounds.Size, CopyPixelOperation.SourceCopy);
                offsetX += screen.Bounds.Width;
            }

            graphics.Dispose();
            return screenshot;
        }

        // Hàm lấy bộ mã hóa cho định dạng ảnh
        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

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
        // ghi lại thông tin kết nối bản 1
        private void LogConnection1(string ip, string status)
        {
            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                string query = "INSERT INTO ConnectionLogs (IPAddress, AccessTime, [Status]) VALUES (@IPAddress, @AccessTime, @Status)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@IPAddress", ip);
                command.Parameters.AddWithValue("@AccessTime", DateTime.Now);
                command.Parameters.AddWithValue("@Status", status);

                connection.Open();
                command.ExecuteNonQuery();
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

        private void RequestLogs()
        {
            StringBuilder logs = new StringBuilder();
            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                string query = "SELECT IPAddress, AccessTime, Status FROM ConnectionLogs";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    logs.AppendLine($"{reader["IPAddress"]} - {reader["AccessTime"]} - {reader["Status"]}");
                }

            }

            // Lưu log vào một tệp tạm thời
            string tempFilePath = Path.Combine(Path.GetTempPath(), "ConnectionLogs.txt");
            File.WriteAllText(tempFilePath, logs.ToString());

            // Mở tệp log bằng Notepad
            System.Diagnostics.Process.Start("notepad.exe", tempFilePath);
        }

        private void requestLogsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            RequestLogs();
        }
    }
}
