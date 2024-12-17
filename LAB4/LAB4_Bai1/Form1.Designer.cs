namespace LAB4_Bai1
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
            btnGet = new Button();
            txbUrl = new TextBox();
            rtbOutput = new RichTextBox();
            SuspendLayout();
            // 
            // btnGet
            // 
            btnGet.Location = new Point(637, 12);
            btnGet.Name = "btnGet";
            btnGet.Size = new Size(105, 29);
            btnGet.TabIndex = 0;
            btnGet.Text = "GET";
            btnGet.UseVisualStyleBackColor = true;
            btnGet.Click += btnGet_Click;
            // 
            // txbUrl
            // 
            txbUrl.Location = new Point(25, 14);
            txbUrl.Name = "txbUrl";
            txbUrl.Size = new Size(592, 27);
            txbUrl.TabIndex = 1;
            txbUrl.Text = "https://uit.edu.vn/";
            // 
            // rtbOutput
            // 
            rtbOutput.Location = new Point(25, 58);
            rtbOutput.Name = "rtbOutput";
            rtbOutput.Size = new Size(717, 380);
            rtbOutput.TabIndex = 2;
            rtbOutput.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(763, 450);
            Controls.Add(rtbOutput);
            Controls.Add(txbUrl);
            Controls.Add(btnGet);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGet;
        private TextBox txbUrl;
        private RichTextBox rtbOutput;
    }
}
