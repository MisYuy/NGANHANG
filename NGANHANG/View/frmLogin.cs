using System;
using System.Data;
using System.Data.SqlClient;
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
                conn.ConnectionString = "Data Source=DESKTOP-KL0DTTA\\NGANHANG;Initial Catalog=NGANHANG;Persist Security Info=True;User ID=HTKN;Password=123";
                Program.connPublisherString = conn.ConnectionString;
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
                cmbChiNhanh.SelectedIndex = 0;
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            Program.loginName = this.txtUserName.Text.Trim();
            Program.password = this.txtPassword.Text.Trim();
            Program.serverName = this.cmbChiNhanh.SelectedValue.ToString().Trim();
            if (Program.loginName.Length == 0 || Program.password.Length == 0)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu còn trống");
                return;
            }
            if (Program.ConnectSqlWithAccount() == 1)
            {
                
                SqlDataReader myReader = Program.ExecSqlDataReader("EXEC SP_DANGNHAP '" + Program.loginName + "'");
                if (myReader != null)
                {
                    if (myReader.Read())
                    {
                        Program.group = myReader.GetString(2);
                        if (Program.group != Program.NGANHANG && Program.group != Program.CHINHANH && Program.group != Program.KHACHHANG)
                        {
                            MessageBox.Show("Lỗi không thể lấy được thông tin tài khoản");
                            myReader.Close();
                            return;
                        }
                        Program.username = myReader.GetString(0);
                        Program.ho_ten = myReader.GetString(1);
                        Program.branch = cmbChiNhanh.SelectedIndex;
                        Program.loginServer = cmbChiNhanh.SelectedValue.ToString();
                        Program.loginLogin = Program.loginName;
                        Program.loginPassword = Program.password;
                        Program.frmMain.SetWorkingSpace(Program.group);
                        MessageBox.Show("Đăng nhập thành công");
                        this.Dispose();
                    }
                    myReader.Close();
                }
                else MessageBox.Show("Không thể đọc thông tin đăng nhập");
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