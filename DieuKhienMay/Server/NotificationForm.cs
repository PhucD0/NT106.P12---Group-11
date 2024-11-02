using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class NotificationForm : Form
    {
        string name, IP;
        public NotificationForm(string name, string IP)
        {
            InitializeComponent();
            this.name = name;
            this.IP = IP;
        }

        private void NotificationForm_Load(object sender, EventArgs e)
        {
            notificationTempLabel.Text = "File sending to " + IP + " " + name + "...";
        }
    }
}
