using System.Net;
using System.IO;
using System.Security.Policy;

namespace LAB4_Bai2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            string url = txbUrl.Text;
            string fileurl = txbFileUrl.Text;

            WebClient myClient = new WebClient();
            using (Stream response = myClient.OpenRead(url))
            {
                using (StreamReader reader = new StreamReader(response))
                {
                    string data = reader.ReadToEnd();
                    rtbOutput.Text = data;
                }
            }

            myClient.DownloadFile(url, fileurl);
        }
    }
}
