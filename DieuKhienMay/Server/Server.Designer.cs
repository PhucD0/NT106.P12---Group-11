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
            label_password = new Label();
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
            txbPort.Location = new Point(129, 86);
            txbPort.Margin = new Padding(4, 3, 4, 3);
            txbPort.Multiline = true;
            txbPort.Name = "txbPort";
            txbPort.Size = new Size(181, 31);
            txbPort.TabIndex = 9;
            // 
            // label_password
            // 
            label_password.AutoSize = true;
            label_password.Font = new Font("Snap ITC", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_password.ForeColor = Color.Coral;
            label_password.Location = new Point(18, 86);
            label_password.Margin = new Padding(4, 0, 4, 0);
            label_password.Name = "label_password";
            label_password.Size = new Size(87, 31);
            label_password.TabIndex = 7;
            label_password.Text = "Port:";
            label_password.TextAlign = ContentAlignment.MiddleCenter;
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
            label1.Size = new Size(99, 27);
            label1.TabIndex = 13;
            label1.Text = "Status:";
            // 
            // txbStatus
            // 
            txbStatus.Location = new Point(129, 40);
            txbStatus.Name = "txbStatus";
            txbStatus.Size = new Size(579, 33);
            txbStatus.TabIndex = 14;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { sendFileToolStripMenuItem, requestLogsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(744, 33);
            menuStrip1.TabIndex = 15;
            menuStrip1.Text = "menuStrip1";
            // 
            // sendFileToolStripMenuItem
            // 
            sendFileToolStripMenuItem.Name = "sendFileToolStripMenuItem";
            sendFileToolStripMenuItem.Size = new Size(99, 29);
            sendFileToolStripMenuItem.Text = "Send File";
            sendFileToolStripMenuItem.Click += sendFileToolStripMenuItem_Click;
            // 
            // requestLogsToolStripMenuItem
            // 
            requestLogsToolStripMenuItem.Name = "requestLogsToolStripMenuItem";
            requestLogsToolStripMenuItem.Size = new Size(134, 29);
            requestLogsToolStripMenuItem.Text = "Request Logs";
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(15F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 224, 192);
            ClientSize = new Size(744, 362);
            Controls.Add(menuStrip1);
            Controls.Add(txbStatus);
            Controls.Add(label1);
            Controls.Add(btnListen);
            Controls.Add(btnStop);
            Controls.Add(txbPort);
            Controls.Add(label_password);
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
        private Label label_password;
        private Button btnStop;
        private Button btnListen;
        private Label label1;
        private TextBox txbStatus;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem sendFileToolStripMenuItem;
        private ToolStripMenuItem requestLogsToolStripMenuItem;
    }
}
