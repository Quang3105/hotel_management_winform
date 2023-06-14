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
    public partial class frmNV : Form
    {
        public static string _connectString = @"Data Source=BVCN88LTV;Initial Catalog=QLKS;Integrated Security=True";
        int _option = 0, pos = 0;
        public frmNV()
        {
            InitializeComponent();
        }

		void Load_NV()
		{
			try
			{
				DataTable dtTB = SqlHelper.ExecuteQuery(
					"sp_list_NV",
					CommandType.StoredProcedure);
				lView.Items.Clear();
				if (dtTB.Rows.Count > 0)
				{
					foreach (DataRow row in dtTB.Rows)
					{
						ListViewItem item = new ListViewItem();
						item.Text = row["MANHANVIEN"].ToString();
						item.SubItems.Add(row["HOTEN"].ToString());
						item.SubItems.Add(row["GIOITINH"].ToString() == "False" ? "Nam" : "Nữ");
						item.SubItems.Add(row["MATKHAU"].ToString());
						item.SubItems.Add(DateTime.Parse(row["NGAYSINH"].ToString()).ToString("d"));
						item.SubItems.Add(row["DIACHI"].ToString());
						item.SubItems.Add(row["SODIENTHOAI"].ToString());
						item.SubItems.Add(DateTime.Parse(row["NGAYVAOLAM"].ToString()).ToString("d"));
						lView.Items.Add(item);
					}
					lView.Items[pos].Selected = true;
					lView_SelectedIndexChanged(lView.Items[pos], System.EventArgs.Empty);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		void SetEdit()
		{
			txtMaNV.ReadOnly = true;
			txtDChi.ReadOnly = false;
			txtDThoai.ReadOnly = false;
			txtMKhau.ReadOnly = false;
			optNam.Enabled = true;
			optNu.Enabled = true;
			txtMKhau_R.Text = txtMKhau.Text;
			txtTenNV.ReadOnly = false;

			dTPicker_NSinh.Enabled = true;
			dTPicker_NVaoLam.Enabled = true;

			cmdSave.Visible = true;
			cmdCancel.Visible = true;

			lView.Enabled = false;

			grpFunction.Enabled = false;

			_option = 2;
		}
		void SetAdd(bool edit)
		{
			txtMaNV.Text = "";
			txtDChi.Text = "";
			txtDThoai.Text = "";
			txtMKhau.Text = "";
			txtMKhau_R.Text = "";
			txtTenNV.Text = "";
			dTPicker_NVaoLam.Value = DateTime.Now;
			dTPicker_NSinh.Value = DateTime.Parse(DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString());

			txtMaNV.ReadOnly = !edit;
			txtDChi.ReadOnly = !edit;
			txtDThoai.ReadOnly = !edit;
			txtMKhau.ReadOnly = !edit;
			txtTenNV.ReadOnly = !edit;
			dTPicker_NSinh.Enabled = edit;
			dTPicker_NVaoLam.Enabled = edit;
			optNam.Enabled = edit;
			optNu.Enabled = edit;

			txtMKhau_R.Visible = edit;
			lbMKhau_R.Visible = edit;

			cmdSave.Visible = edit;
			cmdCancel.Visible = edit;

			lView.Enabled = !edit;

			grpFunction.Enabled = !edit;

			_option = edit ? 1 : 0;
		}
		private void frmPhong_Load(object sender, System.EventArgs e)
		{
			Load_NV();
			SetAdd(false);
		}

		private void lView_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lView.SelectedItems.Count == 0)
				return;

			ListViewItem item = lView.SelectedItems[0];
			pos = item.Index;
			txtMaNV.Text = item.SubItems[0].Text;
			txtTenNV.Text = item.SubItems[1].Text;
			if (item.SubItems[2].Text == "Nam")
				optNam.Checked = true;
			else
				optNu.Checked = true;
			txtMKhau.Text = item.SubItems[3].Text;
			dTPicker_NSinh.Text = item.SubItems[4].Text;
			txtDChi.Text = item.SubItems[5].Text;
			txtDThoai.Text = item.SubItems[6].Text;
			dTPicker_NVaoLam.Text = item.SubItems[7].Text;
		}

		private void cmdExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void cmdDelete_Click(object sender, System.EventArgs e)
		{
			if (txtMaNV.Text == "")
				return;

			DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này không?",
				"Xóa nhân viên",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				SqlHelper.ExecuteNonQuery(
					"sp_del_NhanVien",
					CommandType.StoredProcedure,
					"@MSNV", txtMaNV.Text);

				MessageBox.Show("Đã xóa nhân viên!");
				if (pos == lView.Items.Count - 1)
					pos = 0;
				Load_NV();
			}
		}

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			SetAdd(true);
		}

		private void cmdEdit_Click(object sender, System.EventArgs e)
		{
			if (txtMaNV.Text == "")
				return;

			SetEdit();
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			SetAdd(false);
		}

		private bool Check_Form()
		{
			int y = dTPicker_NSinh.Value.Year + 18;
			if (dTPicker_NVaoLam.Value > DateTime.Now)
			{
				MessageBox.Show("Ngày vào làm không hợp lệ!", "Lỗi");
				dTPicker_NVaoLam.Focus();
				return false;
			}
			else if (txtMKhau.Text != txtMKhau_R.Text)
			{
				MessageBox.Show("Mật khẩu nhập lại không chính xác!", "Lỗi");
				txtMKhau_R.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}

		private void cmdSave_Click(object sender, System.EventArgs e)
		{
			if (txtMaNV.Text.Trim() == "")
				return;
			if (Check_Form())
			{
				try
				{
					SqlHelper.ExecuteNonQuery(
						"sp_ins_NV",
						CommandType.StoredProcedure,
						"@option", _option,
						"@MSNV", txtMaNV.Text.Trim(),
						"@HOTENNV", txtTenNV.Text.Trim(),
						"@MatKhau", txtMKhau.Text.Trim(),
						"@NGAYSINHNV", dTPicker_NSinh.Value,
						"@GIOITINHNV", optNam.Checked ? "0" : "1",
						"@DIACHINV", txtDChi.Text.Trim(),
						"@DIENTHOAINV", txtDThoai.Text.Trim(),
						"@NGAYVAOLAM", dTPicker_NVaoLam.Value);
					Load_NV();
					SetAdd(false);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void frmPhong_Activated(object sender, System.EventArgs e)
		{
			lView_SelectedIndexChanged(lView, System.EventArgs.Empty);
		}

		private void txtMKhau_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			txtMKhau_R.Text = "";
			txtMKhau_R.Visible = true;
			lbMKhau_R.Visible = true;
		}
	}
}
