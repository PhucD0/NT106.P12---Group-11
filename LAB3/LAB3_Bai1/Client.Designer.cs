namespace LAB3_Bai1
{
    partial class Client
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
            IPLabel = new Label();
            PortLabel = new Label();
            IPTextBox = new TextBox();
            PortTextBox = new TextBox();
            MessageLabel = new Label();
            MessageTextBox = new TextBox();
            sendButton = new Button();
            SuspendLayout();
            // 
            // IPLabel
            // 
            IPLabel.AutoSize = true;
            IPLabel.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            IPLabel.Location = new Point(26, 18);
            IPLabel.Name = "IPLabel";
            IPLabel.Size = new Size(158, 28);
            IPLabel.TabIndex = 0;
            IPLabel.Text = "IP Remote Host";
            // 
            // PortLabel
            // 
            PortLabel.AutoSize = true;
            PortLabel.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PortLabel.Location = new Point(386, 18);
            PortLabel.Name = "PortLabel";
            PortLabel.Size = new Size(51, 28);
            PortLabel.TabIndex = 1;
            PortLabel.Text = "Port";
            // 
            // IPTextBox
            // 
            IPTextBox.Font = new Font("Comic Sans MS", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            IPTextBox.Location = new Point(26, 58);
            IPTextBox.Multiline = true;
            IPTextBox.Name = "IPTextBox";
            IPTextBox.Size = new Size(287, 45);
            IPTextBox.TabIndex = 2;
            IPTextBox.Text = "127.0.0.1";
            IPTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // PortTextBox
            // 
            PortTextBox.Font = new Font("Comic Sans MS", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PortTextBox.Location = new Point(386, 58);
            PortTextBox.Multiline = true;
            PortTextBox.Name = "PortTextBox";
            PortTextBox.Size = new Size(183, 45);
            PortTextBox.TabIndex = 3;
            PortTextBox.Text = "8080";
            PortTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // MessageLabel
            // 
            MessageLabel.AutoSize = true;
            MessageLabel.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MessageLabel.Location = new Point(26, 151);
            MessageLabel.Name = "MessageLabel";
            MessageLabel.Size = new Size(93, 28);
            MessageLabel.TabIndex = 4;
            MessageLabel.Text = "Message";
            // 
            // MessageTextBox
            // 
            MessageTextBox.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MessageTextBox.Location = new Point(26, 192);
            MessageTextBox.Multiline = true;
            MessageTextBox.Name = "MessageTextBox";
            MessageTextBox.Size = new Size(543, 145);
            MessageTextBox.TabIndex = 5;
            // 
            // sendButton
            // 
            sendButton.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            sendButton.Location = new Point(25, 363);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(94, 29);
            sendButton.TabIndex = 6;
            sendButton.Text = "Send";
            sendButton.UseVisualStyleBackColor = true;
            sendButton.Click += sendButton_Click;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(603, 416);
            Controls.Add(sendButton);
            Controls.Add(MessageTextBox);
            Controls.Add(MessageLabel);
            Controls.Add(PortTextBox);
            Controls.Add(IPTextBox);
            Controls.Add(PortLabel);
            Controls.Add(IPLabel);
            Name = "Client";
            Text = "UDP Client";
            FormClosing += Client_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label IPLabel;
        private Label PortLabel;
        private TextBox IPTextBox;
        private TextBox PortTextBox;
        private Label MessageLabel;
        private TextBox MessageTextBox;
        private Button sendButton;
    }
}