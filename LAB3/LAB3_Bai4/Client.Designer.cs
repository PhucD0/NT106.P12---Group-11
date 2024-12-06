namespace LAB3_Bai4
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
            textboxShowMessage = new TextBox();
            listviewParticipant = new ListView();
            lableParticipant = new Label();
            labelYourName = new Label();
            textboxYourName = new TextBox();
            buttonConnect = new Button();
            labelMessage = new Label();
            textboxMessage = new TextBox();
            buttonSend = new Button();
            labelServerIP = new Label();
            textboxServerIP = new TextBox();
            textboxRecipient = new TextBox();
            labelReceiver = new Label();
            checkboxPrivate = new CheckBox();
            buttonSendFile = new Button();
            SuspendLayout();
            // 
            // textboxShowMessage
            // 
            textboxShowMessage.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textboxShowMessage.Location = new Point(3, 55);
            textboxShowMessage.Margin = new Padding(3, 4, 3, 4);
            textboxShowMessage.Multiline = true;
            textboxShowMessage.Name = "textboxShowMessage";
            textboxShowMessage.ScrollBars = ScrollBars.Both;
            textboxShowMessage.Size = new Size(646, 308);
            textboxShowMessage.TabIndex = 0;
            // 
            // listviewParticipant
            // 
            listviewParticipant.Location = new Point(657, 55);
            listviewParticipant.Margin = new Padding(3, 4, 3, 4);
            listviewParticipant.Name = "listviewParticipant";
            listviewParticipant.Size = new Size(243, 528);
            listviewParticipant.TabIndex = 1;
            listviewParticipant.UseCompatibleStateImageBehavior = false;
            // 
            // lableParticipant
            // 
            lableParticipant.AutoSize = true;
            lableParticipant.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lableParticipant.Location = new Point(731, 21);
            lableParticipant.Name = "lableParticipant";
            lableParticipant.Size = new Size(113, 28);
            lableParticipant.TabIndex = 2;
            lableParticipant.Text = "Participants";
            // 
            // labelYourName
            // 
            labelYourName.AutoSize = true;
            labelYourName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelYourName.Location = new Point(3, 372);
            labelYourName.Name = "labelYourName";
            labelYourName.Size = new Size(112, 28);
            labelYourName.TabIndex = 3;
            labelYourName.Text = "Your Name:";
            // 
            // textboxYourName
            // 
            textboxYourName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textboxYourName.Location = new Point(3, 404);
            textboxYourName.Margin = new Padding(3, 4, 3, 4);
            textboxYourName.Multiline = true;
            textboxYourName.Name = "textboxYourName";
            textboxYourName.Size = new Size(190, 41);
            textboxYourName.TabIndex = 4;
            // 
            // buttonConnect
            // 
            buttonConnect.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonConnect.Location = new Point(547, 3);
            buttonConnect.Margin = new Padding(3, 4, 3, 4);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Size = new Size(103, 44);
            buttonConnect.TabIndex = 5;
            buttonConnect.Text = "Connect";
            buttonConnect.UseVisualStyleBackColor = true;
            buttonConnect.Click += buttonConnect_Click;
            // 
            // labelMessage
            // 
            labelMessage.AutoSize = true;
            labelMessage.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelMessage.Location = new Point(5, 455);
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new Size(92, 28);
            labelMessage.TabIndex = 6;
            labelMessage.Text = "Message:";
            // 
            // textboxMessage
            // 
            textboxMessage.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textboxMessage.Location = new Point(3, 488);
            textboxMessage.Margin = new Padding(3, 4, 3, 4);
            textboxMessage.Multiline = true;
            textboxMessage.Name = "textboxMessage";
            textboxMessage.Size = new Size(499, 95);
            textboxMessage.TabIndex = 7;
            // 
            // buttonSend
            // 
            buttonSend.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonSend.Location = new Point(527, 488);
            buttonSend.Margin = new Padding(3, 4, 3, 4);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(103, 44);
            buttonSend.TabIndex = 8;
            buttonSend.Text = "Send";
            buttonSend.UseVisualStyleBackColor = true;
            buttonSend.Click += buttonSend_Click;
            // 
            // labelServerIP
            // 
            labelServerIP.AutoSize = true;
            labelServerIP.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelServerIP.Location = new Point(3, 12);
            labelServerIP.Name = "labelServerIP";
            labelServerIP.Size = new Size(92, 28);
            labelServerIP.TabIndex = 9;
            labelServerIP.Text = "Server IP:";
            // 
            // textboxServerIP
            // 
            textboxServerIP.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textboxServerIP.Location = new Point(96, 7);
            textboxServerIP.Margin = new Padding(3, 4, 3, 4);
            textboxServerIP.Multiline = true;
            textboxServerIP.Name = "textboxServerIP";
            textboxServerIP.Size = new Size(239, 39);
            textboxServerIP.TabIndex = 10;
            // 
            // textboxRecipient
            // 
            textboxRecipient.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textboxRecipient.Location = new Point(311, 404);
            textboxRecipient.Margin = new Padding(3, 4, 3, 4);
            textboxRecipient.Multiline = true;
            textboxRecipient.Name = "textboxRecipient";
            textboxRecipient.Size = new Size(190, 41);
            textboxRecipient.TabIndex = 12;
            // 
            // labelReceiver
            // 
            labelReceiver.AutoSize = true;
            labelReceiver.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelReceiver.Location = new Point(311, 372);
            labelReceiver.Name = "labelReceiver";
            labelReceiver.Size = new Size(36, 28);
            labelReceiver.TabIndex = 11;
            labelReceiver.Text = "To:";
            // 
            // checkboxPrivate
            // 
            checkboxPrivate.AutoSize = true;
            checkboxPrivate.Location = new Point(338, 455);
            checkboxPrivate.Margin = new Padding(3, 4, 3, 4);
            checkboxPrivate.Name = "checkboxPrivate";
            checkboxPrivate.Size = new Size(151, 24);
            checkboxPrivate.TabIndex = 13;
            checkboxPrivate.Text = "Private messaging";
            checkboxPrivate.UseVisualStyleBackColor = true;
            // 
            // buttonSendFile
            // 
            buttonSendFile.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonSendFile.Location = new Point(527, 539);
            buttonSendFile.Margin = new Padding(3, 4, 3, 4);
            buttonSendFile.Name = "buttonSendFile";
            buttonSendFile.Size = new Size(103, 44);
            buttonSendFile.TabIndex = 14;
            buttonSendFile.Text = "Send File";
            buttonSendFile.UseVisualStyleBackColor = true;
            buttonSendFile.Click += buttonSendFile_Click;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(buttonSendFile);
            Controls.Add(checkboxPrivate);
            Controls.Add(textboxRecipient);
            Controls.Add(labelReceiver);
            Controls.Add(textboxServerIP);
            Controls.Add(labelServerIP);
            Controls.Add(buttonSend);
            Controls.Add(textboxMessage);
            Controls.Add(labelMessage);
            Controls.Add(buttonConnect);
            Controls.Add(textboxYourName);
            Controls.Add(labelYourName);
            Controls.Add(lableParticipant);
            Controls.Add(listviewParticipant);
            Controls.Add(textboxShowMessage);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Client";
            Text = "Client";
            FormClosing += Client_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textboxShowMessage;
        private ListView listviewParticipant;
        private Label lableParticipant;
        private Label labelYourName;
        private TextBox textboxYourName;
        private Button buttonConnect;
        private Label labelMessage;
        private TextBox textboxMessage;
        private Button buttonSend;
        private Label labelServerIP;
        private TextBox textboxServerIP;
        private TextBox textboxRecipient;
        private Label labelReceiver;
        private CheckBox checkboxPrivate;
        private Button buttonSendFile;
    }
}