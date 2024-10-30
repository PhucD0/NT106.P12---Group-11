﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Data.SqlClient;
using System.Net;
using System.Text;
using System.Data;

namespace Server
{
    public partial class Server : Form
    {
        // KHAI BAO HERE
        private TcpListener listener;
        private TcpClient client;
        private NetworkStream stream;
        private bool isConnected = false;
        private SqlConnection sqlConnection;

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
            StartListening();
        }

        /// <summary>
        /// Xu li ket noi
        /// </summary>
        // Bắt đầu lắng nghe từ client (sd bat dong bo)
        private void StartListening()
        {
            // có gọi hàm HandleClientInput here


            // Ghi lại thông tin kết nối
            LogConnection("Connected", ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString(),
                ((IPEndPoint)client.Client.RemoteEndPoint).Port);
        }

        // Ket thuc ket noi
        private void StopListening()
        {

        }

        // Nhận thông tin điều khiển từ client
        private void HandleClientInput()
        {
            try
            {
                // Xử lí gói tin nhận được từ client
                while(client.Connected)
                {
                    byte[] headerBytesRecv = new byte[6];
                    stream.Read(headerBytesRecv, 0, headerBytesRecv.Length);

                    // Phân loại dữ liệu theo header

                    // 0: dữ liệu ảnh, 1: dữ liệu input
                    int dataType = BitConverter.ToInt32(headerBytesRecv, 0);
                    // độ dài dữ liệu input
                    int dataLength = BitConverter.ToInt32(headerBytesRecv, 2);

                    if(dataType == 0)   // client yêu cầu gửi ảnh màn hình từ server
                    {
                        if(isConnected)
                        {
                            // code something here, co dung ham SendImage()
                        }
                    }
                    else if(dataType == 1) // xử lí dữ liệu input từ client
                    {
                        byte[] dataBytesRecv = new byte[dataLength];
                        stream.Read(dataBytesRecv, 0, dataLength);
                        HandleInputBytes(dataBytesRecv);
                    }
                    else if(dataType == 2)  //yeu cau xem log tu server
                    {
                        DataTable logs = LoadLogs();
                        SendLogs(logs);
                    }
                    else
                    {
                        // Kết nối thất bại
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Exception: {ex.Message}");
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
        private void SendImage()
        {

        }

        /// <summary>
        /// Cap nhat trang thai, được gọi bởi StartListening(), StopListening(),...
        /// </summary>
        /// <param name="message"></param>
        private void UpdateStatus(string message)
        {

        }

        /// <summary>
        /// View logs
        /// </summary>
        // Chuỗi kết nối đến cơ sở dữ liệu
        string connectionString = "Server=your_server;Database=RemoteDesktopDB;User Id=your_user;Password=your_password;";

        // Hàm khởi tạo kết nối
        private SqlConnection InitializeDatabase()
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
                string query = "INSERT INTO ConnectionLogs (Status, IP, Port) VALUES (@Status, @IP, @Port)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@IP", ip);
                    command.Parameters.AddWithValue("@Port", port);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Truy cap co so du lieu de lay lish su ket noi
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
        private void SendLogs(DataTable logs)
        {
            logs = LoadLogs(); 
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
        }

        /// <summary>
        /// gui file
        /// </summary>
        
    }
}
