namespace Server
{
    partial class Server
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txbSeatsEmpty = new TextBox();
            label5 = new Label();
            txbSeatsSelected = new TextBox();
            label4 = new Label();
            txbDevicesConnected = new TextBox();
            label3 = new Label();
            txbPort = new TextBox();
            btnListen = new Button();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // txbSeatsEmpty
            // 
            txbSeatsEmpty.BorderStyle = BorderStyle.FixedSingle;
            txbSeatsEmpty.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txbSeatsEmpty.Location = new Point(362, 390);
            txbSeatsEmpty.Name = "txbSeatsEmpty";
            txbSeatsEmpty.ReadOnly = true;
            txbSeatsEmpty.Size = new Size(33, 24);
            txbSeatsEmpty.TabIndex = 20;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(237, 416);
            label5.Name = "label5";
            label5.Size = new Size(97, 18);
            label5.TabIndex = 19;
            label5.Text = "Số ghế trống:";
            // 
            // txbSeatsSelected
            // 
            txbSeatsSelected.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txbSeatsSelected.BorderStyle = BorderStyle.FixedSingle;
            txbSeatsSelected.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txbSeatsSelected.Location = new Point(345, 417);
            txbSeatsSelected.Name = "txbSeatsSelected";
            txbSeatsSelected.ReadOnly = true;
            txbSeatsSelected.Size = new Size(33, 24);
            txbSeatsSelected.TabIndex = 18;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(237, 390);
            label4.Name = "label4";
            label4.Size = new Size(116, 18);
            label4.TabIndex = 17;
            label4.Text = "Số ghế đã chọn:";
            // 
            // txbDevicesConnected
            // 
            txbDevicesConnected.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txbDevicesConnected.BorderStyle = BorderStyle.FixedSingle;
            txbDevicesConnected.Cursor = Cursors.IBeam;
            txbDevicesConnected.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txbDevicesConnected.Location = new Point(157, 184);
            txbDevicesConnected.Name = "txbDevicesConnected";
            txbDevicesConnected.ReadOnly = true;
            txbDevicesConnected.Size = new Size(33, 24);
            txbDevicesConnected.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(24, 183);
            label3.Name = "label3";
            label3.Size = new Size(125, 18);
            label3.TabIndex = 15;
            label3.Text = "Số thiết bị kết nối:";
            // 
            // txbPort
            // 
            txbPort.BorderStyle = BorderStyle.FixedSingle;
            txbPort.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txbPort.Location = new Point(99, 77);
            txbPort.Name = "txbPort";
            txbPort.Size = new Size(89, 24);
            txbPort.TabIndex = 14;
            txbPort.Text = "8080";
            txbPort.TextAlign = HorizontalAlignment.Center;
            // 
            // btnListen
            // 
            btnListen.BackColor = Color.FromArgb(128, 255, 255);
            btnListen.FlatAppearance.BorderColor = SystemColors.InfoText;
            btnListen.FlatStyle = FlatStyle.Flat;
            btnListen.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnListen.Location = new Point(27, 121);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(161, 29);
            btnListen.TabIndex = 13;
            btnListen.Text = "LISTEN";
            btnListen.UseVisualStyleBackColor = false;
            btnListen.Click += btnListen_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(26, 80);
            label2.Name = "label2";
            label2.Size = new Size(50, 18);
            label2.TabIndex = 12;
            label2.Text = "PORT";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(453, 32);
            label1.Name = "label1";
            label1.Size = new Size(74, 19);
            label1.TabIndex = 11;
            label1.Text = "SERVER";
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txbSeatsEmpty);
            Controls.Add(label5);
            Controls.Add(txbSeatsSelected);
            Controls.Add(label4);
            Controls.Add(txbDevicesConnected);
            Controls.Add(label3);
            Controls.Add(txbPort);
            Controls.Add(btnListen);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "Server";
            Text = "Server";
            Load += Server_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txbSeatsEmpty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbSeatsSelected;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbDevicesConnected;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbPort;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

