using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileTransfer
{
    public partial class NotificationForm : Form
    {
        string? name;
        string? IP;
        public NotificationForm(string? name, string? iP)
        {
            InitializeComponent();
            this.name = name;
            IP = iP;
        }

        private void NotificationForm_Load(object sender, EventArgs e)
        {
            notificationTempLabel.Text = "File sending to " + IP + " " + name + "...";
        }
    }
}
