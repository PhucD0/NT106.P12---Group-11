using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB2_Bai01
{
    
    public partial class Lab02_Bai04 : Form
    {
        [Serializable]
        public class SinhVien
        {
            public string HoTen { get; set; }
            public int MSSV { get; set; }
            public string DienThoai { get; set; }
            public float DiemMon1 { get; set; }
            public float DiemMon2 { get; set; }
            public float DiemMon3 { get; set; }
            public float DiemTrungBinh { get; set; }

            public void TinhDiemTrungBinh()
            {
                DiemTrungBinh = (DiemMon1 + DiemMon2 + DiemMon3) / 3;
            }

            public bool KiemTraDienThoai()
            {
                return DienThoai.Length == 10 && DienThoai.StartsWith("0");
            }

            public bool KiemTraMSSV()
            {
                return MSSV.ToString().Length == 8;
            }
        }
        private List<SinhVien> danhSachSinhVien = new List<SinhVien>();
        private int soPhanTuTrenTrang = 1;
        private int trangHienTai = 1;
        private int indexSinhVienHienTai = 0;
        public Lab02_Bai04()
        {
            InitializeComponent();
            //HienThiTrang(trangHienTai);
        }

        private void Lab02_Bai04_Load(object sender, EventArgs e)
        {

        }



        private void HienThiDanhSach()
        {
            richTextBox1.Clear(); // Xóa nội dung hiện có

            // Tạo một chuỗi để lưu trữ nội dung sẽ hiển thị
            string noiDung = "";


            // Duyệt qua danh sách sinh viên và thêm vào chuỗi
            foreach (SinhVien sv in danhSachSinhVien)
            {
                noiDung += $"{sv.HoTen}\n{sv.MSSV}\n{sv.DienThoai}\n{sv.DiemMon1}\n{sv.DiemMon2}\n{sv.DiemMon3}\n{sv.DiemTrungBinh}\n\n";
            }

            // Gán nội dung vào RichTextBox
            richTextBox1.Text = noiDung;
        }


        private void HienThiSinhVien(int index)
        {
            if (index >= 0 && index < danhSachSinhVien.Count)
            {
                SinhVien sv = danhSachSinhVien[index];
                coutHoten.Text = sv.HoTen;
                coutMSSV.Text = sv.MSSV.ToString();
                coutSDT.Text = sv.DienThoai;
                coutDiem1.Text = sv.DiemMon1.ToString();
                coutDiem2.Text = sv.DiemMon2.ToString();
                coutDiem3.Text = sv.DiemMon3.ToString();
                coutDTB.Text = sv.DiemTrungBinh.ToString();
            }
        }


        private void HienThiTrang(int trang)
        {
            int soTrang = (danhSachSinhVien.Count + soPhanTuTrenTrang - 1) / soPhanTuTrenTrang;

            // Đảm bảo rằng trang nằm trong khoảng hợp lệ
            trangHienTai = Math.Max(1, Math.Min(trang, soTrang));

            // Hiển thị chỉ số trang trên Label
            lblPage.Visible = true;
            lblPage.Text = $"Trang {trangHienTai}/{soTrang}";

            // Cập nhật `indexSinhVienHienTai` dựa trên trang hiện tại
            indexSinhVienHienTai = (trangHienTai - 1) * soPhanTuTrenTrang;

            // Hiển thị sinh viên tại `indexSinhVienHienTai`
            HienThiSinhVien(indexSinhVienHienTai);


        }

     

        private void coutMSSV_TextChanged(object sender, EventArgs e)
        {

        }

        private void btntoWrite_Click_1(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("input4.txt", FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, danhSachSinhVien);
            }
            MessageBox.Show("Lưu danh sách sinh viên thành công.");
        }

        private void btntoRead_Click_1(object sender, EventArgs e)
        {
            if (File.Exists("input4.txt"))
            {
                using (FileStream fs = new FileStream("input4.txt", FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    danhSachSinhVien = (List<SinhVien>)formatter.Deserialize(fs);
                }

                // Tính lại điểm trung bình cho từng sinh viên
                foreach (SinhVien sv in danhSachSinhVien)
                {
                    sv.TinhDiemTrungBinh();
                }

                // Ghi dữ liệu vào file output
                using (FileStream fs = new FileStream("output4.txt", FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, danhSachSinhVien);
                }

                // Hiển thị danh sách sinh viên 
                HienThiDanhSach();
                HienThiTrang(trangHienTai);

                MessageBox.Show("Đọc danh sách sinh viên từ file thành công.");
            }
            else
            {
                MessageBox.Show("File không tồn tại.");
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            SinhVien sv = new SinhVien
            {
                HoTen = txtTen.Text,
                MSSV = int.Parse(txtMSSV.Text),
                DienThoai = txtSDT.Text,
                DiemMon1 = float.Parse(txtDiem1.Text),
                DiemMon2 = float.Parse(txtDiem2.Text),
                DiemMon3 = float.Parse(txtDiem3.Text)
            };

            if (sv.KiemTraMSSV() && sv.KiemTraDienThoai() && sv.DiemMon1 >= 0 && sv.DiemMon1 <= 10 &&
                sv.DiemMon2 >= 0 && sv.DiemMon2 <= 10 && sv.DiemMon3 >= 0 && sv.DiemMon3 <= 10)
            {
                sv.TinhDiemTrungBinh();
                danhSachSinhVien.Add(sv);
                //HienThiTrang(trangHienTai);
            }
            else
            {
                MessageBox.Show("Thông tin không hợp lệ. Vui lòng kiểm tra lại.");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var form1 = (Form1)Tag;
            form1.Show();
            Close();
        }

        private void btnPre_Click_1(object sender, EventArgs e)
        {
            if (trangHienTai > 1)
            {
                HienThiTrang(--trangHienTai);
            }
        }

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            int soTrang = (danhSachSinhVien.Count + soPhanTuTrenTrang - 1) / soPhanTuTrenTrang;
            if (trangHienTai < soTrang)
            {
                HienThiTrang(++trangHienTai);
            }
        }

        private void Lab02_Bai04_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
