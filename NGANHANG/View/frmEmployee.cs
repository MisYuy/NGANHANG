using DevExpress.DashboardCommon.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.Utils.MVVM.Internal.ILReader;

namespace NGANHANG.View
{
    public partial class frmEmployee : Form
    {
        String macn;
        int position;
        String btnStatus;
        public frmEmployee()
        {
            InitializeComponent();
        }
        private Form checkExists(Type t)
        {
            foreach (Form f in MdiChildren)
            {
                if (f.GetType() == t) return f;
            }
            return null;
        }
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (((DataRowView)bdsNV[bdsNV.Position])["TrangThaiXoa"].ToString().Equals("1"))
            {
                MessageBox.Show("Nhân viên hiện không còn ở chi nhánh của bạn nữa\n", "", MessageBoxButtons.OK);
                return;
            }
            if (((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString().Equals(Program.username))
            {
                MessageBox.Show("Bạn không được chuyển bản thân\n", "", MessageBoxButtons.OK);
                return;
            }
            String manv = ((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString();
            Form f = this.checkExists(typeof(frmConvert));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                f = new frmConvert(manv);
                f.Show();
            }
            this.NhanVienTableAdapter.Connection.ConnectionString = Program.connectionString;
            this.NhanVienTableAdapter.Fill(this.NGANHANG_NHANVIEN.NhanVien);
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
            this.NhanVienTableAdapter.Connection.ConnectionString = Program.connectionString;
            this.NhanVienTableAdapter.Fill(this.NGANHANG_NHANVIEN.NhanVien);
            // TODO: This line of code loads data into the 'NGANHANG_NHANVIEN.GD_GOIRUT' table. You can move, or remove it, as needed.
            this.GD_GOIRUTTableAdapter.Connection.ConnectionString = Program.connectionString;
            this.GD_GOIRUTTableAdapter.Fill(this.NGANHANG_NHANVIEN.GD_GOIRUT);
            // TODO: This line of code loads data into the 'NGANHANG_NHANVIEN.GD_CHUYENTIEN' table. You can move, or remove it, as needed.
            this.GD_CHUYENTIENTableAdapter.Connection.ConnectionString = Program.connectionString;
            this.GD_CHUYENTIENTableAdapter.Fill(this.NGANHANG_NHANVIEN.GD_CHUYENTIEN);
            //macn = ((DataRowView)bdsNV[0])["MACN"].ToString();
            macn = (Program.branch == 1 ? "BENTHANH" : "TANDINH");
            cmbChiNhanh.DataSource = Program.bds_dspm;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            if (Program.branch == 0)
            {
                cmbChiNhanh.SelectedIndex = 0;
            }
            else cmbChiNhanh.SelectedIndex = 1;
            if (Program.group == Program.NGANHANG)
            {
                cmbChiNhanh.Enabled = true;
                btnAdd.Enabled = btnConvert.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnUndo.Enabled = btnSave.Enabled = false;
                btnRefresh.Enabled = btnRegister.Enabled = btnExit.Enabled = true;
                groupBox.Enabled = false;
            }
            else
            {
                cmbChiNhanh.Enabled = false;
                btnAdd.Enabled = btnConvert.Enabled = btnDelete.Enabled = btnEdit.Enabled = true;
                btnEdit.Enabled = btnRegister.Enabled = btnRefresh.Enabled = btnExit.Enabled = true;
                btnSave.Enabled = btnUndo.Enabled = false;
                groupBox.Enabled = false;
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
            cbXoa.Enabled = false;
            cbXoa.EditValue = false;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnConvert.Enabled = btnRefresh.Enabled = btnExit.Enabled = btnRegister.Enabled = btnDeleteLogin.Enabled = false;
            btnSave.Enabled = btnUndo.Enabled = true;
            gcNhanVien.Enabled = false;
            btnStatus = "btnAdd";
        }

        private void nhanVienGridControl_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Regex so = new Regex("^\\d{10}$");
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
            if (!so.IsMatch(txtCMND.Text.Trim()))
            {
                MessageBox.Show("CMND sai dạng chuẩn gồm 10 chữ số");
                txtCMND.Focus();
                return;
            }
            if (txtDIACHI.Text.Trim() == "")
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
            if (!so.IsMatch(txtSDT.Text.Trim()))
            {
                MessageBox.Show("Số điện thoại sai dạng chuẩn gồm 10 chữ số");
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
                if (btnStatus!=null && btnStatus.Equals("btnAdd"))
                {
                    int excute = Program.ExecSqlNonQuery("EXEC SP_KT_NHANVIENLAM '" + txtCMND.Text + "'");

                    if (excute == 1 || excute == 2)
                    {
                        return;
                    }
                    else if (excute == 3)
                    {
                        if (MessageBox.Show("Bạn có muốn khôi phục nhân viên?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            int excute2 = Program.ExecSqlNonQuery("EXEC SP_KHOIPHUCNHANVIEN '" + txtCMND.Text + "'");
                            if (excute2 == 0)
                            {
                                MessageBox.Show("Khôi phục thành công");
                                this.NhanVienTableAdapter.Connection.ConnectionString = Program.connectionString;
                                this.NhanVienTableAdapter.Fill(this.NGANHANG_NHANVIEN.NhanVien);
                                gcNhanVien.Enabled = true;
                                btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnRefresh.Enabled = btnConvert.Enabled = btnExit.Enabled = btnRegister.Enabled = btnDeleteLogin.Enabled = true;
                                btnSave.Enabled = btnUndo.Enabled = false;
                                groupBox.Enabled = false;
                            }
                            else MessageBox.Show("Khôi phục thất bại!");
                        }
                        return;
                    }
                }
                bdsNV.EndEdit();
                bdsNV.ResetCurrentItem();
                this.NhanVienTableAdapter.Connection.ConnectionString = Program.connectionString;
                this.NhanVienTableAdapter.Update(this.NGANHANG_NHANVIEN.NhanVien);
                btnStatus = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi ghi nhân viên.\n" + ex.Message);
                return;
            }
            gcNhanVien.Enabled = true;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnRefresh.Enabled = btnConvert.Enabled = btnExit.Enabled= btnRegister.Enabled= btnDeleteLogin.Enabled = true;
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
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnConvert.Enabled = true;
            btnDeleteLogin.Enabled = btnRegister.Enabled= btnRefresh.Enabled = btnExit.Enabled = true;
            btnSave.Enabled = btnUndo.Enabled = false;
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString().Equals(Program.username))
            {
                MessageBox.Show("Bạn không được edit bản thân\n", "", MessageBoxButtons.OK);
                return;
            }

            if (((DataRowView)bdsNV[bdsNV.Position])["TrangThaiXoa"].ToString().Equals("1"))
            {
                MessageBox.Show("Nhân viên hiện không còn ở chi nhánh của bạn nữa");
                return;
            }

            position = bdsNV.Position;
            groupBox.Enabled = true;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnRefresh.Enabled = false;
            btnExit.Enabled = btnConvert.Enabled = btnRegister.Enabled = btnDeleteLogin.Enabled = false;
            btnSave.Enabled = btnUndo.Enabled = true;
            gcNhanVien.Enabled = false;
            cbXoa.Enabled = false;
            btnStatus = "btnEdit";
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
                MessageBox.Show("Lỗi kết nối về chi nhánh mới");
            }
            else
            {
                this.NhanVienTableAdapter.Connection.ConnectionString = Program.connectionString;
                this.NhanVienTableAdapter.Fill(this.NGANHANG_NHANVIEN.NhanVien);
                // TODO: This line of code loads data into the 'NGANHANG_NHANVIEN.GD_GOIRUT' table. You can move, or remove it, as needed.
                this.GD_GOIRUTTableAdapter.Connection.ConnectionString = Program.connectionString;
                this.GD_GOIRUTTableAdapter.Fill(this.NGANHANG_NHANVIEN.GD_GOIRUT);
                // TODO: This line of code loads data into the 'NGANHANG_NHANVIEN.GD_CHUYENTIEN' table. You can move, or remove it, as needed.
                this.GD_CHUYENTIENTableAdapter.Connection.ConnectionString = Program.connectionString;
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
            if (((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString().Equals(Program.username))
            {
                MessageBox.Show("Bạn không được xóa bản thân\n", "", MessageBoxButtons.OK);
                return;
            }
            String manv="";
            manv = ((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString();
            if ((bdsCT.Count>0 && bdsCT.Find("MANV", manv) != -1)||(bdsGR.Count > 0 && bdsGR.Find("MANV", manv) != -1))
            {
                if (MessageBox.Show("Không thế xóa hoàn toàn nhân viên vì nhân viên đã thực hiện giao dịch\n" +
                    "Hành động sau đây hệ thống sẽ tiến hành khóa nhân viên\n" +
                    "Hãy nhấn OK để xác nhận bước tiếp theo", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                }
                else return;
            }

            if (MessageBox.Show("Bạn vẫn muốn xóa nhân viên chứ?\nHành động sau hệ thống cũng sẽ xóa tài khoản của nhân viên\n" +
                "Hãy nhấn OK để xác nhận", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                
                int excute = Program.ExecSqlNonQuery("EXEC SP_XOANHANVIEN '" + manv + "'");
                if (excute == 0)
                {
                    int excute2= Program.ExecSqlNonQuery("EXEC SP_XOA_LOGIN '" + manv + "','" + manv + "'");
                    if(excute2==0) MessageBox.Show("Xóa tài khoản nhân viên thành công");
                    MessageBox.Show("Xóa nhân viên thành công");
                }
                this.NhanVienTableAdapter.Connection.ConnectionString = Program.connectionString;
                this.NhanVienTableAdapter.Fill(this.NGANHANG_NHANVIEN.NhanVien);
                bdsNV.Position = bdsNV.Find("MANV", manv);
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

        private void btnRegister_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (((DataRowView)bdsNV[bdsNV.Position])["TrangThaiXoa"].ToString().Equals("1"))
            {
                MessageBox.Show("Nhân viên hiện không còn ở chi nhánh của bạn nữa\n", "", MessageBoxButtons.OK);
                return;
            }
            if (((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString().Equals(Program.username))
            {
                MessageBox.Show("Bạn đã có tài khoản\n", "", MessageBoxButtons.OK);
                return;
            }
            String manv = ((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString();
            Form f = this.checkExists(typeof(frmRegister));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                f = new frmRegister(manv);
                f.Show();
            }
        }

        private void btnDeleteLogin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (((DataRowView)bdsNV[bdsNV.Position])["TrangThaiXoa"].ToString().Equals("1"))
            {
                MessageBox.Show("Nhân viên hiện không còn ở chi nhánh của bạn nữa\n", "", MessageBoxButtons.OK);
                return;
            }
            if (((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString().Equals(Program.username))
            {
                MessageBox.Show("Bạn không được xóa tài khoản bản thân\n", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có xác nhận xóa tài khoản nhân viên?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                String manv = ((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString();
                int excute = Program.ExecSqlNonQuery("EXEC SP_XOA_LOGIN '" + manv + "','" + manv + "'");
                if (excute == 0) MessageBox.Show("Xóa tài khoản thành công");
            }
        }
    }
}
