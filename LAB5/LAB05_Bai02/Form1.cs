using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit.Net.Imap;
using MailKit;
using MimeKit;

namespace LAB05_Bai02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string imapHost = "imap.gmail.com";
            int imapPort = 993; 
            string username = txtEmail.Text; 
            string appPassword = "vngx lcia mudt vxbz"; 

            try
            {
                using (var client = new ImapClient())
                {
                    client.Connect(imapHost, imapPort, true);
                    client.Authenticate(username, appPassword);

                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);

                    label4.Text = inbox.Count.ToString();
                    label4.Visible = true;


                    listViewEmails.Items.Clear();

                    int displayedEmails = Math.Min(10, inbox.Count);
                    for (int i = 0; i < displayedEmails; i++)
                    {
                        var message = inbox.GetMessage(i);

                        string subject = message.Subject ?? "(Không có tiêu đề)";
                        string from = message.From.ToString();
                        string date = message.Date.ToString("dd/MM/yyyy HH:mm:ss");

                        ListViewItem item = new ListViewItem(new[] { subject, from, date });
                        listViewEmails.Items.Add(item);
                    }

                    label6.Text = displayedEmails.ToString();
                    label6.Visible = true;
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy email: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
