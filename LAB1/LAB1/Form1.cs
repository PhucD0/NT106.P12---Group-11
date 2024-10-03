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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Application.Run(new Lab01_Bai01());
        }

        private void btnBai1_Click(object sender, EventArgs e)
        {
            Lab01_Bai01 form2 = new Lab01_Bai01();
            form2.Tag = this;
            form2.Show(this);
            Hide();
        }
        private void btnBai2_Click(object sender, EventArgs e)
        {
            Lab01_Bai02 form3 = new Lab01_Bai02();
            form3.Tag = this;
            form3.Show(this);
            Hide();
        }

        private void btnBai3_Click(object sender, EventArgs e)
        {
            Lab01_Bai03 form4 = new Lab01_Bai03();
            form4.Tag = this;
            form4.Show(this);
            Hide();
        }

        private void btnBai4_Click(object sender, EventArgs e)
        {
            Lab01_Bai04 form5 = new Lab01_Bai04();
            form5.Tag = this;
            form5.Show(this);
            Hide();
        }

        private void btnBai5_Click(object sender, EventArgs e)
        {
            Lab01_Bai05 form6 = new Lab01_Bai05();
            form6.Tag = this;
            form6.Show(this);
            Hide();
        }
    }
}
