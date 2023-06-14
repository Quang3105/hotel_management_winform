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
    public partial class frmKH : Form
    {
		string msPhong = "", maHDTPhong = "";
		int pos = 0; bool trang_thai_trong = true;
		public frmKH()
        {
            InitializeComponent();
        }

		void Load_Phong()
		{
			DataTable dt = SqlHelper.ExecuteQuery("select * from view_list_Phong",
				CommandType.Text);
			panP.Controls.Clear();
			int i = 0;
			foreach (DataRow row in dt.Rows)
			{
				Label lb = new Label();
				lb.Location = new Point(i * 80, 0);
				lb.Click += new EventHandler(lb_Click);
				lb.Height = panP.Height - 20;
				lb.Width = 80;
				lb.TextAlign = ContentAlignment.MiddleCenter;
				lb.BorderStyle = BorderStyle.FixedSingle;
				lb.Text = row["MAPHONG"].ToString().Trim();
				lb.Name = "lb;" + row["MAPHONG"].ToString();
				panP.Controls.Add(lb);
				if (row["TINHTRANG"].ToString() == "True")
				{
					lb.BackColor = Color.Red;
				}
				else
				{
					lb.BackColor = Color.LightGreen;
				}
				lb.Tag = lb.BackColor.Name;
				i++;
			}
		}

		private void frmPhong_Load(object sender, System.EventArgs e)
		{
			Load_Phong();
			txtNV.Text = mainForm.tenNV;
		}

		private void cmdExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			for (int i = 0; i < lView.Items.Count; i++)
			{
				ListViewItem item = lView.Items[i];

				if (item.SubItems[0].Text == "")
				{
					// Thêm khách hàng
					SqlHelper.ExecuteNonQuery(
						"sp_ins_KH",
						CommandType.StoredProcedure,
						"@option", 1,
						"@MSKH", 1,
						"@HOTENKH", item.SubItems[1].Text,
						"@GIOITINH", item.SubItems[3].Text == "Nam" ? "1" : "0",
						"@DIACHI", item.SubItems[4].Text,
						"@CMND", item.SubItems[2].Text,
						"@DIENTHOAI", item.SubItems[5].Text);

					//Lấy mã số khách hàng mới thêm vào
					DataTable dtKH = SqlHelper.ExecuteQuery(
						"select * from dbo.fn_topKH()",
						CommandType.Text);

					//Thêm chi tiết thuê phòng
					SqlHelper.ExecuteNonQuery(
						"sp_ins_CHITIETTHUEPHONG",
						CommandType.StoredProcedure,
						"@option", 1,
						"@SOHDONGTHUEPHONG", maHDTPhong,
						"@MSKH", dtKH.Rows[0]["MSKH"]);
				}
				else
				{
					SqlHelper.ExecuteNonQuery(
						"sp_ins_KH",
						CommandType.StoredProcedure,
						"@option", 2,
						"@MSKH", item.SubItems[0].Text,
						"@HOTEN", item.SubItems[1].Text,
						"@CMND", item.SubItems[2].Text,
						"@GIOITINH", item.SubItems[3].Text == "Nam" ? "1" : "0",
						"@DIACHI", item.SubItems[4].Text,
						"@DIENTHOAI", item.SubItems[5].Text);
				}
			}
		}

		private void lb_Click(object sender, System.EventArgs e)
		{
			for (int i = 0; i < panP.Controls.Count; i++)
			{
				if (panP.Controls[i].Name.IndexOf("lb;") >= 0)
				{

					if (panP.Controls[i].Tag.ToString() == "Red")
						panP.Controls[i].BackColor = Color.Red;
					else
						panP.Controls[i].BackColor = Color.LightGreen;
				}
			}
			Label lb = sender as Label;
			msPhong = lb.Text;
			if (lb.Tag.ToString() == "Red")
			{
				lb.BackColor = Color.Gray;
				trang_thai_trong = false;
				cmdAdd.Enabled = true;
				cmdSave.Enabled = false;
				lView.Items.Clear();
				//Lấy thông tin khách hàng hiện thuê phòng
				DataTable dtPhong_KH = SqlHelper.ExecuteQuery(
					"sp_Phong_KH",
					CommandType.StoredProcedure,
					"@msphong", msPhong);
				if (dtPhong_KH.Rows.Count > 0)
				{
					foreach (DataRow row in dtPhong_KH.Rows)
					{
						ListViewItem item = new ListViewItem();
						item.Text = row["MAKHACH"].ToString();
						item.SubItems.Add(row["HOTEN"].ToString());
						item.SubItems.Add(row["CMND"].ToString());
						item.SubItems.Add(row["GIOITINH"].ToString() == "True" ? "Nam" : "Nữ");
						item.SubItems.Add(row["DIACHI"].ToString());
						item.SubItems.Add(row["DIENTHOAI"].ToString());
						maHDTPhong = row["SHDTHUEPHONG"].ToString();
						lView.Items.Add(item);
					}
					dTPicker_Thue.Text = dtPhong_KH.Rows[0]["NGAYTHUE"].ToString();
					dTPicker_Tra.Text = dtPhong_KH.Rows[0]["NGAYTRA"].ToString();
				}
			}
			else
			{
				lb.BackColor = Color.LightGray;
				if (trang_thai_trong == false)
					lView.Items.Clear();
				trang_thai_trong = true;
				cmdAdd.Enabled = false;
				cmdSave.Enabled = true;
			}
		}

		private void cmdSave_Click(object sender, System.EventArgs e)
		{
			if (msPhong == "")
			{
				MessageBox.Show("Chưa chọn phòng!.", "Lỗi");
				return;
			}
			try
			{
				//Thêm vào danh sách thuê phòng
				SqlHelper.ExecuteNonQuery(
					"insert into THUEPHONG VALUES (@MSNV, @MSPHONG, @NGAYTHUE, @NGAYTRA)",
					CommandType.Text,
					"@MSNV", mainForm.msNV,
					"@MSPHONG", msPhong,
					"@NGAYTHUE", dTPicker_Thue.Value,
					"@NGAYTRA", dTPicker_Tra.Value);
				//Lấy mã số hợp đồng thuê phòng mới thêm vào
				DataTable dtHD = SqlHelper.ExecuteQuery(
					"select * from dbo.fn_topSHD()",
					CommandType.Text);
				maHDTPhong = dtHD.Rows[0]["SHDTHUEPHONG"].ToString();
				for (int i = 0; i < lView.Items.Count; i++)
				{
					ListViewItem item = lView.Items[i];


					// Thêm khách hàng
					SqlHelper.ExecuteNonQuery(
						"sp_ins_KH",
						CommandType.StoredProcedure,
						"@option",1,
						"@MSKH",1,
						"@HOTEN", item.SubItems[1].Text,
						"@GIOITINH", item.SubItems[3].Text == "Nam" ? "0" : "1",
						"@DIACHI", item.SubItems[4].Text,
						"@CMND", item.SubItems[2].Text,
						"@DIENTHOAI", item.SubItems[5].Text);

					//Lấy mã số khách hàng mới thêm vào
					DataTable dtKH = SqlHelper.ExecuteQuery(
						"select * from dbo.fn_topKH()",
						CommandType.Text);

					//Thêm chi tiết thuê phòng
					SqlHelper.ExecuteNonQuery(
						"sp_ins_CHITIETTHUEPHONG",
						CommandType.StoredProcedure,
						"@option", 1,
						"@SHDTHUEPHONG", maHDTPhong,
						"@MSKH", dtKH.Rows[0]["MAKHACH"]);
				}
				Load_Phong();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void cmdAddNV_Click(object sender, System.EventArgs e)
		{
			if (txtTen.Text == "" || txtCMND.Text == "")
				return;
			ListViewItem item = new ListViewItem();
			item.Text = "";
			item.SubItems.Add(txtTen.Text);
			item.SubItems.Add(txtCMND.Text);
			item.SubItems.Add(optNam.Checked ? "Nam" : "Nữ");
			item.SubItems.Add(txtDChi.Text);
			item.SubItems.Add(txtDThoai.Text);

			lView.Items.Add(item);

			txtTen.Text = "";
			txtDChi.Text = "";
			txtDThoai.Text = "";
			txtCMND.Text = "";
		}

		private void cmdEditNV_Click(object sender, System.EventArgs e)
		{
			if (lView.SelectedItems.Count == 0)
				return;
			ListViewItem item = new ListViewItem();
			item.Text = lView.SelectedItems[0].Text;
			item.SubItems.Add(txtTen.Text);
			item.SubItems.Add(txtCMND.Text);
			item.SubItems.Add(optNam.Checked ? "Nam" : "Nữ");
			item.SubItems.Add(txtDChi.Text);
			item.SubItems.Add(txtDThoai.Text);

			lView.SelectedItems[0].Remove();

			lView.Items.Add(item);
		}

		private void lView_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lView.SelectedItems.Count == 0)
			{
				txtTen.Text = "";
				txtDChi.Text = "";
				txtDThoai.Text = "";
				txtCMND.Text = "";

				return;
			}

			ListViewItem item = lView.SelectedItems[0];
			pos = item.Index;
			txtTen.Text = item.SubItems[1].Text;
			txtCMND.Text = item.SubItems[2].Text;
			if (item.SubItems[3].Text == "Nam")
				optNam.Checked = true;
			else
				optNu.Checked = true;

			txtDChi.Text = item.SubItems[4].Text;
			txtDThoai.Text = item.SubItems[5].Text;
		}

		private void cmdDeleteNV_Click(object sender, System.EventArgs e)
		{
			if (lView.SelectedItems.Count == 0)
				return;
			lView.SelectedItems[0].Remove();
		}
	}
}
