namespace LAB4_Menu
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
            buttonBai5 = new Button();
            SuspendLayout();
            // 
            // buttonBai1
            // 
            buttonBai1.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonBai1.Location = new Point(12, 12);
            buttonBai1.Name = "buttonBai1";
            buttonBai1.Size = new Size(198, 119);
            buttonBai1.TabIndex = 0;
            buttonBai1.Text = "Bài 1";
            buttonBai1.UseVisualStyleBackColor = true;
            buttonBai1.Click += buttonBai1_Click;
            // 
            // buttonBai2
            // 
            buttonBai2.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonBai2.Location = new Point(12, 149);
            buttonBai2.Name = "buttonBai2";
            buttonBai2.Size = new Size(198, 119);
            buttonBai2.TabIndex = 1;
            buttonBai2.Text = "Bài 2";
            buttonBai2.UseVisualStyleBackColor = true;
            buttonBai2.Click += buttonBai2_Click;
            // 
            // buttonBai3
            // 
            buttonBai3.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonBai3.Location = new Point(12, 292);
            buttonBai3.Name = "buttonBai3";
            buttonBai3.Size = new Size(198, 119);
            buttonBai3.TabIndex = 2;
            buttonBai3.Text = "Bài 3";
            buttonBai3.UseVisualStyleBackColor = true;
            buttonBai3.Click += buttonBai3_Click;
            // 
            // buttonBai4
            // 
            buttonBai4.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonBai4.Location = new Point(266, 87);
            buttonBai4.Name = "buttonBai4";
            buttonBai4.Size = new Size(198, 119);
            buttonBai4.TabIndex = 3;
            buttonBai4.Text = "Bài 4";
            buttonBai4.UseVisualStyleBackColor = true;
            buttonBai4.Click += buttonBai4_Click;
            // 
            // buttonBai5
            // 
            buttonBai5.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonBai5.Location = new Point(266, 234);
            buttonBai5.Name = "buttonBai5";
            buttonBai5.Size = new Size(198, 119);
            buttonBai5.TabIndex = 4;
            buttonBai5.Text = "Bài 5";
            buttonBai5.UseVisualStyleBackColor = true;
            buttonBai5.Click += buttonBai5_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(476, 436);
            Controls.Add(buttonBai5);
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
        private Button buttonBai5;
    }
}
