namespace LAB03
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
            Bai1_Button = new Button();
            Bai2_Button = new Button();
            Bai3_Button = new Button();
            Bai4_Button = new Button();
            Bai5_Button = new Button();
            SuspendLayout();
            // 
            // Bai1_Button
            // 
            Bai1_Button.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Bai1_Button.Location = new Point(35, 25);
            Bai1_Button.Name = "Bai1_Button";
            Bai1_Button.Size = new Size(154, 90);
            Bai1_Button.TabIndex = 0;
            Bai1_Button.Text = "Bài 1";
            Bai1_Button.UseVisualStyleBackColor = true;
            // 
            // Bai2_Button
            // 
            Bai2_Button.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Bai2_Button.Location = new Point(35, 140);
            Bai2_Button.Name = "Bai2_Button";
            Bai2_Button.Size = new Size(154, 90);
            Bai2_Button.TabIndex = 1;
            Bai2_Button.Text = "Bài 2";
            Bai2_Button.UseVisualStyleBackColor = true;
            // 
            // Bai3_Button
            // 
            Bai3_Button.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Bai3_Button.Location = new Point(35, 262);
            Bai3_Button.Name = "Bai3_Button";
            Bai3_Button.Size = new Size(154, 90);
            Bai3_Button.TabIndex = 2;
            Bai3_Button.Text = "Bài 3";
            Bai3_Button.UseVisualStyleBackColor = true;
            // 
            // Bai4_Button
            // 
            Bai4_Button.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Bai4_Button.Location = new Point(251, 81);
            Bai4_Button.Name = "Bai4_Button";
            Bai4_Button.Size = new Size(154, 90);
            Bai4_Button.TabIndex = 3;
            Bai4_Button.Text = "Bài 4";
            Bai4_Button.UseVisualStyleBackColor = true;
            // 
            // Bai5_Button
            // 
            Bai5_Button.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Bai5_Button.Location = new Point(251, 204);
            Bai5_Button.Name = "Bai5_Button";
            Bai5_Button.Size = new Size(154, 90);
            Bai5_Button.TabIndex = 4;
            Bai5_Button.Text = "Bài 5";
            Bai5_Button.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 392);
            Controls.Add(Bai5_Button);
            Controls.Add(Bai4_Button);
            Controls.Add(Bai3_Button);
            Controls.Add(Bai2_Button);
            Controls.Add(Bai1_Button);
            Name = "Form1";
            Text = "Menu";
            ResumeLayout(false);
        }

        #endregion

        private Button Bai1_Button;
        private Button Bai2_Button;
        private Button Bai3_Button;
        private Button Bai4_Button;
        private Button Bai5_Button;
    }
}
