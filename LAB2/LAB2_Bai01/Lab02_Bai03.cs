using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB2_Bai01
{
    public partial class Lab02_Bai03 : Form
    {
        public Lab02_Bai03()
        {
            InitializeComponent();
        }

        string filePath;

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filePath = ofd.FileName;
                    rtbInput.Text = File.ReadAllText(filePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An orror has occurred: " + ex.Message, "Error");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (rtbInput.Text == "" && rtbOutput.Text == "")
            {
                MessageBox.Show("Nothing to clear", "Notification");
                return;
            }
            rtbInput.Text = null;
            rtbOutput.Text = null;
        }

        private void btnWriteFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (rtbInput.Text == "")
                {
                    MessageBox.Show("Input is empty.", "Notification");
                    return;
                }
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.ShowDialog();
                using (StreamWriter sr = new StreamWriter(ofd.FileName))
                {
                    sr.WriteLine(rtbOutput.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An orror has occurred: " + ex.Message, "Error");
            }
        }

        private bool isOperator(char c)
        {
            return (c == '+' || c == '-' || c == '*' || c == '/');
        }

        private int priority(char c)
        {
            if (c == '+' || c == '-') return 1;
            if (c == '*' || c == '/') return 2;
            return 0;
        }

        private Queue<string> infix_to_postfix(string st)
        {
            Stack<char> s = new Stack<char>();
            Queue<string> q = new Queue<string>();
            for (int i = 0; i < st.Length; i++)
            {
                char ch = st[i];
                // TH kí tự số
                if (char.IsDigit(ch))
                {
                    string number = ch.ToString();
                    while (i + 1 < st.Length && (char.IsDigit(st[i + 1]) || st[i + 1] == '.'))
                    {
                        number += st[++i];

                    }
                    //if (number.StartsWith(".")) number = "0" + number;
                    q.Enqueue(number);
                }

                // TH dấu mở ngoặc
                else if (ch == '(')
                    s.Push(ch);

                // TH dấu đóng ngoặc
                else if (ch == ')')
                {
                    while (s.Peek() != '(') // Đưa các toán tử vào queue cho đến khi gặp '('
                    {
                        q.Enqueue(s.Pop().ToString());
                    }
                    s.Pop(); // Bỏ dấu '(' khỏi stack
                }

                // TH toán tử
                else if (isOperator(ch))
                {
                    // Stack rỗng
                    if (s.Count == 0)
                        s.Push(ch);
                    // Stack đang có ptu
                    else
                    {
                        // Phần tử đầu stack không là toán tử
                        if (!isOperator(s.Peek()))
                            s.Push(ch);
                        // Phần tử đầu stack là toán tử
                        else
                        {
                            // Toán tử đầu stack có độ ưu tiên nhỏ hơn x
                            int p1 = priority(s.Peek());
                            int p2 = priority(ch);
                            if (p1 < p2)
                                s.Push(ch);
                            // Toán tử đầu stack có độ ưu tiên lớn hơn hoặc bằng x
                            else
                            {
                                while ((s.Count > 0) && (isOperator(s.Peek())) && priority(s.Peek()) >= p2)
                                {
                                    q.Enqueue(s.Pop().ToString());
                                }
                                s.Push(ch);
                            }
                        }
                    }
                }
            }
            // Khi duyet xong, stack con ptu thi day het qua queue
            while (s.Count > 0)
            {
                q.Enqueue(s.Peek().ToString());
                s.Pop();
            }
            return q;
        }

        private double Calculate(double p1, double p2, char c)
        {
            double res = 0;
            switch (c)
            {
                case '+':
                    res = p2 + p1;
                    break;
                case '-':
                    res = p2 - p1;
                    break;
                case '*':
                    res = p2 * p1;
                    break;
                default:
                    res = p2 / p1;
                    break;
            }
            return res;
        }

        private bool CheckKiTu(string s)
        {
            // Tập ký tự cho phép: các số từ 0-9, toán tử +, -, *, /, và dấu ngoặc
            string allowedChars = "0123456789+-*/.() ";

            // Kiểm tra nếu tất cả ký tự trong chuỗi thuộc tập ký tự cho trước
            return s.All(c => allowedChars.Contains(c));
        }

        private bool BracketMatching(string s)
        {
            int parenthesesCount = 0;
            foreach (char c in s)
            {
                if (c == '(') parenthesesCount++;
                if (c == ')') parenthesesCount--;
                if (parenthesesCount < 0) return false; // Nếu đóng ngoặc trước khi mở
            }
            if (parenthesesCount != 0) return false;
            return true;
        }

        private bool CheckDivideByZero(string s)
        {
            // Regex kiểm tra chia cho 0 không hợp lệ
            // Tìm các trường hợp "/0" mà không có số thập phân khác 0 phía sau
            return !Regex.IsMatch(s, @"/0(?!\.\d*[1-9])");
        }

        private bool CheckCuoiChuoi(string s)
        {
            char c = s[s.Length - 1];
            if (c == '+' || c == '-' || c == '*' || c == '/') return false;
            return true;
        }

        private bool CheckToanTuLienKe(string s)
        {
            return !Regex.IsMatch(s, @"[+\-*/]{2,}");
        }

        private bool CheckValidDecimal(string s)
        {
            return !Regex.IsMatch(s, @"(\.\d*\.)|(\d*\.\d*\.\d*)|(^\.\d+|\d+\.$)");
        }

        private bool CheckHopLe(string s)
        {
            s = s.Replace(" ", "");     // Xóa khoảng trắng trong dòng
            if (!CheckKiTu(s)) return false;
            if (!BracketMatching(s)) return false;
            if (!CheckDivideByZero(s)) return false;
            if (!CheckCuoiChuoi(s)) return false;
            if (!CheckToanTuLienKe(s)) return false;
            if (!CheckValidDecimal(s)) return false;
            return true;
        }

        private double CalculateExpression(string line)
        {
            //string trimmedLine = line.Replace(" ", "");     // Xóa khoảng trắng trong dòng
            Queue<string> q = new Queue<string>();
            q = infix_to_postfix(line);
            Stack<double> s = new Stack<double>();

            foreach (var token in q)
            {
                // La toan hang
                if (double.TryParse(token, out double number))
                    s.Push(number);
                // La toan tu
                else
                {
                    double p1 = s.Pop();
                    double p2 = s.Pop();
                    double ans = Calculate(p1, p2, char.Parse(token));
                    s.Push(ans);
                }
            }
            return s.Pop();
            //return q.Count;
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            if (rtbInput.Text == "")
            {
                MessageBox.Show("File not selected or Empty file", "Notification");
                return;
            }

            using (StreamReader sr = new StreamReader(filePath))
            {

                rtbOutput.Clear();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line == "")
                        continue;
                    if (!CheckHopLe(line))
                    {
                        MessageBox.Show("Bieu thuc khong hop le", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        rtbOutput.AppendText("ERROR\n");
                        continue;
                    }
                    double result = CalculateExpression(line);
                    //results[cnt++] = expression + " " + result.ToString();
                    rtbOutput.AppendText($"{line} = {result}\n");
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Form1 menu = new Form1();
            menu.Show();
            this.Hide();
        }
    }
}
