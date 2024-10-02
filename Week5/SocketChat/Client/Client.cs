using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Runtime.InteropServices.ComTypes;

namespace Client
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            Connect();
        }

        /// <summary>
        /// gửi tin đi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Send();
            AddMessage(txbMessage.Text);
        }

        // cần IP, Socket

        //IP: dia chi cua server
        IPEndPoint IP;
        Socket client;


        /// <summary>
        /// kết nối tới server
        /// </summary>
        void Connect()
        {
            //127.0.0.1 va 9999 co the thay doi 
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            // ket noi
            try
            {
                client.Connect(IP);
            }
            catch
            {
                MessageBox.Show("Khong the ket noi server!!", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // tao luong de listen
            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();
        }

        /// <summary>
        /// đóng kết nối hiện thời
        /// </summary>
        void Close()
        {
            client.Close();
        }

        /// <summary>
        /// gửi tin
        /// </summary>
        void Send()
        {
            if (txbMessage.Text != string.Empty)
                client.Send(Serialize(txbMessage.Text));
        }

        /// <summary>
        /// nhận tin
        /// </summary>
        void Receive()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);

                    string message = (string)Deserialize(data);

                    //lsvMessage.Items.Add(new ListViewItem() { Text = message});

                    // Kiểm tra xem có phải là thông báo gửi file hay không
                    if (message.StartsWith("FILE:"))
                    {
                        string fileName = message.Substring(5); // Lấy tên file
                        byte[] fileData = ReceiveFileData(); // Nhận dữ liệu file

                        // Lưu file vào thư mục
                        File.WriteAllBytes(Path.Combine(@"C:\ReceivedFiles", fileName), fileData);
                        MessageBox.Show($"File {fileName} đã được nhận và lưu thành công!");
                    }
                    else
                    {
                        AddMessage(message);
                    }
                }
            }
            catch
            {
                Close();
            }

        }

        /// <summary>
        /// Hàm nhận dữ liệu file từ server
        /// </summary>
        byte[] ReceiveFileData()
        {
            // Nhận kích thước file trước
            byte[] fileSizeBytes = new byte[sizeof(int)];
            client.Receive(fileSizeBytes);
            int fileSize = (int)Deserialize(fileSizeBytes);

            // Nhận dữ liệu file
            byte[] fileData = new byte[fileSize];
            client.Receive(fileData);

            return fileData;
        }

        /// <summary>
        /// add message vào khung chat
        /// </summary>
        /// <param name="s"></param>
        void AddMessage(string s)
        {
            lsvMessage.Items.Add(new ListViewItem() { Text = s });
            txbMessage.Clear();
        }

        /// <summary>
        /// Phân mảnh
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            // phan manh, ptich obj roi gan vo stream
            formatter.Serialize(stream, obj);

            // stream tra ve 1 day byte
            return stream.ToArray();
        }

        /// <summary>
        /// Gom mảnh
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();

            return formatter.Deserialize(stream);
        }

        /// <summary>
        /// đóng kết nối khi đóng form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Chọn file và gửi file tới server
        /// </summary>
        private void btnSendFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;
                    byte[] fileData = File.ReadAllBytes(filePath);
                    string fileName = Path.GetFileName(filePath);

                    // Gửi file trong một luồng riêng để tránh làm "đơ" UI
                    Thread sendFileThread = new Thread(() => SendFile(fileData, fileName));
                    sendFileThread.IsBackground = true;
                    sendFileThread.Start();
                }
            }
        }

        /// <summary>
        /// Hàm gửi file tới server
        /// </summary>
        void SendFile(byte[] fileData, string fileName)
        {
            try
            {
                // Gửi tên file trước
                client.Send(Serialize(fileName));

                // Gửi kích thước file
                client.Send(Serialize(fileData.Length));

                // Gửi dữ liệu file
                client.Send(fileData);

                MessageBox.Show("File đã được gửi thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi file: {ex.Message}");
            }
        }
        /// <summary>
        /// Choose file and Send file
        /// </summary>

    }
}