
namespace QLKS
{
    partial class mainForm
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
            this.Date = new System.Windows.Forms.StatusBarPanel();
            this.stBar = new System.Windows.Forms.StatusBar();
            this.NhanVien = new System.Windows.Forms.StatusBarPanel();
            this.mnAbout = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mnCaNhan = new System.Windows.Forms.MenuItem();
            this.mnTileH = new System.Windows.Forms.MenuItem();
            this.mnTileV = new System.Windows.Forms.MenuItem();
            this.mnCascade = new System.Windows.Forms.MenuItem();
            this.mnSapXep = new System.Windows.Forms.MenuItem();
            this.mnTG = new System.Windows.Forms.MenuItem();
            this.mnHoSoNV = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.mnTBTrangTB = new System.Windows.Forms.MenuItem();
            this.mnThietBi = new System.Windows.Forms.MenuItem();
            this.mnLoaiPhong = new System.Windows.Forms.MenuItem();
            this.mnPhong = new System.Windows.Forms.MenuItem();
            this.mnTB = new System.Windows.Forms.MenuItem();
            this.mnCauHinh = new System.Windows.Forms.MenuItem();
            this.mnSearchKH = new System.Windows.Forms.MenuItem();
            this.mnSearchPhong = new System.Windows.Forms.MenuItem();
            this.mnTimKiem = new System.Windows.Forms.MenuItem();
            this.mnExit = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.mnThanhToan = new System.Windows.Forms.MenuItem();
            this.mnSDDichVu = new System.Windows.Forms.MenuItem();
            this.mnQLKhachHang = new System.Windows.Forms.MenuItem();
            this.mnQuanLy = new System.Windows.Forms.MenuItem();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Date)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // Date
            // 
            this.Date.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Date.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.Date.MinWidth = 200;
            this.Date.Name = "Date";
            this.Date.Text = "Date";
            this.Date.Width = 530;
            // 
            // stBar
            // 
            this.stBar.Location = new System.Drawing.Point(0, 577);
            this.stBar.Name = "stBar";
            this.stBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.NhanVien,
            this.Date});
            this.stBar.ShowPanels = true;
            this.stBar.Size = new System.Drawing.Size(747, 24);
            this.stBar.TabIndex = 2;
            this.stBar.Text = "TTTTTTTTT";
            // 
            // NhanVien
            // 
            this.NhanVien.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.NhanVien.MinWidth = 200;
            this.NhanVien.Name = "NhanVien";
            this.NhanVien.Text = "Nhân viên:";
            this.NhanVien.Width = 200;
            // 
            // mnAbout
            // 
            this.mnAbout.Index = 3;
            this.mnAbout.Text = "Thông tin tác giả";
            this.mnAbout.Click += new System.EventHandler(this.mnAbout_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 2;
            this.menuItem1.Text = "-";
            // 
            // mnCaNhan
            // 
            this.mnCaNhan.Index = 1;
            this.mnCaNhan.Text = "Thay đổi mật khẩu";
            this.mnCaNhan.Click += new System.EventHandler(this.mnCaNhan_Click);
            // 
            // mnTileH
            // 
            this.mnTileH.Index = 2;
            this.mnTileH.Text = "TileHorizontal";
            this.mnTileH.Click += new System.EventHandler(this.mnTileV_Click);
            // 
            // mnTileV
            // 
            this.mnTileV.Index = 1;
            this.mnTileV.Text = "TileVertical";
            this.mnTileV.Click += new System.EventHandler(this.mnTileV_Click);
            // 
            // mnCascade
            // 
            this.mnCascade.Index = 0;
            this.mnCascade.Text = "Cascade";
            this.mnCascade.Click += new System.EventHandler(this.mnCascade_Click);
            // 
            // mnSapXep
            // 
            this.mnSapXep.Index = 0;
            this.mnSapXep.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnCascade,
            this.mnTileV,
            this.mnTileH});
            this.mnSapXep.Text = "Sắp xếp";
            // 
            // mnTG
            // 
            this.mnTG.Index = 3;
            this.mnTG.MdiList = true;
            this.mnTG.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnSapXep,
            this.mnCaNhan,
            this.menuItem1,
            this.mnAbout});
            this.mnTG.Text = "Trợ giúp";
            // 
            // mnHoSoNV
            // 
            this.mnHoSoNV.Index = 2;
            this.mnHoSoNV.Text = "Hồ sơ nhân viên";
            this.mnHoSoNV.Click += new System.EventHandler(this.mnHoSoNV_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 1;
            this.menuItem5.Text = "-";
            // 
            // mnTBTrangTB
            // 
            this.mnTBTrangTB.Index = 3;
            this.mnTBTrangTB.Text = "Trang bị trang thiết bị cho phòng";
            this.mnTBTrangTB.Click += new System.EventHandler(this.mnTBTrangTB_Click);
            // 
            // mnThietBi
            // 
            this.mnThietBi.Index = 2;
            this.mnThietBi.Text = "Nhập trang thiết bị";
            this.mnThietBi.Click += new System.EventHandler(this.mnThietBi_Click);
            // 
            // mnLoaiPhong
            // 
            this.mnLoaiPhong.Index = 1;
            this.mnLoaiPhong.Text = "Loại phòng";
            this.mnLoaiPhong.Click += new System.EventHandler(this.mnLoaiPhong_Click);
            // 
            // mnPhong
            // 
            this.mnPhong.Index = 0;
            this.mnPhong.Text = "Phòng";
            this.mnPhong.Click += new System.EventHandler(this.mnPhong_Click);
            // 
            // mnTB
            // 
            this.mnTB.Index = 0;
            this.mnTB.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnPhong,
            this.mnLoaiPhong,
            this.mnThietBi,
            this.mnTBTrangTB});
            this.mnTB.Text = "Trang bị";
            // 
            // mnCauHinh
            // 
            this.mnCauHinh.Index = 2;
            this.mnCauHinh.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnTB,
            this.menuItem5,
            this.mnHoSoNV});
            this.mnCauHinh.Text = "Cấu hình";
            // 
            // mnSearchKH
            // 
            this.mnSearchKH.Index = 1;
            this.mnSearchKH.Text = "Khách hàng";
            this.mnSearchKH.Click += new System.EventHandler(this.mnSearchKH_Click);
            // 
            // mnSearchPhong
            // 
            this.mnSearchPhong.Index = 0;
            this.mnSearchPhong.Text = "Phòng";
            this.mnSearchPhong.Click += new System.EventHandler(this.mnSearchPhong_Click);
            // 
            // mnTimKiem
            // 
            this.mnTimKiem.Index = 1;
            this.mnTimKiem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnSearchPhong,
            this.mnSearchKH});
            this.mnTimKiem.Text = "Tìm kiếm";
            // 
            // mnExit
            // 
            this.mnExit.Index = 4;
            this.mnExit.Shortcut = System.Windows.Forms.Shortcut.CtrlF4;
            this.mnExit.Text = "Thoát";
            this.mnExit.Click += new System.EventHandler(this.mnExit_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 3;
            this.menuItem3.Text = "-";
            // 
            // mnThanhToan
            // 
            this.mnThanhToan.Index = 2;
            this.mnThanhToan.Text = "Thanh toán phòng";
            this.mnThanhToan.Click += new System.EventHandler(this.mnThanhToan_Click);
            // 
            // mnSDDichVu
            // 
            this.mnSDDichVu.Index = 1;
            this.mnSDDichVu.Text = "Sử dụng dịch vụ";
            this.mnSDDichVu.Click += new System.EventHandler(this.mnQLPhong_Click);
            // 
            // mnQLKhachHang
            // 
            this.mnQLKhachHang.Index = 0;
            this.mnQLKhachHang.Text = "Khách hàng đặt phòng";
            this.mnQLKhachHang.Click += new System.EventHandler(this.mnQLKhachHang_Click);
            // 
            // mnQuanLy
            // 
            this.mnQuanLy.Index = 0;
            this.mnQuanLy.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnQLKhachHang,
            this.mnSDDichVu,
            this.mnThanhToan,
            this.menuItem3,
            this.mnExit});
            this.mnQuanLy.Text = "Quản Lý";
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnQuanLy,
            this.mnTimKiem,
            this.mnCauHinh,
            this.mnTG});
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 601);
            this.Controls.Add(this.stBar);
            this.IsMdiContainer = true;
            this.Menu = this.mainMenu1;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Khách Sạn";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.Date)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NhanVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusBarPanel Date;
        private System.Windows.Forms.StatusBar stBar;
        private System.Windows.Forms.StatusBarPanel NhanVien;
        private System.Windows.Forms.MenuItem mnAbout;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem mnCaNhan;
        private System.Windows.Forms.MenuItem mnTileH;
        private System.Windows.Forms.MenuItem mnTileV;
        private System.Windows.Forms.MenuItem mnCascade;
        private System.Windows.Forms.MenuItem mnSapXep;
        private System.Windows.Forms.MenuItem mnTG;
        private System.Windows.Forms.MenuItem mnHoSoNV;
        private System.Windows.Forms.MenuItem menuItem5;
        public System.Windows.Forms.MenuItem mnTBTrangTB;
        public System.Windows.Forms.MenuItem mnThietBi;
        public System.Windows.Forms.MenuItem mnLoaiPhong;
        private System.Windows.Forms.MenuItem mnPhong;
        private System.Windows.Forms.MenuItem mnTB;
        private System.Windows.Forms.MenuItem mnCauHinh;
        private System.Windows.Forms.MenuItem mnSearchKH;
        private System.Windows.Forms.MenuItem mnSearchPhong;
        private System.Windows.Forms.MenuItem mnTimKiem;
        private System.Windows.Forms.MenuItem mnExit;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem mnThanhToan;
        public System.Windows.Forms.MenuItem mnSDDichVu;
        public System.Windows.Forms.MenuItem mnQLKhachHang;
        private System.Windows.Forms.MenuItem mnQuanLy;
        public System.Windows.Forms.MainMenu mainMenu1;
    }
}

