namespace LAB3_Bai4
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
            buttonListen = new Button();
            textboxLog = new TextBox();
            labelIP = new Label();
            textboxIP = new TextBox();
            SuspendLayout();
            // 
            // buttonListen
            // 
            buttonListen.Location = new Point(444, 3);
            buttonListen.Name = "buttonListen";
            buttonListen.Size = new Size(88, 33);
            buttonListen.TabIndex = 0;
            buttonListen.Text = "Listen";
            buttonListen.UseVisualStyleBackColor = true;
            buttonListen.Click += buttonListen_Click;
            // 
            // textboxLog
            // 
            textboxLog.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textboxLog.Location = new Point(3, 45);
            textboxLog.Multiline = true;
            textboxLog.Name = "textboxLog";
            textboxLog.Size = new Size(529, 393);
            textboxLog.TabIndex = 1;
            // 
            // labelIP
            // 
            labelIP.AutoSize = true;
            labelIP.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelIP.Location = new Point(12, 8);
            labelIP.Name = "labelIP";
            labelIP.Size = new Size(32, 25);
            labelIP.TabIndex = 2;
            labelIP.Text = "IP:";
            // 
            // textboxIP
            // 
            textboxIP.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textboxIP.Location = new Point(44, 4);
            textboxIP.Multiline = true;
            textboxIP.Name = "textboxIP";
            textboxIP.Size = new Size(242, 33);
            textboxIP.TabIndex = 3;
            textboxIP.Text = "127.0.0.1";
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(534, 450);
            Controls.Add(textboxIP);
            Controls.Add(labelIP);
            Controls.Add(textboxLog);
            Controls.Add(buttonListen);
            Name = "Server";
            Text = "Server";
            FormClosing += Server_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonListen;
        private TextBox textboxLog;
        private Label labelIP;
        private TextBox textboxIP;
    }
}
