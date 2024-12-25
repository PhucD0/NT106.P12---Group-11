using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB05_BAI4
{
    public partial class ReadMail : Form
    {
        private MimeMessage _email;

        public ReadMail(MimeMessage email)
        {
            InitializeComponent();
            _email = email;
            DisplayEmail(email);
        }

        private void DisplayEmail(MimeMessage email)
        {
            lbSubject.Text = _email.Subject;
            lbFrom.Text = _email.From.ToString();
            rtbBody.Text = _email.TextBody;
        }
    }
}
