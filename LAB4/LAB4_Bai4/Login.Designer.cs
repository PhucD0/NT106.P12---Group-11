namespace LAB4_Bai4
{
    partial class Login
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
            labelURL = new Label();
            textboxURL = new TextBox();
            labelUsername = new Label();
            labelPassword = new Label();
            textboxPassword = new TextBox();
            textboxUsername = new TextBox();
            buttonLogin = new Button();
            buttonRegister = new Button();
            textboxResult = new TextBox();
            SuspendLayout();
            // 
            // labelURL
            // 
            labelURL.AutoSize = true;
            labelURL.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelURL.Location = new Point(32, 14);
            labelURL.Name = "labelURL";
            labelURL.Size = new Size(47, 23);
            labelURL.TabIndex = 0;
            labelURL.Text = "URL:";
            // 
            // textboxURL
            // 
            textboxURL.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textboxURL.Location = new Point(101, 9);
            textboxURL.Multiline = true;
            textboxURL.Name = "textboxURL";
            textboxURL.Size = new Size(303, 32);
            textboxURL.TabIndex = 1;
            textboxURL.Text = "https://nt106.uitiot.vn/auth/token";
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelUsername.Location = new Point(16, 71);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(85, 23);
            labelUsername.TabIndex = 2;
            labelUsername.Text = "Username:";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPassword.Location = new Point(16, 131);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(81, 23);
            labelPassword.TabIndex = 3;
            labelPassword.Text = "Password:";
            // 
            // textboxPassword
            // 
            textboxPassword.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textboxPassword.Location = new Point(101, 126);
            textboxPassword.Multiline = true;
            textboxPassword.Name = "textboxPassword";
            textboxPassword.Size = new Size(303, 32);
            textboxPassword.TabIndex = 4;
            // 
            // textboxUsername
            // 
            textboxUsername.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textboxUsername.Location = new Point(101, 66);
            textboxUsername.Multiline = true;
            textboxUsername.Name = "textboxUsername";
            textboxUsername.Size = new Size(303, 32);
            textboxUsername.TabIndex = 5;
            // 
            // buttonLogin
            // 
            buttonLogin.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonLogin.Location = new Point(101, 179);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(98, 34);
            buttonLogin.TabIndex = 6;
            buttonLogin.Text = "Login";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // buttonRegister
            // 
            buttonRegister.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonRegister.Location = new Point(306, 179);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(98, 34);
            buttonRegister.TabIndex = 7;
            buttonRegister.Text = "Sign up";
            buttonRegister.UseVisualStyleBackColor = true;
            buttonRegister.Click += buttonRegister_Click;
            // 
            // textboxResult
            // 
            textboxResult.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textboxResult.Location = new Point(16, 237);
            textboxResult.Multiline = true;
            textboxResult.Name = "textboxResult";
            textboxResult.Size = new Size(388, 179);
            textboxResult.TabIndex = 8;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 428);
            Controls.Add(textboxResult);
            Controls.Add(buttonRegister);
            Controls.Add(buttonLogin);
            Controls.Add(textboxUsername);
            Controls.Add(textboxPassword);
            Controls.Add(labelPassword);
            Controls.Add(labelUsername);
            Controls.Add(textboxURL);
            Controls.Add(labelURL);
            Name = "Login";
            Text = "Login";
            FormClosing += Login_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelURL;
        private TextBox textboxURL;
        private Label labelUsername;
        private Label labelPassword;
        private TextBox textboxPassword;
        private TextBox textboxUsername;
        private Button buttonLogin;
        private Button buttonRegister;
        private TextBox textboxResult;
    }
}
