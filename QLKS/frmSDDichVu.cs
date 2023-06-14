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
    public partial class frmSDDichVu : Form
    {
        public frmSDDichVu()
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
			}
		}
		void Load_LoaiP()
		{
			try
			{
				DataTable dtLoaiP = SqlHelper.ExecuteQuery(
					"select * from view_hoaDon",
					CommandType.Text);
				foreach (DataRow row in dtLoaiP.Rows)
					//cboMaP.DataSource=dtLoaiP;
					cboMaP.Items.Add(row["MAPHONG"].ToString().Trim());
				//cboMaP.DisplayMember="msphong";
				//cboMaP.ValueMember="msphong";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void frmPhong_Load(object sender, System.EventArgs e)
		{
			Load_LoaiP();
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

						DataTable dtPhong_KH = SqlHelper.ExecuteQuery(
							"sp_Phong_KH",
							CommandType.StoredProcedure,
							"@msphong", cboMaP.Text);
						string soHDongthue = dtPhong_KH.Rows[0]["SHDTHUEPHONG"].ToString();

						SqlHelper.ExecuteNonQuery("sp_ins_SuDung_DV",
							CommandType.StoredProcedure,
							"@option", 1,
							"@SHDGTHUEPHONG", soHDongthue,
							"@MSTB", mstb.Trim(),
							"@NGAYSD", dTPicker_NgaySD.Value,
							"@SOLUONG", soluong);

					}
				}
			}
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
