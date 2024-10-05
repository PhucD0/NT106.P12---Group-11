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
            TextboxPassword.Location = new Point(91, 87);
            TextboxPassword.Multiline = true;
            TextboxPassword.Name = "TextboxPassword";
            TextboxPassword.Size = new Size(111, 28);
            TextboxPassword.TabIndex = 9;
            // 
            // TextboxPort
            // 
            TextboxPort.Font = new Font("Segoe UI", 15F);
            TextboxPort.Location = new Point(91, 43);
            TextboxPort.Multiline = true;
            TextboxPort.Name = "TextboxPort";
            TextboxPort.Size = new Size(111, 28);
            TextboxPort.TabIndex = 8;
            // 
            // label_password
            // 
            label_password.AutoSize = true;
            label_password.Font = new Font("Segoe UI", 12F);
            label_password.Location = new Point(6, 91);
            label_password.Name = "label_password";
            label_password.Size = new Size(79, 21);
            label_password.TabIndex = 7;
            label_password.Text = "Password:";
            label_password.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_port
            // 
            label_port.AutoSize = true;
            label_port.Font = new Font("Segoe UI", 12F);
            label_port.Location = new Point(44, 46);
            label_port.Name = "label_port";
            label_port.Size = new Size(41, 21);
            label_port.TabIndex = 6;
            label_port.Text = "Port:";
            // 
            // ButtonStartServer
            // 
            ButtonStartServer.Font = new Font("Segoe UI", 15F);
            ButtonStartServer.Location = new Point(563, 36);
            ButtonStartServer.Name = "ButtonStartServer";
            ButtonStartServer.Size = new Size(122, 38);
            ButtonStartServer.TabIndex = 10;
            ButtonStartServer.Text = "Start Server";
            ButtonStartServer.TextAlign = ContentAlignment.TopRight;
            ButtonStartServer.UseVisualStyleBackColor = true;
            // 
            // ButtonStopServer
            // 
            ButtonStopServer.Font = new Font("Segoe UI", 15F);
            ButtonStopServer.Location = new Point(563, 119);
            ButtonStopServer.Name = "ButtonStopServer";
            ButtonStopServer.Size = new Size(122, 38);
            ButtonStopServer.TabIndex = 11;
            ButtonStopServer.Text = "Stop Server";
            ButtonStopServer.TextAlign = ContentAlignment.TopRight;
            ButtonStopServer.UseVisualStyleBackColor = true;
            // 
            // ButtonSaveSetting
            // 
            ButtonSaveSetting.Font = new Font("Segoe UI", 12F);
            ButtonSaveSetting.Location = new Point(91, 130);
            ButtonSaveSetting.Name = "ButtonSaveSetting";
            ButtonSaveSetting.Size = new Size(51, 27);
            ButtonSaveSetting.TabIndex = 12;
            ButtonSaveSetting.Text = "Save";
            ButtonSaveSetting.UseVisualStyleBackColor = true;
            // 
            // ButtonClear
            // 
            ButtonClear.Font = new Font("Segoe UI", 12F);
            ButtonClear.Location = new Point(148, 130);
            ButtonClear.Name = "ButtonClear";
            ButtonClear.Size = new Size(54, 27);
            ButtonClear.TabIndex = 13;
            ButtonClear.Text = "Clear";
            ButtonClear.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(246, 36);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Both;
            textBox1.Size = new Size(311, 121);
            textBox1.TabIndex = 14;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(699, 212);
            Controls.Add(textBox1);
            Controls.Add(ButtonClear);
            Controls.Add(ButtonSaveSetting);
            Controls.Add(ButtonStopServer);
            Controls.Add(ButtonStartServer);
            Controls.Add(TextboxPassword);
            Controls.Add(TextboxPort);
            Controls.Add(label_password);
            Controls.Add(label_port);
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
