using LAB05_Bai02;
using LAB05_Bai1;
using LAB3_Bai3;
using LAB05_BAI4;

namespace LAB5_Menu
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void buttonBai1_Click(object sender, EventArgs e)
        {
            LAB05_Bai1.Form1 bai1 = new LAB05_Bai1.Form1();
            bai1.ShowDialog();
        }

        private void buttonBai2_Click(object sender, EventArgs e)
        {
            LAB05_Bai02.Form1 bai2 = new LAB05_Bai02.Form1();
            bai2.ShowDialog();
        }

        private void buttonBai3_Click(object sender, EventArgs e)
        {
            LAB3_Bai3.MainForm bai3 = new LAB3_Bai3.MainForm(); 
            bai3.ShowDialog();
        }

        private void buttonBai4_Click(object sender, EventArgs e)
        {
            LAB05_BAI4.Form1 bai5 = new LAB05_BAI4.Form1();
            bai5.ShowDialog();
        }
    }
}
