namespace PictureViewer
{
    partial class Form1
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
            ImageList = new ListView();
            MainPictureBox = new PictureBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            openFileToolStripMenuItem = new ToolStripMenuItem();
            previousButton = new Button();
            nextButton = new Button();
            openFileDialog1 = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)MainPictureBox).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ImageList
            // 
            ImageList.Location = new Point(632, 24);
            ImageList.Name = "ImageList";
            ImageList.Size = new Size(156, 387);
            ImageList.TabIndex = 0;
            ImageList.UseCompatibleStateImageBehavior = false;
            ImageList.ItemSelectionChanged += ImageList_ItemSelectionChanged;
            // 
            // MainPictureBox
            // 
            MainPictureBox.Location = new Point(12, 24);
            MainPictureBox.Name = "MainPictureBox";
            MainPictureBox.Size = new Size(614, 387);
            MainPictureBox.TabIndex = 1;
            MainPictureBox.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.White;
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, openFileToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(180, 22);
            openToolStripMenuItem.Text = "Open Directory";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // openFileToolStripMenuItem
            // 
            openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            openFileToolStripMenuItem.Size = new Size(180, 22);
            openFileToolStripMenuItem.Text = "Open File";
            openFileToolStripMenuItem.Click += openFileToolStripMenuItem_Click;
            // 
            // previousButton
            // 
            previousButton.Location = new Point(245, 417);
            previousButton.Name = "previousButton";
            previousButton.Size = new Size(75, 23);
            previousButton.TabIndex = 3;
            previousButton.Text = "Previous";
            previousButton.UseVisualStyleBackColor = true;
            previousButton.Click += navigationButton_Click;
            previousButton.KeyDown += navigationButton_KeyDown;
            // 
            // nextButton
            // 
            nextButton.Location = new Point(326, 417);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(75, 23);
            nextButton.TabIndex = 4;
            nextButton.Text = "Next";
            nextButton.UseVisualStyleBackColor = true;
            nextButton.Click += navigationButton_Click;
            nextButton.KeyDown += navigationbutton_KeyDown;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(nextButton);
            Controls.Add(previousButton);
            Controls.Add(MainPictureBox);
            Controls.Add(ImageList);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Picture Viewer";
            ((System.ComponentModel.ISupportInitialize)MainPictureBox).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void navigationbutton_KeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private ListView ImageList;
        private PictureBox MainPictureBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private Button previousButton;
        private Button nextButton;
        private OpenFileDialog openFileDialog1;
        private ToolStripMenuItem openFileToolStripMenuItem;
    }
}
