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
            SuspendLayout();
            // 
            // textboxShowMessage
            // 
            textboxShowMessage.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textboxShowMessage.Location = new Point(3, 41);
            textboxShowMessage.Multiline = true;
            textboxShowMessage.Name = "textboxShowMessage";
            textboxShowMessage.ScrollBars = ScrollBars.Both;
            textboxShowMessage.Size = new Size(566, 232);
            textboxShowMessage.TabIndex = 0;
            // 
            // listviewParticipant
            // 
            listviewParticipant.Location = new Point(575, 41);
            listviewParticipant.Name = "listviewParticipant";
            listviewParticipant.Size = new Size(213, 397);
            listviewParticipant.TabIndex = 1;
            listviewParticipant.UseCompatibleStateImageBehavior = false;
            // 
            // lableParticipant
            // 
            lableParticipant.AutoSize = true;
            lableParticipant.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lableParticipant.Location = new Point(640, 16);
            lableParticipant.Name = "lableParticipant";
            lableParticipant.Size = new Size(90, 21);
            lableParticipant.TabIndex = 2;
            lableParticipant.Text = "Participants";
            // 
            // labelYourName
            // 
            labelYourName.AutoSize = true;
            labelYourName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelYourName.Location = new Point(3, 279);
            labelYourName.Name = "labelYourName";
            labelYourName.Size = new Size(91, 21);
            labelYourName.TabIndex = 3;
            labelYourName.Text = "Your Name:";
            // 
            // textboxYourName
            // 
            textboxYourName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textboxYourName.Location = new Point(3, 303);
            textboxYourName.Multiline = true;
            textboxYourName.Name = "textboxYourName";
            textboxYourName.Size = new Size(167, 32);
            textboxYourName.TabIndex = 4;
            // 
            // buttonConnect
            // 
            buttonConnect.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonConnect.Location = new Point(479, 2);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Size = new Size(90, 33);
            buttonConnect.TabIndex = 5;
            buttonConnect.Text = "Connect";
            buttonConnect.UseVisualStyleBackColor = true;
            buttonConnect.Click += buttonConnect_Click;
            // 
            // labelMessage
            // 
            labelMessage.AutoSize = true;
            labelMessage.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelMessage.Location = new Point(4, 341);
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new Size(74, 21);
            labelMessage.TabIndex = 6;
            labelMessage.Text = "Message:";
            // 
            // textboxMessage
            // 
            textboxMessage.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textboxMessage.Location = new Point(3, 366);
            textboxMessage.Multiline = true;
            textboxMessage.Name = "textboxMessage";
            textboxMessage.Size = new Size(437, 72);
            textboxMessage.TabIndex = 7;
            // 
            // buttonSend
            // 
            buttonSend.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonSend.Location = new Point(459, 383);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(90, 33);
            buttonSend.TabIndex = 8;
            buttonSend.Text = "Send";
            buttonSend.UseVisualStyleBackColor = true;
            buttonSend.Click += buttonSend_Click;
            // 
            // labelServerIP
            // 
            labelServerIP.AutoSize = true;
            labelServerIP.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelServerIP.Location = new Point(3, 9);
            labelServerIP.Name = "labelServerIP";
            labelServerIP.Size = new Size(75, 21);
            labelServerIP.TabIndex = 9;
            labelServerIP.Text = "Server IP:";
            // 
            // textboxServerIP
            // 
            textboxServerIP.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textboxServerIP.Location = new Point(84, 5);
            textboxServerIP.Multiline = true;
            textboxServerIP.Name = "textboxServerIP";
            textboxServerIP.Size = new Size(210, 30);
            textboxServerIP.TabIndex = 10;
            // 
            // textboxRecipient
            // 
            textboxRecipient.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textboxRecipient.Location = new Point(272, 303);
            textboxRecipient.Multiline = true;
            textboxRecipient.Name = "textboxRecipient";
            textboxRecipient.Size = new Size(167, 32);
            textboxRecipient.TabIndex = 12;
            // 
            // labelReceiver
            // 
            labelReceiver.AutoSize = true;
            labelReceiver.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelReceiver.Location = new Point(272, 279);
            labelReceiver.Name = "labelReceiver";
            labelReceiver.Size = new Size(28, 21);
            labelReceiver.TabIndex = 11;
            labelReceiver.Text = "To:";
            // 
            // checkboxPrivate
            // 
            checkboxPrivate.AutoSize = true;
            checkboxPrivate.Location = new Point(296, 341);
            checkboxPrivate.Name = "checkboxPrivate";
            checkboxPrivate.Size = new Size(122, 19);
            checkboxPrivate.TabIndex = 13;
            checkboxPrivate.Text = "Private messaging";
            checkboxPrivate.UseVisualStyleBackColor = true;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}