namespace LAB3_Bai3
{
    partial class SubForm
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
            labelFrom = new Label();
            labelSubject = new Label();
            textboxDetail = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // labelFrom
            // 
            labelFrom.AutoSize = true;
            labelFrom.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelFrom.Location = new Point(91, 9);
            labelFrom.Name = "labelFrom";
            labelFrom.Size = new Size(14, 23);
            labelFrom.TabIndex = 4;
            labelFrom.Text = ".";
            // 
            // labelSubject
            // 
            labelSubject.AutoSize = true;
            labelSubject.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSubject.Location = new Point(91, 46);
            labelSubject.Name = "labelSubject";
            labelSubject.Size = new Size(14, 23);
            labelSubject.TabIndex = 6;
            labelSubject.Text = ".";
            // 
            // textboxDetail
            // 
            textboxDetail.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textboxDetail.Location = new Point(12, 89);
            textboxDetail.Multiline = true;
            textboxDetail.Name = "textboxDetail";
            textboxDetail.ScrollBars = ScrollBars.Both;
            textboxDetail.Size = new Size(776, 349);
            textboxDetail.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(52, 23);
            label1.TabIndex = 8;
            label1.Text = "From:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 46);
            label2.Name = "label2";
            label2.Size = new Size(73, 23);
            label2.TabIndex = 9;
            label2.Text = "Subject:";
            // 
            // SubForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textboxDetail);
            Controls.Add(labelSubject);
            Controls.Add(labelFrom);
            Name = "SubForm";
            Text = "Đọc Mail";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelFrom;
        private Label labelSubject;
        private TextBox textboxDetail;
        private Label label1;
        private Label label2;
    }
}