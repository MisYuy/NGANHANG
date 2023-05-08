﻿using System;
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

        }

        private void nhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsNV.EndEdit();
            this.tableAdapterManager.UpdateAll(this.NGANHANG_NHANVIEN);

        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            
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
                btnAdd.Enabled = btnConvert.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnUndo.Enabled=btnSave.Enabled = false;
            }
            else
            {
                cmbChiNhanh.Enabled = false;
                btnAdd.Enabled = btnConvert.Enabled = btnDelete.Enabled = btnEdit.Enabled = true;
                btnSave.Enabled = btnUndo.Enabled = false;
            }
            groupBox.Enabled = false;

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
            txtMACN.Text = macn;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnConvert.Enabled = btnRefresh.Enabled = btnExit.Enabled = btnPrint.Enabled = false;
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
            cbPHAI.Text = "Nam";
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
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnRefresh.Enabled = btnPrint.Enabled = btnConvert.Enabled = btnExit.Enabled= true;
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
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnConvert.Enabled = btnPrint.Enabled = btnRefresh.Enabled = btnExit.Enabled = true;
            btnSave.Enabled = btnUndo.Enabled = false;
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            position = bdsNV.Position;
            groupBox.Enabled = true;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnRefresh.Enabled = btnExit.Enabled = btnPrint.Enabled = btnConvert.Enabled = true;
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
            Int32 manv = 0;
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
                    manv = int.Parse(((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString());
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
    }
}