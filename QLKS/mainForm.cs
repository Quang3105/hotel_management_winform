using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS
{
    public partial class mainForm : Form
    {
		public static string msNV = "", tenNV = "";
		public Form father;
		public mainForm(Form father)
		{
			this.father = father;
			InitializeComponent();
		}

		private void mainForm_Load(object sender, EventArgs e)
		{

        }

        private void mnPhong_Click(object sender, EventArgs e)
		{
			frmPhong f = new frmPhong();
			f.MdiParent = this;
			f.Show();
		}

		private void mnThietBi_Click(object sender, System.EventArgs e)
		{
			frmThietBi f = new frmThietBi();
			f.MdiParent = this;
			f.Show();
		}

		private void mnHoSoNV_Click(object sender, System.EventArgs e)
		{
			frmNV f = new frmNV();
			f.MdiParent = this;
			f.Show();
		}

		private void mnLoaiPhong_Click(object sender, System.EventArgs e)
		{
			frmLoaiPhong f = new frmLoaiPhong();
			f.MdiParent = this;
			f.Show();
		}

		private void mnTBTrangTB_Click(object sender, System.EventArgs e)
		{
			frmTBTrangThietBi f = new frmTBTrangThietBi();
			f.MdiParent = this;
			f.Show();
		}

		private void mnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		public void enableFormMain(string masoNV)
		{
			msNV = masoNV;
            DataTable dtNV = SqlHelper.ExecuteQuery(
                "select top 1 MANHANVIEN from NHANVIEN order by MANHANVIEN",
                CommandType.Text);
            if (dtNV.Rows[0]["MANHANVIEN"].ToString() != msNV)
				mnCauHinh.Visible = false;
			dtNV = SqlHelper.ExecuteQuery(
				"select HOTEN from NHANVIEN where MANHANVIEN='" + msNV + "'",
				CommandType.Text);
			tenNV = dtNV.Rows[0]["HOTEN"].ToString();
			stBar.Panels[0].Text = "Nhân viên : " + tenNV;
			stBar.Panels[1].Text = "Hôm nay : " + DateTime.Now.ToShortDateString();
		}

		private void mnQLKhachHang_Click(object sender, System.EventArgs e)
		{
			frmKH f = new frmKH();
			f.MdiParent = this;
			f.Show();
		}

		private void mnQLPhong_Click(object sender, EventArgs e)
		{
			frmSDDichVu f = new frmSDDichVu();
			f.MdiParent = this;
			f.Show();
		}

		private void mnCascade_Click(object sender, EventArgs e)
		{
			this.LayoutMdi(MdiLayout.Cascade);
		}

		private void mnTileH_Click(object sender, EventArgs e)
		{
			this.LayoutMdi(MdiLayout.TileHorizontal);
		}

		private void mnTileV_Click(object sender, EventArgs e)
		{
			this.LayoutMdi(MdiLayout.TileVertical);
		}

		private void mnThanhToan_Click(object sender, EventArgs e)
		{
			frmThanhToanPhong f = new frmThanhToanPhong();
			f.MdiParent = this;
			f.Show();
		}

		private void mnSearchKH_Click(object sender, EventArgs e)
		{
			frmSearchKH f = new frmSearchKH();
			f.MdiParent = this;
			f.Show();
		}

		private void mnSearchPhong_Click(object sender, EventArgs e)
		{
			frmSearchPhong f = new frmSearchPhong();
			f.MdiParent = this;
			f.Show();
		}

		private void mnCaNhan_Click(object sender, EventArgs e)
		{
			frmChangeProfile f = new frmChangeProfile();
			f.MdiParent = this;
			f.Show();
		}

		private void mnAbout_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Nhóm 13 - Chương trình quản lý khách sạn.\r\nTrần Minh Quang\nLê Minh Quang\nNguyễn Giang Thanh", "Thông tin tác giả");
		}

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
			father.Show();
		}

    }
}
