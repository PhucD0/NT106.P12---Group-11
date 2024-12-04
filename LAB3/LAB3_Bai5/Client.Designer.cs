using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    partial class Client
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
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            txbName = new TextBox();
            txbPort = new TextBox();
            label3 = new Label();
            btnBookSeat = new Button();
            label7 = new Label();
            btnConnect = new Button();
            label2 = new Label();
            label1 = new Label();
            txbIP = new TextBox();
            SuspendLayout();
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.Gray;
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Location = new Point(42, 374);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(46, 22);
            textBox3.TabIndex = 29;
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.Cyan;
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.ForeColor = SystemColors.InfoText;
            textBox2.Location = new Point(42, 332);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(46, 22);
            textBox2.TabIndex = 30;
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(42, 291);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(46, 22);
            textBox1.TabIndex = 31;
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(108, 377);
            label6.Name = "label6";
            label6.Size = new Size(94, 19);
            label6.TabIndex = 26;
            label6.Text = "Ghế đã chọn";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(108, 335);
            label5.Name = "label5";
            label5.Size = new Size(110, 19);
            label5.TabIndex = 27;
            label5.Text = "Ghế đang chọn";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(108, 294);
            label4.Name = "label4";
            label4.Size = new Size(77, 19);
            label4.TabIndex = 28;
            label4.Text = "Ghế trống";
            // 
            // txbName
            // 
            txbName.BorderStyle = BorderStyle.FixedSingle;
            txbName.Location = new Point(374, 398);
            txbName.Multiline = true;
            txbName.Name = "txbName";
            txbName.Size = new Size(134, 30);
            txbName.TabIndex = 23;
            // 
            // txbPort
            // 
            txbPort.BorderStyle = BorderStyle.FixedSingle;
            txbPort.Cursor = Cursors.IBeam;
            txbPort.Location = new Point(94, 118);
            txbPort.Name = "txbPort";
            txbPort.Size = new Size(147, 22);
            txbPort.TabIndex = 25;
            txbPort.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(303, 408);
            label3.Name = "label3";
            label3.Size = new Size(40, 19);
            label3.TabIndex = 18;
            label3.Text = "TÊN";
            // 
            // btnBookSeat
            // 
            btnBookSeat.BackColor = Color.Cyan;
            btnBookSeat.FlatAppearance.BorderColor = Color.Black;
            btnBookSeat.FlatStyle = FlatStyle.Flat;
            btnBookSeat.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBookSeat.Location = new Point(544, 398);
            btnBookSeat.Name = "btnBookSeat";
            btnBookSeat.Size = new Size(121, 29);
            btnBookSeat.TabIndex = 21;
            btnBookSeat.Text = "ĐẶT CHỖ";
            btnBookSeat.UseVisualStyleBackColor = false;
            btnBookSeat.Click += btnBookSeat_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(38, 121);
            label7.Name = "label7";
            label7.Size = new Size(50, 19);
            label7.TabIndex = 19;
            label7.Text = "PORT";
            // 
            // btnConnect
            // 
            btnConnect.BackColor = Color.FromArgb(128, 255, 255);
            btnConnect.FlatAppearance.BorderColor = Color.Black;
            btnConnect.FlatStyle = FlatStyle.Flat;
            btnConnect.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConnect.Location = new Point(41, 156);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(200, 29);
            btnConnect.TabIndex = 22;
            btnConnect.Text = "CONNECT";
            btnConnect.UseVisualStyleBackColor = false;
            btnConnect.Click += btnConnect_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(38, 85);
            label2.Name = "label2";
            label2.Size = new Size(24, 19);
            label2.TabIndex = 20;
            label2.Text = "IP";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(481, 30);
            label1.Name = "label1";
            label1.Size = new Size(71, 19);
            label1.TabIndex = 17;
            label1.Text = "CLIENT";
            // 
            // txbIP
            // 
            txbIP.BorderStyle = BorderStyle.FixedSingle;
            txbIP.Cursor = Cursors.IBeam;
            txbIP.Location = new Point(94, 82);
            txbIP.Name = "txbIP";
            txbIP.Size = new Size(147, 22);
            txbIP.TabIndex = 25;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 462);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txbName);
            Controls.Add(txbIP);
            Controls.Add(txbPort);
            Controls.Add(label3);
            Controls.Add(btnBookSeat);
            Controls.Add(label7);
            Controls.Add(btnConnect);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "Client";
            Text = "Client";
            Load += Client_Load_2;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.TextBox txbPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBookSeat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private TextBox txbIP;
    }
}

