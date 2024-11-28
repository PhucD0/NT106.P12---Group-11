namespace LAB3_Bai1
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
            PortTextBox = new TextBox();
            PortLabel = new Label();
            listenButton = new Button();
            ReceivedMessageLabel = new Label();
            MessageTextBox = new TextBox();
            SuspendLayout();
            // 
            // PortTextBox
            // 
            PortTextBox.Font = new Font("Comic Sans MS", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PortTextBox.Location = new Point(92, 18);
            PortTextBox.Multiline = true;
            PortTextBox.Name = "PortTextBox";
            PortTextBox.Size = new Size(183, 45);
            PortTextBox.TabIndex = 5;
            PortTextBox.Text = "8080";
            PortTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // PortLabel
            // 
            PortLabel.AutoSize = true;
            PortLabel.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PortLabel.Location = new Point(35, 26);
            PortLabel.Name = "PortLabel";
            PortLabel.Size = new Size(51, 28);
            PortLabel.TabIndex = 4;
            PortLabel.Text = "Port";
            // 
            // listenButton
            // 
            listenButton.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listenButton.Location = new Point(447, 20);
            listenButton.Name = "listenButton";
            listenButton.Size = new Size(94, 45);
            listenButton.TabIndex = 7;
            listenButton.Text = "Listen";
            listenButton.UseVisualStyleBackColor = true;
            listenButton.Click += listenButton_Click;
            // 
            // ReceivedMessageLabel
            // 
            ReceivedMessageLabel.AutoSize = true;
            ReceivedMessageLabel.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ReceivedMessageLabel.Location = new Point(35, 107);
            ReceivedMessageLabel.Name = "ReceivedMessageLabel";
            ReceivedMessageLabel.Size = new Size(190, 28);
            ReceivedMessageLabel.TabIndex = 8;
            ReceivedMessageLabel.Text = "Received messages";
            // 
            // MessageTextBox
            // 
            MessageTextBox.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MessageTextBox.Location = new Point(35, 138);
            MessageTextBox.Multiline = true;
            MessageTextBox.Name = "MessageTextBox";
            MessageTextBox.ScrollBars = ScrollBars.Both;
            MessageTextBox.Size = new Size(506, 300);
            MessageTextBox.TabIndex = 9;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 450);
            Controls.Add(MessageTextBox);
            Controls.Add(ReceivedMessageLabel);
            Controls.Add(listenButton);
            Controls.Add(PortTextBox);
            Controls.Add(PortLabel);
            Name = "Server";
            Text = "UDP Server";
            FormClosing += Server_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox PortTextBox;
        private Label PortLabel;
        private Button listenButton;
        private Label ReceivedMessageLabel;
        private TextBox MessageTextBox;
    }
}