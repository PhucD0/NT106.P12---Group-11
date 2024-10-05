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
            label_IP.Font = new Font("Snap ITC", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label_IP.ForeColor = Color.FromArgb(255, 128, 0);
            label_IP.Location = new Point(6, 117);
            label_IP.Margin = new Padding(4, 0, 4, 0);
            label_IP.Name = "label_IP";
            label_IP.Size = new Size(210, 35);
            label_IP.TabIndex = 0;
            label_IP.Text = "IP Address:";
            // 
            // label_port
            // 
            label_port.AutoSize = true;
            label_port.BackColor = Color.FromArgb(255, 224, 192);
            label_port.Font = new Font("Snap ITC", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label_port.ForeColor = Color.FromArgb(255, 128, 0);
            label_port.Location = new Point(81, 44);
            label_port.Margin = new Padding(4, 0, 4, 0);
            label_port.Name = "label_port";
            label_port.Size = new Size(102, 35);
            label_port.TabIndex = 1;
            label_port.Text = "Port:";
            // 
            // label_password
            // 
            label_password.AutoSize = true;
            label_password.Font = new Font("Snap ITC", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label_password.ForeColor = Color.Coral;
            label_password.Location = new Point(17, 201);
            label_password.Margin = new Padding(4, 0, 4, 0);
            label_password.Name = "label_password";
            label_password.Size = new Size(183, 35);
            label_password.TabIndex = 2;
            label_password.Text = "Password:";
            label_password.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TextboxIP
            // 
            TextboxIP.Font = new Font("Segoe UI", 15F);
            TextboxIP.Location = new Point(307, 118);
            TextboxIP.Margin = new Padding(4, 3, 4, 3);
            TextboxIP.Multiline = true;
            TextboxIP.Name = "TextboxIP";
            TextboxIP.ScrollBars = ScrollBars.Both;
            TextboxIP.Size = new Size(521, 41);
            TextboxIP.TabIndex = 3;
            // 
            // TextboxPort
            // 
            TextboxPort.BackColor = Color.White;
            TextboxPort.Font = new Font("Segoe UI", 15F);
            TextboxPort.Location = new Point(307, 42);
            TextboxPort.Margin = new Padding(4, 3, 4, 3);
            TextboxPort.Multiline = true;
            TextboxPort.Name = "TextboxPort";
            TextboxPort.Size = new Size(521, 41);
            TextboxPort.TabIndex = 4;
            // 
            // TextboxPassword
            // 
            TextboxPassword.Font = new Font("Segoe UI", 15F);
            TextboxPassword.Location = new Point(307, 198);
            TextboxPassword.Margin = new Padding(4, 3, 4, 3);
            TextboxPassword.Multiline = true;
            TextboxPassword.Name = "TextboxPassword";
            TextboxPassword.Size = new Size(521, 41);
            TextboxPassword.TabIndex = 5;
            // 
            // ButtonSaveIP
            // 
            ButtonSaveIP.Font = new Font("Snap ITC", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ButtonSaveIP.ForeColor = Color.Coral;
            ButtonSaveIP.Location = new Point(307, 260);
            ButtonSaveIP.Margin = new Padding(4, 3, 4, 3);
            ButtonSaveIP.Name = "ButtonSaveIP";
            ButtonSaveIP.Size = new Size(111, 40);
            ButtonSaveIP.TabIndex = 6;
            ButtonSaveIP.Text = "Save IP";
            ButtonSaveIP.UseVisualStyleBackColor = true;
            // 
            // ButtonClear
            // 
            ButtonClear.Font = new Font("Snap ITC", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ButtonClear.ForeColor = Color.Coral;
            ButtonClear.Location = new Point(719, 260);
            ButtonClear.Margin = new Padding(4, 3, 4, 3);
            ButtonClear.Name = "ButtonClear";
            ButtonClear.Size = new Size(111, 40);
            ButtonClear.TabIndex = 7;
            ButtonClear.Text = "Clear";
            ButtonClear.UseVisualStyleBackColor = true;
            // 
            // ButtonConnect
            // 
            ButtonConnect.Font = new Font("Snap ITC", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ButtonConnect.ForeColor = Color.Coral;
            ButtonConnect.Location = new Point(509, 260);
            ButtonConnect.Margin = new Padding(4, 3, 4, 3);
            ButtonConnect.Name = "ButtonConnect";
            ButtonConnect.Size = new Size(111, 40);
            ButtonConnect.TabIndex = 8;
            ButtonConnect.Text = "Connect";
            ButtonConnect.UseVisualStyleBackColor = true;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(10F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 224, 192);
            ClientSize = new Size(947, 331);
            Controls.Add(ButtonConnect);
            Controls.Add(ButtonClear);
            Controls.Add(ButtonSaveIP);
            Controls.Add(TextboxPassword);
            Controls.Add(TextboxPort);
            Controls.Add(TextboxIP);
            Controls.Add(label_password);
            Controls.Add(label_port);
            Controls.Add(label_IP);
            Font = new Font("Snap ITC", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.Coral;
            Margin = new Padding(4, 3, 4, 3);
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
