using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NGANHANG
{
    static class Program
    {
        // Program variables
        public static SqlConnection sqlConnection = new SqlConnection();

        public static String connectionString = null;
        public static String serverName = "DESKTOP-KL0DTTA\\NGANHANG";
        public static String databaseName = "NGANHANG";
        public static String connPublisherString = "";

        public static String loginName = "";
        public static String username = "";
        public static String password = "";
        public static String ho_ten = "";
        public static String group = "";
        public static int branch;
        public static BindingSource bds_dspm= new BindingSource();
        public static frmMain frmMain;

        //hỗ trợ kết nối
        public static String remoteLogin = "HTKN";
        public static String remotePassword ="123";

        //Tài khoản đăng nhập
        public static String loginServer = "";
        public static String loginLogin = "";
        public static String loginPassword = "";

        public static readonly String NGANHANG = "NGANHANG";
        public static readonly String CHINHANH = "CHINHANH";
        public static readonly String KHACHHANG = "KHACHHANG";

        [STAThread]
        static void Main()
        {
            if (Program.ConnectSqlWithoutAccount() != 1)
            {
                MessageBox.Show("Kết nối tới database thất bại!");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmMain = new frmMain();
            Application.Run(frmMain);
        }

        #region Connect To Database Methods
        public static int ConnectSqlWithAccount()
        {
            if(sqlConnection != null || Program.sqlConnection.State == System.Data.ConnectionState.Open)
            {
                Program.sqlConnection.Close();
            }

            // Kiểm tra tồn tại tài khoản trong chi nhánh chỉ định
            try
            {
                connectionString = $"Data Source={Program.serverName};Initial Catalog={Program.databaseName};Integrated Security=True";
                //connPublisherString = connectionString;

                Program.sqlConnection.ConnectionString = connectionString;
                Program.sqlConnection.Open();
                SqlDataReader myReader = Program.ExecSqlDataReader($"SELECT * FROM sys.sql_logins WHERE name = '{Program.loginName}'");
                if (myReader.Read())
                {
                    Program.sqlConnection.Close();
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại trong database");
                    Program.sqlConnection.Close();
                    myReader.Close();
                    return 0;
                }
                myReader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi kết nối database: " + ex);
                return 0;
            }

            // Kiểm tra username và password
            try
            {
                connectionString = $"Data Source={Program.serverName};Initial Catalog={Program.databaseName};User ID={Program.loginName};Password={Program.password}";

                Program.sqlConnection.ConnectionString = connectionString;
                Program.sqlConnection.Open();
                return 1;
            }
            catch(SqlException ex)
            {
                connectionString = null;
                MessageBox.Show("Mật khẩu không chính xác!");
                return 0;
            }
        }

        public static int ConnectSqlWithoutAccount()
        {
            if (sqlConnection != null || Program.sqlConnection.State == System.Data.ConnectionState.Open)
            {
                Program.sqlConnection.Close();
            }
            try
            {
                connectionString = $"Data Source={Program.serverName};Initial Catalog={Program.databaseName};Integrated Security=True";

                Program.sqlConnection.ConnectionString = connectionString;
                Program.sqlConnection.Open();
                return 1;
            }
            catch (SqlException ex)
            {
                connectionString = null;
                MessageBox.Show("Kết nối thất bại: " + ex.Message);
                return 0;
            }
        }
        #endregion
        
        #region Execute Methods
        public static SqlDataReader ExecSqlDataReader(String query)
        {
            SqlDataReader myReader;
            SqlCommand cmd = new SqlCommand(query, Program.sqlConnection);
            cmd.CommandType = System.Data.CommandType.Text;
            if (Program.sqlConnection.State == System.Data.ConnectionState.Closed) Program.sqlConnection.Open();
            try
            {
                myReader = cmd.ExecuteReader();
                return myReader;
            }
            catch (SqlException ex)
            {
                Program.sqlConnection.Close();
                MessageBox.Show(ex.Message);
                return null;
            }

        }

        public static int ExecSqlNonQuery(String cmdString)
        {
            SqlCommand cmd = new SqlCommand(cmdString, Program.sqlConnection);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 600; //10 phút
            if (Program.sqlConnection.State == ConnectionState.Closed) Program.sqlConnection.Open();
            try
            {
                cmd.ExecuteNonQuery();
                Program.sqlConnection.Close();
                return 0;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                sqlConnection.Close();
                return ex.State; //Trạng thái lỗi trả về từ RAISERROR
            }
        }
        #endregion

        public static void LogOut()
        {
            Program.loginName = "";
            Program.username = "";
            Program.password = "";

            Program.loginPassword = "";
            Program.loginLogin = "";
            Program.frmMain.SetWorkingSpace("LogOut");
        }
    }
}
