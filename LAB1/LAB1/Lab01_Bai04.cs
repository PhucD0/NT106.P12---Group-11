using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            DateTime birthDate = dtpBirthday.Value;
            int day = birthDate.Day;
            int month = birthDate.Month;
            string zodiac = Get_Zodiac(day, month);

            txbOutput.Text = string.Format("Bạn thuộc cung: {0}", zodiac);
        }
        
        private string Get_Zodiac(int day, int month)
        {
            string res = "";
            switch(month)
            {
                case 1:
                    if (day <= 20)
                        res = "Ma Kết";
                    else
                        res = "Bảo Bình";
                    break;
                case 2:
                    if (day <= 19)
                        res = "Bảo Bình";
                    else
                        res = "Song Ngư";
                    break;
                case 3:
                    if (day <= 20)
                        res = "Song Ngư";
                    else
                        res = "Bạch Dương";
                    break;
                case 4:
                    if (day <= 20)
                        res = "Bạch Dương";
                    else
                        res = "Kim Ngưu";
                    break;
                case 5:
                    if (day <= 21)
                        res = "Kim Ngưu";
                    else
                        res = "Song Tử";
                    break;
                case 6:
                    if (day <= 21)
                        res = "Song Tử";
                    else
                        res = "Cự Giải";
                    break;
                case 7:
                    if (day <= 22)
                        res = "Cự Giải";
                    else
                        res = "Sư Tử";
                    break;
                case 8:
                    if (day <= 22)
                        res = "Sư Tử";
                    else
                        res = "Xử Nữ";
                    break;
                case 9:
                    if (day <= 23)
                        res = "Xử Nữ";
                    else
                        res = "Thiên Bình";
                    break;
                case 10:
                    if (day <= 23)
                        res = "Thiên Bình";
                    else
                        res = "Thần Nông";
                    break;
                case 11:
                    if (day <= 22)
                        res = "Thần Nông";
                    else
                        res = "Nhân Mã";
                    break;
                default:
                    if (day <= 21)
                        res = "Nhân Mã";
                    else
                        res = "Ma Kết";
                    break;
            }
            return res;
        }
    }
}
