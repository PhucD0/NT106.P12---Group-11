using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LAB1
{
    partial class Lab01_Bai03
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_Title = new System.Windows.Forms.Label();
            this.label_Input = new System.Windows.Forms.Label();
            this.textBox_Input = new System.Windows.Forms.TextBox();
            this.label_Result = new System.Windows.Forms.Label();
            this.textBox_Result = new System.Windows.Forms.TextBox();
            this.button_Read = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.ButtonClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Title.Location = new System.Drawing.Point(160, 42);
            this.label_Title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(452, 25);
            this.label_Title.TabIndex = 0;
            this.label_Title.Text = "CHƯƠNG TRÌNH ĐỌC SỐ NGUYÊN (tối đa 12 chữ số)";
            // 
            // label_Input
            // 
            this.label_Input.AutoSize = true;
            this.label_Input.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Input.Location = new System.Drawing.Point(293, 78);
            this.label_Input.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Input.Name = "label_Input";
            this.label_Input.Size = new System.Drawing.Size(125, 21);
            this.label_Input.TabIndex = 1;
            this.label_Input.Text = "Nhập số cần đọc";
            // 
            // textBox_Input
            // 
            this.textBox_Input.Location = new System.Drawing.Point(240, 119);
            this.textBox_Input.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Input.Name = "textBox_Input";
            this.textBox_Input.Size = new System.Drawing.Size(218, 20);
            this.textBox_Input.TabIndex = 2;
            // 
            // label_Result
            // 
            this.label_Result.AutoSize = true;
            this.label_Result.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Result.Location = new System.Drawing.Point(313, 206);
            this.label_Result.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Result.Name = "label_Result";
            this.label_Result.Size = new System.Drawing.Size(75, 21);
            this.label_Result.TabIndex = 3;
            this.label_Result.Text = "KẾT QUẢ:";
            // 
            // textBox_Result
            // 
            this.textBox_Result.Location = new System.Drawing.Point(160, 238);
            this.textBox_Result.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Result.Name = "textBox_Result";
            this.textBox_Result.Size = new System.Drawing.Size(388, 20);
            this.textBox_Result.TabIndex = 4;
            // 
            // button_Read
            // 
            this.button_Read.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Read.Location = new System.Drawing.Point(240, 160);
            this.button_Read.Margin = new System.Windows.Forms.Padding(2);
            this.button_Read.Name = "button_Read";
            this.button_Read.Size = new System.Drawing.Size(64, 32);
            this.button_Read.TabIndex = 5;
            this.button_Read.Text = "Đọc";
            this.button_Read.UseVisualStyleBackColor = true;
            this.button_Read.Click += new System.EventHandler(this.button_Read_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(586, 325);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(68, 24);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // ButtonClear
            // 
            this.ButtonClear.Location = new System.Drawing.Point(383, 160);
            this.ButtonClear.Name = "ButtonClear";
            this.ButtonClear.Size = new System.Drawing.Size(75, 32);
            this.ButtonClear.TabIndex = 8;
            this.ButtonClear.Text = "Xóa";
            this.ButtonClear.UseVisualStyleBackColor = true;
            this.ButtonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // Lab01_Bai03
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 390);
            this.Controls.Add(this.ButtonClear);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.button_Read);
            this.Controls.Add(this.textBox_Result);
            this.Controls.Add(this.label_Result);
            this.Controls.Add(this.textBox_Input);
            this.Controls.Add(this.label_Input);
            this.Controls.Add(this.label_Title);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Lab01_Bai03";
            this.Text = "Bai3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Lab01_Bai03_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label_Title;
        private Label label_Input;
        private TextBox textBox_Input;
        private Label label_Result;
        private TextBox textBox_Result;
        private Button button_Read;
        private Button btnExit;
        private Button ButtonClear;
    }
}