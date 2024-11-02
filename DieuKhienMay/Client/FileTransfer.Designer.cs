namespace Client
{
    partial class FileTransfer
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
            components = new System.ComponentModel.Container();
            notificationPanel = new Panel();
            notificationTempLabel = new Label();
            startButton = new Button();
            exitButton = new Button();
            changeSaveLocButton = new Button();
            stopButton = new Button();
            notificationLabel = new Label();
            infoLabel = new Label();
            savePathLabel = new Label();
            onlinePCList = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            browseButton = new Button();
            sendFileButton = new Button();
            clearButton = new Button();
            fileNameLabel = new Label();
            fileNotificationLabel = new Label();
            InsertIPLabel = new Label();
            ipBox = new TextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            notificationPanel.SuspendLayout();
            SuspendLayout();
            // 
            // notificationPanel
            // 
            notificationPanel.Controls.Add(notificationTempLabel);
            notificationPanel.Location = new Point(227, 135);
            notificationPanel.Name = "notificationPanel";
            notificationPanel.Size = new Size(156, 37);
            notificationPanel.TabIndex = 0;
            // 
            // notificationTempLabel
            // 
            notificationTempLabel.AutoSize = true;
            notificationTempLabel.Location = new Point(3, 10);
            notificationTempLabel.Name = "notificationTempLabel";
            notificationTempLabel.Size = new Size(149, 15);
            notificationTempLabel.TabIndex = 0;
            notificationTempLabel.Text = "Please wait. File Sending to";
            // 
            // startButton
            // 
            startButton.Location = new Point(0, 0);
            startButton.Name = "startButton";
            startButton.Size = new Size(143, 46);
            startButton.TabIndex = 0;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // exitButton
            // 
            exitButton.Location = new Point(459, 0);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(143, 46);
            exitButton.TabIndex = 1;
            exitButton.Text = "Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // changeSaveLocButton
            // 
            changeSaveLocButton.Location = new Point(279, 0);
            changeSaveLocButton.Name = "changeSaveLocButton";
            changeSaveLocButton.Size = new Size(183, 46);
            changeSaveLocButton.TabIndex = 2;
            changeSaveLocButton.Text = "Save Location";
            changeSaveLocButton.UseVisualStyleBackColor = true;
            changeSaveLocButton.Click += changeSaveLocButton_Click;
            // 
            // stopButton
            // 
            stopButton.Location = new Point(140, 0);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(143, 46);
            stopButton.TabIndex = 3;
            stopButton.Text = "Stop";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // notificationLabel
            // 
            notificationLabel.AutoSize = true;
            notificationLabel.Location = new Point(0, 49);
            notificationLabel.Name = "notificationLabel";
            notificationLabel.Size = new Size(10, 15);
            notificationLabel.TabIndex = 4;
            notificationLabel.Text = ".";
            // 
            // infoLabel
            // 
            infoLabel.AutoSize = true;
            infoLabel.Location = new Point(140, 49);
            infoLabel.Name = "infoLabel";
            infoLabel.Size = new Size(10, 15);
            infoLabel.TabIndex = 5;
            infoLabel.Text = ".";
            // 
            // savePathLabel
            // 
            savePathLabel.AutoSize = true;
            savePathLabel.Location = new Point(279, 49);
            savePathLabel.Name = "savePathLabel";
            savePathLabel.Size = new Size(10, 15);
            savePathLabel.TabIndex = 6;
            savePathLabel.Text = ".";
            // 
            // onlinePCList
            // 
            onlinePCList.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            onlinePCList.Location = new Point(140, 119);
            onlinePCList.Name = "onlinePCList";
            onlinePCList.Size = new Size(322, 10);
            onlinePCList.TabIndex = 7;
            onlinePCList.UseCompatibleStateImageBehavior = false;
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
            // browseButton
            // 
            browseButton.Location = new Point(9, 180);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(143, 46);
            browseButton.TabIndex = 8;
            browseButton.Text = "Browse";
            browseButton.UseVisualStyleBackColor = true;
            // 
            // sendFileButton
            // 
            sendFileButton.Location = new Point(149, 180);
            sendFileButton.Name = "sendFileButton";
            sendFileButton.Size = new Size(322, 46);
            sendFileButton.TabIndex = 9;
            sendFileButton.Text = "Send File to Selected Computer";
            sendFileButton.UseVisualStyleBackColor = true;
            sendFileButton.Click += sendFileButton_Click;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(468, 180);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(143, 46);
            clearButton.TabIndex = 10;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // fileNameLabel
            // 
            fileNameLabel.AutoSize = true;
            fileNameLabel.Location = new Point(21, 162);
            fileNameLabel.Name = "fileNameLabel";
            fileNameLabel.Size = new Size(10, 15);
            fileNameLabel.TabIndex = 12;
            fileNameLabel.Text = ".";
            // 
            // fileNotificationLabel
            // 
            fileNotificationLabel.AutoSize = true;
            fileNotificationLabel.Location = new Point(21, 135);
            fileNotificationLabel.Name = "fileNotificationLabel";
            fileNotificationLabel.Size = new Size(10, 15);
            fileNotificationLabel.TabIndex = 13;
            fileNotificationLabel.Text = ".";
            // 
            // InsertIPLabel
            // 
            InsertIPLabel.AutoSize = true;
            InsertIPLabel.Location = new Point(0, 79);
            InsertIPLabel.Name = "InsertIPLabel";
            InsertIPLabel.Size = new Size(104, 15);
            InsertIPLabel.TabIndex = 14;
            InsertIPLabel.Text = "Insert receiver's IP:";
            // 
            // ipBox
            // 
            ipBox.Location = new Point(107, 76);
            ipBox.Name = "ipBox";
            ipBox.Size = new Size(176, 23);
            ipBox.TabIndex = 15;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // FileTransfer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(609, 236);
            Controls.Add(ipBox);
            Controls.Add(InsertIPLabel);
            Controls.Add(fileNotificationLabel);
            Controls.Add(fileNameLabel);
            Controls.Add(clearButton);
            Controls.Add(sendFileButton);
            Controls.Add(browseButton);
            Controls.Add(onlinePCList);
            Controls.Add(savePathLabel);
            Controls.Add(infoLabel);
            Controls.Add(notificationLabel);
            Controls.Add(stopButton);
            Controls.Add(changeSaveLocButton);
            Controls.Add(exitButton);
            Controls.Add(startButton);
            Controls.Add(notificationPanel);
            Name = "FileTransfer";
            Text = "FileTransfer";
            FormClosing += FileTransfer_FormClosing;
            Load += FileTransfer_Load;
            notificationPanel.ResumeLayout(false);
            notificationPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel notificationPanel;
        private Button startButton;
        private Button exitButton;
        private Button changeSaveLocButton;
        private Button stopButton;
        private Label notificationLabel;
        private Label infoLabel;
        private Label savePathLabel;
        private ListView onlinePCList;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Label notificationTempLabel;
        private Button browseButton;
        private Button sendFileButton;
        private Button clearButton;
        private Label fileNameLabel;
        private Label fileNotificationLabel;
        private Label InsertIPLabel;
        private TextBox ipBox;
        private System.Windows.Forms.Timer timer1;
    }
}