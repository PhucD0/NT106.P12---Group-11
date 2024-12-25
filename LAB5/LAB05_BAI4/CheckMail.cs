using MailKit;
using MailKit.Net.Imap;
using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB05_BAI4
{
    public partial class CheckMail : Form
    {
        private string _username;
        private string _password;
        private string _server;
        private int _port;
        private ImapClient _client;

        public CheckMail(string username, string password, ImapClient client)
        {
            InitializeComponent();
            _username = username;
            _password = password;
            _server = mtbImapServer.Text;
            _port = int.Parse(mtbImapPort.Text);
            _client = client;
            LoadForm();
        }

        private void LoadForm()
        {
            mtbEmail.Text = _username;
            mtbEmail.ReadOnly = true;
            mtbPass.Text = _password;
            mtbPass.ReadOnly = true;   
            mtbImapServer.ReadOnly = true;
            mtbImapPort.ReadOnly = true;
            mtbSMTPServer.ReadOnly = true;
            mtbSMTPPort.ReadOnly = true;


            var inbox = _client.Inbox;
            inbox.Open(FolderAccess.ReadOnly);

            lvEmails.Items.Clear();

            // xử lý để hiển thị email lên listview: message.Subject; message.From; message.Date
            for (int i = 0; i < 5; i++)
            {
                var message = inbox.GetMessage(i);

                ListViewItem item = new ListViewItem((i+1).ToString());
                item.SubItems.Add(message.From.ToString());
                item.SubItems.Add(message.Subject);
                item.SubItems.Add(message.Date.ToString());
                item.Tag = message;
                lvEmails.Items.Add(item);
            }
            inbox.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (_client != null && _client.IsConnected)
            {
                _client.Disconnect(true); // Ngắt kết nối IMAP
                _client.Dispose();       // Giải phóng tài nguyên
            }

            this.Close();
        }

        private void lvEmails_DoubleClick(object sender, EventArgs e)
        {
            if(lvEmails.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvEmails.SelectedItems[0];
                MimeMessage email = (MimeMessage)selectedItem.Tag; // Lấy email từ Tag

                // Mở form đọc thư
                using (ReadMail readMailForm = new ReadMail(email))
                {
                    readMailForm.ShowDialog();
                }
            }
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            string serverSMTP = mtbSMTPServer.Text;
            int smtpPort = int.Parse(mtbSMTPPort.Text);
            using (SendMail sendMail = new SendMail(_username, _password, serverSMTP, smtpPort))
            {
                sendMail.ShowDialog();
            }
        }
    }
}
