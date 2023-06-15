using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NGANHANG.View
{
    public partial class frmService : Form
    {
        public frmService()
        {
            InitializeComponent();
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            // Loại bỏ dữ liệu khách hàng cũ
            txtCMND.Text = "";
            txtKhachHang.Text = "";
            txtSoDu.Text = "";
            groupControlGuiRut.Enabled = groupControlChuyenTien.Enabled = false;

            // Kiểm tra chuỗi nhập
            if (Regex.Match(txtSoTk.Text, "[^0-9]").Success)
            {
                labelError.Visible = true;
                btnCheck.Enabled = false;
            }
            else
            {
                labelError.Visible = false;
                btnCheck.Enabled = true;
            }
            // Kiểm tra chuỗi rỗng
            if (txtSoTk.Text == "") btnCheck.Enabled = false;
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            String sql = string.Format("EXEC SP_LayThongTinChuTaiKhoan '{0}'", txtSoTk.Text);
            SqlDataReader reader = Program.ExecSqlDataReader(sql);
            try
            {
                if (reader.Read())
                {
                    txtCMND.Text = reader.GetString(0);
                    txtKhachHang.Text = reader.GetString(1);
                    txtSoDu.Text = ((int)reader.GetDecimal(2)).ToString();
                    groupControlGuiRut.Enabled = groupControlChuyenTien.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin");
                    txtSoTk.Focus();
                    groupControlGuiRut.Enabled = groupControlChuyenTien.Enabled = false;
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Lỗi\n" + ex.Message);
            }
            finally
            {
                reader.Close();
            }
        }
        private void txtSoTienGuiRut_EditValueChanged(object sender, EventArgs e)
        {
            if (Regex.Match(txtSoTienGuiRut.Text, "[^0-9]").Success)
            {
                labelErrorGuiRut.Visible = true;
                btnRut.Enabled = btnGui.Enabled = false;
            }
            else
            {
                labelErrorGuiRut.Visible = false;
                btnRut.Enabled = btnGui.Enabled = true;
            }
            if(txtSoTienGuiRut.Text == ""){
                btnRut.Enabled = btnGui.Enabled = false;
            }
        }

        private void txtSoTKThuHuong_EditValueChanged(object sender, EventArgs e)
        {
            txtCMNDNhan.Text = "";
            txtKhachHangNhan.Text = "";
            txtSoTienChuyen.Text = "";
            txtSoTienChuyen.Enabled = false;
            btnChuyen.Enabled = false;

            if (Regex.Match(txtSoTKThuHuong.Text, "[^0-9]").Success)
            {
                labelErrorTKChuyen.Visible = true;
                btnCheckTKChuyen.Enabled = false;
            }
            else
            {
                labelErrorTKChuyen.Visible = false;
                btnCheckTKChuyen.Enabled = true;
            }
        }

        private void txtSoTienChuyen_EditValueChanged(object sender, EventArgs e)
        {
            if (Regex.Match(txtSoTienChuyen.Text, "[^0-9]").Success)
            {
                labelErrorChuyenTien.Visible = true;
                btnChuyen.Enabled = false;
            }
            else
            {
                labelErrorChuyenTien.Visible = false;
                btnChuyen.Enabled = true;
            }

            if(txtSoTienChuyen.Text == "")
            {
                btnChuyen.Enabled = false;
            }
        }

        private void btnRut_Click(object sender, EventArgs e)
        {
            BigInteger sodu = BigInteger.Parse(txtSoDu.Text);
            BigInteger inputTien = BigInteger.Parse(txtSoTienGuiRut.Text);
            if(inputTien < 100000)
            {
                MessageBox.Show("Số tiền tối thiểu là 100,000");
                return;
            }
            if(sodu < inputTien)
            {
                MessageBox.Show("Số dư tài khoản không đủ");
                return;
            }
            if(MessageBox.Show("Xác nhận rút " + sodu + " ?","Xác nhận",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                String sql = string.Format("EXEC SP_RUTTIEN '{0}', '{1}'", txtSoTk.Text, inputTien);
                if(Program.ExecSqlNonQuery(sql) == 0)
                {
                    MessageBox.Show("Giao dịch rút tiền thành công");
                    txtSoDu.Text = (sodu - inputTien).ToString();
                }
            }
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            BigInteger sodu = BigInteger.Parse(txtSoDu.Text);
            BigInteger inputTien = BigInteger.Parse(txtSoTienGuiRut.Text);
            if (inputTien < 100000)
            {
                MessageBox.Show("Số tiền tối thiểu là 100,000");
                return;
            }
            if(MessageBox.Show("Xác nhận gửi vào tài khoản " + inputTien + " ?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                String sql = string.Format("EXEC SP_GOITIEN '{0}', '{1}'", txtSoTk.Text, inputTien);
                if (Program.ExecSqlNonQuery(sql) == 0)
                {
                    MessageBox.Show("Giao dịch gửi tiền thành công");
                    txtSoDu.Text = (sodu + inputTien).ToString();
                }
            }
        }

        private void frmService_Load(object sender, EventArgs e)
        {

        }

        private void frmService_Activated(object sender, EventArgs e)
        {
            Program.serverName = Program.loginServer;
            Program.login = Program.loginLogin;
            Program.password = Program.loginPassword;
            if (Program.ConnectSql() == 0)
            {
                MessageBox.Show("Lỗi kết nối server");
                this.Dispose();
            }
        }

        private void btnCheckTKChuyen_Click(object sender, EventArgs e)
        {
            if(txtSoTKThuHuong.Text == txtSoTk.Text)
            {
                MessageBox.Show("Không thể chuyển cho tài khoản hiện tại");
                return;
            }
            String sql = string.Format("EXEC SP_LayThongTinChuTaiKhoan '{0}'", txtSoTKThuHuong.Text);
            SqlDataReader reader = Program.ExecSqlDataReader(sql);
            try
            {
                if (reader.Read())
                {
                    txtCMNDNhan.Text = reader.GetString(0);
                    txtKhachHangNhan.Text = reader.GetString(1);
                    txtSoTienChuyen.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin");
                    txtSoTKThuHuong.Focus();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi\n" + ex.Message);
            }
            finally
            {
                reader.Close();
            }
        }

        private void btnChuyen_Click(object sender, EventArgs e)
        {
            /*if (Regex.Match(txtSoTienChuyen.Text, "[^0-9]").Success)
            {
                labelErrorChuyenTien.Visible = true;
                return;
            }
            else labelErrorChuyenTien.Visible = false;*/

            BigInteger sodu = BigInteger.Parse(txtSoDu.Text);
            BigInteger inputTien = BigInteger.Parse(txtSoTienChuyen.Text);

            if (inputTien < 100000)
            {
                MessageBox.Show("Số tiền tối thiểu là 100,000");
                return;
            }

            if(sodu < inputTien)
            {
                MessageBox.Show("Không đủ số dư");
                return;
            }

            if (MessageBox.Show("Xác nhận chuyển khoản " + inputTien + " ?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                String sql = string.Format("EXEC SP_CHUYENTIEN '{0}', '{1}', '{2}'", txtSoTk.Text, txtSoTKThuHuong.Text, inputTien);
                if (Program.ExecSqlNonQuery(sql) == 0)
                {
                    MessageBox.Show("Giao dịch chuyển tiền thành công");
                    txtSoDu.Text = (sodu - inputTien).ToString();
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
