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
    public partial class Lab01_Bai03 : Form
    {
        public Lab01_Bai03()
        {
            InitializeComponent();
        }

        // Mảng các từ để chuyển đổi số sang chữ
        static string[] ones = { "", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
        static string[] tens = { "", "", "hai mươi", "ba mươi", "bốn mươi", "năm mươi", "sáu mươi", "bảy mươi", "tám mươi", "chín mươi" };

        // Chuyển đổi số sang chữ
        static string ConvertToWords(long number)
        {
            if (number == 0) return "không";
            return ConvertGroup(number);
        }

        // Xử lý chia nhóm số
        static string ConvertGroup(long number)
        {
            string result = "";
            if (number >= 1000000000)
            {
                result += ConvertGroup(number / 1000000000) + " tỷ ";
                number %= 1000000000;
            }
            if (number >= 1000000)
            {
                result += ConvertGroup(number / 1000000) + " triệu ";
                number %= 1000000;
            }
            if (number >= 1000)
            {
                result += ConvertGroup(number / 1000) + " nghìn ";
                number %= 1000;
            }
            if (number >= 100)
            {
                result += ones[number / 100] + " trăm ";
                number %= 100;
            }
            if (number >= 20)
            {
                result += tens[number / 10] + " ";
                number %= 10;
            }
            if (number > 0)
            {
                result += ones[number];
            }
            return result.Trim();
        }

        private void button_Read_Click(object sender, EventArgs e)
        {
            if (long.TryParse(textBox_Input.Text, out long number) && number >= 0 && number <= 999999999999)
            {
                string resultInWords = ConvertToWords(number);  // Chuyển đổi số thành chữ
                textBox_Result.Text = resultInWords; // Hiển thị chữ trong Label
            }
            else
            {
                textBox_Result.Text = "Số không hợp lệ"; // Nếu nhập sai
            }
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            var form1 = (Form1)Tag;
            form1.Show();
            Close();
        }
    }
}
