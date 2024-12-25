using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using MailKit.Net.Imap;
using MimeKit;

namespace LAB05_BAI4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string imapServer = mtbImapServer.Text;
            int imapPort = int.Parse(mtbImapPort.Text);
            string username = mtbEmail.Text;
            string password = mtbPass.Text;

            try
            {
                var client = new ImapClient();
                await client.ConnectAsync(imapServer, imapPort, true); // imap host, port, use ssl.
                await client.AuthenticateAsync(username, password); // gmail accout, app password.
                //client.Disconnect(true);

                MessageBox.Show("Đăng nhập thành công");

                this.Hide();

                using (CheckMail checkMailForm = new CheckMail(username, password, client))
                {
                    checkMailForm.ShowDialog();
                }

                this.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đăng nhập thất bại: {ex.Message}");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
