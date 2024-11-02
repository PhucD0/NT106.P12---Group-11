using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class FileTransfer : Form
    {
        public FileTransfer()
        {
            InitializeComponent();
        }

        private void notificationPanel_Paint(object sender, PaintEventArgs e)
        {
            notificationPanel.Visible = false;
        }
    }
}
