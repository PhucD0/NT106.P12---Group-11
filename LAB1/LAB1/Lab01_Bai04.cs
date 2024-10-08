using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace LAB1
{
    public partial class Lab01_Bai04 : Form
    {
        public Lab01_Bai04()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var form1 = (Form1)Tag;
            form1.Show();
            Close();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string zodiac = "";
            int day, month;
            string dateInput = txbInput.Text;
            DateTime dateOfBirth;

            bool isValid = DateTime.TryParseExact(dateInput, "dd/MM/yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out dateOfBirth);

            if (isValid)
            {
                day = dateOfBirth.Day;
                month = dateOfBirth.Month;

                zodiac = Get_Zodiac(day, month);

                txbOutput.Text = string.Format("Bạn thuộc cung: {0}", zodiac);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập ngày hợp lệ", "Lỗi định dạng",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //zodiac = "";
        }
        
        private string Get_Zodiac(int day, int month)
        {
            string res = "";
            switch(month)
            {
                case 1:
                    res = (day <= 20) ? "Ma Kết" : "Bảo Bình";
                    break;
                case 2:
                    res = (day <= 19) ? "Bảo Bình" : "Song Ngư";
                    break;
                case 3:
                    res = (day <= 20) ? "Song Ngư" : "Bạch Dương";
                    break;
                case 4:
                    res = (day <= 20) ? "Bạch Dương" : "Kim Ngưu";
                    break;
                case 5:
                    res = (day <= 21) ? "Kim Ngưu" : "Song Tử";
                    break;
                case 6:
                    res = (day <= 21) ? "Song Tử" : "Cự Giải";
                    break;
                case 7:
                    res = (day <= 22) ? "Cự Giải" : "Sư Tử";
                    break;
                case 8:
                    res = (day <= 22) ? "Sư Tử" : "Xử Nữ";
                    break;
                case 9:
                    res = (day <= 23) ? "Xử Nữ" : "Thiên Bình";
                    break;
                case 10:
                    res = (day <= 23) ? "Thiên Bình" : "Thần Nông";
                    break;
                case 11:
                    res = (day <= 22) ? "Thần Nông" : "Nhân Mã";
                    break;
                default:
                    res = (day <= 21) ? "Nhân Mã" : "Ma Kết";
                    break;

            }
            return res;
        }
    }
}
