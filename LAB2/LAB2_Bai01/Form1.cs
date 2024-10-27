using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB2_Bai01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBai1_Click(object sender, EventArgs e)
        {
            Lab02_Bai01 form2 = new Lab02_Bai01();
            form2.Tag = this;
            form2.Show(this);
            Hide();
        }
        private void btnBai2_Click_1(object sender, EventArgs e)
        {
            Lab02_Bai02 form3 = new Lab02_Bai02();
            form3.Tag = this;
            form3.Show(this);
            Hide();
        }

        private void btnBai3_Click(object sender, EventArgs e)
        {
            Lab02_Bai03 form4 = new Lab02_Bai03();
            form4.Tag = this;
            form4.Show(this);
            Hide();
        }

        private void btnBai4_Click(object sender, EventArgs e)
        {
            Lab02_Bai04 form5 = new Lab02_Bai04();
            form5.Tag = this;
            form5.Show(this);
            Hide();
        }

        private void btnBai5_Click_1(object sender, EventArgs e)
        {
            Lab02_Bai05 form6 = new Lab02_Bai05();
            form6.Tag = this;
            form6.Show(this);
            Hide();
        }

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
