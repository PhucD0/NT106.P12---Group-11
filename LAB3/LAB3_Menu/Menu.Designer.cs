namespace LAB3_Menu
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
            button_Bai1 = new Button();
            button_Bai2 = new Button();
            button_Bai3 = new Button();
            button_Bai4 = new Button();
            button_Bai5 = new Button();
            SuspendLayout();
            // 
            // button_Bai1
            // 
            button_Bai1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_Bai1.Location = new Point(12, 12);
            button_Bai1.Name = "button_Bai1";
            button_Bai1.Size = new Size(149, 102);
            button_Bai1.TabIndex = 0;
            button_Bai1.Text = "Bài 1";
            button_Bai1.UseVisualStyleBackColor = true;
            button_Bai1.Click += button_Bai1_Click;
            // 
            // button_Bai2
            // 
            button_Bai2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_Bai2.Location = new Point(12, 167);
            button_Bai2.Name = "button_Bai2";
            button_Bai2.Size = new Size(149, 102);
            button_Bai2.TabIndex = 1;
            button_Bai2.Text = "Bài 2";
            button_Bai2.UseVisualStyleBackColor = true;
            button_Bai2.Click += button_Bai2_Click;
            // 
            // button_Bai3
            // 
            button_Bai3.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_Bai3.Location = new Point(12, 323);
            button_Bai3.Name = "button_Bai3";
            button_Bai3.Size = new Size(149, 102);
            button_Bai3.TabIndex = 2;
            button_Bai3.Text = "Bài 3";
            button_Bai3.UseVisualStyleBackColor = true;
            button_Bai3.Click += button_Bai3_Click;
            // 
            // button_Bai4
            // 
            button_Bai4.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_Bai4.Location = new Point(256, 91);
            button_Bai4.Name = "button_Bai4";
            button_Bai4.Size = new Size(149, 102);
            button_Bai4.TabIndex = 3;
            button_Bai4.Text = "Bài 4";
            button_Bai4.UseVisualStyleBackColor = true;
            button_Bai4.Click += button_Bai4_Click;
            // 
            // button_Bai5
            // 
            button_Bai5.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_Bai5.Location = new Point(256, 252);
            button_Bai5.Name = "button_Bai5";
            button_Bai5.Size = new Size(149, 102);
            button_Bai5.TabIndex = 4;
            button_Bai5.Text = "Bài 5";
            button_Bai5.UseVisualStyleBackColor = true;
            button_Bai5.Click += button_Bai5_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(439, 451);
            Controls.Add(button_Bai5);
            Controls.Add(button_Bai4);
            Controls.Add(button_Bai3);
            Controls.Add(button_Bai2);
            Controls.Add(button_Bai1);
            Name = "Menu";
            Text = "Menu";
            FormClosing += Menu_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private Button button_Bai1;
        private Button button_Bai2;
        private Button button_Bai3;
        private Button button_Bai4;
        private Button button_Bai5;
    }
}
