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
            txbIP = new TextBox();
            txbPort = new TextBox();
            btnSaveIP = new Button();
            btnConnect = new Button();
            pictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
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
            // txbIP
            // 
            txbIP.Font = new Font("Segoe UI", 15F);
            txbIP.Location = new Point(175, 52);
            txbIP.Margin = new Padding(4, 3, 4, 3);
            txbIP.Multiline = true;
            txbIP.Name = "txbIP";
            txbIP.ScrollBars = ScrollBars.Both;
            txbIP.Size = new Size(493, 41);
            txbIP.TabIndex = 3;
            // 
            // txbPort
            // 
            txbPort.BackColor = Color.White;
            txbPort.Font = new Font("Segoe UI", 15F);
            txbPort.Location = new Point(175, 113);
            txbPort.Margin = new Padding(4, 3, 4, 3);
            txbPort.Multiline = true;
            txbPort.Name = "txbPort";
            txbPort.Size = new Size(493, 41);
            txbPort.TabIndex = 4;
            // 
            // btnSaveIP
            // 
            btnSaveIP.Font = new Font("Snap ITC", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSaveIP.ForeColor = Color.Coral;
            btnSaveIP.Location = new Point(577, 163);
            btnSaveIP.Margin = new Padding(4, 3, 4, 3);
            btnSaveIP.Name = "btnSaveIP";
            btnSaveIP.Size = new Size(91, 36);
            btnSaveIP.TabIndex = 6;
            btnSaveIP.Text = "Save";
            btnSaveIP.UseVisualStyleBackColor = true;
            btnSaveIP.Click += btnSaveIP_Click;
            // 
            // btnConnect
            // 
            btnConnect.Font = new Font("Snap ITC", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConnect.ForeColor = Color.Coral;
            btnConnect.Location = new Point(700, 46);
            btnConnect.Margin = new Padding(4, 3, 4, 3);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(130, 108);
            btnConnect.TabIndex = 8;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // pictureBox
            // 
            pictureBox.BackColor = Color.White;
            pictureBox.Location = new Point(24, 224);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(806, 423);
            pictureBox.TabIndex = 9;
            pictureBox.TabStop = false;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(12F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 224, 192);
            ClientSize = new Size(884, 670);
            Controls.Add(pictureBox);
            Controls.Add(btnConnect);
            Controls.Add(btnSaveIP);
            Controls.Add(txbPort);
            Controls.Add(txbIP);
            Controls.Add(label_port);
            Controls.Add(label_IP);
            Font = new Font("Snap ITC", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.Coral;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Client";
            Text = "Client";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_IP;
        private Label label_port;
        private TextBox txbIP;
        private TextBox txbPort;
        private Button btnSaveIP;
        private Button btnConnect;
        private PictureBox pictureBox;
    }
}
