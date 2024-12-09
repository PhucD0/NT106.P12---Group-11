using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB4_Bai3
{
    public partial class Form2 : Form
    {
        private string txtUrl;
        private string html;
        public Form2(string txtUrl, string html)
        {
            InitializeComponent();
            this.txtUrl = txtUrl;
            this.html = html;
            txtHtml.Text = html;
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            txtHtml.Width = this.ClientSize.Width - 28;
            txtHtml.Height = this.ClientSize.Height - 14;
        }
    }
}
