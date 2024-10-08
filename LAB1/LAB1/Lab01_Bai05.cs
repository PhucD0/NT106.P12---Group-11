using LAB1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Quanlithisinh
{
    public partial class Lab01_Bai05 : Form
    {
        private List<ThiSinh> danhSachThiSinh = new List<ThiSinh>();
        private int idCounter = 1;
        
        public Lab01_Bai05()
        {
            InitializeComponent();
            dgvThiSinh.AutoGenerateColumns = false;
            dgvThiSinh.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ID", HeaderText = "ID", Name = "ID" });
            dgvThiSinh.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "HovaTen", HeaderText = "Họ và Tên", Name = "HoTen" });
            dgvThiSinh.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "GioiTinh", HeaderText = "Giới Tính", Name = "GioiTinh" });
            dgvThiSinh.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DiemMon1", HeaderText = "Điểm Môn 1", Name = "DiemMon1" });
            dgvThiSinh.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DiemMon2", HeaderText = "Điểm Môn 2", Name = "DiemMon2" });
            dgvThiSinh.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DiemMon3", HeaderText = "Điểm Môn 3", Name = "DiemMon3" });
            dgvThiSinh.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DiemTrungBinh", HeaderText = "Điểm Trung Bình", Name = "DiemTrungBinh" });
            dgvThiSinh.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "XepLoai", HeaderText = "Xếp Loại", Name = "XepLoai" });
            // Thêm cột nút xóa
            DataGridViewButtonColumn btnXoaColumn = new DataGridViewButtonColumn();
            btnXoaColumn.HeaderText = "Xóa";
            btnXoaColumn.Name = "Xoa"; // Đặt tên cho cột
            btnXoaColumn.Text = "Xóa";
            btnXoaColumn.UseColumnTextForButtonValue = true;
            dgvThiSinh.Columns.Add(btnXoaColumn);

            // Đảm bảo sự kiện chỉ được đăng ký một lần
            dgvThiSinh.CellClick -= dgvThiSinh_CellClick;
            dgvThiSinh.CellClick += dgvThiSinh_CellClick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void pickGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textHovaTen_Validating(object sender, CancelEventArgs e)
        {
            if (textHovaTen.Text.Length > 30)
            {
                e.Cancel = true;
                errorProvider1.SetError(textHovaTen, "Họ và tên không được vượt quá 30 ký tự.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textHovaTen, null);
            }
        }

        private void pickGender_Validating(object sender, CancelEventArgs e)
        {
            if (pickGender.SelectedIndex == -1)
            {
                e.Cancel = true;
                errorProvider1.SetError(pickGender, "Vui lòng chọn giới tính.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(pickGender, null);
            }
        }
        private void ValidateDiem(System.Windows.Forms.TextBox textBox, CancelEventArgs e)
        {
            if (double.TryParse(textBox.Text, out double diem))
            {
                if (diem < 0 || diem > 10)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(textBox, "Điểm phải nằm trong khoảng từ 0 đến 10.");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(textBox, null);
                }
            }
            else
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox, "Vui lòng nhập số hợp lệ.");
            }
        }
        private void textDiem1_Validating(object sender, CancelEventArgs e)
        {
            ValidateDiem(sender as System.Windows.Forms.TextBox, e);
        }

        private void textDiem2_Validating(object sender, CancelEventArgs e)
        {
            ValidateDiem(sender as System.Windows.Forms.TextBox, e);
        }

        private void textDiem3_Validating(object sender, CancelEventArgs e)
        {
            ValidateDiem(sender as System.Windows.Forms.TextBox, e);
        }


        private void pressToSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textHovaTen.Text) || string.IsNullOrWhiteSpace(textDiem1.Text) || string.IsNullOrWhiteSpace(textDiem2.Text) || string.IsNullOrWhiteSpace(textDiem3.Text) || pickGender.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin thí sinh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string hoTen = textHovaTen.Text;
            string gioitinh = pickGender.SelectedItem.ToString();
            double diemMon1 = Math.Round(double.Parse(textDiem1.Text), 1);
            double diemMon2 = Math.Round(double.Parse(textDiem2.Text), 1);
            double diemMon3 = Math.Round(double.Parse(textDiem3.Text), 1);

            ThiSinh thiSinh = new ThiSinh
            {
                ID = $"TS{idCounter:D3}",
                HovaTen = hoTen,
                GioiTinh = gioitinh,
                DiemMon1 = diemMon1,
                DiemMon2 = diemMon2,
                DiemMon3 = diemMon3,
            };

            danhSachThiSinh.Add(thiSinh);
            idCounter++;

            CapNhatDanhSachThiSinh();
        }

        private void pressToDelete_Click(object sender, EventArgs e)
        {
            XoaTruongNhapLieu();
        }

        private void XoaTruongNhapLieu()
        {
            textHovaTen.Clear();
            pickGender.SelectedIndex = -1;
            textDiem1.Clear();
            textDiem2.Clear();
            textDiem3.Clear();
        }

        private void CapNhatDanhSachThiSinh()
        {
            dgvThiSinh.DataSource = null;
            dgvThiSinh.DataSource = danhSachThiSinh;
        }

        public class ThiSinh
        {
            public string ID { get; set; }
            public string HovaTen { get; set; }
            public string GioiTinh { get; set; }
            public double DiemMon1 { get; set; }
            public double DiemMon2 { get; set; }
            public double DiemMon3 { get; set; }
            public double DiemTrungBinh => Math.Round((DiemMon1 + DiemMon2 + DiemMon3) / 3, 2);
            public string XepLoai
            {
                get
                {
                    if (DiemTrungBinh >= 8 && DiemMon1 >= 6.5 && DiemMon2 >= 6.5 && DiemMon3 >= 6.5)
                        return "Giỏi";
                    if (DiemTrungBinh >= 6.5 && DiemMon1 >= 5 && DiemMon2 >= 5 && DiemMon3 >= 5)
                        return "Khá";
                    if (DiemTrungBinh >= 5 && DiemMon1 >= 3.5 && DiemMon2 >= 3.5 && DiemMon3 >= 3.5)
                        return "Trung Bình";
                    if (DiemTrungBinh >= 3.5 && DiemMon1 >= 2 && DiemMon2 >= 2 && DiemMon3 >= 2)
                        return "Yếu";
                    return "Kém";
                }
            }
        }


        private void dgvThiSinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            // Kiểm tra nếu cột được nhấn là cột nút xóa
            if (e.ColumnIndex >= 0 && e.ColumnIndex < dgvThiSinh.Columns.Count &&
                e.ColumnIndex == dgvThiSinh.Columns["Xoa"].Index && e.RowIndex >= 0 && e.RowIndex < dgvThiSinh.Rows.Count)
            {
                // Lấy hàng được chọn
                DataGridViewRow selectedRow = dgvThiSinh.Rows[e.RowIndex];

                // Kiểm tra giá trị của ô "ID"
                if (selectedRow.Cells["ID"].Value != null)
                {
                    string id = selectedRow.Cells["ID"].Value.ToString();
                    ThiSinh thiSinh = danhSachThiSinh.FirstOrDefault(ts => ts.ID == id);

                    if (thiSinh != null)
                    {
                        // Xóa thí sinh khỏi danh sách
                        danhSachThiSinh.Remove(thiSinh);

                        // Cập nhật DataGridView
                        dgvThiSinh.DataSource = null;
                        dgvThiSinh.DataSource = danhSachThiSinh;
                    }
                }
            }
        }


        private void btnThongKe_Click_1(object sender, EventArgs e)
        {
            int soLuongGioi = 0;
            int soLuongKha = 0;
            int soLuongTrungBinh = 0;
            int soLuongYeuKem = 0;
            // Thống kê số lượng thí sinh dự thi
            int soLuongThiSinh = danhSachThiSinh.Count;

            // Tên thí sinh có điểm trung bình cao nhất
            double diemTrungBinhCaoNhat = danhSachThiSinh.Max(ts => ts.DiemTrungBinh);
            var thiSinhDiemCaoNhat = danhSachThiSinh.Where(ts => ts.DiemTrungBinh == diemTrungBinhCaoNhat).ToList();
            string tenThiSinhDiemCaoNhat = thiSinhDiemCaoNhat.Count > 0 ? string.Join(", ", thiSinhDiemCaoNhat.Select(ts => ts.HovaTen)) : "Không có thí sinh";

            // Số lượng thí sinh xếp loại giỏi, khá, trung bình và yếu, kém
            foreach (DataGridViewRow row in dgvThiSinh.Rows)
            {
                if (row.Cells["XepLoai"].Value != null)
                {
                    string xepLoai = row.Cells["XepLoai"].Value.ToString();

                    // Đếm số lượng thí sinh theo xếp loại
                    switch (xepLoai)
                    {
                        case "Giỏi":
                            soLuongGioi++;
                            break;
                        case "Khá":
                            soLuongKha++;
                            break;
                        case "Trung Bình":
                            soLuongTrungBinh++;
                            break;
                        case "Yếu":
                        case "Kém":
                            soLuongYeuKem++;
                            break;
                    }
                }
            }

            // Hiển thị kết quả trong GroupBox
            lblSoLuongThiSinh.Text = $"Số lượng thí sinh dự thi: {soLuongThiSinh}";
            lblTenThiSinhDiemCaoNhat.Text = $"Tên thí sinh có điểm trung bình cao nhất: {tenThiSinhDiemCaoNhat}";
            lblSoLuongGioi.Text = $"Số lượng thí sinh xếp loại giỏi: {soLuongGioi}";
            lblSoLuongKha.Text = $"Số lượng thí sinh xếp loại khá: {soLuongKha}";
            lblSoLuongTrungBinh.Text = $"Số lượng thí sinh xếp loại trung bình: {soLuongTrungBinh}";
            lblSoLuongYeuKem.Text = $"Số lượng thí sinh xếp loại yếu, kém: {soLuongYeuKem}";
            
            // Hiện lên các label bị ẩn
            lblSoLuongThiSinh.Visible = true;
            lblTenThiSinhDiemCaoNhat.Visible = true;
            lblSoLuongGioi.Visible = true;
            lblSoLuongKha.Visible = true;
            lblSoLuongTrungBinh.Visible = true;
            lblSoLuongYeuKem.Visible = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var form1 = (Form1)Tag;
            form1.Show();
            Close();
        }
    }
    
}
