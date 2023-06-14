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
    public partial class frmSearchPhong : Form
    {

        DataTable dtP;
        DataView dv;
        public frmSearchPhong()
        {
            InitializeComponent();
            dtP = SqlHelper.ExecuteQuery("select * from view_list_Phong", CommandType.Text);

            dv = dtP.DefaultView;
            Load_LoaiP();
        }

		void Load_LoaiP()
		{
			try
			{
				DataTable dtLoaiP = SqlHelper.ExecuteQuery(
					"sp_List_LoaiPhong",
					CommandType.StoredProcedure);
				cboLoaiP.Items.Add(String.Format("Tất cả loại phòng"));
				if (dtLoaiP.Rows.Count > 0)
				{
					foreach (DataRow row in dtLoaiP.Rows)
						cboLoaiP.Items.Add(row["LOAIPHONG"].ToString());
				}
				cboLoaiP.SelectedIndex = 0;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		private void cmdTim_Click(object sender, EventArgs e)
		{
			string strSQL = "";

			if (txtMaP.Text != "")
				strSQL = "MaPhong='" + txtMaP.Text.Trim() + "'";
			if (cboLoaiP.Text != "Tất cả loại phòng")
				strSQL = strSQL + " and LoaiPhong='" + cboLoaiP.Text + "'";
			if (chkTrong.Checked)
				strSQL = strSQL + " and TinhTrang='False'";
			else
				strSQL = strSQL + " and TinhTrang='True'";
			int n = strSQL.IndexOf("and");
			if (n == 1)
				strSQL = strSQL.Substring(n + 4);
			dv.RowFilter = strSQL;
			dtGrid.DataSource = dv;
		}

		private void cmdThoat_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
