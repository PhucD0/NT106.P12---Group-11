using LAB4_Bai1;
using LAB4_Bai2;
using LAB4_Bai3;
using LAB4_Bai4;
using LAB4_Bai5;

namespace LAB4_Menu
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void buttonBai1_Click(object sender, EventArgs e)
        {
            LAB4_Bai1.Form1 bai1 = new LAB4_Bai1.Form1();
            this.Hide();
            bai1.Show();
        }

        private void buttonBai2_Click(object sender, EventArgs e)
        {
            LAB4_Bai2.Form1 bai2 = new LAB4_Bai2.Form1();
            this.Hide();
            bai2.Show();
        }

        private void buttonBai3_Click(object sender, EventArgs e)
        {
            LAB4_Bai3.Form1 bai3 = new LAB4_Bai3.Form1();
            this.Hide();
            bai3.Show();
        }

        private void buttonBai4_Click(object sender, EventArgs e)
        {
            LAB4_Bai4.Login bai4 = new LAB4_Bai4.Login();
            this.Hide();
            bai4.Show();
        }

        private void buttonBai5_Click(object sender, EventArgs e)
        {
            LAB4_Bai5.Bai5 bai5 = new LAB4_Bai5.Bai5();
            this.Hide();
            bai5.Show();
        }
    }
}
