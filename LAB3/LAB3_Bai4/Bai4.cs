using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB3_Bai4
{
    public partial class Bai4 : Form
    {
        public Bai4()
        {
            InitializeComponent();
        }

        private void ServerButton_Click(object sender, EventArgs e)
        {
            Server server = new Server();
            this.Hide();
            server.Show();
        }

        private void ClientButton_Click(object sender, EventArgs e)
        {
            Client client = new Client();   
            this.Hide();
            client.Show();
        }

        private void Bai4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
