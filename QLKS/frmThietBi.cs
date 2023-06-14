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
    public partial class frmThietBi : Form
    {
        public static string _connectString = @"Data Source=BVCN88LTV;Initial Catalog=QLKS;Integrated Security=True";
        int _option = 0, pos = 0;
        public frmThietBi()
        {
            InitializeComponent();
        }
		void Load_TB()
		{
			try
			{
				DataTable dtTB = SqlHelper.ExecuteQuery(
					"select * from THIETBI_DV", CommandType.Text);
				/*DataTable dtTB = SqlHelper.ExecuteQuery(
					"pr_list_ThietBi",
					CommandType.StoredProcedure,
					"@option", "3");*/
				lView.Items.Clear();
				if (dtTB.Rows.Count > 0)
				{
					foreach (DataRow row in dtTB.Rows)
					{
						ListViewItem item = new ListViewItem();
						item.Text = row["MATHIETBI"].ToString();
						item.SubItems.Add(row["TENTHIETBI"].ToString());
						item.SubItems.Add(Double.Parse(row["GIATIEN"].ToString()).ToString("c"));
						item.SubItems.Add(row["DVT"].ToString());

						lView.Items.Add(item);
					}
					lView.Items[pos].Selected = true;
					lView_SelectedIndexChanged(lView.Items[pos], EventArgs.Empty);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		void SetEdit()
		{
			txtMaTB.ReadOnly = true;
			txtTenTB.ReadOnly = false;
			txtDVT.ReadOnly = false;
			txtGia.ReadOnly = false;

			cmdSave.Visible = true;
			cmdCancel.Visible = true;

			lView.Enabled = false;

			grpFunction.Enabled = false;

			_option = 2;
		}
		void SetAdd(bool edit)
		{
			txtMaTB.Text = "";
			txtMaTB.ReadOnly = !edit;

			txtTenTB.ReadOnly = !edit;
			txtDVT.ReadOnly = !edit;
			txtGia.ReadOnly = !edit;
			txtTenTB.Text = "";
			txtDVT.Text = "";
			txtGia.Text = "";

			cmdSave.Visible = edit;
			cmdCancel.Visible = edit;

			lView.Enabled = !edit;

			grpFunction.Enabled = !edit;

			_option = edit ? 1 : 0;
		}
		private void frmPhong_Load(object sender, EventArgs e)
		{
			Load_TB();
			SetAdd(false);
		}
		private void lView_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lView.SelectedItems.Count == 0)
				return;

			ListViewItem item = lView.SelectedItems[0];
			pos = item.Index;
			txtMaTB.Text = item.SubItems[0].Text;
			txtTenTB.Text = item.SubItems[1].Text;
			txtGia.Text = item.SubItems[2].Text;
			txtDVT.Text = item.SubItems[3].Text;
		}

		private void cmdExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void cmdDelete_Click(object sender, EventArgs e)
		{
			if (txtMaTB.Text == "")
				return;

			DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa thiết bị này không?",
				"Xóa thiết bị",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				SqlHelper.ExecuteNonQuery(
					"sp_del_THIETBI_DV",
					CommandType.StoredProcedure,
					"@MATHIETBI", txtMaTB.Text);

				MessageBox.Show("Đã xóa thiết bị!");
				if (pos == lView.Items.Count - 1)
					pos = 0;
				Load_TB();
			}
		}

		private void cmdAdd_Click(object sender, EventArgs e)
		{
			SetAdd(true);
		}

		private void cmdEdit_Click(object sender, EventArgs e)
		{
			if (txtMaTB.Text == "")
				return;

			SetEdit();
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			SetAdd(false);
		}

		private void cmdSave_Click(object sender, EventArgs e)
		{
			if (txtMaTB.Text.Trim() == "")
				return;
			string gia = txtGia.Text;
			if (gia.Substring(0, 1) == "$")
				gia = txtGia.Text.Substring(1, txtGia.Text.Length - 1);
			try
			{
				if (Double.Parse(gia) < 0)
				{
					MessageBox.Show("Giá tiền không được là số âm.", "Lỗi");
					txtGia.Text = "0";
					return;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Giá tiền không hợp lệ.");
				return;
			}
			try
			{
				SqlHelper.ExecuteNonQuery(
					"sp_ins_THIETBI_DV",
					CommandType.StoredProcedure,
					"@option", _option,
					"@MATHIETBI", txtMaTB.Text.Trim(),
					"@TENTHIETBI", txtTenTB.Text.Trim(),
					"@DVT", txtDVT.Text.Trim(),
					"@GIATIEN", Double.Parse(gia));
				Load_TB();
				SetAdd(false);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		private void frmPhong_Activated(object sender, EventArgs e)
		{
			lView_SelectedIndexChanged(lView, EventArgs.Empty);
		}
	}
}
