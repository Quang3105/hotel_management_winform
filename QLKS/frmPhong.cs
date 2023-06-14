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
    public partial class frmPhong : Form
    {
        public static string _connectString = @"Data Source=BVCN88LTV;Initial Catalog=QLKS;Integrated Security=True";
        int _option = 0, pos = 0;
        public frmPhong()
        {
            InitializeComponent();
        }

		void Load_LoaiP()
		{
			try
			{
				DataTable dtLoaiP = SqlHelper.ExecuteQuery(
					"SELECT * FROM LOAIPHONG",
					CommandType.Text);
				cboLoaiP.DataSource = dtLoaiP;
				cboLoaiP.DisplayMember = "LOAIPHONG";
				cboLoaiP.ValueMember = "MALOAIPHONG";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		void Load_Phong()
		{
			try
			{
				DataTable dtPhong = SqlHelper.ExecuteQuery(
					"SELECT * FROM view_list_Phong",
					CommandType.Text);
				lView.Items.Clear();
				if (dtPhong.Rows.Count > 0)
				{
					foreach (DataRow row in dtPhong.Rows)
					{
						ListViewItem item = new ListViewItem();
						item.Text = row["MAPHONG"].ToString();
						item.SubItems.Add(row["LOAIPHONG"].ToString());
						//a
						String str = row["TINHTRANG"].ToString();
						//a
						item.SubItems.Add(row["TINHTRANG"].ToString() == "False" ? "Trống" : "Không trống");
						item.SubItems.Add(row["MALOAIPHONG"].ToString());

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
			txtMaP.ReadOnly = true;
			cboLoaiP.Enabled = true;
			optKhongTrong.Enabled = true;
			optTrong.Enabled = true;

			cmdSave.Visible = true;
			cmdCancel.Visible = true;

			lView.Enabled = false;

			grpFunction.Enabled = false;

			_option = 2;
		}
		void SetAdd(bool edit)
		{
			txtMaP.Text = "";
			cboLoaiP.SelectedIndex = -1;

			txtMaP.ReadOnly = !edit;
			cboLoaiP.Enabled = edit;
			optTrong.Checked = true;

			cmdSave.Visible = edit;
			cmdCancel.Visible = edit;

			lView.Enabled = !edit;

			grpFunction.Enabled = !edit;

			_option = edit ? 1 : 0;
		}
		private void frmPhong_Load(object sender, System.EventArgs e)
		{
			Load_LoaiP();
			Load_Phong();
			SetAdd(false);
		}

		private void lView_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lView.SelectedItems.Count == 0)
				return;

			ListViewItem item = lView.SelectedItems[0];
			pos = item.Index;
			txtMaP.Text = item.SubItems[0].Text;
			cboLoaiP.SelectedValue = item.SubItems[3].Text;
			if (item.SubItems[2].Text == "Trống")
				optTrong.Checked = true;
			else
				optKhongTrong.Checked = true;
		}

		private void cmdExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void cmdDelete_Click(object sender, System.EventArgs e)
		{
			if (txtMaP.Text == "")
				return;

			DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa phòng này không?",
				"Xóa phòng",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				SqlHelper.ExecuteNonQuery(
					"sp_del_Phong",
					CommandType.StoredProcedure,
					"@msPhong", txtMaP.Text);

				MessageBox.Show("Đã xóa phòng!");
				if (pos == lView.Items.Count - 1)
					pos = 0;
				Load_Phong();
			}
		}

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			SetAdd(true);
		}

		private void cmdEdit_Click(object sender, System.EventArgs e)
		{
			if (txtMaP.Text == "")
				return;

			SetEdit();
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			SetAdd(false);
		}

		private void cmdSave_Click(object sender, System.EventArgs e)
		{
			if (txtMaP.Text.Trim() == "")
				return;
			try
			{
				SqlHelper.ExecuteNonQuery(
					"sp_ins_Phong",
					CommandType.StoredProcedure,
					"@option", _option,
					"@MSPHONG", txtMaP.Text.Trim(),
					"@MSLOAIPHONG", cboLoaiP.SelectedValue,
					"@TINHTRANG", optTrong.Checked ? "0" : "1");
				Load_Phong();
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
