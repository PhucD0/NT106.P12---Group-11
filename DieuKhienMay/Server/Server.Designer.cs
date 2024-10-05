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
            ButtonStartServer = new Button();
            ButtonStopServer = new Button();
            ButtonSaveSetting = new Button();
            ButtonClear = new Button();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // TextboxPassword
            // 
            TextboxPassword.Font = new Font("Segoe UI", 15F);
            TextboxPassword.Location = new Point(130, 99);
            TextboxPassword.Margin = new Padding(4, 3, 4, 3);
            TextboxPassword.Multiline = true;
            TextboxPassword.Name = "TextboxPassword";
            TextboxPassword.Size = new Size(157, 31);
            TextboxPassword.TabIndex = 9;
            // 
            // TextboxPort
            // 
            TextboxPort.Font = new Font("Segoe UI", 15F);
            TextboxPort.Location = new Point(130, 49);
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
            label_password.Location = new Point(18, 103);
            label_password.Margin = new Padding(4, 0, 4, 0);
            label_password.Name = "label_password";
            label_password.Size = new Size(104, 22);
            label_password.TabIndex = 7;
            label_password.Text = "Password:";
            label_password.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_port
            // 
            label_port.AutoSize = true;
            label_port.Font = new Font("Snap ITC", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_port.ForeColor = Color.Coral;
            label_port.Location = new Point(43, 52);
            label_port.Margin = new Padding(4, 0, 4, 0);
            label_port.Name = "label_port";
            label_port.Size = new Size(58, 22);
            label_port.TabIndex = 6;
            label_port.Text = "Port:";
            // 
            // ButtonStartServer
            // 
            ButtonStartServer.Font = new Font("Snap ITC", 13F, FontStyle.Bold);
            ButtonStartServer.ForeColor = Color.Coral;
            ButtonStartServer.Location = new Point(804, 41);
            ButtonStartServer.Margin = new Padding(4, 3, 4, 3);
            ButtonStartServer.Name = "ButtonStartServer";
            ButtonStartServer.Size = new Size(174, 43);
            ButtonStartServer.TabIndex = 10;
            ButtonStartServer.Text = "Start Server";
            ButtonStartServer.UseVisualStyleBackColor = true;
            // 
            // ButtonStopServer
            // 
            ButtonStopServer.Font = new Font("Snap ITC", 13F, FontStyle.Bold);
            ButtonStopServer.ForeColor = Color.Coral;
            ButtonStopServer.Location = new Point(804, 135);
            ButtonStopServer.Margin = new Padding(4, 3, 4, 3);
            ButtonStopServer.Name = "ButtonStopServer";
            ButtonStopServer.Size = new Size(174, 43);
            ButtonStopServer.TabIndex = 11;
            ButtonStopServer.Text = "Stop Server";
            ButtonStopServer.UseVisualStyleBackColor = true;
            // 
            // ButtonSaveSetting
            // 
            ButtonSaveSetting.Font = new Font("Snap ITC", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ButtonSaveSetting.ForeColor = Color.Coral;
            ButtonSaveSetting.Location = new Point(130, 147);
            ButtonSaveSetting.Margin = new Padding(4, 3, 4, 3);
            ButtonSaveSetting.Name = "ButtonSaveSetting";
            ButtonSaveSetting.Size = new Size(73, 31);
            ButtonSaveSetting.TabIndex = 12;
            ButtonSaveSetting.Text = "Save";
            ButtonSaveSetting.UseVisualStyleBackColor = true;
            // 
            // ButtonClear
            // 
            ButtonClear.Font = new Font("Snap ITC", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ButtonClear.ForeColor = Color.Coral;
            ButtonClear.Location = new Point(211, 147);
            ButtonClear.Margin = new Padding(4, 3, 4, 3);
            ButtonClear.Name = "ButtonClear";
            ButtonClear.Size = new Size(77, 31);
            ButtonClear.TabIndex = 13;
            ButtonClear.Text = "Clear";
            ButtonClear.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(351, 41);
            textBox1.Margin = new Padding(4, 3, 4, 3);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Both;
            textBox1.Size = new Size(443, 137);
            textBox1.TabIndex = 14;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(10F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 224, 192);
            ClientSize = new Size(999, 240);
            Controls.Add(textBox1);
            Controls.Add(ButtonClear);
            Controls.Add(ButtonSaveSetting);
            Controls.Add(ButtonStopServer);
            Controls.Add(ButtonStartServer);
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
        private Button ButtonStartServer;
        private Button ButtonStopServer;
        private Button ButtonSaveSetting;
        private Button ButtonClear;
        private TextBox textBox1;
    }
}
