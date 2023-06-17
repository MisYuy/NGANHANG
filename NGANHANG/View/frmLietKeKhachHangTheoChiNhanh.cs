using DevExpress.CodeParser;
using DevExpress.XtraReports.UI;
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
    public partial class frmLietKeKhachHangTheoChiNhanh : Form
    {
        private SqlConnection getConnectToPublisher()
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = Program.connPublisherString;
                return conn;
            }
            catch (SqlException e)
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
            catch (Exception e)
            {
                MessageBox.Show("Connect failed");
            }
            return false;
        }
        public frmLietKeKhachHangTheoChiNhanh()
        {
            InitializeComponent();
            if (!loadCbData())
            {
                this.Dispose();
                return;
            }
        }

        private void frmLietKeKhachHangTheoChiNhanh_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nGANHANGDataSet1.Get_Subscribes' table. You can move, or remove it, as needed.
            //this.get_SubscribesTableAdapter.Connection.ConnectionString = Program.connString;
            //this.get_SubscribesTableAdapter.Fill(this.nGANHANGDataSet1.Get_Subscribes);
            // TODO: This line of code loads data into the 'nGANHANGDataSetkhachhang.KhachHang' table. You can move, or remove it, as needed.
            this.khachHangTableAdapter.Connection.ConnectionString = Program.connString;
            this.khachHangTableAdapter.Fill(this.nGANHANGDataSetkhachhang.KhachHang);
            //
            
            cmbChiNhanh.DataSource = Program.bds_dspm;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.branch;
            if(Program.group=="NganHang")
            {
                cmbChiNhanh.Enabled = true;
            }
            else cmbChiNhanh.Enabled=false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            string chiNhanh = cmbChiNhanh.Text;
            string chiNhanhCode = chiNhanh.Equals("BẾN THÀNH") ? "BENTHANH" : "TANDINH";
           
           
            rpt_LietKeKhachHangTheoChiNhanh rpt = new rpt_LietKeKhachHangTheoChiNhanh(chiNhanhCode);
            rpt.lbTieuDe.Text = "DANH SÁCH KHÁCH HÀNG THEO CHI NHÁNH " + cmbChiNhanh.Text.ToUpperInvariant();
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();

        }

        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView") return;
            Program.serverName = cmbChiNhanh.SelectedValue.ToString();
            if (cmbChiNhanh.SelectedIndex != Program.branch)
            {
                Program.login = Program.remoteLogin;
                Program.password = Program.remotePassword;
            }
            else
            {
                Program.login = Program.loginLogin;
                Program.password = Program.loginPassword;
            }
            if (Program.ConnectSql() == 0)
            {
                MessageBox.Show("Lỗi kết nối về chi nhánh mới");
            }
            else
            {
                this.khachHangTableAdapter.Connection.ConnectionString = Program.connString;
                this.khachHangTableAdapter.Fill(this.nGANHANGDataSetkhachhang.KhachHang);
            }
           
        }
    }
}
