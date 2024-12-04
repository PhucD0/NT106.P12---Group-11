namespace LAB3_Bai4
{
    partial class Bai4
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
            ServerButton = new Button();
            ClientButton = new Button();
            SuspendLayout();
            // 
            // ServerButton
            // 
            ServerButton.BackColor = SystemColors.ActiveCaptionText;
            ServerButton.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ServerButton.ForeColor = SystemColors.ControlLightLight;
            ServerButton.Location = new Point(230, 0);
            ServerButton.Margin = new Padding(3, 2, 3, 2);
            ServerButton.Name = "ServerButton";
            ServerButton.Size = new Size(241, 338);
            ServerButton.TabIndex = 3;
            ServerButton.Text = "SERVER";
            ServerButton.UseVisualStyleBackColor = false;
            ServerButton.Click += ServerButton_Click;
            // 
            // ClientButton
            // 
            ClientButton.BackColor = SystemColors.ActiveCaption;
            ClientButton.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ClientButton.Location = new Point(0, 0);
            ClientButton.Margin = new Padding(3, 2, 3, 2);
            ClientButton.Name = "ClientButton";
            ClientButton.Size = new Size(241, 338);
            ClientButton.TabIndex = 2;
            ClientButton.Text = "CLIENT";
            ClientButton.UseVisualStyleBackColor = false;
            ClientButton.Click += ClientButton_Click;
            // 
            // Bai4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(469, 336);
            Controls.Add(ServerButton);
            Controls.Add(ClientButton);
            Name = "Bai4";
            Text = "Bai4";
            FormClosing += Bai4_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private Button ServerButton;
        private Button ClientButton;
    }
}