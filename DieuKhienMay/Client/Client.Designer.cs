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
            menuStrip1 = new MenuStrip();
            sendFileToolStripMenuItem = new ToolStripMenuItem();
            requestLogsToolStripMenuItem = new ToolStripMenuItem();
            listBox = new ListBox();
            menuStrip1.SuspendLayout();
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
            label_IP.Size = new Size(98, 53);
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
            label_port.Size = new Size(152, 53);
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
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { sendFileToolStripMenuItem, requestLogsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(884, 33);
            menuStrip1.TabIndex = 10;
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
            requestLogsToolStripMenuItem.Click += requestLogsToolStripMenuItem_Click;
            // 
            // listBox
            // 
            listBox.FormattingEnabled = true;
            listBox.ItemHeight = 27;
            listBox.Location = new Point(175, 91);
            listBox.Name = "listBox";
            listBox.Size = new Size(150, 112);
            listBox.TabIndex = 11;
            listBox.Visible = false;
            listBox.MouseClick += listBox_MouseClick_1;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(15F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 224, 192);
            ClientSize = new Size(884, 257);
            Controls.Add(listBox);
            Controls.Add(btnConnect);
            Controls.Add(btnSaveIP);
            Controls.Add(txbPort);
            Controls.Add(txbIP);
            Controls.Add(label_port);
            Controls.Add(label_IP);
            Controls.Add(menuStrip1);
            Font = new Font("Snap ITC", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.Coral;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Client";
            Text = "Client";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
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
        private MenuStrip menuStrip1;
        private ToolStripMenuItem sendFileToolStripMenuItem;
        private ToolStripMenuItem requestLogsToolStripMenuItem;
        private ListBox listBox;
    }
}
