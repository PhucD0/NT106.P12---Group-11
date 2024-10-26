namespace LAB2_Bai01
{
    partial class Lab02_Bai05
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
            this.DirectoryView = new System.Windows.Forms.TreeView();
            this.RichTextBox_FileContent = new System.Windows.Forms.RichTextBox();
            this.Label_FileContent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DirectoryView
            // 
            this.DirectoryView.Location = new System.Drawing.Point(0, 12);
            this.DirectoryView.Name = "DirectoryView";
            this.DirectoryView.Size = new System.Drawing.Size(186, 354);
            this.DirectoryView.TabIndex = 0;
            this.DirectoryView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.DirectoryView_BeforeExpand);
            this.DirectoryView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.DirectoryView_AfterSelect_1);
            // 
            // RichTextBox_FileContent
            // 
            this.RichTextBox_FileContent.Location = new System.Drawing.Point(195, 12);
            this.RichTextBox_FileContent.Name = "RichTextBox_FileContent";
            this.RichTextBox_FileContent.Size = new System.Drawing.Size(406, 354);
            this.RichTextBox_FileContent.TabIndex = 1;
            this.RichTextBox_FileContent.Text = "";
            // 
            // Label_FileContent
            // 
            this.Label_FileContent.AutoSize = true;
            this.Label_FileContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Label_FileContent.Location = new System.Drawing.Point(192, 3);
            this.Label_FileContent.Name = "Label_FileContent";
            this.Label_FileContent.Size = new System.Drawing.Size(83, 17);
            this.Label_FileContent.TabIndex = 2;
            this.Label_FileContent.Text = "File Content";
            // 
            // Lab02_Bai05
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.Label_FileContent);
            this.Controls.Add(this.RichTextBox_FileContent);
            this.Controls.Add(this.DirectoryView);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Lab02_Bai05";
            this.Text = "Lab02_Bai05";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Lab02_Bai05_FormClosing);
            this.Load += new System.EventHandler(this.Lab02_Bai05_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView DirectoryView;
        private System.Windows.Forms.RichTextBox RichTextBox_FileContent;
        private System.Windows.Forms.Label Label_FileContent;
    }
}