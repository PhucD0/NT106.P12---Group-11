namespace LAB3_Bai1
{
    public partial class Bai1 : Form
    {
        public Bai1()
        {
            InitializeComponent();
        }

        private void ClientButton_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            client.Show();
            this.Hide();
        }

        private void ServerButton_Click(object sender, EventArgs e)
        {
            Server server = new Server();
            server.Show();
            this.Hide();
        }

        private void Bai1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
