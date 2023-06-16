using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NGANHANG.View
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!txtOldPass.Text.Equals(Program.loginPassword))
            {
                MessageBox.Show("Không đúng mật khẩu cũ", "Thông báo");
                return;
            }
            if (txtNewPass.Text.Trim()==""|| txtRepeatPass.Text.Trim() == "")
            {
                MessageBox.Show("Mật khẩu không chứa khoảng trắng", "Thông báo");
                return;
            }

            if (!txtNewPass.Text.Equals(txtRepeatPass.Text))
            {
                MessageBox.Show("Mật khẩu xác nhận lại không đúng", "Thông báo");
                return;
            }

            if (MessageBox.Show("Xác nhận đổi mật khẩu?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                String sql = string.Format("EXEC SP_DOI_MAT_KHAU '"+Program.loginLogin +"','" + txtNewPass.Text+"'");
                if (Program.ConnectSqlNotUser() == 1)
                {//Kết nối tài khoản window
                    int excute = Program.ExecSqlNonQuery(sql);
                    if (excute == 0)
                    {
                        MessageBox.Show("Đổi mật khẩu thành công, vui lòng đăng nhập lại", "Thông báo");
                        
                        Program.conn.ConnectionString = Program.connPublisherString;
                        Program.conn.Open();
                        Program.LogOut();
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Đổi mật khẩu thất bại", "Lỗi");
                        if (Program.ConnectSql() == 0) MessageBox.Show("Kết nối lại tài khoản thất bại");//Kết nối lại tài khoản
                    }
                }
                else MessageBox.Show("Kết nối tài khoản window trong server thất bại");

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
