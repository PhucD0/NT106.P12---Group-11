using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Xml.Linq;


namespace LAB05_BAI4
{
    public partial class SendMail : Form
    {
        private string _username;
        private string _password;
        private string _server;
        private int _port;

        public SendMail(string username, string password, string server, int port)
        {
            InitializeComponent();
            _username = username;
            _password = password;
            _server = server;
            _port = port;
            txbUser.Text = username;
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            var client = new SmtpClient();
            await client.ConnectAsync(_server, _port, true); // smtp host, port, use ssl.
            await client.AuthenticateAsync(_username, _password); // gmail account, app password

            var message = new MimeMessage();
            string name = txbName.Text;
            string from = txbUser.Text;
            string to = txbTo.Text;
            string subject = txbSubject.Text;
            string body = rtbBody.Text;
            message.From.Add(new MailboxAddress(name, from));
            message.To.Add(new MailboxAddress("", to));
            message.Subject = subject;
            var bodyBuilder = new BodyBuilder
            {
                TextBody = body // Gửi ở dạng plain text
            };

            // Thêm file đính kèm (nếu có)
            if (!string.IsNullOrWhiteSpace(txbAttachment.Text)) // `txbAttachment` là TextBox hiển thị đường dẫn file
            {
                bodyBuilder.Attachments.Add(txbAttachment.Text);
            }

            // Gắn nội dung vào email
            message.Body = bodyBuilder.ToMessageBody();
            await client.SendAsync(message);
            await client.DisconnectAsync(true); // Ngắt kết nối

            MessageBox.Show("Gửi email thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close(); // Đóng form sau khi gửi
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All Files (*.*)|*.*";
                openFileDialog.Title = "Chọn tệp đính kèm";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txbAttachment.Text = openFileDialog.FileName; // Hiển thị đường dẫn file trong TextBox
                }
            }
        }
    }
}
