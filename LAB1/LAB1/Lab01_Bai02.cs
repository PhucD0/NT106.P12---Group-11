using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB1
{
    public partial class Lab01_Bai02 : Form
    {
        public Lab01_Bai02()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var form1 = (Form1)Tag;
            form1.Show();
            Close();
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            int numA, numB;

            // Xử lý trường hợp khi người dùng không chọn
            if (comboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select an option!");
                return;
            }

            try
            {
                numA = Int32.Parse(txtInput1.Text.Trim());
                numB = Int32.Parse(txtInput2.Text.Trim());

                string SelectedOption = comboBox.SelectedItem.ToString();

                //Xử lý bảng cửu chương

                if (SelectedOption == "Bảng cửu chương")
                {
                    string multiplicationTable = "";
                    int result = numB - numA;
                    for (int i = 1; i <= 10; i++)
                    {
                        multiplicationTable += $"{result} x {i} = {result * i}\r\n";
                    }
                    txtOutput.Text = $"Bảng cửu chương B - A:\n{multiplicationTable}";
                }
                else
                {

                    //Kiểm tra hợp lệ A - B để tính giai thừa

                    if (numA - numB < 0) 
                    {
                        MessageBox.Show("A bé hơn B. Vui lòng nhập lại!");
                    }
                    else 
                    {

                        // Tính giai thừa của A - B

                        long result = 1;
                        for (int i = 1; i <= (numA - numB  ); i++)
                        {
                            result *= i;
                        }

                        //Tính tổng A^1 + A^2 + ... + A^B

                        long sum = 0;
                        int Base = 1;
                        for (int i = 1; i <= numB; i++)
                        {
                            Base *= numA;
                            sum += Base;
                        }

                        txtOutput.Text = $"(A - B)! = {result}{Environment.NewLine}Tổng S: {sum}";
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Input invalid! Please try again.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtInput1.Clear();
            txtInput2.Clear();
            txtOutput.Clear();
        }

        private void Lab01_Bai02_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();    
            Form1 form = new Form1();
            form.Show();
        }
    }
}
