namespace LAB5_Menu
{
    partial class Menu
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
            buttonBai1 = new Button();
            buttonBai2 = new Button();
            buttonBai3 = new Button();
            buttonBai4 = new Button();
            SuspendLayout();
            // 
            // buttonBai1
            // 
            buttonBai1.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonBai1.Location = new Point(12, 12);
            buttonBai1.Name = "buttonBai1";
            buttonBai1.Size = new Size(155, 89);
            buttonBai1.TabIndex = 0;
            buttonBai1.Text = "Bài 1";
            buttonBai1.UseVisualStyleBackColor = true;
            buttonBai1.Click += buttonBai1_Click;
            // 
            // buttonBai2
            // 
            buttonBai2.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonBai2.Location = new Point(12, 130);
            buttonBai2.Name = "buttonBai2";
            buttonBai2.Size = new Size(155, 89);
            buttonBai2.TabIndex = 1;
            buttonBai2.Text = "Bài 2";
            buttonBai2.UseVisualStyleBackColor = true;
            buttonBai2.Click += buttonBai2_Click;
            // 
            // buttonBai3
            // 
            buttonBai3.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonBai3.Location = new Point(199, 12);
            buttonBai3.Name = "buttonBai3";
            buttonBai3.Size = new Size(155, 89);
            buttonBai3.TabIndex = 2;
            buttonBai3.Text = "Bài 3";
            buttonBai3.UseVisualStyleBackColor = true;
            buttonBai3.Click += buttonBai3_Click;
            // 
            // buttonBai4
            // 
            buttonBai4.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonBai4.Location = new Point(199, 130);
            buttonBai4.Name = "buttonBai4";
            buttonBai4.Size = new Size(155, 89);
            buttonBai4.TabIndex = 3;
            buttonBai4.Text = "Bài 4";
            buttonBai4.UseVisualStyleBackColor = true;
            buttonBai4.Click += buttonBai4_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(365, 232);
            Controls.Add(buttonBai4);
            Controls.Add(buttonBai3);
            Controls.Add(buttonBai2);
            Controls.Add(buttonBai1);
            Name = "Menu";
            Text = "Menu";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonBai1;
        private Button buttonBai2;
        private Button buttonBai3;
        private Button buttonBai4;
    }
}
