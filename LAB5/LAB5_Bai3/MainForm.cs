using MailKit.Net.Pop3;
using MimeKit;
using System;
using System.Windows.Forms;

namespace LAB3_Bai3
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            listViewMails.ItemActivate += listViewMails_ItemActivate;
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both fields!");
                return;
            }

            try
            {
                using (var client = new Pop3Client())
                {
                    await client.ConnectAsync("pop.gmail.com", 995, true);
                    await client.AuthenticateAsync(email, password);
                    MessageBox.Show("Successfully logged in!");
                    int messageCount = client.Count;

                    listViewMails.Items.Clear();
                    for (int i = 0; i < messageCount; i++)
                    {
                        var message = await client.GetMessageAsync(i);

                        var item = new ListViewItem(new[]
                        {
                            message.From.ToString(),
                            message.Subject ?? "(No Subject)",
                            message.Date.DateTime.ToString("g")
                        });

                        item.Tag = message;
                        listViewMails.Items.Add(item);
                    }
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listViewMails_ItemActivate(object sender, EventArgs e)
        {
            if (listViewMails.SelectedItems.Count > 0)
            {
                var selectedItem = listViewMails.SelectedItems[0];
                var message = selectedItem.Tag as MimeMessage;

                if (message != null)
                {
                    var subForm = new SubForm(
                        message.From.ToString(),
                        message.Subject ?? "(No Subject)",
                        message.TextBody ?? "(No Content)"
                    );
                    subForm.ShowDialog();
                }
            }
        }
    }
}