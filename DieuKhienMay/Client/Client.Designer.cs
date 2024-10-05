namespace Client
{
    partial class Client
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
            label_IP = new Label();
            label_port = new Label();
            label_password = new Label();
            TextboxIP = new TextBox();
            TextboxPort = new TextBox();
            TextboxPassword = new TextBox();
            ButtonSaveIP = new Button();
            ButtonClear = new Button();
            ButtonConnect = new Button();
            SuspendLayout();
            // 
            // label_IP
            // 
            label_IP.AutoSize = true;
            label_IP.Font = new Font("Segoe UI", 20F);
            label_IP.Location = new Point(51, 104);
            label_IP.Name = "label_IP";
            label_IP.Size = new Size(146, 37);
            label_IP.TabIndex = 0;
            label_IP.Text = "IP Address:";
            // 
            // label_port
            // 
            label_port.AutoSize = true;
            label_port.Font = new Font("Segoe UI", 20F);
            label_port.Location = new Point(81, 37);
            label_port.Name = "label_port";
            label_port.Size = new Size(71, 37);
            label_port.TabIndex = 1;
            label_port.Text = "Port:";
            // 
            // label_password
            // 
            label_password.AutoSize = true;
            label_password.Font = new Font("Segoe UI", 20F);
            label_password.Location = new Point(51, 175);
            label_password.Name = "label_password";
            label_password.Size = new Size(134, 37);
            label_password.TabIndex = 2;
            label_password.Text = "Password:";
            label_password.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TextboxIP
            // 
            TextboxIP.Font = new Font("Segoe UI", 15F);
            TextboxIP.Location = new Point(215, 104);
            TextboxIP.Multiline = true;
            TextboxIP.Name = "TextboxIP";
            TextboxIP.ScrollBars = ScrollBars.Both;
            TextboxIP.Size = new Size(366, 37);
            TextboxIP.TabIndex = 3;
            // 
            // TextboxPort
            // 
            TextboxPort.Font = new Font("Segoe UI", 15F);
            TextboxPort.Location = new Point(215, 37);
            TextboxPort.Multiline = true;
            TextboxPort.Name = "TextboxPort";
            TextboxPort.Size = new Size(366, 37);
            TextboxPort.TabIndex = 4;
            // 
            // TextboxPassword
            // 
            TextboxPassword.Font = new Font("Segoe UI", 15F);
            TextboxPassword.Location = new Point(215, 175);
            TextboxPassword.Multiline = true;
            TextboxPassword.Name = "TextboxPassword";
            TextboxPassword.Size = new Size(366, 37);
            TextboxPassword.TabIndex = 5;
            // 
            // ButtonSaveIP
            // 
            ButtonSaveIP.Font = new Font("Segoe UI", 12F);
            ButtonSaveIP.Location = new Point(215, 229);
            ButtonSaveIP.Name = "ButtonSaveIP";
            ButtonSaveIP.Size = new Size(78, 35);
            ButtonSaveIP.TabIndex = 6;
            ButtonSaveIP.Text = "Save IP";
            ButtonSaveIP.UseVisualStyleBackColor = true;
            // 
            // ButtonClear
            // 
            ButtonClear.Font = new Font("Segoe UI", 12F);
            ButtonClear.Location = new Point(503, 229);
            ButtonClear.Name = "ButtonClear";
            ButtonClear.Size = new Size(78, 35);
            ButtonClear.TabIndex = 7;
            ButtonClear.Text = "Clear";
            ButtonClear.UseVisualStyleBackColor = true;
            // 
            // ButtonConnect
            // 
            ButtonConnect.Font = new Font("Segoe UI", 12F);
            ButtonConnect.Location = new Point(356, 229);
            ButtonConnect.Name = "ButtonConnect";
            ButtonConnect.Size = new Size(78, 35);
            ButtonConnect.TabIndex = 8;
            ButtonConnect.Text = "Connect";
            ButtonConnect.UseVisualStyleBackColor = true;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(663, 292);
            Controls.Add(ButtonConnect);
            Controls.Add(ButtonClear);
            Controls.Add(ButtonSaveIP);
            Controls.Add(TextboxPassword);
            Controls.Add(TextboxPort);
            Controls.Add(TextboxIP);
            Controls.Add(label_password);
            Controls.Add(label_port);
            Controls.Add(label_IP);
            Name = "Client";
            Text = "Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_IP;
        private Label label_port;
        private Label label_password;
        private TextBox TextboxIP;
        private TextBox TextboxPort;
        private TextBox TextboxPassword;
        private Button ButtonSaveIP;
        private Button ButtonClear;
        private Button ButtonConnect;
    }
}
