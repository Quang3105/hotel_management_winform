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
    public partial class frmLoaiPhong : Form
    {
		public static string _connectString = @"Data Source=BVCN88LTV;Initial Catalog=QLKS;Integrated Security=True";
		int _option = 0, pos = 0;
		public frmLoaiPhong()
        {
            InitializeComponent();
        }

		void Load_LoaiPhong()
		{
			try
			{
				DataTable dtLP = SqlHelper.ExecuteQuery(
					"sp_List_LoaiPhong",
					CommandType.StoredProcedure);
				lView.Items.Clear();
				if (dtLP.Rows.Count > 0)
				{
					foreach (DataRow row in dtLP.Rows)
					{
						ListViewItem item = new ListViewItem();
						item.Text = row["MALOAIPHONG"].ToString();
						item.SubItems.Add(row["LOAIPHONG"].ToString());
						item.SubItems.Add(Double.Parse(row["GIATIEN"].ToString()).ToString("c"));

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
			txtMaLoaiP.ReadOnly = true;
			txtLoaiP.ReadOnly = false;
			txtGia.ReadOnly = false;

			cmdSave.Visible = true;
			cmdCancel.Visible = true;


			lView.Enabled = false;

			grpFunction.Enabled = false;

			_option = 2;
		}
		void SetAdd(bool edit)
		{
			txtMaLoaiP.Text = "";

			txtMaLoaiP.ReadOnly = !edit;
			txtLoaiP.ReadOnly = !edit;
			txtGia.ReadOnly = !edit;
			txtLoaiP.Text = "";
			txtGia.Text = "";

			cmdSave.Visible = edit;
			cmdCancel.Visible = edit;

			lView.Enabled = !edit;

			grpFunction.Enabled = !edit;

			_option = edit ? 1 : 0;
		}
		private void frmPhong_Load(object sender, System.EventArgs e)
		{
			Load_LoaiPhong();
			SetAdd(false);
		}

		private void lView_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lView.SelectedItems.Count == 0)
				return;

			ListViewItem item = lView.SelectedItems[0];
			pos = item.Index;
			txtMaLoaiP.Text = item.SubItems[0].Text;
			txtLoaiP.Text = item.SubItems[1].Text;
			txtGia.Text = item.SubItems[2].Text;
		}

		private void cmdExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void cmdDelete_Click(object sender, System.EventArgs e)
		{
			if (txtMaLoaiP.Text == "")
				return;

			DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa loại phòng này không?",
				"Xóa loại phòng",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				SqlHelper.ExecuteNonQuery(
					"sp_del_LoaiPhong",
					CommandType.StoredProcedure,
					"@MSLOAIPHONG", txtMaLoaiP.Text);

				MessageBox.Show("Đã xóa loại phòng!");
				if (pos == lView.Items.Count - 1)
					pos = 0;
				Load_LoaiPhong();
			}
		}

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			SetAdd(true);
		}

		private void cmdEdit_Click(object sender, System.EventArgs e)
		{
			if (txtMaLoaiP.Text == "")
				return;

			SetEdit();
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			SetAdd(false);
		}

		private void cmdSave_Click(object sender, System.EventArgs e)
		{
			if (txtMaLoaiP.Text.Trim() == "")
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
					"sp_ins_LoaiPhong",
					CommandType.StoredProcedure,
					"@option", _option,
					"@MSLOAIPHONG", txtMaLoaiP.Text.Trim(),
					"@LOAIPHONG", txtLoaiP.Text.Trim(),
					"@GIATIEN", Double.Parse(gia));
				Load_LoaiPhong();
				SetAdd(false);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		private void frmPhong_Activated(object sender, System.EventArgs e)
		{
			lView_SelectedIndexChanged(lView, System.EventArgs.Empty);
		}
	}
}
