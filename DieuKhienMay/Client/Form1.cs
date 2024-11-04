using System;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;



namespace Client
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private Thread receivingThread;
        private CancellationTokenSource cts = new CancellationTokenSource();
        public Form1(TcpClient client)
        {
            InitializeComponent();
            this.client = client;
            stream = client.GetStream();

            // Gửi kích thước của PictureBox cho server
            SendPictureBoxSize();

            // Bắt đầu nhận hình ảnh từ server
            receivingThread = new Thread(() => ReceiveDesktopImages(cts.Token));
            receivingThread.Start();

            // Gán sự kiện chuột và bàn phím
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;
            this.KeyPreview = true; // Đảm bảo Form nhận sự kiện KeyDown
        }

        private void ReceiveDesktopImages(CancellationToken token)
        {
            try
            {
                while (client.Connected && !token.IsCancellationRequested)
                {
                    // Nhận kích thước của ảnh từ server
                    byte[] sizeBytes = new byte[4];
                    int bytesRead = stream.Read(sizeBytes, 0, sizeBytes.Length);
                    if (bytesRead == 0 || token.IsCancellationRequested) break; // Ngắt kết nối

                    int imageSize = BitConverter.ToInt32(sizeBytes, 0);

                    // Nhận dữ liệu ảnh dựa vào kích thước đã nhận
                    byte[] imageBytes = new byte[imageSize];
                    int totalBytesRead = 0;
                    while (totalBytesRead < imageSize && !token.IsCancellationRequested)
                    {
                        bytesRead = stream.Read(imageBytes, totalBytesRead, imageSize - totalBytesRead);
                        if (bytesRead == 0) break; // Ngắt kết nối
                        totalBytesRead += bytesRead;
                    }

                    // Chuyển đổi byte[] thành đối tượng Image
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        Image receivedImage = Image.FromStream(ms);

                        // Hiển thị ảnh và điều chỉnh kích thước Form2 và pictureBox1 để phù hợp
                        pictureBox1.Invoke((MethodInvoker)(() =>
                        {
                            // Đặt kích thước của pictureBox1 để khớp với kích thước hình ảnh
                            pictureBox1.Size = new Size(receivedImage.Width, receivedImage.Height);

                            // Tạo một khoảng đệm (ví dụ 20px) để form lớn hơn pictureBox1
                            int padding = 20;

                            // Đặt kích thước của form lớn hơn kích thước của pictureBox1 với khoảng đệm
                            this.Size = new Size(receivedImage.Width + padding * 2, receivedImage.Height + padding * 2);

                            // Căn giữa pictureBox1 trong Form2 (nếu cần)
                            pictureBox1.Location = new Point(padding, padding);

                            // Đảm bảo ảnh thu phóng để hiển thị đầy đủ
                            //pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                            pictureBox1.Image = receivedImage;
                        }));
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

        // Sự kiện khi nhấn chuột
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            string button = e.Button.ToString();
            SendMouseEvent("click", e.X, e.Y, button);
        }

        // Sự kiện khi di chuyển chuột
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            SendMouseEvent("move", e.X, e.Y, "none");
        }

        // Sự kiện khi nhấn phím
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            SendKeyboardEvent("keydown", e.KeyCode.ToString());
        }

        // Sự kiện khi thả phím
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            SendKeyboardEvent("keyup", e.KeyCode.ToString());
        }

        private void SendPictureBoxSize()
        {
            try
            {
                string message = $"size:{pictureBox1.Width}:{pictureBox1.Height}";
                byte[] data = Encoding.ASCII.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending PictureBox size: " + ex.Message);
            }
        }
        // Phương thức gửi sự kiện chuột đến server
        private void SendMouseEvent(string action, int x, int y, string button)
        {
            try
            {
                string message = $"mouse:{action}:{x}:{y}:{button}";
                byte[] data = Encoding.ASCII.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending mouse event: " + ex.Message);
            }
        }

        // Gửi sự kiện bàn phím
        private void SendKeyboardEvent(string action, string key)
        {
            try
            {
                string message = $"keyboard:{action}:{key}";
                byte[] data = Encoding.ASCII.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending keyboard event: " + ex.Message);
            }
        }

        // Gửi sự kiện khi thả chuột ra
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            string button = e.Button.ToString();
            SendMouseEvent("mouseup", e.X, e.Y, button);
        }

        // Gửi sự kiện khi nhấn chuột xuống
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            string button = e.Button.ToString();
            SendMouseEvent("mousedown", e.X, e.Y, button);
        }
    }
}
