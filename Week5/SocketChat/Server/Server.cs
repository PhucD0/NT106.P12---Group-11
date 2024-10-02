using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            Connect();
        }

        IPEndPoint IP;
        Socket server;
        List<Socket> clientList;    // ds luu tru cac clients

        /// <summary>
        /// kết nối tới server
        /// </summary>
        void Connect()
        {
            clientList = new List<Socket>();
            //127.0.0.1 va 9999 co the thay doi 
            IP = new IPEndPoint(IPAddress.Any, 9999);       // doi IP cua bat cu client nao
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            server.Bind(IP);

            // Doi 1 client nao do nch
            Thread Listen = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        server.Listen(100);     //100 dua trong hang doi
                        Socket client = server.Accept();
                        clientList.Add(client);


                        Thread receive = new Thread(Receive);
                        receive.IsBackground = true;
                        receive.Start(client);
                    }
                }
                catch
                {
                    IP = new IPEndPoint(IPAddress.Any, 9999);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }       // 1 client tat thi ko bi loi(vong lap vo tan)

            });
            Listen.IsBackground = true;
            Listen.Start();
        }

        /// <summary>
        /// đóng kết nối hiện thời
        /// </summary>
        void Close()
        {
            server.Close();
        }

        /// <summary>
        /// gửi tin
        /// </summary>
        void Send(Socket client)
        {
            if (client != null && txbMessage.Text != string.Empty)
                client.Send(Serialize(txbMessage.Text));
        }

        /// <summary>
        /// nhận tin
        /// </summary>
        void Receive(object obj)
        {
            Socket client = obj as Socket;
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);

                    string message = (string)Deserialize(data);

                    //lsvMessage.Items.Add(new ListViewItem() { Text = message});

                    // Kiểm tra nếu message là yêu cầu gửi file
                    if (message.StartsWith("FILE:"))
                    {
                        // Nhận file
                        string fileName = message.Substring(5); // Tên file được gửi
                        byte[] fileData = ReceiveFileData(client); // Nhận dữ liệu file

                        // Lưu file vào server (tùy chọn)
                        File.WriteAllBytes(Path.Combine(@"C:\ReceivedFiles", fileName), fileData);

                        // Gửi file tới các client khác
                        foreach (Socket item in clientList)
                        {
                            if (item != null && item != client)
                            {
                                SendFile(item, fileName, fileData);
                            }
                        }

                        AddMessage($"Đã nhận file: {fileName} từ client.");
                    }
                    else
                    {
                        // Gửi tin nhắn đến các client khác
                        foreach (Socket item in clientList)
                        {
                            if (item != null && item != client)
                                item.Send(Serialize(message));
                        }
                        AddMessage(message);
                    }
                }
            }
            catch
            {
                clientList.Remove(client);
                client.Close();
            }

        }


        byte[] ReceiveFileData(Socket client)
        {
            // Nhận kích thước file
            byte[] fileSizeBytes = new byte[sizeof(int)];
            client.Receive(fileSizeBytes);
            int fileSize = (int)Deserialize(fileSizeBytes);

            // Nhận dữ liệu file
            byte[] fileData = new byte[fileSize];
            client.Receive(fileData);

            return fileData;
        }



        void SendFile(Socket client, string fileName, byte[] fileData)
        {
            try
            {
                // Gửi tên file trước
                client.Send(Serialize("FILE:" + fileName));

                // Gửi kích thước file
                client.Send(Serialize(fileData.Length));

                // Gửi dữ liệu file
                client.Send(fileData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi file tới client: {ex.Message}");
            }
        }

        /// <summary>
        /// add message vào khung chat
        /// </summary>
        /// <param name="s"></param>
        void AddMessage(string s)
        {
            lsvMessage.Items.Add(new ListViewItem() { Text = s });
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
        /// dong ket noi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// gui tin cho tat ca cac client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            foreach (Socket item in clientList)
            {

                Send(item);
            }
            AddMessage(txbMessage.Text);
            txbMessage.Clear();
        }
    }
}