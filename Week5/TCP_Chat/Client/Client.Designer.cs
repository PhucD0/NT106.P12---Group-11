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
            Label_IP = new Label();
            TextboxIP = new TextBox();
            LabelName = new Label();
            TextboxUsername = new TextBox();
            ButtonConnect = new Button();
            TextboxConversation = new TextBox();
            labelMessage = new Label();
            TextboxMessage = new TextBox();
            ButtonSend = new Button();
            ButtonSendFile = new Button();
            textBox1 = new TextBox();
            LabelTo = new Label();
            SuspendLayout();
            // 
            // Label_IP
            // 
            Label_IP.AutoSize = true;
            Label_IP.Font = new Font("Segoe UI", 12F);
            Label_IP.Location = new Point(6, 8);
            Label_IP.Name = "Label_IP";
            Label_IP.Size = new Size(86, 21);
            Label_IP.TabIndex = 3;
            Label_IP.Text = "IP Address:";
            // 
            // TextboxIP
            // 
            TextboxIP.Location = new Point(98, 8);
            TextboxIP.Name = "TextboxIP";
            TextboxIP.Size = new Size(126, 23);
            TextboxIP.TabIndex = 2;
            TextboxIP.Text = "127.0.0.1";
            // 
            // LabelName
            // 
            LabelName.AutoSize = true;
            LabelName.Font = new Font("Segoe UI", 12F);
            LabelName.Location = new Point(230, 10);
            LabelName.Name = "LabelName";
            LabelName.Size = new Size(55, 21);
            LabelName.TabIndex = 4;
            LabelName.Text = "Name:";
            // 
            // TextboxUsername
            // 
            TextboxUsername.Location = new Point(291, 10);
            TextboxUsername.Name = "TextboxUsername";
            TextboxUsername.Size = new Size(126, 23);
            TextboxUsername.TabIndex = 5;
            // 
            // ButtonConnect
            // 
            ButtonConnect.Font = new Font("Segoe UI", 11F);
            ButtonConnect.Location = new Point(615, 8);
            ButtonConnect.Name = "ButtonConnect";
            ButtonConnect.Size = new Size(152, 27);
            ButtonConnect.TabIndex = 6;
            ButtonConnect.Text = "Connect";
            ButtonConnect.UseVisualStyleBackColor = true;
            ButtonConnect.Click += ButtonConnect_Click;
            // 
            // TextboxConversation
            // 
            TextboxConversation.Location = new Point(6, 46);
            TextboxConversation.Multiline = true;
            TextboxConversation.Name = "TextboxConversation";
            TextboxConversation.ScrollBars = ScrollBars.Both;
            TextboxConversation.Size = new Size(782, 300);
            TextboxConversation.TabIndex = 8;
            // 
            // labelMessage
            // 
            labelMessage.AutoSize = true;
            labelMessage.Font = new Font("Segoe UI", 11F);
            labelMessage.Location = new Point(6, 348);
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new Size(70, 20);
            labelMessage.TabIndex = 9;
            labelMessage.Text = "Message:";
            // 
            // TextboxMessage
            // 
            TextboxMessage.Location = new Point(6, 369);
            TextboxMessage.Multiline = true;
            TextboxMessage.Name = "TextboxMessage";
            TextboxMessage.ScrollBars = ScrollBars.Both;
            TextboxMessage.Size = new Size(603, 60);
            TextboxMessage.TabIndex = 11;
            // 
            // ButtonSend
            // 
            ButtonSend.Font = new Font("Segoe UI", 11F);
            ButtonSend.Location = new Point(615, 369);
            ButtonSend.Name = "ButtonSend";
            ButtonSend.Size = new Size(167, 27);
            ButtonSend.TabIndex = 12;
            ButtonSend.Text = "Send";
            ButtonSend.UseVisualStyleBackColor = true;
            ButtonSend.Click += ButtonSend_Click;
            // 
            // ButtonSendFile
            // 
            ButtonSendFile.Font = new Font("Segoe UI", 11F);
            ButtonSendFile.Location = new Point(615, 402);
            ButtonSendFile.Name = "ButtonSendFile";
            ButtonSendFile.Size = new Size(167, 27);
            ButtonSendFile.TabIndex = 13;
            ButtonSendFile.Text = "Send File";
            ButtonSendFile.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(476, 10);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(126, 23);
            textBox1.TabIndex = 15;
            // 
            // LabelTo
            // 
            LabelTo.AutoSize = true;
            LabelTo.Font = new Font("Segoe UI", 12F);
            LabelTo.Location = new Point(439, 9);
            LabelTo.Name = "LabelTo";
            LabelTo.Size = new Size(28, 21);
            LabelTo.TabIndex = 14;
            LabelTo.Text = "To:";
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(LabelTo);
            Controls.Add(ButtonSendFile);
            Controls.Add(ButtonSend);
            Controls.Add(TextboxMessage);
            Controls.Add(labelMessage);
            Controls.Add(TextboxConversation);
            Controls.Add(ButtonConnect);
            Controls.Add(TextboxUsername);
            Controls.Add(LabelName);
            Controls.Add(Label_IP);
            Controls.Add(TextboxIP);
            Name = "Client";
            Text = "Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Label_IP;
        private TextBox TextboxIP;
        private Label LabelName;
        private TextBox TextboxUsername;
        private Button ButtonConnect;
        private TextBox TextboxConversation;
        private Label labelMessage;
        private TextBox TextboxMessage;
        private Button ButtonSend;
        private Button ButtonSendFile;
        private TextBox textBox1;
        private Label LabelTo;
    }
}
