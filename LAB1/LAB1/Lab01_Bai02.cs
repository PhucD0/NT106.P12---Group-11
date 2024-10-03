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
            //if (comboBox.Text == "Bảng cửu chương")
            //{
            //    txtOutput.Text = "Hi";
            //}
            //else
            //{
            //    txtOutput.Text = "Hello";
            //}
            int numA, numB;
            try
            {
                numA = Int32.Parse(txtInput1.Text.Trim());
                numB = Int32.Parse(txtInput2.Text.Trim());

                string SelectedOption = comboBox.SelectedItem.ToString();
                if (SelectedOption == "Bảng cửu chương")
                {
                    string multiplicationTable = "";
                    int result = numB - numA;
                    for (int i = 1; i <= 10; i++)
                    {
                        multiplicationTable += $"{result} x {i} = {result * i}\r\n";
                    }
                    txtOutput.Text = multiplicationTable;
                }
                else
                {
                    long sum = 0;
                    int Base = 1;
                    for (int i = 1; i <= numB; i++)
                    {
                        Base *= numA;
                        sum += Base;
                    }
                    txtOutput.Text = sum.ToString();
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
            //comboBox.Items.Clear();
        }
    }
}
