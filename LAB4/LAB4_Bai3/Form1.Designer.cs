namespace LAB4_Bai3
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
            btnLoad = new Button();
            btnDownFiles = new Button();
            btnReload = new Button();
            btnDownResources = new Button();
            txtUrl = new TextBox();
            webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            btnViewsources = new Button();
            ((System.ComponentModel.ISupportInitialize)webView).BeginInit();
            SuspendLayout();
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(12, 12);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(112, 34);
            btnLoad.TabIndex = 0;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnDownFiles
            // 
            btnDownFiles.Location = new Point(773, 61);
            btnDownFiles.Name = "btnDownFiles";
            btnDownFiles.Size = new Size(135, 34);
            btnDownFiles.TabIndex = 1;
            btnDownFiles.Text = "Down Files";
            btnDownFiles.UseVisualStyleBackColor = true;
            btnDownFiles.Click += btnDownFiles_Click;
            // 
            // btnReload
            // 
            btnReload.Location = new Point(988, 12);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(112, 34);
            btnReload.TabIndex = 2;
            btnReload.Text = "Reload";
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += btnReload_Click;
            // 
            // btnDownResources
            // 
            btnDownResources.Location = new Point(914, 61);
            btnDownResources.Name = "btnDownResources";
            btnDownResources.Size = new Size(186, 34);
            btnDownResources.TabIndex = 3;
            btnDownResources.Text = "Down Resources";
            btnDownResources.UseVisualStyleBackColor = true;
            btnDownResources.Click += btnDownResources_Click;
            // 
            // txtUrl
            // 
            txtUrl.Location = new Point(130, 12);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(852, 31);
            txtUrl.TabIndex = 4;
            // 
            // webView
            // 
            webView.AllowExternalDrop = true;
            webView.CreationProperties = null;
            webView.DefaultBackgroundColor = Color.White;
            webView.Location = new Point(12, 101);
            webView.Name = "webView";
            webView.Size = new Size(1088, 598);
            webView.TabIndex = 5;
            webView.ZoomFactor = 1D;
            // 
            // btnViewsources
            // 
            btnViewsources.Location = new Point(632, 61);
            btnViewsources.Name = "btnViewsources";
            btnViewsources.Size = new Size(135, 34);
            btnViewsources.TabIndex = 6;
            btnViewsources.Text = "View Sources";
            btnViewsources.UseVisualStyleBackColor = true;
            btnViewsources.Click += btnViewsources_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1112, 711);
            Controls.Add(btnViewsources);
            Controls.Add(webView);
            Controls.Add(txtUrl);
            Controls.Add(btnDownResources);
            Controls.Add(btnReload);
            Controls.Add(btnDownFiles);
            Controls.Add(btnLoad);
            Name = "Form1";
            Text = "Form1";
            Resize += Form1_Resize;
            ((System.ComponentModel.ISupportInitialize)webView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLoad;
        private Button btnDownFiles;
        private Button btnReload;
        private Button btnDownResources;
        private TextBox txtUrl;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private Button btnViewsources;
    }
}
