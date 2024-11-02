namespace Server
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
            ipBox = new TextBox();
            fileNotificationLabel = new Label();
            fileNameLabel = new Label();
            clearButton = new Button();
            sendFileButton = new Button();
            browseButton = new Button();
            notificationTempLabel = new Label();
            columnHeader2 = new ColumnHeader();
            InsertIPLabel = new Label();
            columnHeader1 = new ColumnHeader();
            onlinePCList = new ListView();
            savePathLabel = new Label();
            infoLabel = new Label();
            notificationLabel = new Label();
            stopButton = new Button();
            changeSaveLocButton = new Button();
            exitButton = new Button();
            startButton = new Button();
            notificationPanel = new Panel();
            timer1 = new System.Windows.Forms.Timer(components);
            notificationPanel.SuspendLayout();
            SuspendLayout();
            // 
            // ipBox
            // 
            ipBox.Location = new Point(107, 76);
            ipBox.Name = "ipBox";
            ipBox.Size = new Size(176, 23);
            ipBox.TabIndex = 31;
            // 
            // fileNotificationLabel
            // 
            fileNotificationLabel.AutoSize = true;
            fileNotificationLabel.Location = new Point(12, 135);
            fileNotificationLabel.Name = "fileNotificationLabel";
            fileNotificationLabel.Size = new Size(10, 15);
            fileNotificationLabel.TabIndex = 29;
            fileNotificationLabel.Text = ".";
            // 
            // fileNameLabel
            // 
            fileNameLabel.AutoSize = true;
            fileNameLabel.Location = new Point(12, 162);
            fileNameLabel.Name = "fileNameLabel";
            fileNameLabel.Size = new Size(10, 15);
            fileNameLabel.TabIndex = 28;
            fileNameLabel.Text = ".";
            // 
            // clearButton
            // 
            clearButton.Location = new Point(459, 180);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(143, 46);
            clearButton.TabIndex = 27;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // sendFileButton
            // 
            sendFileButton.Location = new Point(140, 180);
            sendFileButton.Name = "sendFileButton";
            sendFileButton.Size = new Size(322, 46);
            sendFileButton.TabIndex = 26;
            sendFileButton.Text = "Send File to Selected Computer";
            sendFileButton.UseVisualStyleBackColor = true;
            sendFileButton.Click += sendFileButton_Click;
            // 
            // browseButton
            // 
            browseButton.Location = new Point(0, 180);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(143, 46);
            browseButton.TabIndex = 25;
            browseButton.Text = "Browse";
            browseButton.UseVisualStyleBackColor = true;
            browseButton.Click += browseButton_Click;
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
            // columnHeader2
            // 
            columnHeader2.Text = "Computer Name";
            columnHeader2.Width = 263;
            // 
            // InsertIPLabel
            // 
            InsertIPLabel.AutoSize = true;
            InsertIPLabel.Location = new Point(0, 79);
            InsertIPLabel.Name = "InsertIPLabel";
            InsertIPLabel.Size = new Size(104, 15);
            InsertIPLabel.TabIndex = 30;
            InsertIPLabel.Text = "Insert receiver's IP:";
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "IP Address";
            columnHeader1.Width = 271;
            // 
            // onlinePCList
            // 
            onlinePCList.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            onlinePCList.Location = new Point(140, 119);
            onlinePCList.Name = "onlinePCList";
            onlinePCList.Size = new Size(322, 10);
            onlinePCList.TabIndex = 24;
            onlinePCList.UseCompatibleStateImageBehavior = false;
            // 
            // savePathLabel
            // 
            savePathLabel.AutoSize = true;
            savePathLabel.Location = new Point(279, 49);
            savePathLabel.Name = "savePathLabel";
            savePathLabel.Size = new Size(10, 15);
            savePathLabel.TabIndex = 23;
            savePathLabel.Text = ".";
            // 
            // infoLabel
            // 
            infoLabel.AutoSize = true;
            infoLabel.Location = new Point(140, 49);
            infoLabel.Name = "infoLabel";
            infoLabel.Size = new Size(10, 15);
            infoLabel.TabIndex = 22;
            infoLabel.Text = ".";
            // 
            // notificationLabel
            // 
            notificationLabel.AutoSize = true;
            notificationLabel.Location = new Point(0, 49);
            notificationLabel.Name = "notificationLabel";
            notificationLabel.Size = new Size(10, 15);
            notificationLabel.TabIndex = 21;
            notificationLabel.Text = ".";
            // 
            // stopButton
            // 
            stopButton.Location = new Point(140, 0);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(143, 46);
            stopButton.TabIndex = 20;
            stopButton.Text = "Stop";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // changeSaveLocButton
            // 
            changeSaveLocButton.Location = new Point(279, 0);
            changeSaveLocButton.Name = "changeSaveLocButton";
            changeSaveLocButton.Size = new Size(183, 46);
            changeSaveLocButton.TabIndex = 19;
            changeSaveLocButton.Text = "Save Location";
            changeSaveLocButton.UseVisualStyleBackColor = true;
            changeSaveLocButton.Click += changeSaveLocButton_Click;
            // 
            // exitButton
            // 
            exitButton.Location = new Point(459, 0);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(143, 46);
            exitButton.TabIndex = 18;
            exitButton.Text = "Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // startButton
            // 
            startButton.Location = new Point(0, 0);
            startButton.Name = "startButton";
            startButton.Size = new Size(143, 46);
            startButton.TabIndex = 16;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // notificationPanel
            // 
            notificationPanel.Controls.Add(notificationTempLabel);
            notificationPanel.Location = new Point(223, 135);
            notificationPanel.Name = "notificationPanel";
            notificationPanel.Size = new Size(156, 37);
            notificationPanel.TabIndex = 17;
            // 
            // FileTransfer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(605, 231);
            Controls.Add(ipBox);
            Controls.Add(fileNotificationLabel);
            Controls.Add(fileNameLabel);
            Controls.Add(clearButton);
            Controls.Add(sendFileButton);
            Controls.Add(browseButton);
            Controls.Add(InsertIPLabel);
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
            Load += FileTransfer_Load;
            notificationPanel.ResumeLayout(false);
            notificationPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox ipBox;
        private Label fileNotificationLabel;
        private Label fileNameLabel;
        private Button clearButton;
        private Button sendFileButton;
        private Button browseButton;
        private Label notificationTempLabel;
        private ColumnHeader columnHeader2;
        private Label InsertIPLabel;
        private ColumnHeader columnHeader1;
        private ListView onlinePCList;
        private Label savePathLabel;
        private Label infoLabel;
        private Label notificationLabel;
        private Button stopButton;
        private Button changeSaveLocButton;
        private Button exitButton;
        private Button startButton;
        private Panel notificationPanel;
        private System.Windows.Forms.Timer timer1;
    }
}