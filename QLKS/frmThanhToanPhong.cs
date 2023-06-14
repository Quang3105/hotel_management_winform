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
    public partial class frmThanhToanPhong : Form
    {
        DateTime ngaytra;
        double tong_tien = 0;
        public frmThanhToanPhong()
        {
            InitializeComponent();
        }

		void Load_Phong()
		{
			try
			{
				DataTable dtLoaiP = SqlHelper.ExecuteQuery(
					"select * FROM VIEW_TP",
					CommandType.Text);
				cboMaP.DataSource = dtLoaiP;
				cboMaP.DisplayMember = "MAPHONG";
				cboMaP.ValueMember = "SHDTHUEPHONG";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void frmPhong_Load(object sender, System.EventArgs e)
		{
			Load_Phong();

		}

		private void cmdExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void cmdShow_Click(object sender, System.EventArgs e)
		{
			try
			{
				//MessageBox.Show(cboMaP.SelectedValue.ToString());

				DataTable dtTT = SqlHelper.ExecuteQuery(
					"sp_list_SuDungDV",
					CommandType.StoredProcedure,
					"@SOHDONGTHUEPHONG", cboMaP.SelectedValue);

				lView.Items.Clear();
				double giaDV = 0;
				lView.Items.Clear();
				if (dtTT.Rows.Count > 0)
				{
					foreach (DataRow row in dtTT.Rows)
					{
						ListViewItem item = new ListViewItem();
						item.Text = row["TENTHIETBI"].ToString();
						item.SubItems.Add(DateTime.Parse(row["NGAYSUDUNG"].ToString()).ToString("d"));
						item.SubItems.Add(row["SOLUONG"].ToString());
						item.SubItems.Add(Double.Parse(row["GIATIEN"].ToString()).ToString("c"));
						giaDV = giaDV + Double.Parse(row["GIATIEN"].ToString()) * Double.Parse(row["SOLUONG"].ToString());
						lView.Items.Add(item);
					}
				}
				DataTable dtNgayThue = SqlHelper.ExecuteQuery(
					"select NGAYTHUE from THUEPHONG where SHDTHUEPHONG=" + cboMaP.SelectedValue,
					CommandType.Text);
				DateTime ngaythue = DateTime.Parse(dtNgayThue.Rows[0]["NGAYTHUE"].ToString());
				ngaytra = DateTime.Now;
				double giaPhong = Lay_Tien_Phong(cboMaP.Text.Trim(), ngaythue, ngaytra);

				tong_tien = giaDV + giaPhong;
				txtBaoCao.Text = "Nhân viên thanh toán: \t" + mainForm.tenNV + "\r\n";
				txtBaoCao.Text = txtBaoCao.Text + "Mã số phòng thuê: \t\t" + cboMaP.Text.Trim() + "\r\n";
				txtBaoCao.Text = txtBaoCao.Text + "Ngày thuê: \t\t" + ngaythue.ToShortDateString() + "\r\n";
				txtBaoCao.Text = txtBaoCao.Text + "Ngày trả: \t\t\t" + ngaytra.ToShortDateString() + "\r\n";
				txtBaoCao.Text = txtBaoCao.Text + "Phí thuê phòng: \t\t" + giaPhong.ToString("c") + "\r\n";
				txtBaoCao.Text = txtBaoCao.Text + "Phí sử dụng dịch vụ: \t" + giaDV.ToString("c") + "\r\n";
				txtBaoCao.Text = txtBaoCao.Text + "--------------------------------------------------------\r\n";
				txtBaoCao.Text = txtBaoCao.Text + "Tổng cộng: \t\t" + tong_tien.ToString("c");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		double Lay_Tien_Phong(string msphong, DateTime ngaythue, DateTime ngaytra)
		{
			DataTable dtGiaP = SqlHelper.ExecuteQuery(
				"select LOAIPHONG.GIATIEN from DMPHONG, LOAIPHONG where LOAIPHONG.MALOAIPHONG=DMPHONG.MALOAIPHONG and DMPHONG.MAPHONG= @MAPHONG",
				CommandType.Text,"@MAPHONG", msphong);
			double giatien = double.Parse(dtGiaP.Rows[0]["GIATIEN"].ToString());
			TimeSpan t;
			t = ngaytra.Subtract(ngaythue);
			double songay = t.TotalDays;

			giatien = giatien * Math.Round(songay);
			return Math.Round(giatien);
		}

		private void cmdThanhToan_Click(object sender, System.EventArgs e)
		{
			try
			{
				//Đưa csdl vào table HDTHANHTOANPHONG
				SqlHelper.ExecuteNonQuery(
					"sp_ins_HDThanhToan",
					CommandType.StoredProcedure,
					"@SOHDTHUEPHONG", cboMaP.SelectedValue,
					"@MSNV", mainForm.msNV,
					"@NGAYTHANHTOAN", ngaytra,
					"@TIENPHONG", Double.Parse(tong_tien.ToString()));
				//Đặt lại trạng thái trống cho phòng
				SqlHelper.ExecuteNonQuery(
					"Update DMPHONG set TINHTRANG='0' WHERE MAPHONG='" + cboMaP.Text.Trim() + "'",
					CommandType.Text);
				txtBaoCao.Clear();
				lView.Items.Clear();
				Load_Phong();
				MessageBox.Show("Thanh toán thành công");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
