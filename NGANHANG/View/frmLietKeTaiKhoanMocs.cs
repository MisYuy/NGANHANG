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
    public partial class frmLietKeTaiKhoanMocs : Form
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
        public frmLietKeTaiKhoanMocs()
        {
            InitializeComponent();
            if (!loadCbData())
            {
                this.Dispose();
                return;
            }
        }

        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView") return;
            Program.serverName = cmbChiNhanh.SelectedValue.ToString();
            if (cmbChiNhanh.SelectedIndex != Program.branch)
            {
                Program.loginName = Program.remoteLogin;
                Program.password = Program.remotePassword;
            }
            else
            {
                Program.loginName = Program.loginLogin;
                Program.password = Program.loginPassword;
            }
            if (Program.ConnectSqlWithAccount() == 0)
            {
                //MessageBox.Show("Lỗi kết nối về chi nhánh mới");
            }
            else
            {
                
               
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            string chiNhanh = cmbChiNhanh.Text;
            string chiNhanhCode = chiNhanh.Equals("BẾN THÀNH") ? "BENTHANH" : "TANDINH";
            dateKT.Properties.MaxValue = DateTime.Today;
            if (!DateTime.TryParseExact(dateBD.Text, "dd/MM/yyyy", null, DateTimeStyles.None, out DateTime ngayBatDau))
            {
                MessageBox.Show("Ngày bắt đầu không hợp lệ. Vui lòng nhập đúng định dạng dd/MM/yyyy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime ngayKetThuc;
            if (!DateTime.TryParseExact(dateKT.Text, "dd/MM/yyyy", null, DateTimeStyles.None, out ngayKetThuc))
            {
                MessageBox.Show("Ngày kết thúc không hợp lệ. Vui lòng nhập đúng định dạng dd/MM/yyyy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime ngayHienTai = DateTime.Now.Date;
            if (ngayKetThuc > ngayHienTai)
            {
                MessageBox.Show("Ngày kết thúc không thể lớn hơn ngày hiện tại. Ngày kết thúc sẽ được đặt là ngày hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ngayKetThuc = ngayHienTai;
            }

            if (ngayBatDau > ngayKetThuc)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string ngayBD = ngayBatDau.ToString("yyyy/MM/dd");
            string ngayKT = ngayKetThuc.ToString("yyyy/MM/dd");
            rpt_TaiKhoanMo_1_ChiNhanh rpt = new rpt_TaiKhoanMo_1_ChiNhanh(chiNhanhCode, ngayBD, ngayKT);
           
            rpt.lbTieuDe.Text = "DANH SÁCH  TÀI KHOẢN MỞ Ở "+chiNhanh +" TỪ " + ngayBatDau.ToString("dd/MM/yyyy") +
                " ĐẾN NGÀY " + ngayKetThuc.ToString("dd/MM/yyyy");

            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }



        private void btnXemTatCa_Click(object sender, EventArgs e)
        {
            dateKT.Properties.MaxValue = DateTime.Today;
            if (!DateTime.TryParseExact(dateBD.Text, "dd/MM/yyyy", null, DateTimeStyles.None, out DateTime ngayBatDau))
            {
                MessageBox.Show("Ngày bắt đầu không hợp lệ. Vui lòng nhập đúng định dạng dd/MM/yyyy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime ngayKetThuc;
            if (!DateTime.TryParseExact(dateKT.Text, "dd/MM/yyyy", null, DateTimeStyles.None, out ngayKetThuc))
            {
                MessageBox.Show("Ngày kết thúc không hợp lệ. Vui lòng nhập đúng định dạng dd/MM/yyyy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime ngayHienTai = DateTime.Now.Date;
            if (ngayKetThuc > ngayHienTai)
            {
                MessageBox.Show("Ngày kết thúc không thể lớn hơn ngày hiện tại. Ngày kết thúc sẽ được đặt là ngày hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ngayKetThuc = ngayHienTai;
            }

            if (ngayBatDau > ngayKetThuc)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string ngayBD = ngayBatDau.ToString("yyyy/MM/dd");
            string ngayKT = ngayKetThuc.ToString("yyyy/MM/dd");

            rpt_TaiKhoanMoTatCaChiNhanh rpt = new rpt_TaiKhoanMoTatCaChiNhanh(ngayBD, ngayKT);
            rpt.lbTieuDe.Text = "DANH SÁCH TẤT CẢ TÀI KHOẢN MỞ TỪ " + ngayBatDau.ToString("MMddyyyy") +
                " ĐẾN NGÀY " + ngayKetThuc.ToString("MMddyyyy");



            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }



        private void frmLietKeTaiKhoanMocs_Load(object sender, EventArgs e)
        {
            cmbChiNhanh.DataSource = Program.bds_dspm;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.branch;
            if (Program.group == Program.NGANHANG)
            {
                cmbChiNhanh.Enabled = true;
                btnXemTatCa.Enabled = true;
            }
            else { 
                cmbChiNhanh.Enabled = false;
                btnXemTatCa.Enabled = false;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
