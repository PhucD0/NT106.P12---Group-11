namespace LAB2_Bai01
{
    partial class Lab02_Bai03
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.rtbInput = new System.Windows.Forms.RichTextBox();
            this.btnReadFile = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnWriteFile = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(177, 184);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "File output";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(177, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "File input";
            // 
            // rtbOutput
            // 
            this.rtbOutput.Location = new System.Drawing.Point(178, 202);
            this.rtbOutput.Margin = new System.Windows.Forms.Padding(2);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.Size = new System.Drawing.Size(371, 127);
            this.rtbOutput.TabIndex = 9;
            this.rtbOutput.Text = "";
            // 
            // rtbInput
            // 
            this.rtbInput.Location = new System.Drawing.Point(178, 50);
            this.rtbInput.Margin = new System.Windows.Forms.Padding(2);
            this.rtbInput.Name = "rtbInput";
            this.rtbInput.Size = new System.Drawing.Size(371, 108);
            this.rtbInput.TabIndex = 10;
            this.rtbInput.Text = "";
            // 
            // btnReadFile
            // 
            this.btnReadFile.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnReadFile.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReadFile.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadFile.ForeColor = System.Drawing.Color.Red;
            this.btnReadFile.Location = new System.Drawing.Point(52, 32);
            this.btnReadFile.Margin = new System.Windows.Forms.Padding(2);
            this.btnReadFile.Name = "btnReadFile";
            this.btnReadFile.Size = new System.Drawing.Size(94, 42);
            this.btnReadFile.TabIndex = 5;
            this.btnReadFile.Text = "Read File";
            this.btnReadFile.UseVisualStyleBackColor = false;
            this.btnReadFile.Click += new System.EventHandler(this.btnReadFile_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnExit.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Red;
            this.btnExit.Location = new System.Drawing.Point(52, 293);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 42);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnWriteFile
            // 
            this.btnWriteFile.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnWriteFile.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWriteFile.ForeColor = System.Drawing.Color.Red;
            this.btnWriteFile.Location = new System.Drawing.Point(52, 164);
            this.btnWriteFile.Margin = new System.Windows.Forms.Padding(2);
            this.btnWriteFile.Name = "btnWriteFile";
            this.btnWriteFile.Size = new System.Drawing.Size(94, 42);
            this.btnWriteFile.TabIndex = 7;
            this.btnWriteFile.Text = "Write File";
            this.btnWriteFile.UseVisualStyleBackColor = false;
            this.btnWriteFile.Click += new System.EventHandler(this.btnWriteFile_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnClear.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Red;
            this.btnClear.Location = new System.Drawing.Point(52, 230);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(94, 42);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCal
            // 
            this.btnCal.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCal.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCal.ForeColor = System.Drawing.Color.Red;
            this.btnCal.Location = new System.Drawing.Point(52, 95);
            this.btnCal.Margin = new System.Windows.Forms.Padding(2);
            this.btnCal.Name = "btnCal";
            this.btnCal.Size = new System.Drawing.Size(94, 42);
            this.btnCal.TabIndex = 4;
            this.btnCal.Text = "Calculate";
            this.btnCal.UseVisualStyleBackColor = false;
            this.btnCal.Click += new System.EventHandler(this.btnCal_Click);
            // 
            // Lab02_Bai03
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbOutput);
            this.Controls.Add(this.rtbInput);
            this.Controls.Add(this.btnReadFile);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnWriteFile);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCal);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Lab02_Bai03";
            this.Text = "Lab02_Bai03";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.RichTextBox rtbInput;
        private System.Windows.Forms.Button btnReadFile;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnWriteFile;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCal;
    }
}