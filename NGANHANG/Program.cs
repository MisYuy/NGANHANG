using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace NGANHANG
{
    static class Program
    {
        // Program variables
        public static SqlConnection conn = new SqlConnection();
        public static String connString = null;
        public static String serverName = "";
        public static String database = "NGANHANG";
        public static String connPublisherString = "Data Source = MSI; Initial Catalog =" +database+"; Integrated Security = True";
        public static String login = "";
        public static String userName = "";
        public static String password = "";
        public static String name = "";
        public static String group = "";
        public static int branch;
        public static BindingSource bds_dspm= new BindingSource();
        public static frmMain f;

        //hỗ trợ kết nối
        public static String remoteLogin = "HTKN";
        public static String remotePassword="123";
        //Tài khoản đăng nhập
        public static String loginServer = "";
        public static String loginLogin = "";
        public static String loginPassword = "";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            f = new frmMain();
            Application.Run(f);
        }

        // Functionns
        public static int ConnectSql()
        {
            if(conn != null || Program.conn.State == System.Data.ConnectionState.Open)
            {
                Program.conn.Close();
            }
            try
            {
                Program.conn.ConnectionString = "Data Source = " + Program.serverName+ "; Initial Catalog = NGANHANG; Integrated Security = True";
                Program.conn.Open();
                SqlDataReader myReader = Program.ExecSqlDataReader("SELECT * FROM sys.sql_logins WHERE name = '" + Program.login + "'");
                if (myReader.Read())
                {
                    Program.conn.Close();
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại trong server chỉ định");
                    Program.conn.Close();
                    myReader.Close();
                    return 0;
                }
                myReader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi kết nối server");
                return 0;
            }
            try
            {
                connString = "Data Source=" + Program.serverName 
                    + ";Initial Catalog=" + Program.database
                    + ";User ID=" + Program.login
                    + ";Password=" + Program.password;
                Program.conn.ConnectionString = connString;
                Program.conn.Open();
                return 1;
            }
            catch(SqlException ex)
            {
                connString = null;
                MessageBox.Show("Mật khẩu login không chính xác");
                return 0;
            }
        }

        public static int ConnectSqlNotUser()
        {
            if (conn != null || Program.conn.State == System.Data.ConnectionState.Open)
            {
                Program.conn.Close();
            }
            try
            {
                connString = "Data Source=" + Program.serverName
                    + ";Initial Catalog=" + Program.database
                    + "; Integrated Security = True";
                Program.conn.ConnectionString = connString;
                Program.conn.Open();
                return 1;
            }
            catch (SqlException ex)
            {
                connString = null;
                MessageBox.Show("Kết nối thất bại: "+ex.Message);
                return 0;
            }
        }

        public static void LogOut()
        {
            Program.login = "";
            Program.password = "";
            Program.loginPassword = "";
            Program.loginLogin = "";
            Program.f.SetWorkingSpace("LogOut");
        }

        public static SqlDataReader ExecSqlDataReader(String query)
        {
            SqlDataReader myReader;
            SqlCommand cmd = new SqlCommand(query, Program.conn);
            cmd.CommandType = System.Data.CommandType.Text;
            if (Program.conn.State == System.Data.ConnectionState.Closed) Program.conn.Open();
            try
            {
                myReader = cmd.ExecuteReader();
                return myReader;
            }
            catch(SqlException ex)
            {
                Program.conn.Close();
                MessageBox.Show(ex.Message);
                return null;
            }

        }

        public static DataTable ExecSqlDataTable(String query)
        {
            DataTable dt = new DataTable();
            if (Program.conn.State == ConnectionState.Closed) conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(query, Program.conn);
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        public static int ExecSqlNonQuery(String cmdString)
        {
            SqlCommand cmd = new SqlCommand(cmdString, Program.conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 600; //10 phút
            if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
                Program.conn.Close();
                return 0;
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
                return ex.State; //Trạng thái lỗi trả về từ RAISERROR
            }
        }
    }
}
