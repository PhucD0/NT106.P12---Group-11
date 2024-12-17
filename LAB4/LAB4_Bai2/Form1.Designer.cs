namespace LAB4_Bai2
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
            btnDownload = new Button();
            txbUrl = new TextBox();
            txbFileUrl = new TextBox();
            rtbOutput = new RichTextBox();
            SuspendLayout();
            // 
            // btnDownload
            // 
            btnDownload.Location = new Point(622, 17);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(94, 29);
            btnDownload.TabIndex = 0;
            btnDownload.Text = "Download";
            btnDownload.UseVisualStyleBackColor = true;
            btnDownload.Click += btnDownload_Click;
            // 
            // txbUrl
            // 
            txbUrl.Location = new Point(28, 19);
            txbUrl.Name = "txbUrl";
            txbUrl.Size = new Size(576, 27);
            txbUrl.TabIndex = 1;
            txbUrl.Text = "https://uit.edu.vn/";
            // 
            // txbFileUrl
            // 
            txbFileUrl.Location = new Point(28, 70);
            txbFileUrl.Name = "txbFileUrl";
            txbFileUrl.Size = new Size(576, 27);
            txbFileUrl.TabIndex = 1;
            txbFileUrl.Text = "D:\\kudo\\NT106\\ThucHanh\\THUCHANH\\uit.html";
            // 
            // rtbOutput
            // 
            rtbOutput.Location = new Point(28, 119);
            rtbOutput.Name = "rtbOutput";
            rtbOutput.Size = new Size(688, 326);
            rtbOutput.TabIndex = 2;
            rtbOutput.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(750, 464);
            Controls.Add(rtbOutput);
            Controls.Add(txbFileUrl);
            Controls.Add(txbUrl);
            Controls.Add(btnDownload);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDownload;
        private TextBox txbUrl;
        private TextBox txbFileUrl;
        private RichTextBox rtbOutput;
    }
}
