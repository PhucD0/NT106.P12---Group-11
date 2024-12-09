using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB4_Bai3
{
    public partial class Form3 : Form
    {
        private List<string> resourceUrls;
        public Form3(List<string> resourceUrls)
        {
            InitializeComponent();
            this.resourceUrls = resourceUrls;
            // Hiển thị danh sách tài nguyên vào ListBox hoặc DataGridView
            foreach (var url in resourceUrls)
            {
                listBox1.Items.Add(url);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedResource = listBox1.SelectedItem.ToString();
                DownloadResource(selectedResource);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tài nguyên để tải về.");
            }
        }
        private string GetFileExtensionFromURL(string url)
        {
            // Lấy phần mở rộng từ URL (bao gồm dấu chấm)
            string extension = Path.GetExtension(url);

            // Nếu không tìm thấy phần mở rộng trong URL, trả về .txt
            if (string.IsNullOrEmpty(extension))
            {
                return ".txt";
            }
            // Nếu phần mở rộng có chứa "?", có thể URL chứa tham số, loại bỏ phần đó
            if (extension.Contains("?"))
            {
                extension = extension.Split('?')[0];
            }

            // Trả về phần mở rộng
            return extension.ToLower();
        }

        private void DownloadResource(string url)
        {
            string fileExtension = GetFileExtensionFromURL(url);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = $"{fileExtension.ToUpper()} Files (*{fileExtension})|*{fileExtension}|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFile(url, saveFileDialog.FileName);
                    MessageBox.Show("Tải thành công!");
                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void Form3_Resize(object sender, EventArgs e)
        {
            listBox1.Width = this.ClientSize.Width - 24;
            listBox1.Height = this.ClientSize.Height - 84 - 12;
        }
    }
}
