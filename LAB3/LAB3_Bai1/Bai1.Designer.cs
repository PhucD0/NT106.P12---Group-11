namespace LAB3_Bai1
{
    partial class Bai1
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
            ClientButton = new Button();
            ServerButton = new Button();
            SuspendLayout();
            // 
            // ClientButton
            // 
            ClientButton.BackColor = SystemColors.ActiveCaption;
            ClientButton.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ClientButton.Location = new Point(0, 0);
            ClientButton.Name = "ClientButton";
            ClientButton.Size = new Size(275, 450);
            ClientButton.TabIndex = 0;
            ClientButton.Text = "CLIENT";
            ClientButton.UseVisualStyleBackColor = false;
            ClientButton.Click += ClientButton_Click;
            // 
            // ServerButton
            // 
            ServerButton.BackColor = SystemColors.ActiveCaptionText;
            ServerButton.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ServerButton.ForeColor = SystemColors.ControlLightLight;
            ServerButton.Location = new Point(263, 0);
            ServerButton.Name = "ServerButton";
            ServerButton.Size = new Size(275, 450);
            ServerButton.TabIndex = 1;
            ServerButton.Text = "SERVER";
            ServerButton.UseVisualStyleBackColor = false;
            ServerButton.Click += ServerButton_Click;
            // 
            // Bai1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(538, 450);
            Controls.Add(ServerButton);
            Controls.Add(ClientButton);
            Name = "Bai1";
            Text = "Bài 1";
            FormClosing += Bai1_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private Button ClientButton;
        private Button ServerButton;
    }
}
