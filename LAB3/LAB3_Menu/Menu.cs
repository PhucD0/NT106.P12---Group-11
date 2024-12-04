using LAB3_Bai1;
using LAB3_Bai2;
using LAB3_Bai3;
using LAB3_Bai4;
using LAB3_Bai5;
using Server;
using System.Net.Sockets;


namespace LAB3_Menu
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button_Bai1_Click(object sender, EventArgs e)
        {
            Bai1 bai1 = new Bai1();
            this.Hide();
            bai1.Show();
        }

        private void button_Bai2_Click(object sender, EventArgs e)
        {
            Bai2 bai2 = new Bai2();
            this.Hide();
            bai2.Show();
        }

        private void button_Bai3_Click(object sender, EventArgs e)
        {
            Bai3 bai3 = new Bai3();
            this.Hide();
            bai3.Show();
        }

        private void button_Bai4_Click(object sender, EventArgs e)
        {
            Bai4 bai4 = new Bai4();
            this.Hide();
            bai4.Show();
        }

        private void button_Bai5_Click(object sender, EventArgs e)
        {
            //Error adding Bai 5 to the menu
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
