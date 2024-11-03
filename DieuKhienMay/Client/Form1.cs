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
                            // Đặt kích thước Form2 và pictureBox1 để phù hợp với kích thước hình ảnh nhận được
                            this.Size = new Size(receivedImage.Width, receivedImage.Height);
                            pictureBox1.Size = new Size(receivedImage.Width, receivedImage.Height);

                            // Đảm bảo ảnh thu phóng để hiển thị đầy đủ
                            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
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

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            // Điều chỉnh tọa độ trước khi gửi
            int adjustedX = e.X * Screen.PrimaryScreen.Bounds.Width / pictureBox1.Width;
            int adjustedY = e.Y * Screen.PrimaryScreen.Bounds.Height / pictureBox1.Height;
            SendMouseEvent("click", adjustedX, adjustedY, e.Button.ToString());
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            // Điều chỉnh tọa độ trước khi gửi
            int adjustedX = e.X * Screen.PrimaryScreen.Bounds.Width / pictureBox1.Width;
            int adjustedY = e.Y * Screen.PrimaryScreen.Bounds.Height / pictureBox1.Height;
            SendMouseEvent("move", adjustedX, adjustedY, "");
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            SendKeyboardEvent("keydown", e.KeyCode.ToString());
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Yêu cầu hủy luồng
            cts.Cancel();

            // Đợi cho luồng nhận kết thúc
            receivingThread?.Join();

            stream?.Close();
            client?.Close();
            cts.Dispose();

            base.OnFormClosing(e);
        }


    }
}
