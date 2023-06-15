using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }

        private void frmSaoKeGiaoDich_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nGANHANGDataSet_ADMIN.VIEW_TAIKHOAN' table. You can move, or remove it, as needed.
            this.vIEW_TAIKHOANTableAdapter.Fill(this.nGANHANGDataSet_ADMIN.VIEW_TAIKHOAN);

        }

        private void button1_Click(object sender, EventArgs e)
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

            string ngayBD = ngayBatDau.ToString("ddMMyyyy");
            string ngayKT = ngayKetThuc.ToString("ddMMyyyy");




            rpt_SaoKeGiaoDichTaiKhoan rpt = new rpt_SaoKeGiaoDichTaiKhoan(txtSoTaiKhoan.Text, ngayBD, ngayKT);
            rpt.lbTieuDe.Text = "SAO KÊ GIAO DỊCH TÀI KHOẢN TỪ " + ngayBatDau.ToString("dd/MM/yyyy") +
                " ĐẾN NGÀY " + ngayKetThuc.ToString("dd/MM/yyyy");
        }

        private void vIEW_TAIKHOANGridControl_Click(object sender, EventArgs e)
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
            this.Close();
        }
    }
}
