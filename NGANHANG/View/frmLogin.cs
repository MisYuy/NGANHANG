using DevExpress.XtraEditors;
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
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        private SqlConnection getConnectToPublisher()
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = Program.connPublisherString;
                return conn;
            }
            catch(SqlException e)
            {
                MessageBox.Show("Connection failed, please check your server name and database");
            }
            return null;
        }
        private bool loadCbData()
        {
            SqlConnection conn = getConnectToPublisher();
            try
            {
                conn.Open();
                String sql = "Select * from Get_Subscribes";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Program.bds_dspm.DataSource = dt;
                cmbChiNhanh.DataSource = dt;
                cmbChiNhanh.DisplayMember = "TENCN";
                cmbChiNhanh.ValueMember = "TENSERVER";
                conn.Close();
                cmbChiNhanh.SelectedIndex = 1; cmbChiNhanh.SelectedIndex = 0;
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show("Connect failed");
            }
            return false;
        }
        public frmLogin()
        {
            InitializeComponent();
            if (!loadCbData())
            {
                this.Dispose();
                return;
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        /*private Boolean checkLoginExist(String login)
        {
            //Combo box chưa tạo hoặc có lỗi hiển thị
            if (this.cbQuarter==null || this.cbQuarter.SelectedValue==null||this.cbQuarter.SelectedValue.ToString().Length==0)
            {
                MessageBox.Show("Lỗi lấy dữ liệu combo box");
                return false;
            }
            Program.serverName = this.cbQuarter.SelectedValue.ToString();
            Program.login = "sa";
            Program.password = "123";
            if (Program.ConnectSql() == 1)
            {
                SqlDataReader myReader = Program.ExecSqlDataReader("SELECT * FROM sys.sql_logins WHERE name = '" + login + "'");
                if(myReader.Read())
                {
                    Program.conn.Close();
                    return true;
                }
                MessageBox.Show("Tài khoản không tồn tại");
                Program.conn.Close();
                return false;
            }
            MessageBox.Show("Lỗi kết nối server! Không thể kiểm tra tài khoản có tồn tại không");
            return false;
        }*/
        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            Program.login = this.txtUserName.Text.Trim();
            Program.password = this.txtPassword.Text.Trim();
            Program.serverName = this.cmbChiNhanh.SelectedValue.ToString().Trim();
            if (Program.login.Length == 0 || Program.password.Length == 0)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu còn trống");
                return;
            }
            if (Program.ConnectSql() == 1)
            {
                SqlDataReader myReader = Program.ExecSqlDataReader("EXEC SP_DANGNHAP '" + Program.login + "'");
                if (myReader.Read())
                {
                    Program.group = myReader.GetString(2);
                    if (Program.group != "NganHang" && Program.group != "ChiNhanh" && Program.group != "KhachHang")
                    {
                        MessageBox.Show("Lỗi không thể lấy được thông tin tài khoản");
                        return;
                    }
                    Program.userName = myReader.GetString(0);
                    Program.name = myReader.GetString(1);
                    Program.branch = cmbChiNhanh.SelectedIndex;
                    Program.loginServer = cmbChiNhanh.SelectedValue.ToString();
                    Program.loginLogin = Program.login;
                    Program.loginPassword = Program.password;
                }

                Program.f.SetWorkingSpace(Program.group);
                MessageBox.Show("Đăng nhập thành công");
                this.Dispose();
            }
        }

        private void cbQuarter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}