namespace Server
{
    public partial class Server : Form
    {
        // KHAI BAO HERE

        public Server()
        {
            InitializeComponent();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopListening();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            StartListening();
        }

        // Bat dau ket noi
        private void StartListening()
        {

        }

        // Ket thuc ket noi
        private void StopListening()
        {

        }

        // Xu li du lieu 


        // Gui anh
        private void SendImage()
        {

        }

        // Cap nhat trang thai
        private void UpdateStatus(string message)
        {

        }
    }
}
