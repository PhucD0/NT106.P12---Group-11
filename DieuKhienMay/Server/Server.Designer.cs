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
            btnStop = new Button();
            btnListen = new Button();
            label1 = new Label();
            txbStatus = new TextBox();
            menuStrip1 = new MenuStrip();
            sendFileToolStripMenuItem = new ToolStripMenuItem();
            requestLogsToolStripMenuItem = new ToolStripMenuItem();
            txbPort = new TextBox();
            txbIP = new TextBox();
            label_port = new Label();
            label_IP = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnStop
            // 
            btnStop.Font = new Font("Snap ITC", 13F, FontStyle.Bold);
            btnStop.ForeColor = Color.Coral;
            btnStop.Location = new Point(697, 94);
            btnStop.Margin = new Padding(4, 3, 4, 3);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(130, 87);
            btnStop.TabIndex = 11;
            btnStop.Text = "Stop ";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnListen
            // 
            btnListen.Font = new Font("Snap ITC", 13F, FontStyle.Bold);
            btnListen.ForeColor = Color.Coral;
            btnListen.Location = new Point(537, 94);
            btnListen.Margin = new Padding(4, 3, 4, 3);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(130, 87);
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
            label1.Size = new Size(83, 23);
            label1.TabIndex = 13;
            label1.Text = "Status:";
            // 
            // txbStatus
            // 
            txbStatus.Location = new Point(160, 40);
            txbStatus.Name = "txbStatus";
            txbStatus.Size = new Size(667, 28);
            txbStatus.TabIndex = 14;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { sendFileToolStripMenuItem, requestLogsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(873, 28);
            menuStrip1.TabIndex = 15;
            menuStrip1.Text = "menuStrip1";
            // 
            // sendFileToolStripMenuItem
            // 
            sendFileToolStripMenuItem.Name = "sendFileToolStripMenuItem";
            sendFileToolStripMenuItem.Size = new Size(83, 24);
            sendFileToolStripMenuItem.Text = "Send File";
            sendFileToolStripMenuItem.Click += sendFileToolStripMenuItem_Click;
            // 
            // requestLogsToolStripMenuItem
            // 
            requestLogsToolStripMenuItem.Name = "requestLogsToolStripMenuItem";
            requestLogsToolStripMenuItem.Size = new Size(111, 24);
            requestLogsToolStripMenuItem.Text = "Request Logs";
            requestLogsToolStripMenuItem.Click += requestLogsToolStripMenuItem_Click_1;
            // 
            // txbPort
            // 
            txbPort.BackColor = Color.White;
            txbPort.Font = new Font("Segoe UI", 15F);
            txbPort.Location = new Point(160, 140);
            txbPort.Margin = new Padding(4, 3, 4, 3);
            txbPort.Multiline = true;
            txbPort.Name = "txbPort";
            txbPort.Size = new Size(346, 41);
            txbPort.TabIndex = 19;
            // 
            // txbIP
            // 
            txbIP.Font = new Font("Segoe UI", 15F);
            txbIP.Location = new Point(160, 85);
            txbIP.Margin = new Padding(4, 3, 4, 3);
            txbIP.Multiline = true;
            txbIP.Name = "txbIP";
            txbIP.Size = new Size(346, 41);
            txbIP.TabIndex = 18;
            // 
            // label_port
            // 
            label_port.AutoSize = true;
            label_port.BackColor = Color.FromArgb(255, 224, 192);
            label_port.Font = new Font("Snap ITC", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label_port.ForeColor = Color.FromArgb(255, 128, 0);
            label_port.Location = new Point(9, 148);
            label_port.Margin = new Padding(4, 0, 4, 0);
            label_port.Name = "label_port";
            label_port.Size = new Size(127, 44);
            label_port.TabIndex = 17;
            label_port.Text = "Port:";
            // 
            // label_IP
            // 
            label_IP.AutoSize = true;
            label_IP.Font = new Font("Snap ITC", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label_IP.ForeColor = Color.FromArgb(255, 128, 0);
            label_IP.Location = new Point(9, 85);
            label_IP.Margin = new Padding(4, 0, 4, 0);
            label_IP.Name = "label_IP";
            label_IP.Size = new Size(82, 44);
            label_IP.TabIndex = 16;
            label_IP.Text = "IP:";
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(12F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 224, 192);
            ClientSize = new Size(873, 253);
            Controls.Add(txbPort);
            Controls.Add(txbIP);
            Controls.Add(label_port);
            Controls.Add(label_IP);
            Controls.Add(menuStrip1);
            Controls.Add(txbStatus);
            Controls.Add(label1);
            Controls.Add(btnListen);
            Controls.Add(btnStop);
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
        private Button btnStop;
        private Button btnListen;
        private Label label1;
        private TextBox txbStatus;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem sendFileToolStripMenuItem;
        private ToolStripMenuItem requestLogsToolStripMenuItem;
        private TextBox txbPort;
        private TextBox txbIP;
        private Label label_port;
        private Label label_IP;
    }
}
