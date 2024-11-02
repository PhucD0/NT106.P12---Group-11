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
            txbPort = new TextBox();
            txbIP = new TextBox();
            label_password = new Label();
            label_port = new Label();
            btnStop = new Button();
            btnListen = new Button();
            label1 = new Label();
            txbStatus = new TextBox();
            menuStrip1 = new MenuStrip();
            sendFileToolStripMenuItem = new ToolStripMenuItem();
            requestLogsToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txbPort
            // 
            txbPort.Font = new Font("Segoe UI", 15F);
            txbPort.Location = new Point(130, 137);
            txbPort.Margin = new Padding(4, 3, 4, 3);
            txbPort.Multiline = true;
            txbPort.Name = "txbPort";
            txbPort.Size = new Size(181, 31);
            txbPort.TabIndex = 9;
            // 
            // txbIP
            // 
            txbIP.Font = new Font("Segoe UI", 15F);
            txbIP.Location = new Point(130, 86);
            txbIP.Margin = new Padding(4, 3, 4, 3);
            txbIP.Multiline = true;
            txbIP.Name = "txbIP";
            txbIP.Size = new Size(181, 31);
            txbIP.TabIndex = 8;
            // 
            // label_password
            // 
            label_password.AutoSize = true;
            label_password.Font = new Font("Snap ITC", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_password.ForeColor = Color.Coral;
            label_password.Location = new Point(18, 141);
            label_password.Margin = new Padding(4, 0, 4, 0);
            label_password.Name = "label_password";
            label_password.Size = new Size(58, 22);
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
            label_port.Size = new Size(38, 22);
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
            label1.Location = new Point(18, 45);
            label1.Name = "label1";
            label1.Size = new Size(65, 17);
            label1.TabIndex = 13;
            label1.Text = "Status:";
            // 
            // txbStatus
            // 
            txbStatus.Location = new Point(129, 40);
            txbStatus.Name = "txbStatus";
            txbStatus.Size = new Size(579, 24);
            txbStatus.TabIndex = 14;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { sendFileToolStripMenuItem, requestLogsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(744, 24);
            menuStrip1.TabIndex = 15;
            menuStrip1.Text = "menuStrip1";
            // 
            // sendFileToolStripMenuItem
            // 
            sendFileToolStripMenuItem.Name = "sendFileToolStripMenuItem";
            sendFileToolStripMenuItem.Size = new Size(66, 20);
            sendFileToolStripMenuItem.Text = "Send File";
            sendFileToolStripMenuItem.Click += sendFileToolStripMenuItem_Click;
            // 
            // requestLogsToolStripMenuItem
            // 
            requestLogsToolStripMenuItem.Name = "requestLogsToolStripMenuItem";
            requestLogsToolStripMenuItem.Size = new Size(89, 20);
            requestLogsToolStripMenuItem.Text = "Request Logs";
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(10F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 224, 192);
            ClientSize = new Size(744, 362);
            Controls.Add(menuStrip1);
            Controls.Add(txbStatus);
            Controls.Add(label1);
            Controls.Add(btnListen);
            Controls.Add(btnStop);
            Controls.Add(txbPort);
            Controls.Add(txbIP);
            Controls.Add(label_password);
            Controls.Add(label_port);
            Font = new Font("Snap ITC", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Server";
            Text = "Server";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txbPort;
        private TextBox txbIP;
        private Label label_password;
        private Label label_port;
        private Button btnStop;
        private Button btnListen;
        private Label label1;
        private TextBox txbStatus;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem sendFileToolStripMenuItem;
        private ToolStripMenuItem requestLogsToolStripMenuItem;
    }
}
