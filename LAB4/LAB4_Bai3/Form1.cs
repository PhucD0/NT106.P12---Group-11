using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;
using HtmlAgilityPack;
using System.Text.Json;
using System.Web;

namespace LAB4_Bai3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            webView.Source = new Uri(txtUrl.Text);
        }



        private void btnDownFiles_Click(object sender, EventArgs e)
        {
            string currentUrl = webView.Source.ToString();
            if (string.IsNullOrEmpty(currentUrl))
            {
                MessageBox.Show("Vui lòng nhập URL trước.");
                return;
            }
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "All Files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile(currentUrl, saveFileDialog.FileName);
                        MessageBox.Show("Tải thành công!");
                    }
                }
            }
        }

        private void btnDownResources_Click(object sender, EventArgs e)
        {
            string currentUrl = webView.Source.ToString();
            if (string.IsNullOrEmpty(currentUrl))
            {
                MessageBox.Show("Vui lòng nhập URL trước.");
                return;
            }
            string html = GetHTML(txtUrl.Text);
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            List<string> resourceUrls = GetResourceUrls(doc);
            var form3 = new Form3(resourceUrls);
            form3.Show();

        }

        // Phương thức trích xuất các URL tài nguyên (hình ảnh, css, js)
        private List<string> GetResourceUrls(HtmlAgilityPack.HtmlDocument doc)
        {
            List<string> resourceUrls = new List<string>();
            string GetBaseDomain(string url)
            {
                try
                {
                    Uri uri = new Uri(url);
                    // Combine scheme and host to get the base domain
                    return $"{uri.Scheme}://{uri.Host}/";
                }
                catch (UriFormatException)
                {
                    // Return the original URL if it cannot be parsed
                    return url;
                }
            }
            string baseUrl = GetBaseDomain(txtUrl.Text);


            // Helper function to convert relative URLs to absolute URLs
            string MakeAbsoluteUrl(string url, string baseUrl)
            {
                if (string.IsNullOrEmpty(baseUrl))
                {
                    return url; // If no base URL is provided, return the URL as is
                }

                try
                {
                    Uri baseUri = new Uri(baseUrl, UriKind.Absolute);
                    Uri absoluteUri = new Uri(baseUri, url);
                    return absoluteUri.ToString();
                }
                catch (UriFormatException)
                {
                    return url; // Return the original URL if conversion fails
                }
            }


            // Trích xuất các URL từ thẻ <img>, thuộc tính src
            var imgTags = doc.DocumentNode.SelectNodes("//img[@src]");
            if (imgTags != null)
            {
                foreach (var tag in imgTags)
                {
                    string url = tag.GetAttributeValue("src", string.Empty);
                    if (!string.IsNullOrEmpty(url))
                    {
                        resourceUrls.Add(MakeAbsoluteUrl(url, baseUrl));
                    }
                }
            }

            // Trích xuất các URL từ thẻ <script>, thuộc tính src
            var scriptTags = doc.DocumentNode.SelectNodes("//script[@src]");
            if (scriptTags != null)
            {
                foreach (var tag in scriptTags)
                {
                    string url = tag.GetAttributeValue("src", string.Empty);
                    if (!string.IsNullOrEmpty(url))
                    {
                        resourceUrls.Add(MakeAbsoluteUrl(url, baseUrl));
                    }
                }
            }

            // Trích xuất các URL từ thẻ <link>, thuộc tính href (dùng cho CSS hoặc icon)
            var linkTags = doc.DocumentNode.SelectNodes("//link[@href]");
            if (linkTags != null)
            {
                foreach (var tag in linkTags)
                {
                    string url = tag.GetAttributeValue("href", string.Empty);
                    if (!string.IsNullOrEmpty(url))
                    {
                        resourceUrls.Add(MakeAbsoluteUrl(url, baseUrl));
                    }
                }
            }

            // Loại bỏ các URL trùng lặp và trả về danh sách
            return resourceUrls.Distinct().ToList();
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            int marginX = 6;
            int marginY = 15;
            webView.Width = this.ClientSize.Width - 24;
            webView.Height = this.ClientSize.Height - 101 - 12;
            btnReload.Left = this.ClientSize.Width - 6 - btnLoad.Width;
            txtUrl.Left = btnLoad.Left + btnLoad.Width + marginX;
            txtUrl.Width = this.ClientSize.Width - btnReload.Width - 12 - txtUrl.Left;
            btnDownResources.Left = this.ClientSize.Width - 12 - btnDownResources.Width;
            btnDownFiles.Left = this.ClientSize.Width - btnDownResources.Width - 6 - 12 - btnDownFiles.Width;
            btnViewsources.Left = btnDownFiles.Left - 6 - btnViewsources.Width;
        }

        private string GetHTML(string url)
        {
            WebRequest rq = WebRequest.Create(url);
            WebResponse rp = rq.GetResponse();
            Stream stream = rp.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream))
            {
                string html = reader.ReadToEnd();
                return html;
            }
        }

        private void btnViewsources_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text;
            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Vui lòng nhập URL trước.");
                return;
            }
            string html = GetHTML(url);
            var viewSourceForm = new Form2(url, html);
            viewSourceForm.Show();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            webView.Reload();
        }
    }
}
