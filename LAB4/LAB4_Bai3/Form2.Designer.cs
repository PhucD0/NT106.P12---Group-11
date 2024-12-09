namespace LAB4_Bai3
{
    partial class Form2
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
            txtHtml = new RichTextBox();
            SuspendLayout();
            // 
            // txtHtml
            // 
            txtHtml.Location = new Point(14, 12);
            txtHtml.Name = "txtHtml";
            txtHtml.Size = new Size(774, 426);
            txtHtml.TabIndex = 2;
            txtHtml.Text = "";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtHtml);
            Name = "Form2";
            Text = "Form2";
            Resize += Form2_Resize;
            ResumeLayout(false);
        }

        #endregion
        private RichTextBox txtHtml;
    }
}