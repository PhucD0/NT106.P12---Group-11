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
    public partial class Lab01_Bai01 : Form
    {
        public Lab01_Bai01()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var form1 = (Form1)Tag;
            form1.Show();
            Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            double num1, num2, num3;
            try
            {
                num1 = double.Parse(txtInput1.Text);
                num2 = double.Parse(txtInput2.Text);
                num3 = double.Parse(txtInput3.Text);
                txtMaxNum.Text = (Math.Max(Math.Max(num1, num2), num3)).ToString();
                txtMinNum.Text = (Math.Min(Math.Min(num1, num2), num3)).ToString();
            }
            catch (FormatException) 
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);    
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtInput1.Clear();
            txtInput2.Clear();
            txtInput3.Clear();
            txtMaxNum.Clear();
            txtMinNum.Clear();
        }
    }
}
