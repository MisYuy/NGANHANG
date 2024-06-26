using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NGANHANG.View
{
    public partial class frmSaoKeGiaoDich : Form
    {
        public frmSaoKeGiaoDich()
        {
            InitializeComponent();
            gridView2.RowClick += OnSelectRow;
        }

        private void frmSaoKeGiaoDich_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nGANHANGDataSet_ADMIN.VIEW_TAIKHOAN' table. You can move, or remove it, as needed.
            this.vIEW_TAIKHOANTableAdapter.Connection.ConnectionString = Program.connectionString;
            //this.vIEW_TAIKHOANTableAdapter.Fill(this.nGANHANGDataSet_ADMIN.VIEW_TAIKHOAN);
            loadTaiKhoan();
        }

        public void loadTaiKhoan()
        {
            using (SqlConnection conn = new SqlConnection(Program.connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_LAY_TAT_CA_TAI_KHOAN", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    bdsVIEW_TAIKHOAN.DataSource = dt;
                    gridControl_taikhoan.DataSource = bdsVIEW_TAIKHOAN;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading account data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OnSelectRow(object sender, EventArgs e)
        {
            // Lấy dòng đang được chọn
            var selectedRow = gridView2.GetFocusedDataRow();

            // Kiểm tra xem dòng có tồn tại và có giá trị trong cột SOTK không
            if (selectedRow != null && selectedRow["SOTK"] != null)
            {
                // Lấy giá trị từ cột SOTK của dòng được chọn
                var selectedValue = selectedRow["SOTK"].ToString();

                // Gán giá trị vào textEdit
                txtSoTaiKhoan.Text = selectedValue;
            }
            else
            {
                // Nếu không có giá trị, xóa nội dung của textEdit
                txtSoTaiKhoan.Text = string.Empty;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        // Add these methods to your frmSaoKeGiaoDich class
        private void btnView_Click(object sender, EventArgs e)
        {
            dateKetThuc.Properties.MaxValue = DateTime.Today;

            if (!DateTime.TryParseExact(dateBatDau.Text, "dd/MM/yyyy", null, DateTimeStyles.None, out DateTime ngayBatDau))
            {
                MessageBox.Show("Ngày bắt đầu không hợp lệ. Vui lòng nhập đúng định dạng dd/MM/yyyy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime ngayKetThuc;
            if (!DateTime.TryParseExact(dateKetThuc.Text, "dd/MM/yyyy", null, DateTimeStyles.None, out ngayKetThuc))
            {
                MessageBox.Show("Ngày kết thúc không hợp lệ. Vui lòng nhập đúng định dạng dd/MM/yyyy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ngayBatDau > ngayKetThuc)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string ngayBD = ngayBatDau.ToString("yyyy-MM-dd");
            string ngayKT = ngayKetThuc.ToString("yyyy-MM-dd");
            DateTime ngayBD2 = ngayBatDau.Date;
            DateTime ngayKT2 = ngayKetThuc.Date;

            // Create the connection parameters
            MsSqlConnectionParameters connectionParameters = new MsSqlConnectionParameters(
                "DESKTOP-KL0DTTA\\TANDINH", // Server name
                "NGANHANG",                 // Database name
                "TH",                       // User ID
                "123",                      // Password
                MsSqlAuthorizationType.SqlServer // Authentication type
            );

            // Create a new SQL data source with the connection parameters
            SqlDataSource sqlDataSource = new SqlDataSource(connectionParameters);

            // Create a stored procedure query
            StoredProcQuery storedProcQuery = new StoredProcQuery("SP_SAO_KE_GIAO_DICH", "SP_SAO_KE_GIAO_DICH");
            storedProcQuery.Parameters.Add(new QueryParameter("@SOTK", typeof(string), txtSoTaiKhoan.Text)); // Example account number
            storedProcQuery.Parameters.Add(new QueryParameter("@NGAYBD", typeof(DateTime), ngayBD));
            storedProcQuery.Parameters.Add(new QueryParameter("@NGAYKT", typeof(DateTime), ngayKT));

            // Add the query to the data source
            sqlDataSource.Queries.Add(storedProcQuery);
            sqlDataSource.Fill();

            // Create an instance of the report
            TransactionReport report = new TransactionReport();

            // Assign the data source to the report
            report.DataSource = sqlDataSource;
            report.DataMember = "SP_SAO_KE_GIAO_DICH";

            // Show the report preview
            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.ShowPreview();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
