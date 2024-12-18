using System.Net;
using System.IO;
using System.Security.Policy;

namespace LAB4_Bai1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            string url = txbUrl.Text;

            string HTMLtext = getHTML(url);

            rtbOutput.Text = HTMLtext;
        }

        private string getHTML(string szURL)
        {
            string responseFromServer = "";

            WebRequest request = WebRequest.Create(szURL);

            using (WebResponse response = request.GetResponse())
            {
                using (Stream dataStream = response.GetResponseStream())
                {

                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        responseFromServer = reader.ReadToEnd();
                    }
                }
            }

            return responseFromServer;
        }
    }
}
