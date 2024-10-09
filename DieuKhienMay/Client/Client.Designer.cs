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
            TextboxIP = new TextBox();
            TextboxPort = new TextBox();
            ButtonSaveIP = new Button();
            ButtonConnect = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label_IP
            // 
            label_IP.AutoSize = true;
            label_IP.Font = new Font("Snap ITC", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label_IP.ForeColor = Color.FromArgb(255, 128, 0);
            label_IP.Location = new Point(24, 52);
            label_IP.Margin = new Padding(4, 0, 4, 0);
            label_IP.Name = "label_IP";
            label_IP.Size = new Size(82, 44);
            label_IP.TabIndex = 0;
            label_IP.Text = "IP:";
            // 
            // label_port
            // 
            label_port.AutoSize = true;
            label_port.BackColor = Color.FromArgb(255, 224, 192);
            label_port.Font = new Font("Snap ITC", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label_port.ForeColor = Color.FromArgb(255, 128, 0);
            label_port.Location = new Point(24, 115);
            label_port.Margin = new Padding(4, 0, 4, 0);
            label_port.Name = "label_port";
            label_port.Size = new Size(127, 44);
            label_port.TabIndex = 1;
            label_port.Text = "Port:";
            // 
            // TextboxIP
            // 
            TextboxIP.Font = new Font("Segoe UI", 15F);
            TextboxIP.Location = new Point(175, 52);
            TextboxIP.Margin = new Padding(4, 3, 4, 3);
            TextboxIP.Multiline = true;
            TextboxIP.Name = "TextboxIP";
            TextboxIP.ScrollBars = ScrollBars.Both;
            TextboxIP.Size = new Size(493, 41);
            TextboxIP.TabIndex = 3;
            // 
            // TextboxPort
            // 
            TextboxPort.BackColor = Color.White;
            TextboxPort.Font = new Font("Segoe UI", 15F);
            TextboxPort.Location = new Point(175, 113);
            TextboxPort.Margin = new Padding(4, 3, 4, 3);
            TextboxPort.Multiline = true;
            TextboxPort.Name = "TextboxPort";
            TextboxPort.Size = new Size(493, 41);
            TextboxPort.TabIndex = 4;
            // 
            // ButtonSaveIP
            // 
            ButtonSaveIP.Font = new Font("Snap ITC", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ButtonSaveIP.ForeColor = Color.Coral;
            ButtonSaveIP.Location = new Point(577, 163);
            ButtonSaveIP.Margin = new Padding(4, 3, 4, 3);
            ButtonSaveIP.Name = "ButtonSaveIP";
            ButtonSaveIP.Size = new Size(91, 36);
            ButtonSaveIP.TabIndex = 6;
            ButtonSaveIP.Text = "Save";
            ButtonSaveIP.UseVisualStyleBackColor = true;
            // 
            // ButtonConnect
            // 
            ButtonConnect.Font = new Font("Snap ITC", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ButtonConnect.ForeColor = Color.Coral;
            ButtonConnect.Location = new Point(700, 46);
            ButtonConnect.Margin = new Padding(4, 3, 4, 3);
            ButtonConnect.Name = "ButtonConnect";
            ButtonConnect.Size = new Size(130, 108);
            ButtonConnect.TabIndex = 8;
            ButtonConnect.Text = "Connect";
            ButtonConnect.UseVisualStyleBackColor = true;
            ButtonConnect.Click += ButtonConnect_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Location = new Point(24, 224);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(806, 423);
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(12F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 224, 192);
            ClientSize = new Size(884, 670);
            Controls.Add(pictureBox1);
            Controls.Add(ButtonConnect);
            Controls.Add(ButtonSaveIP);
            Controls.Add(TextboxPort);
            Controls.Add(TextboxIP);
            Controls.Add(label_port);
            Controls.Add(label_IP);
            Font = new Font("Snap ITC", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.Coral;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Client";
            Text = "Client";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_IP;
        private Label label_port;
        private TextBox TextboxIP;
        private TextBox TextboxPort;
        private Button ButtonSaveIP;
        private Button ButtonConnect;
        private PictureBox pictureBox1;
    }
}
