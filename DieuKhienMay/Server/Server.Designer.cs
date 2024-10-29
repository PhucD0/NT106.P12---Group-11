namespace Server
{
    partial class Server
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TextboxPassword = new TextBox();
            TextboxPort = new TextBox();
            label_password = new Label();
            label_port = new Label();
            btnStop = new Button();
            btnListen = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // TextboxPassword
            // 
            TextboxPassword.Font = new Font("Segoe UI", 15F);
            TextboxPassword.Location = new Point(130, 137);
            TextboxPassword.Margin = new Padding(4, 3, 4, 3);
            TextboxPassword.Multiline = true;
            TextboxPassword.Name = "TextboxPassword";
            TextboxPassword.Size = new Size(157, 31);
            TextboxPassword.TabIndex = 9;
            // 
            // TextboxPort
            // 
            TextboxPort.Font = new Font("Segoe UI", 15F);
            TextboxPort.Location = new Point(130, 86);
            TextboxPort.Margin = new Padding(4, 3, 4, 3);
            TextboxPort.Multiline = true;
            TextboxPort.Name = "TextboxPort";
            TextboxPort.Size = new Size(157, 31);
            TextboxPort.TabIndex = 8;
            // 
            // label_password
            // 
            label_password.AutoSize = true;
            label_password.Font = new Font("Snap ITC", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_password.ForeColor = Color.Coral;
            label_password.Location = new Point(18, 141);
            label_password.Margin = new Padding(4, 0, 4, 0);
            label_password.Name = "label_password";
            label_password.Size = new Size(72, 27);
            label_password.TabIndex = 7;
            label_password.Text = "Port:";
            label_password.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_port
            // 
            label_port.AutoSize = true;
            label_port.Font = new Font("Snap ITC", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_port.ForeColor = Color.Coral;
            label_port.Location = new Point(43, 89);
            label_port.Margin = new Padding(4, 0, 4, 0);
            label_port.Name = "label_port";
            label_port.Size = new Size(47, 27);
            label_port.TabIndex = 6;
            label_port.Text = "IP:";
            // 
            // btnStop
            // 
            btnStop.Font = new Font("Snap ITC", 13F, FontStyle.Bold);
            btnStop.ForeColor = Color.Coral;
            btnStop.Location = new Point(510, 86);
            btnStop.Margin = new Padding(4, 3, 4, 3);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(130, 82);
            btnStop.TabIndex = 11;
            btnStop.Text = "Stop ";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnListen
            // 
            btnListen.Font = new Font("Snap ITC", 13F, FontStyle.Bold);
            btnListen.ForeColor = Color.Coral;
            btnListen.Location = new Point(348, 86);
            btnListen.Margin = new Padding(4, 3, 4, 3);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(130, 82);
            btnListen.TabIndex = 12;
            btnListen.Text = "Listen";
            btnListen.UseVisualStyleBackColor = true;
            btnListen.Click += btnListen_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 24);
            label1.Name = "label1";
            label1.Size = new Size(83, 23);
            label1.TabIndex = 13;
            label1.Text = "Status:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(136, 19);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(579, 28);
            textBox1.TabIndex = 14;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(12F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 224, 192);
            ClientSize = new Size(744, 362);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(btnListen);
            Controls.Add(btnStop);
            Controls.Add(TextboxPassword);
            Controls.Add(TextboxPort);
            Controls.Add(label_password);
            Controls.Add(label_port);
            Font = new Font("Snap ITC", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Server";
            Text = "Server";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TextboxPassword;
        private TextBox TextboxPort;
        private Label label_password;
        private Label label_port;
        private Button btnStop;
        private Button btnListen;
        private Label label1;
        private TextBox textBox1;
    }
}
