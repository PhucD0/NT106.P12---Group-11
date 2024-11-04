namespace FileTransfer
{
    partial class NotificationForm
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
            notificationTempLabel = new Label();
            SuspendLayout();
            // 
            // notificationTempLabel
            // 
            notificationTempLabel.AutoSize = true;
            notificationTempLabel.Font = new Font("Comic Sans MS", 10F);
            notificationTempLabel.Location = new Point(1, 9);
            notificationTempLabel.Name = "notificationTempLabel";
            notificationTempLabel.Size = new Size(187, 19);
            notificationTempLabel.TabIndex = 8;
            notificationTempLabel.Text = "Please wait. File Sending to";
            // 
            // NotificationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 128);
            ClientSize = new Size(800, 38);
            Controls.Add(notificationTempLabel);
            Name = "NotificationForm";
            Text = "NotificationForm";
            Load += NotificationForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label notificationTempLabel;
    }
}