using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB2_Bai01
{
    public partial class Lab02_Bai02 : Form
    {
        public Lab02_Bai02()
        {
            InitializeComponent();
        }

        static string ConvertUnit(long bytes)
        {
            string[] sizes = new string[] { "Bytes", "KB", "MB", "GB" };
            double len = bytes;
            int idx = 0;
            while (len >= 1024 && idx < sizes.Length - 1)
            {
                idx++;
                len /= 1024;
            }
            return string.Format("{0:0.##} {1}", len, sizes[idx]);
        }

        private void btnRead_Click_1(object sender, EventArgs e)
        {
            string content = "", name, path;
            long fileSize = 0;
            long cnt_line = 0, cnt_word = 0, cnt_char = 0;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();

            FileStream fs = new FileStream(ofd.FileName, FileMode.Open);
            using (StreamReader sr = new StreamReader(fs))
            {
                // lấy nội dung 
                content = sr.ReadToEnd();

                // đặt con trỏ về đầu file
                fs.Seek(0, SeekOrigin.Begin);

                // lấy số dòng, số kí tự
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        cnt_line++;
                        cnt_char += line.Length;
                        // lấy số từ
                        char[] delimeters = new char[] { ' ', ',', '.', ';', ':', '!', '?' };
                        string[] words = line.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
                        cnt_word += words.Length;
                    }
                }

            }
            // lấy tên file
            name = ofd.SafeFileName;
            // lấy đường dẫn
            path = ofd.FileName;

            // lấy kích thước file
            FileInfo fi = new FileInfo(path);
            fileSize = fi.Length;
            // viet mot cai ham chuyen doi cho phu hop: byte, kb, mb, gb
            txbSize.Text = ConvertUnit(fileSize);

            rtbOutput.Text = content;
            txbFileName.Text = name;
            txbURI.Text = path;
            txbLine.Text = cnt_line.ToString();
            txbCharacter.Text = cnt_char.ToString();
            txbWord.Text = cnt_word.ToString();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
