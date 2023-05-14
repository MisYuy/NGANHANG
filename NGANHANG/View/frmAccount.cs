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
    public partial class frmAccount : Form
    {
        String macn;
        int position;
        public frmAccount()
        {
            InitializeComponent();
        }
        private void taiKhoanBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.TaiKhoanBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.TaiKhoanDataSet);

        }

        private void frmAccount_Load(object sender, EventArgs e)
        {
            TaiKhoanDataSet.EnforceConstraints = false;
            TaiKhoanTableAdapter.Connection.ConnectionString = Program.connString;
            this.TaiKhoanTableAdapter.Fill(this.TaiKhoanDataSet.TaiKhoan);

            macn = (Program.branch == 0 ? "BENTHANH" : "TANDINH");
         
            if (Program.group == "NganHang")
            {
                btnAdd.Enabled = btnDelete.Enabled = btnUndo.Enabled = btnSave.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = btnDelete.Enabled = true;
                btnSave.Enabled = btnUndo.Enabled = false;
            }
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            taiKhoanGridControl.Enabled = false;
            position = TaiKhoanBindingSource.Position;
            TaiKhoanBindingSource.AddNew();
            txtMaCN.Text = macn;
            panelControl2.Enabled = true;
            btnAdd.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = false;
            btnUndo.Enabled = btnSave.Enabled = true;
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtSoTK.Text = txtSoTK.Text.Trim();
            txtCMND.Text = txtCMND.Text.Trim();
            txtSoDu.Text = txtSoDu.Text.Trim();
            //SoTk tự động 
            if(txtCMND.Text == "")
            {
                MessageBox.Show("CMND không được để trống");
                return;
            }
            if(txtSoDu.Text == "")
            {
                MessageBox.Show("Số dư không được để trống");
                return;
            }

            try
            {
                TaiKhoanBindingSource.EndEdit();
                TaiKhoanBindingSource.ResetCurrentItem();
                
                SqlDataReader myReader = Program.ExecSqlDataReader("EXEC SP_TAOLOGIN '" + txtSoTK.Text + "','" + "123" + "','" + txtSoTK.Text + "', 'KhachHang'");
                myReader.Read();
                MessageBox.Show("Tạo thành công");
                myReader.Close();
                
                this.TaiKhoanTableAdapter.Connection.ConnectionString = Program.connString;
                this.TaiKhoanTableAdapter.Update(this.TaiKhoanDataSet.TaiKhoan);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi tài khoản.\n" + ex.Message);
                return;
            }
            taiKhoanGridControl.Enabled = true;
            btnAdd.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = true;
            btnSave.Enabled = btnUndo.Enabled = false;
            panelControl2.Enabled = false;
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TaiKhoanBindingSource.CancelEdit();
            TaiKhoanBindingSource.Position = position;
            taiKhoanGridControl.Enabled = true;
            panelControl2.Enabled = false;
            btnAdd.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = true;
            btnUndo.Enabled = btnSave.Enabled = false;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.TaiKhoanTableAdapter.Fill(this.TaiKhoanDataSet.TaiKhoan);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi reload: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Dispose();
        }
    }
}
