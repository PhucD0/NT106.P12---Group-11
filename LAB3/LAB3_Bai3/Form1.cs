

namespace LAB3_Bai3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Server serverForm = new Server();
            serverForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Client clientForm = new Client();
            clientForm.Show();
        }
    }
}
