using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static Client.Client;



namespace Client
{
    public partial class Form1 : Form
    {
        public class InputEvent
        {
            public int EventType { get; set; }
            public int Button { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public int Delta { get; set; }
            public int Key { get; set; }
        }


        private TcpClient client;
        private NetworkStream stream;
        private Thread receivingThread;
        private CancellationTokenSource cts = new CancellationTokenSource();
        private Image receivedImage;
        private Size originalImageSize;

        public async Task SendEvent(InputEvent inputEvent)
        {
            byte[] data = new byte[24];
            Buffer.BlockCopy(BitConverter.GetBytes(inputEvent.EventType), 0, data, 0, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(inputEvent.Button), 0, data, 4, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(inputEvent.X), 0, data, 8, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(inputEvent.Y), 0, data, 12, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(inputEvent.Delta), 0, data, 16, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(inputEvent.Key), 0, data, 20, 4);

            await stream.WriteAsync(data, 0, data.Length);
        }


        //public Form1(TcpClient client)
        //{
        //    InitializeComponent();
        //    this.client = client;
        //    stream = client.GetStream();

        //    // Gửi kích thước của PictureBox cho server
        //    SendPictureBoxSize();

        //    // Bắt đầu nhận hình ảnh từ server
        //    receivingThread = new Thread(() => ReceiveDesktopImages(cts.Token));
        //    receivingThread.Start();

        //    // Gán sự kiện chuột và bàn phím
        //    pictureBox1.MouseDown += pictureBox1_MouseDown;
        //    pictureBox1.MouseUp += pictureBox1_MouseUp;
        //    pictureBox1.MouseMove += pictureBox1_MouseMove;
        //    this.KeyDown += Form1_KeyDown;
        //    this.KeyUp += Form1_KeyUp;
        //    this.KeyPreview = true; // Đảm bảo Form nhận sự kiện KeyDown

        //    // Handle form resizing to refresh the PictureBox
        //    this.Resize += Form1_Resize;
        //}

        // Refresh PictureBox on form resize
        public Form1(TcpClient client)
        {
            InitializeComponent();
            this.client = client;
            stream = client.GetStream();

            // Bắt đầu nhận hình ảnh từ server
            receivingThread = new Thread(() => ReceiveDesktopImages(cts.Token));
            receivingThread.Start();

            // Bật Double Buffering cho Form để hạn chế nhấp nháy
            this.DoubleBuffered = true;

            // Xử lý sự kiện thay đổi kích thước Form
            this.Resize += (sender, e) => this.Invalidate();
            this.Paint += Form1_Paint;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (receivedImage != null)
            {
                // Tính toán kích thước và vị trí hình ảnh để duy trì tỷ lệ
                double formRatio = (double)this.ClientSize.Width / this.ClientSize.Height;
                double imageRatio = (double)originalImageSize.Width / originalImageSize.Height;

                int newWidth, newHeight;

                if (formRatio > imageRatio)
                {
                    newHeight = this.ClientSize.Height;
                    newWidth = (int)(newHeight * imageRatio);
                }
                else
                {
                    newWidth = this.ClientSize.Width;
                    newHeight = (int)(newWidth / imageRatio);
                }

                int x = (this.ClientSize.Width - newWidth) / 2;
                int y = (this.ClientSize.Height - newHeight) / 2;

                // Vẽ hình ảnh đã nhận vào form tại vị trí và kích thước được tính toán
                e.Graphics.DrawImage(receivedImage, new Rectangle(x, y, newWidth, newHeight));
            }
        }

        private void ReceiveDesktopImages(CancellationToken token)
        {
            try
            {
                while (client.Connected && !token.IsCancellationRequested)
                {
                    byte[] sizeBytes = new byte[4];
                    int bytesRead = stream.Read(sizeBytes, 0, sizeBytes.Length);
                    if (bytesRead == 0 || token.IsCancellationRequested) break;

                    int imageSize = BitConverter.ToInt32(sizeBytes, 0);
                    byte[] imageBytes = new byte[imageSize];
                    int totalBytesRead = 0;
                    while (totalBytesRead < imageSize && !token.IsCancellationRequested)
                    {
                        bytesRead = stream.Read(imageBytes, totalBytesRead, imageSize - totalBytesRead);
                        if (bytesRead == 0) break;
                        totalBytesRead += bytesRead;
                    }

                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        Image newImage = Image.FromStream(ms);
                        originalImageSize = newImage.Size;

                        // Cập nhật hình ảnh mới và yêu cầu Form vẽ lại
                        receivedImage?.Dispose(); // Giải phóng hình ảnh cũ nếu có
                        receivedImage = newImage;
                        this.Invoke((MethodInvoker)(() => this.Invalidate()));
                    }
                }
            }
            catch (Exception ex)
            {
                if (!token.IsCancellationRequested)
                {
                    MessageBox.Show("Error receiving image: " + ex.Message);
                }
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            var inputEvent = new InputEvent
            {
                EventType = 2, // 2 cho MouseDown
                Button = (int)e.Button,
                X = e.X,
                Y = e.Y
            };
            SendEvent(inputEvent).Wait();


        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            var inputEvent = new InputEvent
            {
                EventType = 3, // 3 cho MouseUp
                Button = (int)e.Button,
                X = e.X,
                Y = e.Y
            };
            SendEvent(inputEvent).Wait();

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // Tính toán tỉ lệ kích thước màn hình giữa client và server
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            int adjustedX = e.X * 1920 / screenWidth; // Thay 1920 bằng độ phân giải màn hình server của bạn
            int adjustedY = e.Y * 1200 / screenHeight; // Thay 1080 bằng độ phân giải màn hình server của bạn

            var inputEvent = new InputEvent
            {
                EventType = 1, // 1 cho MouseMove
                X = adjustedX,
                Y = adjustedY
            };
            SendEvent(inputEvent).Wait();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            var inputEvent = new InputEvent
            {
                EventType = 4, // 4 cho KeyDown
                Key = (int)e.KeyCode
            };
            SendEvent(inputEvent).Wait();
        }




        //private void SendPictureBoxSize()
        //{
        //    try
        //    {
        //        string message = $"size:{pictureBox1.Width}:{pictureBox1.Height}";
        //        byte[] data = Encoding.ASCII.GetBytes(message);
        //        stream.Write(data, 0, data.Length);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error sending PictureBox size: " + ex.Message);
        //    }
        //}
        // Phương thức gửi sự kiện chuột đến server

    }
}
