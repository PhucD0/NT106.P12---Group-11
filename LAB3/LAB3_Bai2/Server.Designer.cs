namespace LAB3_Bai2
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
            btnListen = new Button();
            txtMessages = new TextBox();
            SuspendLayout();
            // 
            // btnListen
            // 
            btnListen.Location = new Point(465, 40);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(112, 34);
            btnListen.TabIndex = 1;
            btnListen.Text = "Listen";
            btnListen.UseVisualStyleBackColor = true;
            btnListen.Click += btnListen_Click;
            // 
            // txtMessages
            // 
            txtMessages.Location = new Point(12, 88);
            txtMessages.Multiline = true;
            txtMessages.Name = "txtMessages";
            txtMessages.Size = new Size(565, 350);
            txtMessages.TabIndex = 2;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(589, 450);
            Controls.Add(txtMessages);
            Controls.Add(btnListen);
            Name = "Server";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnListen;
        private TextBox txtMessages;
    }
}