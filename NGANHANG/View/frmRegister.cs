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
    public partial class frmRegister : Form
    {
        private static String manv;
        public frmRegister(String x)
        {
            InitializeComponent();
            manv = x;
            txtLogin.Text = manv;
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            txtGroup.Text = Program.group;
        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có xác nhận tạo tài khoản nhân viên?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                try
                {
                    SqlDataReader myReader = Program.ExecSqlDataReader("EXEC SP_TAOLOGIN '" + manv + "','" + txtPassword.Text + "','"+manv+"','"+txtGroup.Text+"'");
                    myReader.Read();
                    MessageBox.Show("Tạo thành công");
                    myReader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tạo tài khoản nhân viên.\n" + ex.Message, "", MessageBoxButtons.OK);

                }
                this.Dispose();
            }
            else this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
