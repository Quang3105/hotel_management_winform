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
    public partial class frmTBTrangThietBi : Form
    {
        public static string _connectString = @"Data Source=BVCN88LTV;Initial Catalog=QLKS;Integrated Security=True";
        int _option = 0;
        public frmTBTrangThietBi()
        {
            InitializeComponent();
        }
		void Load_TrangThietBi()
		{
			DataTable dt = SqlHelper.ExecuteQuery("select * from THIETBI_DV",
				CommandType.Text);
			panTrangBi.Controls.Clear();
			int i = 0;
			foreach (DataRow row in dt.Rows)
			{
				CheckBox chk = new CheckBox();
				chk.Checked = false;
				chk.Location = new Point(5, i * 25 + 3);
				chk.CheckedChanged += new EventHandler(chk_CheckedChanged);
				chk.Width = 10;
				chk.FlatStyle = FlatStyle.System;
				chk.Name = "chk;" + row["MATHIETBI"].ToString();
				panTrangBi.Controls.Add(chk);

				Label lbl = new Label();
				lbl.Text = row["TENTHIETBI"].ToString();
				lbl.BorderStyle = BorderStyle.None;
				lbl.Location = new Point(5 + 10 + 5, i * 25 + 5);
				lbl.Width = 150;
				panTrangBi.Controls.Add(lbl);

				NumericUpDown num = new NumericUpDown();
				num.Value = 0;
				num.Minimum = 0;
				num.Maximum = 10;
				num.Location = new Point(5 + 10 + 5 + 150 + 5, i * 25 + 5);
				num.Visible = true;
				num.Enabled = false;
				num.Width = 50;
				panTrangBi.Controls.Add(num);

				chk.Tag = num;
				i++;
				DataTable dtTB = SqlHelper.ExecuteQuery(
				"select * from THIETBI_PHONG where MATHIETBI='" + row["MATHIETBI"].ToString() + "' and MALOAIPHONG='" + cboLoaiP.SelectedValue + "'",
				CommandType.Text);
				if (dtTB.Rows.Count > 0)
				{
					chk.Checked = true;
					num.Value = int.Parse(dtTB.Rows[0]["SOLUONG"].ToString());
				}
			}
		}
		void Load_LoaiP()
		{
			try
			{
				DataTable dtLoaiP = SqlHelper.ExecuteQuery(
					"select * from LOAIPHONG",
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
		void Load_TBTrangThietBi()
		{
			try
			{
				DataTable dtLP = SqlHelper.ExecuteQuery(
						"select * from THIETBI_PHONG TP LEFT JOIN THIETBI_DV TD ON TP.MATHIETBI = TD.MATHIETBI",
						CommandType.Text);
				lView.Items.Clear();
				if (dtLP.Rows.Count > 0)
				{
					foreach (DataRow row in dtLP.Rows)
					{
						ListViewItem item = new ListViewItem();
						item.Text = row["MALOAIPHONG"].ToString();
						item.SubItems.Add(row["TENTHIETBI"].ToString());
						item.SubItems.Add(row["SOLUONG"].ToString());

						lView.Items.Add(item);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void frmPhong_Load(object sender, System.EventArgs e)
		{
			Load_LoaiP();
			Load_TBTrangThietBi();
			Load_TrangThietBi();
		}

		private void cmdExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void chk_CheckedChanged(object sender, System.EventArgs e)
		{
			CheckBox chk = sender as CheckBox;
			NumericUpDown num = chk.Tag as NumericUpDown;
			num.Enabled = chk.Checked;
			cmdSave.Enabled = true;
		}

		private void cboLoaiP_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Load_TrangThietBi();
		}

		private void cmdSave_Click(object sender, System.EventArgs e)
		{
			cmdSave.Enabled = false;

			for (int i = 0; i < panTrangBi.Controls.Count; i++)
			{
				if (panTrangBi.Controls[i].Name.IndexOf("chk;") >= 0)
				{
					CheckBox chk = panTrangBi.Controls[i] as CheckBox;
					if (chk.Checked)
					{
						string mstb = chk.Name.Replace("chk;", "");
						NumericUpDown num = chk.Tag as NumericUpDown;
						string soluong = num.Value.ToString();

						DataTable dtTB = SqlHelper.ExecuteQuery(
							"select * from THIETBI_PHONG where MATHIETBI='" + mstb + "' and MALOAIPHONG='" + cboLoaiP.SelectedValue + "'",
							CommandType.Text);
						if (dtTB.Rows.Count > 0)
						{
							_option = 2;
							if (soluong == "0")
								_option = 3;
						}
						else
						{
							_option = 1;
							if (soluong == "0")
								_option = 0;
						}
						if (_option != 0)
							SqlHelper.ExecuteNonQuery("sp_ins_THIETBI_PHONG",
								CommandType.StoredProcedure,
								"@option", _option,
								"@MALOAIPHONG", cboLoaiP.SelectedValue,
								"@MATHIETBI", mstb,
								"@SOLUONG", soluong);
					}
				}
			}
			Load_TBTrangThietBi();
			Load_TrangThietBi();
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmTBTrangTB_Resize(object sender, System.EventArgs e)
		{
			panTrangBi.Width = this.Width - groupBox1.Width - 20;
		}

    }
}
