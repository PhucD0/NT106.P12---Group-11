using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Server : Form
    {
        private Button selectedButton = null; // Lưu Button hiện đang được chọn
        private TcpListener server;
        private Thread listenerThread;
        private List<TcpClient> clients = new List<TcpClient>();
        private Dictionary<int, string> seatStatus = new Dictionary<int, string>(); // Ghế và trạng thái
        private Dictionary<int, Button> seatButtons = new Dictionary<int, Button>();
        private int connectedDevices = 0;


        public Server()
        {
            InitializeComponent();
            CreateControls();
        }

        // Khởi tạo 25 ghế
        private void CreateControls()
        {
            int rows = 5; // Số hàng
            int cols = 5; // Số cột
            int padding = 10; // Khoảng cách giữa các nút
            int buttonWidth = 65; // Chiều rộng của nút (hình chữ nhật)
            int buttonHeight = 38; // Chiều cao của nút (hình chữ nhật)
            int startX = 180; // Tọa độ X bắt đầu
            int startY = 60; // Tọa độ Y bắt đầu

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int idx = i * cols + j + 1;
                    seatStatus[idx] = "Trống";
                    Button seatButton = new Button
                    {
                        Width = buttonWidth,
                        Height = buttonHeight,
                        Left = startX + j * (buttonWidth + padding),
                        Top = startY + i * (buttonHeight + padding),
                        Text = idx.ToString(), // Hiển thị số thứ tự trên nút
                        BackColor = Color.White,  // Màu nền của nút
                        FlatStyle = FlatStyle.Flat, // Chuyển sang kiểu FlatStyle để tùy chỉnh viền
                        Font = new Font("Arial", 10, FontStyle.Regular), // Tùy chỉnh font chữ
                        TextAlign = ContentAlignment.MiddleCenter // Căn giữa nội dung nút
                    };

                    
                    // Tùy chỉnh viền của nút
                    seatButton.FlatAppearance.BorderColor = Color.Black; // Viền màu đen
                    seatButton.FlatAppearance.BorderSize = 1; // Độ dày viền là 1 pixel

                    seatButtons[idx] = seatButton;  // thêm vào danh sách

                    // Thêm nút vào Form
                    this.Controls.Add(seatButton);
                }
            }
        }

        private void Server_Load(object sender, EventArgs e)
        {
            ConfigureTextBoxAsLabel(txbDevicesConnected);
            ConfigureTextBoxAsLabel(txbSeatsSelected);
            ConfigureTextBoxAsLabel(txbSeatsEmpty);

            UpdateConnectedDevices(0); // Khởi tạo số thiết bị
            UpdateSeatCounts();        // Khởi tạo số liệu ghế
        }

        // Hàm cấu hình TextBox như Label
        private void ConfigureTextBoxAsLabel(TextBox textBox)
        {
            textBox.BorderStyle = BorderStyle.None;
            textBox.ReadOnly = true;
            textBox.BackColor = this.BackColor;
            textBox.TabStop = false;
        }

        // Hàm cập nhật số thiết bị kết nối
        private void UpdateConnectedDevices(int change)
        {
            connectedDevices += change;
            txbDevicesConnected.Text = connectedDevices.ToString();
        }

        // Hàm cập nhật số ghế đã chọn
        private void UpdateSeatsSelected()
        {
            int selectedSeats = seatStatus.Values.Count(status => status != "Trống");
            txbSeatsSelected.Text = selectedSeats.ToString();
        }

        // Hàm cập nhật số ghế trống
        private void UpdateSeatsEmpty()
        {
            int emptySeats = seatStatus.Values.Count(status => status == "Trống");
            txbSeatsEmpty.Text = emptySeats.ToString();
        }

        // Hàm tích hợp cập nhật số ghế
        private void UpdateSeatCounts()
        {
            UpdateSeatsSelected();
            UpdateSeatsEmpty();
        }

        private void ProcessSeatChange(int seatNumber, string clientName)
        {
            seatStatus[seatNumber] = clientName;

            // Cập nhật số ghế đã chọn
            int selectedSeats = seatStatus.Values.Count(status => status != "Trống");
            txbSeatsSelected.Text = selectedSeats.ToString();

            // Cập nhật số ghế trống
            int emptySeats = seatStatus.Values.Count(status => status == "Trống");
            txbSeatsEmpty.Text = emptySeats.ToString();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txbPort.Text, out int port))
            {
                listenerThread = new Thread(() => StartListening(port));
                listenerThread.IsBackground = true;
                listenerThread.Start();

                btnListen.Enabled = false; // Disable nút Listen
            }
            else
            {
                MessageBox.Show("Vui lòng nhập cổng hợp lệ!");
            }
        }

        private void StartListening(int port)
        {
                server = new TcpListener(IPAddress.Any, port);
                server.Start();

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();    // Chấp nhận kết nối từ client

                    lock (clients)
                    {
                        clients.Add(client); // Thêm client vào danh sách
                    }

                    // Cập nhật giao diện: tăng số thiết bị
                    Invoke((Action)(() =>
                    {
                        UpdateConnectedDevices(1);
                    }));

                    // Thông báo client kết nối
                    Invoke((Action)(() =>
                    {
                        MessageBox.Show($"Client mới đã kết nối: {client.Client.RemoteEndPoint}");
                    }));

                    Thread clientThread = new Thread(() => HandleClient(client));
                    clientThread.IsBackground = true;
                    clientThread.Start();
                }

        }

        private void HandleClient(TcpClient client)
        {
            try
            {
                // Gửi trạng thái ghế hiện tại cho client mới
                BroadcastSeatStatus(client);

                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    ProcessClientMessage(client, message);
                }
            }
            catch
            {
                // Xử lý khi client mất kết nối
                lock (clients)
                {
                    clients.Remove(client);
                }

                Invoke((Action)(() =>
                {
                    UpdateConnectedDevices(-1);
                }));
            }
        }

        private void ProcessClientMessage(TcpClient client, string message)
        {
            try
            {
                string[] parts = message.Split('|');
                if (parts.Length == 2 && int.TryParse(parts[0], out int seatNumber))
                {
                    string clientName = parts[1];
                    lock (seatStatus)
                    {
                        if (seatStatus[seatNumber] == "Trống")
                        {
                            seatStatus[seatNumber] = clientName; // Cập nhật trạng thái ghế
                            ProcessSeatChange(seatNumber, clientName);
                            UpdateSeatUI(seatNumber, clientName);
                            BroadcastSeatStatus(); // Gửi tới tất cả client
                        }
                        else
                        {
                            Console.WriteLine($"Ghế {seatNumber} đã được đặt bởi {seatStatus[seatNumber]}.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Sai định dạng thông điệp từ client.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi xử lý thông điệp client: {ex.Message}");
            }
        }

        private void UpdateSeatUI(int seatNumber, string clientName)
        {
            try
            {
                if (seatButtons[seatNumber].InvokeRequired)
                {
                    seatButtons[seatNumber].Invoke((Action)(() =>
                    {
                        if (seatButtons.ContainsKey(seatNumber))
                        {
                            seatButtons[seatNumber].BackColor = Color.Cyan;
                            seatButtons[seatNumber].Text = clientName;
                        }
                        else
                        {
                            Console.WriteLine($"Ghế {seatNumber} không tồn tại.");
                        }
                    }));
                }
                else
                {
                    if (seatButtons.ContainsKey(seatNumber))
                    {
                        seatButtons[seatNumber].BackColor = Color.Cyan;
                        seatButtons[seatNumber].Text = clientName;
                    }
                }
            }
            catch (InvalidOperationException invOpEx)
            {
                Console.WriteLine($"Lỗi cập nhật giao diện (Invoke): {invOpEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi không xác định khi cập nhật giao diện: {ex.Message}");
            }
        }

        private void BroadcastSeatStatus(TcpClient specificClient = null)
        {
            lock (clients)
            {
                string statusMessage = string.Join(",", seatStatus.Select(kvp => $"{kvp.Key}:{kvp.Value}"));
                byte[] data = Encoding.UTF8.GetBytes(statusMessage);


                // Nếu chỉ gửi cho một client cụ thể
                if (specificClient != null)
                {
                    try
                    {
                        NetworkStream stream = specificClient.GetStream();
                        stream.Write(data, 0, data.Length);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi gửi trạng thái ghế tới client cụ thể: {ex.Message}");
                    }
                    return;
                }

                // Nếu gửi cho tất cả clients
                foreach (var c in clients.ToList()) // Sao chép danh sách để tránh lỗi nếu client bị xóa
                {
                    if (c.Connected)
                    {
                        try
                        {
                            NetworkStream stream = c.GetStream();
                            stream.Write(data, 0, data.Length);
                        }
                        catch
                        {
                            // Xử lý client mất kết nối
                            clients.Remove(c);
                        }
                    }
                }
            }
        }
    }
}
