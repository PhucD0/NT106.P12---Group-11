﻿namespace Server
{
    partial class Server
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
            TextboxIP = new TextBox();
            Label_IP = new Label();
            ButtonListen = new Button();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // TextboxIP
            // 
            TextboxIP.Location = new Point(95, 9);
            TextboxIP.Name = "TextboxIP";
            TextboxIP.Size = new Size(126, 23);
            TextboxIP.TabIndex = 0;
            // 
            // Label_IP
            // 
            Label_IP.AutoSize = true;
            Label_IP.Font = new Font("Segoe UI", 12F);
            Label_IP.Location = new Point(3, 9);
            Label_IP.Name = "Label_IP";
            Label_IP.Size = new Size(86, 21);
            Label_IP.TabIndex = 1;
            Label_IP.Text = "IP Address:";
            // 
            // ButtonListen
            // 
            ButtonListen.Location = new Point(227, 9);
            ButtonListen.Name = "ButtonListen";
            ButtonListen.Size = new Size(75, 23);
            ButtonListen.TabIndex = 2;
            ButtonListen.Text = "Listen";
            ButtonListen.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(3, 38);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Both;
            textBox1.Size = new Size(299, 400);
            textBox1.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(304, 450);
            Controls.Add(textBox1);
            Controls.Add(ButtonListen);
            Controls.Add(Label_IP);
            Controls.Add(TextboxIP);
            Name = "Form1";
            Text = "Server";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TextboxIP;
        private Label Label_IP;
        private Button ButtonListen;
        private TextBox textBox1;
    }
}
