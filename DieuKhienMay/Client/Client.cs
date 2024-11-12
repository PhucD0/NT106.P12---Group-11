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
using System.Text;
using System.Configuration;
using System.Net;
using static System.Windows.Forms.DataFormats;
using FileTransfer;
using static Client.Form1;
using Newtonsoft.Json;

namespace Client
{
    
    public partial class Client : Form
    {
        // KHAI BAO HERE
        private TcpClient? client;
        private int port;
        private List<(string ip, int port)> savedConnections = new List<(string, int)>();
        private const int maxConnectionAttempts = 5;

        private ListBox? listBox;


        public Client()
        {
            InitializeComponent();

            // Gọi sự kiện khi mouse hover vào textbox IP
            txbIP.MouseHover += TxtIP_MouseHover;

            CreateListBox();

            this.Click += (s, e) => HideValidIPs();
        }

        // Tạo listbox khi form được khởi tạo, và listbox bị ẩn
        private void CreateListBox()
        {
            listBox = new ListBox();
            // Thiết lập chế độ vẽ OwnerDraw
            listBox.DrawMode = DrawMode.OwnerDrawFixed;
            listBox.DrawItem += ListBox_DrawItem;
            listBox.Location = new Point(txbIP.Left, txbIP.Bottom + 5); // Đặt ListBox dưới TextBox txpIP
            listBox.Size = new Size(230, 100); // Đặt kích thước của ListBox
            listBox.Visible = false; // Ẩn ListBox
            this.Controls.Add(listBox); // Thêm ListBox vào form
        }


        // Hàm vẽ từng mục với padding và màu nền khi chọn
        private void ListBox_DrawItem(object? sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index >= 0)
            {
                // Chọn màu nền khi chọn và không chọn
                Color backgroundColor = (e.State & DrawItemState.Selected) == DrawItemState.Selected
                    ? Color.LightBlue : Color.White;

                using (Brush brush = new SolidBrush(backgroundColor))
                {
                    e.Graphics.FillRectangle(brush, e.Bounds);
                }

                // Chọn màu và vẽ văn bản
                e.Graphics.DrawString(listBox?.Items[e.Index].ToString(),
                    e.Font!, Brushes.Black, e.Bounds.Left + 5, e.Bounds.Top + 2);
            }

            e.DrawFocusRectangle();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectToServer();
        }

        /// <summary>
        /// Xu li ket noi
        /// </summary>

        // Ket noi den server
        private void ConnectToServer()
        {
            port = int.Parse(txbPort.Text);
            client = new TcpClient();

            try
            {
                client.Connect(txbIP.Text, port);
                MessageBox.Show("Connected to server!");

                // Mở Form2 để hiển thị màn hình server
                Form1 displayForm = new Form1(client);
                displayForm.Show();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Failed to connect: " + ex.Message);
            }
        }

        /// <summary>
        /// Gui file 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm main = new mainForm();
            main.Show();
        }
        
        /// <summary>
        /// Luu dia chi IP và port
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveIP_Click(object sender, EventArgs e)
        {
            string ip = txbIP.Text.Trim();
            string portText = txbPort.Text.Trim();

            if (IsValidIP(ip) && int.TryParse(portText, out int port) && IsValidPort(port))
            {
                savedConnections.Add((ip, port));
                MessageBox.Show("Địa chỉ IP và Port đã được lưu.");
            }
            else
            {
                MessageBox.Show("Địa chỉ IP hoặc Port không hợp lệ.");
            }
        }

        // Sự kiện rê chuột vào textbox IP
        private void TxtIP_MouseHover(object? sender, EventArgs e)
        {
            listBox?.Items.Clear();
            listBox?.BringToFront();

            foreach (var connection in savedConnections)
            {
                listBox?.Items.Add($"{connection.ip}:{connection.port}");
            }

            if (listBox?.Items.Count > 0)
            {
                listBox.Visible = true;
                listBox.MouseClick += listBox_MouseClick_1;

            }
            else
            {
                HideValidIPs();
            }
        }

        // Kiểm tra tính hợp lệ của IP và port
        private bool IsValidIP(string ip)
        {
            return IPAddress.TryParse(ip, out _);
        }

        private bool IsValidPort(int port)
        {
            return port > 0 && port <= 65535;
        }

        // Sự kiện click vào listbox để chọn IP và port
        private void listBox_MouseClick_1(object? sender, MouseEventArgs e)
        {
            if (listBox?.SelectedItem != null)
            {
                string? selected = listBox.SelectedItem.ToString();
                
                if (!string.IsNullOrEmpty(selected))
                {
                    var parts = selected.Split(':');

                    if (parts.Length == 2)
                    {
                        string ip = parts[0];
                        string port = parts[1];

                        listBox.Visible = false;
                    }
                    else
                    {
                        // Handle the case where the format is not as expected (e.g., missing port or IP)
                        Console.WriteLine("Invalid format. Expected 'IP:port'.");
                    }
                }
                else
                {
                    // Handle the case where 'selected' is null or empty
                    Console.WriteLine("Input string is null or empty.");
                }
            }
        }

        private void HideValidIPs()
        {
            if (listBox != null)
            {
                listBox.Visible = false;
            }
        }
    }
}
