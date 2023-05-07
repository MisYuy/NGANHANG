using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NGANHANG.View
{
    public partial class frmCustomer : Form
    {
        String macn;
        int position;
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void khachHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.khachHangBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.khachHang_BENTHANH);

        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            
            this.khachHangTableAdapter.Connection.ConnectionString = Program.connString;
            this.khachHangTableAdapter.Fill(this.khachHang_BENTHANH.KhachHang);

            this.taiKhoanTableAdapter.Connection.ConnectionString = Program.connString;
            this.taiKhoanTableAdapter.Fill(this.khachHang_BENTHANH.TaiKhoan);

            macn = ((DataRowView)khachHangBindingSource[0])["MACN"].ToString();
            cmbChiNhanh.DataSource = Program.bds_dspm;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            if (Program.branch == 0)
            {
                cmbChiNhanh.SelectedIndex = 0;
            }
            else cmbChiNhanh.SelectedIndex = 1;
            if (Program.group == "NganHang")
            {
                cmbChiNhanh.Enabled = true;
                btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnUndo.Enabled = btnSave.Enabled = false;
            }
            else
            {
                cmbChiNhanh.Enabled = false;
                btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = true;
                btnSave.Enabled = btnUndo.Enabled = false;
            }
        }

        private void khachHangGridControl_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            position = khachHangBindingSource.Position;
            panelControlKH.Enabled = true;
            khachHangBindingSource.AddNew();
            txtMaCN.Text = macn;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = false;
            btnSave.Enabled = btnUndo.Enabled = true;
            khachHangGridControl.Enabled = false;
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            khachHangBindingSource.CancelEdit();
            if (btnAdd.Enabled == false) khachHangBindingSource.Position = position;
            khachHangGridControl.Enabled = true;
            panelControlKH.Enabled = false;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = true;
            btnSave.Enabled = btnUndo.Enabled = false;
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Dispose();
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.khachHangTableAdapter.Fill(this.khachHang_BENTHANH.KhachHang);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi reload: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            position = khachHangBindingSource.Position;
            panelControlKH.Enabled = true;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = false;
            btnSave.Enabled = btnUndo.Enabled = true;
            khachHangGridControl.Enabled = false;
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

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
                this.khachHangTableAdapter.Fill(this.khachHang_BENTHANH.KhachHang);
            
                this.taiKhoanTableAdapter.Connection.ConnectionString = Program.connString;
                this.taiKhoanTableAdapter.Fill(this.khachHang_BENTHANH.TaiKhoan);
                /*macn = ((DataRowView)bdsNV[0])["MACN"].ToString();//**/
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtCMND.Text.Trim() == "")
            {
                MessageBox.Show("CMND không được để trống");
                txtCMND.Focus();
                return;
            }
            if (txtTen.Text.Trim() == "")
            {
                MessageBox.Show("Tên không được để trống");
                txtTen.Focus();
                return;
            }
            if (dateNgayCap.ToString() == "")
            {
                MessageBox.Show("Ngày cấp không được để trống");
                dateNgayCap.Focus();
                return;
            }
            if(txtPhai.Text.Trim() == "")
            {
                MessageBox.Show("Phái không được để trống");
                txtPhai.Focus();
                return;
            }
            else
            {
                String phai = txtPhai.Text.Trim();
                if(phai == "Nam" || phai == "Nữ")
                {
                    MessageBox.Show("Phái là Nam hoặc Nữ");
                    txtPhai.Focus();
                    return;

                }
            }
            
            try
            {
                khachHangBindingSource.EndEdit();
                khachHangBindingSource.ResetCurrentItem();
                this.khachHangTableAdapter.Connection.ConnectionString = Program.connString;
                this.khachHangTableAdapter.Update(this.khachHang_BENTHANH.KhachHang);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi khách hàng.\n" + ex.Message);
                return;
            }
            khachHangGridControl.Enabled = true;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = true;
            btnSave.Enabled = btnUndo.Enabled = false;
            panelControlKH.Enabled = false;
        }

        private void cmbPhai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
