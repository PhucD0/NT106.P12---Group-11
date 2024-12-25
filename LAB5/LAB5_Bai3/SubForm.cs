using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB3_Bai3
{
    public partial class SubForm : Form
    {
        public SubForm(string sender, string subject, string details)
        {
            InitializeComponent();

            labelFrom.Text = $"{sender}";
            labelSubject.Text = $"{subject}";
            textboxDetail.Text = details;
        }
    }
}
