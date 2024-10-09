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
            components = new System.ComponentModel.Container();
            Label_IP = new Label();
            TextboxIP = new TextBox();
            LabelName = new Label();
            TextboxName = new TextBox();
            ButtonConnect = new Button();
            ButtonPrivateRoom = new Button();
            textBox1 = new TextBox();
            labelMessage = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            textBox2 = new TextBox();
            ButtonSend = new Button();
            ButtonSendFile = new Button();
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
            // TextboxName
            // 
            TextboxName.Location = new Point(291, 10);
            TextboxName.Name = "TextboxName";
            TextboxName.Size = new Size(126, 23);
            TextboxName.TabIndex = 5;
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
            // 
            // ButtonPrivateRoom
            // 
            ButtonPrivateRoom.Font = new Font("Segoe UI", 11F);
            ButtonPrivateRoom.Location = new Point(442, 8);
            ButtonPrivateRoom.Name = "ButtonPrivateRoom";
            ButtonPrivateRoom.Size = new Size(167, 27);
            ButtonPrivateRoom.TabIndex = 7;
            ButtonPrivateRoom.Text = "Private Chat Room";
            ButtonPrivateRoom.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(6, 46);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Both;
            textBox1.Size = new Size(782, 300);
            textBox1.TabIndex = 8;
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
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // textBox2
            // 
            textBox2.Location = new Point(6, 369);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ScrollBars = ScrollBars.Both;
            textBox2.Size = new Size(603, 60);
            textBox2.TabIndex = 11;
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
            // Client
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ButtonSendFile);
            Controls.Add(ButtonSend);
            Controls.Add(textBox2);
            Controls.Add(labelMessage);
            Controls.Add(textBox1);
            Controls.Add(ButtonPrivateRoom);
            Controls.Add(ButtonConnect);
            Controls.Add(TextboxName);
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
        private TextBox TextboxName;
        private Button ButtonConnect;
        private Button ButtonPrivateRoom;
        private TextBox textBox1;
        private Label labelMessage;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox textBox2;
        private Button ButtonSend;
        private Button ButtonSendFile;
    }
}
