namespace Quanlithisinh
{
    partial class Lab01_Bai05
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
            this.components = new System.ComponentModel.Container();
            this.dgvThiSinh = new System.Windows.Forms.DataGridView();
            this.textNhap = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.pickGender = new System.Windows.Forms.ComboBox();
            this.pressToDelete = new System.Windows.Forms.Button();
            this.pressToSave = new System.Windows.Forms.Button();
            this.textDiem3 = new System.Windows.Forms.TextBox();
            this.textDiem2 = new System.Windows.Forms.TextBox();
            this.textDiem1 = new System.Windows.Forms.TextBox();
            this.textHovaTen = new System.Windows.Forms.TextBox();
            this.labelDiem3 = new System.Windows.Forms.Label();
            this.labelDiem2 = new System.Windows.Forms.Label();
            this.labelDiem1 = new System.Windows.Forms.Label();
            this.labelGioiTinh = new System.Windows.Forms.Label();
            this.labelHovaTen = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBoxThongKe = new System.Windows.Forms.GroupBox();
            this.lblSoLuongTrungBinh = new System.Windows.Forms.Label();
            this.lblSoLuongYeuKem = new System.Windows.Forms.Label();
            this.lblSoLuongKha = new System.Windows.Forms.Label();
            this.lblSoLuongGioi = new System.Windows.Forms.Label();
            this.lblTenThiSinhDiemCaoNhat = new System.Windows.Forms.Label();
            this.lblSoLuongThiSinh = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThiSinh)).BeginInit();
            this.textNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBoxThongKe.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvThiSinh
            // 
            this.dgvThiSinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThiSinh.Location = new System.Drawing.Point(1, 241);
            this.dgvThiSinh.Name = "dgvThiSinh";
            this.dgvThiSinh.Size = new System.Drawing.Size(799, 210);
            this.dgvThiSinh.TabIndex = 0;
            this.dgvThiSinh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThiSinh_CellClick);
            // 
            // textNhap
            // 
            this.textNhap.Controls.Add(this.btnExit);
            this.textNhap.Controls.Add(this.btnThongKe);
            this.textNhap.Controls.Add(this.pickGender);
            this.textNhap.Controls.Add(this.pressToDelete);
            this.textNhap.Controls.Add(this.pressToSave);
            this.textNhap.Controls.Add(this.textDiem3);
            this.textNhap.Controls.Add(this.textDiem2);
            this.textNhap.Controls.Add(this.textDiem1);
            this.textNhap.Controls.Add(this.textHovaTen);
            this.textNhap.Controls.Add(this.labelDiem3);
            this.textNhap.Controls.Add(this.labelDiem2);
            this.textNhap.Controls.Add(this.labelDiem1);
            this.textNhap.Controls.Add(this.labelGioiTinh);
            this.textNhap.Controls.Add(this.labelHovaTen);
            this.textNhap.Location = new System.Drawing.Point(12, 45);
            this.textNhap.Name = "textNhap";
            this.textNhap.Size = new System.Drawing.Size(393, 151);
            this.textNhap.TabIndex = 1;
            this.textNhap.TabStop = false;
            this.textNhap.Text = "Nhập Thí Sinh";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(296, 122);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(204, 122);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(75, 23);
            this.btnThongKe.TabIndex = 13;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click_1);
            // 
            // pickGender
            // 
            this.pickGender.FormattingEnabled = true;
            this.pickGender.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.pickGender.Location = new System.Drawing.Point(70, 58);
            this.pickGender.Name = "pickGender";
            this.pickGender.Size = new System.Drawing.Size(125, 21);
            this.pickGender.TabIndex = 12;
            this.pickGender.SelectedIndexChanged += new System.EventHandler(this.pickGender_SelectedIndexChanged);
            this.pickGender.Validating += new System.ComponentModel.CancelEventHandler(this.pickGender_Validating);
            // 
            // pressToDelete
            // 
            this.pressToDelete.Location = new System.Drawing.Point(107, 122);
            this.pressToDelete.Name = "pressToDelete";
            this.pressToDelete.Size = new System.Drawing.Size(75, 23);
            this.pressToDelete.TabIndex = 11;
            this.pressToDelete.Text = "Xóa";
            this.pressToDelete.UseVisualStyleBackColor = true;
            this.pressToDelete.Click += new System.EventHandler(this.pressToDelete_Click);
            // 
            // pressToSave
            // 
            this.pressToSave.Location = new System.Drawing.Point(6, 122);
            this.pressToSave.Name = "pressToSave";
            this.pressToSave.Size = new System.Drawing.Size(75, 23);
            this.pressToSave.TabIndex = 10;
            this.pressToSave.Text = "Lưu";
            this.pressToSave.UseVisualStyleBackColor = true;
            this.pressToSave.Click += new System.EventHandler(this.pressToSave_Click);
            // 
            // textDiem3
            // 
            this.textDiem3.Location = new System.Drawing.Point(271, 91);
            this.textDiem3.Name = "textDiem3";
            this.textDiem3.Size = new System.Drawing.Size(100, 20);
            this.textDiem3.TabIndex = 9;
            this.textDiem3.Validating += new System.ComponentModel.CancelEventHandler(this.textDiem3_Validating);
            // 
            // textDiem2
            // 
            this.textDiem2.Location = new System.Drawing.Point(271, 58);
            this.textDiem2.Name = "textDiem2";
            this.textDiem2.Size = new System.Drawing.Size(100, 20);
            this.textDiem2.TabIndex = 8;
            this.textDiem2.Validating += new System.ComponentModel.CancelEventHandler(this.textDiem2_Validating);
            // 
            // textDiem1
            // 
            this.textDiem1.Location = new System.Drawing.Point(271, 24);
            this.textDiem1.Name = "textDiem1";
            this.textDiem1.Size = new System.Drawing.Size(100, 20);
            this.textDiem1.TabIndex = 7;
            this.textDiem1.Validating += new System.ComponentModel.CancelEventHandler(this.textDiem1_Validating);
            // 
            // textHovaTen
            // 
            this.textHovaTen.Location = new System.Drawing.Point(70, 24);
            this.textHovaTen.Name = "textHovaTen";
            this.textHovaTen.Size = new System.Drawing.Size(125, 20);
            this.textHovaTen.TabIndex = 5;
            this.textHovaTen.Validating += new System.ComponentModel.CancelEventHandler(this.textHovaTen_Validating);
            // 
            // labelDiem3
            // 
            this.labelDiem3.AutoSize = true;
            this.labelDiem3.Location = new System.Drawing.Point(201, 94);
            this.labelDiem3.Name = "labelDiem3";
            this.labelDiem3.Size = new System.Drawing.Size(64, 13);
            this.labelDiem3.TabIndex = 4;
            this.labelDiem3.Text = "Điểm Môn 3";
            // 
            // labelDiem2
            // 
            this.labelDiem2.AutoSize = true;
            this.labelDiem2.Location = new System.Drawing.Point(201, 61);
            this.labelDiem2.Name = "labelDiem2";
            this.labelDiem2.Size = new System.Drawing.Size(64, 13);
            this.labelDiem2.TabIndex = 3;
            this.labelDiem2.Text = "Điểm Môn 2";
            // 
            // labelDiem1
            // 
            this.labelDiem1.AutoSize = true;
            this.labelDiem1.Location = new System.Drawing.Point(201, 27);
            this.labelDiem1.Name = "labelDiem1";
            this.labelDiem1.Size = new System.Drawing.Size(64, 13);
            this.labelDiem1.TabIndex = 2;
            this.labelDiem1.Text = "Điểm Môn 1";
            // 
            // labelGioiTinh
            // 
            this.labelGioiTinh.AutoSize = true;
            this.labelGioiTinh.Location = new System.Drawing.Point(13, 61);
            this.labelGioiTinh.Name = "labelGioiTinh";
            this.labelGioiTinh.Size = new System.Drawing.Size(51, 13);
            this.labelGioiTinh.TabIndex = 1;
            this.labelGioiTinh.Text = "Giới Tính";
            // 
            // labelHovaTen
            // 
            this.labelHovaTen.AutoSize = true;
            this.labelHovaTen.Location = new System.Drawing.Point(6, 27);
            this.labelHovaTen.Name = "labelHovaTen";
            this.labelHovaTen.Size = new System.Drawing.Size(58, 13);
            this.labelHovaTen.TabIndex = 0;
            this.labelHovaTen.Text = "Họ và Tên";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBoxThongKe
            // 
            this.groupBoxThongKe.Controls.Add(this.lblSoLuongTrungBinh);
            this.groupBoxThongKe.Controls.Add(this.lblSoLuongYeuKem);
            this.groupBoxThongKe.Controls.Add(this.lblSoLuongKha);
            this.groupBoxThongKe.Controls.Add(this.lblSoLuongGioi);
            this.groupBoxThongKe.Controls.Add(this.lblTenThiSinhDiemCaoNhat);
            this.groupBoxThongKe.Controls.Add(this.lblSoLuongThiSinh);
            this.groupBoxThongKe.Location = new System.Drawing.Point(411, 45);
            this.groupBoxThongKe.Name = "groupBoxThongKe";
            this.groupBoxThongKe.Size = new System.Drawing.Size(377, 151);
            this.groupBoxThongKe.TabIndex = 2;
            this.groupBoxThongKe.TabStop = false;
            this.groupBoxThongKe.Text = "Thống Kê";
            // 
            // lblSoLuongTrungBinh
            // 
            this.lblSoLuongTrungBinh.AutoSize = true;
            this.lblSoLuongTrungBinh.Location = new System.Drawing.Point(172, 31);
            this.lblSoLuongTrungBinh.Name = "lblSoLuongTrungBinh";
            this.lblSoLuongTrungBinh.Size = new System.Drawing.Size(35, 13);
            this.lblSoLuongTrungBinh.TabIndex = 5;
            this.lblSoLuongTrungBinh.Text = "label6";
            this.lblSoLuongTrungBinh.Visible = false;
            // 
            // lblSoLuongYeuKem
            // 
            this.lblSoLuongYeuKem.AutoSize = true;
            this.lblSoLuongYeuKem.Location = new System.Drawing.Point(172, 58);
            this.lblSoLuongYeuKem.Name = "lblSoLuongYeuKem";
            this.lblSoLuongYeuKem.Size = new System.Drawing.Size(35, 13);
            this.lblSoLuongYeuKem.TabIndex = 4;
            this.lblSoLuongYeuKem.Text = "label5";
            this.lblSoLuongYeuKem.Visible = false;
            // 
            // lblSoLuongKha
            // 
            this.lblSoLuongKha.AutoSize = true;
            this.lblSoLuongKha.Location = new System.Drawing.Point(6, 58);
            this.lblSoLuongKha.Name = "lblSoLuongKha";
            this.lblSoLuongKha.Size = new System.Drawing.Size(35, 13);
            this.lblSoLuongKha.TabIndex = 3;
            this.lblSoLuongKha.Text = "label4";
            this.lblSoLuongKha.Visible = false;
            // 
            // lblSoLuongGioi
            // 
            this.lblSoLuongGioi.AutoSize = true;
            this.lblSoLuongGioi.Location = new System.Drawing.Point(6, 91);
            this.lblSoLuongGioi.Name = "lblSoLuongGioi";
            this.lblSoLuongGioi.Size = new System.Drawing.Size(35, 13);
            this.lblSoLuongGioi.TabIndex = 2;
            this.lblSoLuongGioi.Text = "label3";
            this.lblSoLuongGioi.Visible = false;
            // 
            // lblTenThiSinhDiemCaoNhat
            // 
            this.lblTenThiSinhDiemCaoNhat.AutoSize = true;
            this.lblTenThiSinhDiemCaoNhat.Location = new System.Drawing.Point(6, 122);
            this.lblTenThiSinhDiemCaoNhat.Name = "lblTenThiSinhDiemCaoNhat";
            this.lblTenThiSinhDiemCaoNhat.Size = new System.Drawing.Size(35, 13);
            this.lblTenThiSinhDiemCaoNhat.TabIndex = 1;
            this.lblTenThiSinhDiemCaoNhat.Text = "label2";
            this.lblTenThiSinhDiemCaoNhat.Visible = false;
            // 
            // lblSoLuongThiSinh
            // 
            this.lblSoLuongThiSinh.AutoSize = true;
            this.lblSoLuongThiSinh.Location = new System.Drawing.Point(6, 27);
            this.lblSoLuongThiSinh.Name = "lblSoLuongThiSinh";
            this.lblSoLuongThiSinh.Size = new System.Drawing.Size(35, 13);
            this.lblSoLuongThiSinh.TabIndex = 0;
            this.lblSoLuongThiSinh.Text = "label1";
            this.lblSoLuongThiSinh.Visible = false;
            // 
            // Lab01_Bai05
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxThongKe);
            this.Controls.Add(this.textNhap);
            this.Controls.Add(this.dgvThiSinh);
            this.Name = "Lab01_Bai05";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thi sinh";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThiSinh)).EndInit();
            this.textNhap.ResumeLayout(false);
            this.textNhap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBoxThongKe.ResumeLayout(false);
            this.groupBoxThongKe.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvThiSinh;
        private System.Windows.Forms.GroupBox textNhap;
        private System.Windows.Forms.Label labelDiem3;
        private System.Windows.Forms.Label labelDiem2;
        private System.Windows.Forms.Label labelDiem1;
        private System.Windows.Forms.Label labelGioiTinh;
        private System.Windows.Forms.Label labelHovaTen;
        private System.Windows.Forms.Button pressToDelete;
        private System.Windows.Forms.Button pressToSave;
        private System.Windows.Forms.TextBox textDiem3;
        private System.Windows.Forms.TextBox textDiem2;
        private System.Windows.Forms.TextBox textDiem1;
        private System.Windows.Forms.TextBox textHovaTen;
        private System.Windows.Forms.ComboBox pickGender;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBoxThongKe;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Label lblSoLuongTrungBinh;
        private System.Windows.Forms.Label lblSoLuongYeuKem;
        private System.Windows.Forms.Label lblSoLuongKha;
        private System.Windows.Forms.Label lblSoLuongGioi;
        private System.Windows.Forms.Label lblTenThiSinhDiemCaoNhat;
        private System.Windows.Forms.Label lblSoLuongThiSinh;
        private System.Windows.Forms.Button btnExit;
    }
}

