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
    public partial class frmChangeProfile : Form
    {
        public frmChangeProfile()
        {
            InitializeComponent();
        }
		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void cmdLogin_Click(object sender, System.EventArgs e)
		{
			if (txtPassWord.Text != txtPassWordR.Text)
			{
				MessageBox.Show("Mật khẩu nhập lại không chính xác!.", "Lỗi...");
				return;
			}
			SqlHelper.ExecuteNonQuery(
					"Update NHANVIEN set MATKHAU = @mk WHERE MANHANVIEN = @manv",
                    CommandType.Text, "@mk", txtPassWord.Text.Trim(), "@manv", mainForm.msNV);
			MessageBox.Show("Mật khẩu đã được thay đổi thành công!.", "Đã đổi mật khẩu");
		}

		private void frmChangeProfile_Load(object sender, System.EventArgs e)
		{
			txtMaNV.Text = mainForm.msNV;
		}
	}
}
