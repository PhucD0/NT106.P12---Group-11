namespace FileTransfer
{
    partial class mainForm
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
            startButton = new Button();
            stopButton = new Button();
            changeSaveLocButton = new Button();
            exitButton = new Button();
            notificationLabel = new Label();
            infoLabel = new Label();
            savePathLabel = new Label();
            onlinePCList = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            notificationPanel = new Panel();
            notificationTempLabel = new Label();
            fileNotificationLabel = new Label();
            fileNameLabel = new Label();
            browseButton = new Button();
            label1 = new Label();
            ipBox = new TextBox();
            sendFileButton = new Button();
            clearButton = new Button();
            notificationPanel.SuspendLayout();
            SuspendLayout();
            // 
            // startButton
            // 
            startButton.BackColor = Color.FromArgb(255, 192, 128);
            startButton.Font = new Font("Snap ITC", 12F, FontStyle.Bold | FontStyle.Italic);
            startButton.Location = new Point(0, 0);
            startButton.Margin = new Padding(3, 4, 3, 4);
            startButton.Name = "startButton";
            startButton.Size = new Size(173, 64);
            startButton.TabIndex = 0;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = false;
            startButton.Click += startButton_Click;
            // 
            // stopButton
            // 
            stopButton.BackColor = Color.FromArgb(255, 192, 128);
            stopButton.Font = new Font("Snap ITC", 12F, FontStyle.Bold | FontStyle.Italic);
            stopButton.Location = new Point(169, 0);
            stopButton.Margin = new Padding(3, 4, 3, 4);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(173, 64);
            stopButton.TabIndex = 1;
            stopButton.Text = "Stop";
            stopButton.UseVisualStyleBackColor = false;
            stopButton.Click += stopButton_Click;
            // 
            // changeSaveLocButton
            // 
            changeSaveLocButton.BackColor = Color.FromArgb(255, 192, 128);
            changeSaveLocButton.Font = new Font("Snap ITC", 12F, FontStyle.Bold | FontStyle.Italic);
            changeSaveLocButton.Location = new Point(338, 0);
            changeSaveLocButton.Margin = new Padding(3, 4, 3, 4);
            changeSaveLocButton.Name = "changeSaveLocButton";
            changeSaveLocButton.Size = new Size(247, 64);
            changeSaveLocButton.TabIndex = 2;
            changeSaveLocButton.Text = "Save Location";
            changeSaveLocButton.UseVisualStyleBackColor = false;
            changeSaveLocButton.Click += changeSaveLocButton_Click;
            // 
            // exitButton
            // 
            exitButton.BackColor = Color.FromArgb(255, 192, 128);
            exitButton.Font = new Font("Snap ITC", 12F, FontStyle.Bold | FontStyle.Italic);
            exitButton.Location = new Point(582, 0);
            exitButton.Margin = new Padding(3, 4, 3, 4);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(173, 64);
            exitButton.TabIndex = 3;
            exitButton.Text = "Exit";
            exitButton.UseVisualStyleBackColor = false;
            exitButton.Click += exitButton_Click;
            // 
            // notificationLabel
            // 
            notificationLabel.AutoSize = true;
            notificationLabel.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            notificationLabel.Location = new Point(0, 68);
            notificationLabel.Name = "notificationLabel";
            notificationLabel.Size = new Size(17, 21);
            notificationLabel.TabIndex = 4;
            notificationLabel.Text = ".";
            // 
            // infoLabel
            // 
            infoLabel.AutoSize = true;
            infoLabel.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            infoLabel.Location = new Point(169, 68);
            infoLabel.Name = "infoLabel";
            infoLabel.Size = new Size(17, 21);
            infoLabel.TabIndex = 5;
            infoLabel.Text = ".";
            // 
            // savePathLabel
            // 
            savePathLabel.AutoSize = true;
            savePathLabel.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            savePathLabel.Location = new Point(338, 68);
            savePathLabel.Name = "savePathLabel";
            savePathLabel.Size = new Size(201, 20);
            savePathLabel.TabIndex = 6;
            savePathLabel.Text = "C:\\Users\\Public\\Downloads";
            // 
            // onlinePCList
            // 
            onlinePCList.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            onlinePCList.Font = new Font("Snap ITC", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            onlinePCList.Location = new Point(223, 119);
            onlinePCList.Margin = new Padding(3, 4, 3, 4);
            onlinePCList.Name = "onlinePCList";
            onlinePCList.Size = new Size(316, 299);
            onlinePCList.TabIndex = 7;
            onlinePCList.UseCompatibleStateImageBehavior = false;
            onlinePCList.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "IP Address";
            columnHeader1.Width = 271;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Computer Name";
            columnHeader2.Width = 263;
            // 
            // notificationPanel
            // 
            notificationPanel.BackColor = Color.FromArgb(255, 192, 128);
            notificationPanel.Controls.Add(notificationTempLabel);
            notificationPanel.Location = new Point(77, 231);
            notificationPanel.Margin = new Padding(3, 4, 3, 4);
            notificationPanel.Name = "notificationPanel";
            notificationPanel.Size = new Size(585, 111);
            notificationPanel.TabIndex = 8;
            // 
            // notificationTempLabel
            // 
            notificationTempLabel.AutoSize = true;
            notificationTempLabel.Font = new Font("Comic Sans MS", 10F);
            notificationTempLabel.Location = new Point(3, 41);
            notificationTempLabel.Name = "notificationTempLabel";
            notificationTempLabel.Size = new Size(229, 24);
            notificationTempLabel.TabIndex = 7;
            notificationTempLabel.Text = "Please wait. File Sending to";
            // 
            // fileNotificationLabel
            // 
            fileNotificationLabel.AutoSize = true;
            fileNotificationLabel.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fileNotificationLabel.ForeColor = Color.FromArgb(255, 128, 0);
            fileNotificationLabel.Location = new Point(0, 433);
            fileNotificationLabel.Name = "fileNotificationLabel";
            fileNotificationLabel.Size = new Size(12, 20);
            fileNotificationLabel.TabIndex = 9;
            fileNotificationLabel.Text = ".";
            // 
            // fileNameLabel
            // 
            fileNameLabel.AutoSize = true;
            fileNameLabel.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fileNameLabel.ForeColor = Color.FromArgb(192, 64, 0);
            fileNameLabel.Location = new Point(0, 476);
            fileNameLabel.Name = "fileNameLabel";
            fileNameLabel.Size = new Size(12, 20);
            fileNameLabel.TabIndex = 10;
            fileNameLabel.Text = ".";
            // 
            // browseButton
            // 
            browseButton.BackColor = Color.FromArgb(255, 192, 128);
            browseButton.Font = new Font("Snap ITC", 12F, FontStyle.Bold | FontStyle.Italic);
            browseButton.Location = new Point(0, 507);
            browseButton.Margin = new Padding(3, 4, 3, 4);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(173, 64);
            browseButton.TabIndex = 11;
            browseButton.Text = "Browse";
            browseButton.UseVisualStyleBackColor = false;
            browseButton.Click += browseButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(184, 500);
            label1.Name = "label1";
            label1.Size = new Size(148, 20);
            label1.TabIndex = 12;
            label1.Text = "Insert receiver's IP";
            // 
            // ipBox
            // 
            ipBox.Location = new Point(173, 527);
            ipBox.Margin = new Padding(3, 4, 3, 4);
            ipBox.Multiline = true;
            ipBox.Name = "ipBox";
            ipBox.Size = new Size(169, 39);
            ipBox.TabIndex = 13;
            // 
            // sendFileButton
            // 
            sendFileButton.BackColor = Color.FromArgb(255, 192, 128);
            sendFileButton.Font = new Font("Snap ITC", 12F, FontStyle.Bold | FontStyle.Italic);
            sendFileButton.Location = new Point(338, 505);
            sendFileButton.Margin = new Padding(3, 4, 3, 4);
            sendFileButton.Name = "sendFileButton";
            sendFileButton.Size = new Size(247, 64);
            sendFileButton.TabIndex = 14;
            sendFileButton.Text = "Send File";
            sendFileButton.UseVisualStyleBackColor = false;
            sendFileButton.Click += sendFileButton_Click;
            // 
            // clearButton
            // 
            clearButton.BackColor = Color.FromArgb(255, 192, 128);
            clearButton.Font = new Font("Snap ITC", 12F, FontStyle.Bold | FontStyle.Italic);
            clearButton.Location = new Point(582, 505);
            clearButton.Margin = new Padding(3, 4, 3, 4);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(173, 64);
            clearButton.TabIndex = 15;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = false;
            clearButton.Click += clearButton_Click;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(754, 580);
            Controls.Add(clearButton);
            Controls.Add(sendFileButton);
            Controls.Add(ipBox);
            Controls.Add(label1);
            Controls.Add(browseButton);
            Controls.Add(fileNameLabel);
            Controls.Add(fileNotificationLabel);
            Controls.Add(notificationPanel);
            Controls.Add(onlinePCList);
            Controls.Add(savePathLabel);
            Controls.Add(infoLabel);
            Controls.Add(notificationLabel);
            Controls.Add(exitButton);
            Controls.Add(changeSaveLocButton);
            Controls.Add(stopButton);
            Controls.Add(startButton);
            Margin = new Padding(3, 4, 3, 4);
            Name = "mainForm";
            Text = "File Transfer";
            FormClosing += mainForm_FormClosing;
            Load += mainForm_Load;
            notificationPanel.ResumeLayout(false);
            notificationPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button startButton;
        private Button stopButton;
        private Button changeSaveLocButton;
        private Button exitButton;
        private Label notificationLabel;
        private Label infoLabel;
        private Label savePathLabel;
        private ListView onlinePCList;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Panel notificationPanel;
        private Label notificationTempLabel;
        private Label fileNotificationLabel;
        private Label fileNameLabel;
        private Button browseButton;
        private Label label1;
        private TextBox ipBox;
        private Button sendFileButton;
        private Button clearButton;
    }
}
