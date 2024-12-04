using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Client : Form
    {
        private TcpClient client;
        private Thread receiveThread;
        private Dictionary<int, Button> seatButtons = new Dictionary<int, Button>();
        private Button selectedButton = null; // Lưu button đang được chọn
        private int selectedSeatNumber = -1; // Lưu số ghế đang được chọn

        public Client()
        {
            InitializeComponent();
            CreateControls();
        }

        private void CreateControls()
        {
            int rows = 5; // Số hàng
            int cols = 5; // Số cột
            int padding = 10; // Khoảng cách giữa các nút
            int buttonWidth = 65; // Chiều rộng của nút (hình chữ nhật)
            int buttonHeight = 37; // Chiều cao của nút (hình chữ nhật)
            int startX = 210; // Tọa độ X bắt đầu
            int startY = 60; // Tọa độ Y bắt đầu

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int idx = i * cols + j + 1;

                    Button btn = new Button
                    {
                        Width = buttonWidth,
                        Height = buttonHeight,
                        Left = startX + j * (buttonWidth + padding),
                        Top = startY + i * (buttonHeight + padding),
                        Text = idx.ToString(), // Hiển thị số thứ tự trên nút
                        BackColor = Color.White,  // Màu nền của nút
                        FlatStyle = FlatStyle.Flat, // Chuyển sang kiểu FlatStyle để tùy chỉnh viền
                        Font = new Font("Arial", 10, FontStyle.Regular), // Tùy chỉnh font chữ
                        TextAlign = ContentAlignment.MiddleCenter, // Căn giữa nội dung nút
                        Tag = idx
                    };

                    // Thêm sự kiện nhấp chuột (tùy chọn)
                    btn.Click += SeatButton_Click;

                    seatButtons[idx] = btn;


                    // Tùy chỉnh viền của nút
                    btn.FlatAppearance.BorderColor = Color.Black; // Viền màu đen
                    btn.FlatAppearance.BorderSize = 1; // Độ dày viền là 1 pixel


                    // Thêm nút vào Form
                    this.Controls.Add(btn);
                }
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                client = new TcpClient(txbIP.Text, int.Parse(txbPort.Text));
                receiveThread = new Thread(ReceiveSeatUpdates);
                receiveThread.IsBackground = true;
                receiveThread.Start();

                MessageBox.Show("Đã kết nối tới server!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        private void SeatButton_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txbName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên trước khi chọn ghế!");
                return;
            }

            Button btn = sender as Button;

            // Nếu đã có ghế được chọn, trả ghế cũ về trạng thái ban đầu
            if (selectedButton != null)
            {
                selectedButton.BackColor = Color.White;
            }

            // Lưu ghế hiện tại là ghế đang được chọn
            selectedButton = btn;
            selectedSeatNumber = (int)btn.Tag;

            // Đổi màu ghế sang trạng thái "đang chọn"
            btn.BackColor = Color.Cyan;
        }

        private void ReceiveSeatUpdates()
        {
            try
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];

                while (true)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        string seatUpdate = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        UpdateSeatStatus(seatUpdate);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Mất kết nối tới server!");
            }
        }

        private void UpdateSeatStatus(string seatUpdate)
        {
            string[] seatInfo = seatUpdate.Split(',');

            foreach (string info in seatInfo)
            {
                string[] parts = info.Split(':');
                if (parts.Length == 2 && int.TryParse(parts[0], out int seatNumber))
                {
                    string status = parts[1];

                    Invoke((Action)(() =>
                    {
                        if (seatButtons.ContainsKey(seatNumber))
                        {
                            // Cập nhật trạng thái ghế
                            if (status == "Trống")
                            {
                                seatButtons[seatNumber].BackColor = Color.White;
                                seatButtons[seatNumber].Enabled = true;
                                seatButtons[seatNumber].Text = seatNumber.ToString();
                            }
                            else
                            {
                                seatButtons[seatNumber].BackColor = Color.Gray;
                                seatButtons[seatNumber].Enabled = false;
                                seatButtons[seatNumber].Text = status;
                            }
                        }
                    }));
                }
            }
        }

        private void btnBookSeat_Click(object sender, EventArgs e)
        {
            if (client == null || !client.Connected)
            {
                MessageBox.Show("Vui lòng kết nối tới server trước khi đặt chỗ!");
                return;
            }

            if (selectedButton == null || selectedSeatNumber == -1)
            {
                MessageBox.Show("Vui lòng chọn ghế trước khi đặt chỗ!");
                return;
            }

            string clientName = txbName.Text.Trim();
            if (string.IsNullOrWhiteSpace(clientName))
            {
                MessageBox.Show("Vui lòng nhập tên trước khi đặt chỗ!");
                return;
            }

            // Gửi yêu cầu đặt chỗ tới server
            string message = $"{selectedSeatNumber}|{clientName}";
            byte[] data = Encoding.UTF8.GetBytes(message);
            client.GetStream().Write(data, 0, data.Length);

            // Đổi trạng thái ghế thành "đã đặt" và khóa lại
            selectedButton.BackColor = Color.Gray;
            selectedButton.Enabled = false;

            // Reset trạng thái sau khi đặt chỗ
            selectedButton = null;
            selectedSeatNumber = -1;
        }

        private void Client_Load(object sender, EventArgs e)
        {

        }

        private void Client_Load_1(object sender, EventArgs e)
        {

        }

        private void Client_Load_2(object sender, EventArgs e)
        {

        }
    }
}
