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
            public int ModifierKeys { get; set; } // Thêm trường để lưu trạng thái các phím tổ hợp
        }


        private TcpClient client;
        private NetworkStream stream;
        private Thread receivingThread;
        private CancellationTokenSource cts = new CancellationTokenSource();
        private Image? receivedImage;
        private Size originalImageSize;

        public async Task SendEvent(InputEvent inputEvent)
        {
            byte[] data = new byte[28];
            Buffer.BlockCopy(BitConverter.GetBytes(inputEvent.EventType), 0, data, 0, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(inputEvent.Button), 0, data, 4, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(inputEvent.X), 0, data, 8, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(inputEvent.Y), 0, data, 12, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(inputEvent.Delta), 0, data, 16, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(inputEvent.Key), 0, data, 20, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(inputEvent.ModifierKeys), 0, data, 24, 4);

            await stream.WriteAsync(data, 0, data.Length);
        }


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

        // Vẽ hình ảnh lên form và giữ đúng tỉ lệ
        private void Form1_Paint(object? sender, PaintEventArgs e)
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

                // Lấp đầy vùng form bằng hình ảnh đã được co giãn và giữ chất lượng
                e.Graphics.Clear(this.BackColor); // Đặt nền cho form
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImage(receivedImage, new Rectangle(x, y, newWidth, newHeight));
            }
        }

        // Nhận ảnh từ server
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

        /// <summary>
        /// Gửi các sự kiện chuột và bàn phím
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            var inputEvent = new InputEvent
            {
                EventType = 2, // 2 cho MouseDown
                Button = (int)e.Button,
                X = e.X,
                Y = e.Y
            };
            await SendEvent(inputEvent);
        }

        private async void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            var inputEvent = new InputEvent
            {
                EventType = 3, // 3 cho MouseUp
                Button = (int)e.Button,
                X = e.X,
                Y = e.Y
            };
            await SendEvent(inputEvent);
        }

        private async void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (receivedImage == null) return;

            // Kích thước và vị trí của hình ảnh trên form
            double formRatio = (double)this.ClientSize.Width / this.ClientSize.Height;
            double imageRatio = (double)originalImageSize.Width / originalImageSize.Height;

            int newWidth, newHeight;
            int xOffset, yOffset;

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

            xOffset = (this.ClientSize.Width - newWidth) / 2;
            yOffset = (this.ClientSize.Height - newHeight) / 2;

            // Tính toán tọa độ chuột dựa trên vị trí và kích thước của hình ảnh
            int adjustedX = (e.X - xOffset) * originalImageSize.Width / newWidth;
            int adjustedY = (e.Y - yOffset) * originalImageSize.Height / newHeight;

            var inputEvent = new InputEvent
            {
                EventType = 1, // 1 cho MouseMove
                X = adjustedX,
                Y = adjustedY
            };
            await SendEvent(inputEvent);
        }

        private async void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            var inputEvent = new InputEvent
            {
                EventType = 4, // 4 cho KeyDown
                Key = (int)e.KeyCode,
                ModifierKeys = (int)Control.ModifierKeys // Lưu trạng thái các phím tổ hợp
            };
            await SendEvent(inputEvent);
        }

    }
}
