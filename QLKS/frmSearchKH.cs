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
    public partial class frmSearchKH : Form
    {
        DataTable dtKH;
        DataView dv;
        public frmSearchKH()
        {
            InitializeComponent();
            dtKH = SqlHelper.ExecuteQuery("select * FROM KHACHHANG",
                                            CommandType.Text);

            dv = dtKH.DefaultView;
        }
		private void cmdTim_Click(object sender, System.EventArgs e)
		{
			string strSQL = "";

			if (txtTen.Text != "")
				strSQL = "HoTen like '%" + txtTen.Text.Trim() + "%'";
			if (txtCMND.Text != "")
				strSQL = strSQL + " and CMND='" + txtCMND.Text.Trim() + "'";
			if (txtDiaChi.Text != "")
				strSQL = strSQL + " and DiaChi like '%" + txtDiaChi.Text.Trim() + "%'";
			int n = strSQL.IndexOf("and");
			if (n == 1)
				strSQL = strSQL.Substring(n + 4);
			dv.RowFilter = strSQL;
			dtGrid.DataSource = dv;
		}

		private void cmdThoat_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
