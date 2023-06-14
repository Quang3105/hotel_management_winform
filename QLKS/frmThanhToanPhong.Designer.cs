
namespace QLKS
{
    partial class frmThanhToanPhong
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdExit = new System.Windows.Forms.Button();
            this.cmdShow = new System.Windows.Forms.Button();
            this.cboMaP = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBaoCao = new System.Windows.Forms.TextBox();
            this.lView = new System.Windows.Forms.ListView();
            this.TenDV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ngay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SoLuong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Gia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdThanhToan = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdExit);
            this.groupBox2.Controls.Add(this.cmdShow);
            this.groupBox2.Controls.Add(this.cboMaP);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.cmdThanhToan);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(544, 472);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hợp đồng thanh toán";
            // 
            // cmdExit
            // 
            this.cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdExit.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExit.Location = new System.Drawing.Point(312, 424);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(168, 40);
            this.cmdExit.TabIndex = 31;
            this.cmdExit.Text = "Thoát";
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cmdShow
            // 
            this.cmdShow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdShow.Location = new System.Drawing.Point(240, 40);
            this.cmdShow.Name = "cmdShow";
            this.cmdShow.Size = new System.Drawing.Size(72, 24);
            this.cmdShow.TabIndex = 29;
            this.cmdShow.Text = "Xem";
            this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
            // 
            // cboMaP
            // 
            this.cboMaP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaP.Location = new System.Drawing.Point(112, 40);
            this.cboMaP.Name = "cboMaP";
            this.cboMaP.Size = new System.Drawing.Size(104, 21);
            this.cboMaP.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 24);
            this.label1.TabIndex = 27;
            this.label1.Text = "Chọn mã phòng:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBaoCao);
            this.groupBox1.Controls.Add(this.lView);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 344);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết sử dụng dịch vụ";
            // 
            // txtBaoCao
            // 
            this.txtBaoCao.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBaoCao.Location = new System.Drawing.Point(8, 24);
            this.txtBaoCao.Multiline = true;
            this.txtBaoCao.Name = "txtBaoCao";
            this.txtBaoCao.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBaoCao.Size = new System.Drawing.Size(512, 136);
            this.txtBaoCao.TabIndex = 27;
            // 
            // lView
            // 
            this.lView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TenDV,
            this.Ngay,
            this.SoLuong,
            this.Gia});
            this.lView.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lView.FullRowSelect = true;
            this.lView.GridLines = true;
            this.lView.HideSelection = false;
            this.lView.Location = new System.Drawing.Point(8, 160);
            this.lView.Name = "lView";
            this.lView.Size = new System.Drawing.Size(512, 176);
            this.lView.TabIndex = 14;
            this.lView.UseCompatibleStateImageBehavior = false;
            this.lView.View = System.Windows.Forms.View.Details;
            // 
            // TenDV
            // 
            this.TenDV.Text = "Tên dịch vụ";
            this.TenDV.Width = 200;
            // 
            // Ngay
            // 
            this.Ngay.Text = "Ngày sử dụng";
            this.Ngay.Width = 150;
            // 
            // SoLuong
            // 
            this.SoLuong.Text = "Số lượng";
            // 
            // Gia
            // 
            this.Gia.Text = "Giá";
            // 
            // cmdThanhToan
            // 
            this.cmdThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdThanhToan.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdThanhToan.Location = new System.Drawing.Point(72, 424);
            this.cmdThanhToan.Name = "cmdThanhToan";
            this.cmdThanhToan.Size = new System.Drawing.Size(168, 40);
            this.cmdThanhToan.TabIndex = 31;
            this.cmdThanhToan.Text = "Thanh toán";
            this.cmdThanhToan.Click += new System.EventHandler(this.cmdThanhToan_Click);
            // 
            // frmThanhToanPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 489);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmThanhToanPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khách hàng thanh toán phòng";
            this.Load += new System.EventHandler(this.frmPhong_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Button cmdShow;
        private System.Windows.Forms.ComboBox cboMaP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBaoCao;
        private System.Windows.Forms.ListView lView;
        private System.Windows.Forms.ColumnHeader TenDV;
        private System.Windows.Forms.ColumnHeader Ngay;
        private System.Windows.Forms.ColumnHeader SoLuong;
        private System.Windows.Forms.ColumnHeader Gia;
        private System.Windows.Forms.Button cmdThanhToan;
    }
}