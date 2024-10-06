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
                        res = "Cung Ma Kết";
                    else
                        res = "Cung Bảo Bình";
                    break;
                case 2:
                    if (day <= 19)
                        res = "Cung Bảo Bình";
                    else
                        res = "Cung Song Ngư";
                    break;
                case 3:
                    if (day <= 20)
                        res = "Cung Song Ngư";
                    else
                        res = "Cung Bạch Dương";
                    break;
                case 4:
                    if (day <= 20)
                        res = "Cung Bạch Dương";
                    else
                        res = "Cung Kim Ngưu";
                    break;
                case 5:
                    if (day <= 21)
                        res = "Cung Kim Ngưu";
                    else
                        res = "Cung Song Tử";
                    break;
                case 6:
                    if (day <= 21)
                        res = "Cung Song Tử";
                    else
                        res = "Cung Cự Giải";
                    break;
                case 7:
                    if (day <= 22)
                        res = "Cung Cự Giải";
                    else
                        res = "Cung Sư Tử";
                    break;
                case 8:
                    if (day <= 22)
                        res = "Cung Sư Tử";
                    else
                        res = "Cung Xử Nữ";
                    break;
                case 9:
                    if (day <= 23)
                        res = "Cung Xử Nữ";
                    else
                        res = "Cung Thiên Bình";
                    break;
                case 10:
                    if (day <= 23)
                        res = "Cung Thiên Bình";
                    else
                        res = "Cung Thần Nông";
                    break;
                case 11:
                    if (day <= 22)
                        res = "Cung Thần Nông";
                    else
                        res = "Cung Nhân Mã";
                    break;
                default:
                    if (day <= 21)
                        res = "Cung Nhân Mã";
                    else
                        res = "Cung Ma Kết";
                    break;
            }
            return res;
        }
    }
}
