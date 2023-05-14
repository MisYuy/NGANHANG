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
    public partial class frmEmployee : Form
    {
        String macn;
        int position;
        public frmEmployee()
        {
            InitializeComponent();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (((DataRowView)bdsNV[bdsNV.Position])["TrangThaiXoa"].ToString().Equals("1"))
            {
                MessageBox.Show("Nhân viên hiện không còn ở chi nhánh của bạn nữa\n", "", MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show("Bạn có xác nhận chuyển nhân viên?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    String manv = ((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString();
                    SqlDataReader myReader = Program.ExecSqlDataReader("EXEC SP_CONVERT_EMPLOYEE '" + manv + "'");
                    if(myReader.Read())
                    {
                        MessageBox.Show("Chuyển thành công");
                        this.NhanVienTableAdapter.Connection.ConnectionString = Program.connString;
                        this.NhanVienTableAdapter.Fill(this.NGANHANG_NHANVIEN.NhanVien);
                       
                    }
                    else
                    {
                        MessageBox.Show("Chuyển thất bại");

                    }
                    myReader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chuyển nhân viên.\n" + ex.Message, "", MessageBoxButtons.OK);
                    
                }
                 
            }
        }

        private void nhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsNV.EndEdit();
            this.tableAdapterManager.UpdateAll(this.NGANHANG_NHANVIEN);

        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            this.NGANHANG_NHANVIEN.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'nGANHANG_NHANVIEN.NhanVien' table. You can move, or remove it, as needed.
            this.NhanVienTableAdapter.Connection.ConnectionString = Program.connString;
            this.NhanVienTableAdapter.Fill(this.NGANHANG_NHANVIEN.NhanVien);
            // TODO: This line of code loads data into the 'NGANHANG_NHANVIEN.GD_GOIRUT' table. You can move, or remove it, as needed.
            this.GD_GOIRUTTableAdapter.Connection.ConnectionString = Program.connString;
            this.GD_GOIRUTTableAdapter.Fill(this.NGANHANG_NHANVIEN.GD_GOIRUT);
            // TODO: This line of code loads data into the 'NGANHANG_NHANVIEN.GD_CHUYENTIEN' table. You can move, or remove it, as needed.
            this.GD_CHUYENTIENTableAdapter.Connection.ConnectionString = Program.connString;
            this.GD_CHUYENTIENTableAdapter.Fill(this.NGANHANG_NHANVIEN.GD_CHUYENTIEN);
            macn = ((DataRowView)bdsNV[0])["MACN"].ToString();//*
            cmbChiNhanh.DataSource = Program.bds_dspm;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            if (Program.branch == 0)
            {
                cmbChiNhanh.SelectedIndex = 0;
            }
            else cmbChiNhanh.SelectedIndex = 1;
            if (Program.group == "NGANHANG")
            {
                cmbChiNhanh.Enabled = true;
                btnAdd.Enabled = btnConvert.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnUndo.Enabled = btnSave.Enabled = false;
                groupBox.Enabled = false;
            }
            else
            {
                cmbChiNhanh.Enabled = false;
                btnAdd.Enabled = btnConvert.Enabled = btnDelete.Enabled = btnEdit.Enabled = true;
                btnSave.Enabled = btnUndo.Enabled = false;
                groupBox.Enabled = true;
            }
            

        }

        private void nhanVienBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void txtHO_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void pHAILabel_Click(object sender, EventArgs e)
        {

        }

        private void pHAITextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void dIACHILabel_Click(object sender, EventArgs e)
        {

        }

        private void dIACHITextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void trangThaiXoaLabel1_Click(object sender, EventArgs e)
        {

        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            position = bdsNV.Position;
            groupBox.Enabled = true;
            bdsNV.AddNew();
            txtPHAI.Text = "Nam";
            txtMACN.Text = macn;
            cbXoa.EditValue = false;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnConvert.Enabled = btnRefresh.Enabled = btnExit.Enabled = false;
            btnSave.Enabled = btnUndo.Enabled = true;
            gcNhanVien.Enabled = false;
        }

        private void nhanVienGridControl_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMANV.Text.Trim() == "")
            {
                MessageBox.Show("Mã nhân viên không được để trống");
                txtMANV.Focus();
                return;

            }
            if (txtHO.Text.Trim() == "")
            {
                MessageBox.Show("Họ không được để trống");
                txtHO.Focus();
                return;

            }
            if (txtTEN.Text.Trim() == "")
            {
                MessageBox.Show("Tên không được để trống");
                txtTEN.Focus();
                return;

            }
            if (txtPHAI.Text.Trim() == "")
            {
                MessageBox.Show("Giới tính không được để trống");
                txtPHAI.Focus();
                return;

            }
            else if(txtPHAI.Text!="Nam" && txtPHAI.Text!="Nữ")
            {
                MessageBox.Show("Giới tính là 'Nam' hoặc 'Nữ'");
                txtPHAI.Focus();
                return;
            }
            if (txtCMND.Text.Trim() == "")
            {
                MessageBox.Show("Chứng minh nhân dân không được để trống");
                txtCMND.Focus();
                return;

            }
            if (txtDIACHI.Text == null)
            {
                MessageBox.Show("Địa chỉ không được để trống");
                txtDIACHI.Focus();
                return;

            }
            if (txtSDT.Text.Trim() == "")
            {
                MessageBox.Show("Số điện thoại không được để trống");
                txtSDT.Focus();
                return;

            }
            if (txtMACN.Text.Trim() == "")
            {
                MessageBox.Show("Mã chi nhánh không được để trống");
                txtMACN.Focus();
                return;

            }
            if (txtMACN.Text.Trim() == "")
            {
                MessageBox.Show("Mã chi nhánh không được để trống");
                txtMACN.Focus();
                return;

            }
            try
            {
                bdsNV.EndEdit();
                bdsNV.ResetCurrentItem();
                this.NhanVienTableAdapter.Connection.ConnectionString = Program.connString;
                this.NhanVienTableAdapter.Update(this.NGANHANG_NHANVIEN.NhanVien);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi ghi nhân viên.\n" + ex.Message);
                return;
            }
            gcNhanVien.Enabled = true;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnRefresh.Enabled = btnConvert.Enabled = btnExit.Enabled= true;
            btnSave.Enabled = btnUndo.Enabled = false;
            groupBox.Enabled = false;
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.NhanVienTableAdapter.Fill(this.NGANHANG_NHANVIEN.NhanVien);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi reload: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsNV.CancelEdit();
            if (btnAdd.Enabled == false) bdsNV.Position = position;
            gcNhanVien.Enabled = true;
            groupBox.Enabled = false;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnConvert.Enabled = btnRefresh.Enabled = btnExit.Enabled = true;
            btnSave.Enabled = btnUndo.Enabled = false;
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            position = bdsNV.Position;
            groupBox.Enabled = true;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnRefresh.Enabled = btnExit.Enabled = btnConvert.Enabled = false;
            btnSave.Enabled = btnUndo.Enabled = true;
            gcNhanVien.Enabled = false;
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Dispose();
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
                this.NhanVienTableAdapter.Connection.ConnectionString = Program.connString;
                this.NhanVienTableAdapter.Fill(this.NGANHANG_NHANVIEN.NhanVien);
                // TODO: This line of code loads data into the 'NGANHANG_NHANVIEN.GD_GOIRUT' table. You can move, or remove it, as needed.
                this.GD_GOIRUTTableAdapter.Connection.ConnectionString = Program.connString;
                this.GD_GOIRUTTableAdapter.Fill(this.NGANHANG_NHANVIEN.GD_GOIRUT);
                // TODO: This line of code loads data into the 'NGANHANG_NHANVIEN.GD_CHUYENTIEN' table. You can move, or remove it, as needed.
                this.GD_CHUYENTIENTableAdapter.Connection.ConnectionString = Program.connString;
                this.GD_CHUYENTIENTableAdapter.Fill(this.NGANHANG_NHANVIEN.GD_CHUYENTIEN);
                /*macn = ((DataRowView)bdsNV[0])["MACN"].ToString();//**/
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (((DataRowView)bdsNV[bdsNV.Position])["TrangThaiXoa"].ToString().Equals("1"))
            {
                MessageBox.Show("Nhân viên hiện không còn ở chi nhánh của bạn nữa\n", "", MessageBoxButtons.OK);
                return;
            }
            String manv="";
            if (bdsCT.Count > 0)
            {
                MessageBox.Show("Không thế xóa nhân viên vì đã thực hiện giao dịch chuyển tiền");

            }
            if (bdsGR.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên vì đã thực hiện giao dịch gởi rút");

            }
            if (MessageBox.Show("Bạn có xác nhận xóa nhân viên?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    manv = ((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString();
                    bdsNV.RemoveCurrent();
                    this.NhanVienTableAdapter.Connection.ConnectionString = Program.connString;
                    this.NhanVienTableAdapter.Update(this.NGANHANG_NHANVIEN.NhanVien);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa nhân viên. Bạn hãy xóa lại\n" + ex.Message, "", MessageBoxButtons.OK);
                    this.NhanVienTableAdapter.Fill(this.NGANHANG_NHANVIEN.NhanVien);
                    bdsNV.Position = bdsNV.Find("MANV", manv);
                    return;

                }
            }
            if (bdsNV.Count == 0) btnDelete.Enabled = false;
        }

        private void cbPHAI_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void cbXoa_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtPHAI_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
