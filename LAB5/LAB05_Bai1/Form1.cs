using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace LAB05_Bai1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string smtpHost = "smtp.gmail.com";
            int smtpPort = 587; 
            string username = txtFrom.Text; 
            string appPassword = "vngx lcia mudt vxbz"; 
            string toEmail = txtTo.Text;
            string subject = txtSubject.Text;
            string body = txtBody.Text;

            try
            {
                SmtpClient smtpClient = new SmtpClient(smtpHost, smtpPort)
                {
                    Credentials = new NetworkCredential(username, appPassword),
                    EnableSsl = true 
                };

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(username),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false 
                };
                mailMessage.To.Add(toEmail);

                smtpClient.Send(mailMessage);
                MessageBox.Show("Email đã được gửi thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gửi email thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
