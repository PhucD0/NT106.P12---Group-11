namespace LAB1
{
    partial class Lab01_Bai02
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
            this.btnCal = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInput1 = new System.Windows.Forms.TextBox();
            this.txtInput2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCal
            // 
            this.btnCal.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnCal.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnCal.FlatAppearance.BorderSize = 2;
            this.btnCal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCal.Location = new System.Drawing.Point(56, 215);
            this.btnCal.Name = "btnCal";
            this.btnCal.Size = new System.Drawing.Size(190, 34);
            this.btnCal.TabIndex = 0;
            this.btnCal.Text = "Tính các giá trị";
            this.btnCal.UseVisualStyleBackColor = false;
            this.btnCal.Click += new System.EventHandler(this.btnCal_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnDelete.FlatAppearance.BorderSize = 2;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(359, 215);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 34);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnExit.FlatAppearance.BorderSize = 2;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(613, 215);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(101, 34);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nhập A";
            // 
            // txtInput1
            // 
            this.txtInput1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput1.Location = new System.Drawing.Point(138, 36);
            this.txtInput1.Name = "txtInput1";
            this.txtInput1.Size = new System.Drawing.Size(172, 30);
            this.txtInput1.TabIndex = 4;
            // 
            // txtInput2
            // 
            this.txtInput2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput2.Location = new System.Drawing.Point(523, 36);
            this.txtInput2.Name = "txtInput2";
            this.txtInput2.Size = new System.Drawing.Size(172, 30);
            this.txtInput2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(439, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nhập B";
            // 
            // comboBox
            // 
            this.comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "Bảng cửu chương",
            "Tính toán giá trị"});
            this.comboBox.Location = new System.Drawing.Point(293, 118);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(164, 28);
            this.comboBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 282);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Kết quả";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(39, 310);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(675, 128);
            this.txtOutput.TabIndex = 9;
            // 
            // Lab01_Bai02
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.txtInput2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInput1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCal);
            this.Name = "Lab01_Bai02";
            this.Text = "Lab01_Bai02";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCal;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInput1;
        private System.Windows.Forms.TextBox txtInput2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOutput;
    }
}