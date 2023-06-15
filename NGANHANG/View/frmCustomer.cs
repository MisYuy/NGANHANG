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

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            this.nGANHANG_ChiNhanh.EnforceConstraints = false;
            cmbChiNhanh.DataSource = Program.bds_dspm;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";

            cmbChiNhanh.SelectedIndex = Program.branch;
            macn = (Program.branch == 0 ? "BENTHANH" : "TANDINH");

            if (Program.group == "NganHang")
            {
                groupControlTaiKhoan.Enabled = false;
                btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnUndo.Enabled = btnSave.Enabled = false;
            }
            else
            {
                groupControlTaiKhoan.Enabled = true;
                btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = true;
                btnSave.Enabled = btnUndo.Enabled = false;
            }
            this.dateNgayCap.Properties.MaxValue = DateTime.Today;
            
            Program.serverName = cmbChiNhanh.SelectedValue.ToString();
            if(Program.ConnectSql() == 1)
            {
                khachHangTableAdapter.Connection.ConnectionString = Program.connString;
                khachHangTableAdapter.Fill(this.nGANHANG_ChiNhanh.KhachHang);

                taiKhoanTableAdapter.Connection.ConnectionString = Program.connString;
                taiKhoanTableAdapter.Fill(this.nGANHANG_ChiNhanh.TaiKhoan);
            }
            else
            {
                this.Dispose();
            }
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            position = bdsKhachHang.Position;
            bdsKhachHang.AddNew();
            panelControlKH.Enabled = true;
            khachHangGridControl.Enabled = false;
            groupControlTaiKhoan.Enabled = false;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = false;
            btnSave.Enabled = btnUndo.Enabled = true;
            txtMaCN.Text = macn;
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsKhachHang.CancelEdit();
            //Trường hợp thêm khách hàng
            if(bdsKhachHang.Position != position)
            {
                bdsKhachHang.RemoveCurrent();
                bdsKhachHang.Position = position;
            }
            khachHangGridControl.Enabled = true;
            panelControlKH.Enabled = false;
            groupControlTaiKhoan.Enabled = true;
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
                this.khachHangTableAdapter.Fill(this.nGANHANG_ChiNhanh.KhachHang);
                this.taiKhoanTableAdapter.Fill(this.nGANHANG_ChiNhanh.TaiKhoan);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi reload: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(bdsKhachHang.Count == 0)
            {
                MessageBox.Show("Không có thông tin khách hàng");
                btnEdit.Enabled = false;
                return;
            }
            position = bdsKhachHang.Position;
            panelControlKH.Enabled = true;
            khachHangGridControl.Enabled = false;
            groupControlTaiKhoan.Enabled = false;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = false;
            btnSave.Enabled = btnUndo.Enabled = true;
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String cmnd = "";
            if(bdsKhachHang.Count == 0)
            {
                MessageBox.Show("Không có khách hàng để xóa");
                return;
            }
            if (bdsTaiKhoan.Count > 0)
            {
                MessageBox.Show("Không thế xóa khách hàng đã tạo tài khoản");
                return;
            }
            
            if (MessageBox.Show("Bạn có xác nhận xóa khách hàng?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    cmnd = ((DataRowView)bdsKhachHang[bdsKhachHang.Position])["CMND"].ToString();
                    bdsKhachHang.RemoveCurrent();
                    this.khachHangTableAdapter.Update(this.nGANHANG_ChiNhanh.KhachHang);
                    String sql = string.Format("EXEC SP_XOALOGIN '{0}','{1}'", cmnd, cmnd);
                    Program.serverName = cmbChiNhanh.SelectedValue.ToString();
                    if (Program.ConnectSql() == 1)
                    {
                        Program.ExecSqlNonQuery(sql);
                    }
                    MessageBox.Show("Xóa thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa khách hàng. Bạn hãy xóa lại\n" + ex.Message);
                    this.khachHangTableAdapter.Fill(this.nGANHANG_ChiNhanh.KhachHang);
                    bdsKhachHang.Position = bdsKhachHang.Find("CMND", cmnd);
                    return;
                }
            }
            if (bdsKhachHang.Count == 0) btnDelete.Enabled = false;
        }

        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView") return;

            Program.serverName = cmbChiNhanh.SelectedValue.ToString();
            if (cmbChiNhanh.SelectedIndex != Program.branch)
            {
                Program.login = Program.remoteLogin;
                Program.password = Program.remotePassword;
                btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = false;
            }
            else
            {
                Program.login = Program.loginLogin;
                Program.password = Program.loginPassword;
                btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = true;
            }
            if (Program.ConnectSql() == 0)
            {
                MessageBox.Show("Lỗi kết nối về chi nhánh mới");
                this.Dispose();
            }
            else
            {
                this.khachHangTableAdapter.Connection.ConnectionString = Program.connString;
                this.khachHangTableAdapter.Fill(this.nGANHANG_ChiNhanh.KhachHang);
            
                this.taiKhoanTableAdapter.Connection.ConnectionString = Program.connString;
                this.taiKhoanTableAdapter.Fill(this.nGANHANG_ChiNhanh.TaiKhoan);
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtCMND.Text = txtCMND.Text.Trim();
            txtHo.Text = txtHo.Text.Trim();
            txtTen.Text = txtTen.Text.Trim();
            txtDiaChi.Text = txtDiaChi.Text.Trim();
            txtSoDT.Text = txtSoDT.Text.Trim();

            if(txtCMND.Text == "")
            {
                MessageBox.Show("CMND không được để trống");
                txtCMND.Focus();
                return;
            }
            if (!Regex.Match(txtCMND.Text,"^[0-9]{10}$").Success)
            {
                MessageBox.Show("CMND phải là chuỗi 10 số");
                txtCMND.Focus();
                return;
            }
            if (txtHo.Text == "")
            {
                MessageBox.Show("Họ không được để trống");
                txtTen.Focus();
                return;
            }
            if (txtTen.Text == "")
            {
                MessageBox.Show("Tên không được để trống");
                txtTen.Focus();
                return;
            }
            if(txtPhai.Text != "Nam" && txtPhai.Text != "Nữ")
            {
                MessageBox.Show("Vui lòng nhập phái là Nam hoặc Nữ");
                return;
            }
            if (dateNgayCap.ToString() == "")
            {
                MessageBox.Show("Ngày cấp không được để trống");
                dateNgayCap.Focus();
                return;
            }

            if(txtSoDT.Text != null && !Regex.Match(txtSoDT.Text, "^0[0-9]{9,11}$").Success)
            {
                MessageBox.Show("Số điện thoại phải là chuỗi 0 và 9 hoặc 11 chữ số liền kề, vui lòng nhập lại");
                return;
            }
            
            try
            {
                bdsKhachHang.EndEdit();
                bdsKhachHang.ResetCurrentItem();
                this.khachHangTableAdapter.Update(this.nGANHANG_ChiNhanh.KhachHang);
                if(position != bdsKhachHang.Position)
                {
                    String sql = string.Format("EXEC dbo.SP_TAOLOGIN '{0}', '{1}', '{2}', '{3}'", txtCMND.Text,"123",txtCMND.Text, "KhachHang");
                    Program.serverName = cmbChiNhanh.SelectedValue.ToString();
                    if(Program.ConnectSql() == 1 && Program.ExecSqlNonQuery(sql) == 0)
                    {
                        MessageBox.Show("Lưu thành công");
                    }
                    else
                    {
                        bdsKhachHang.RemoveCurrent();
                        this.khachHangTableAdapter.Update(this.nGANHANG_ChiNhanh.KhachHang);
                        MessageBox.Show("Thêm khách hàng thất bại, lỗi tạo tài khoản đăng nhập");
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi khách hàng.\n" + ex.Message);
                return;
            }
            khachHangGridControl.Enabled = true;
            panelControlKH.Enabled = false;
            groupControlTaiKhoan.Enabled = true;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = true;
            btnSave.Enabled = btnUndo.Enabled = false;
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (bdsKhachHang.Count == 0) toolStripMenuItemThem.Visible = false;
            else toolStripMenuItemThem.Visible = true;

            if (bdsTaiKhoan.Count == 0) toolStripMenuItemXoa.Visible = false;
            else toolStripMenuItemXoa.Visible = true;
        }

        private void toolStripMenuItemThem_Click(object sender, EventArgs e)
        {
            if(txtCMND.Text == "")
            {
                MessageBox.Show("Không có thông tin chủ tài khoản");
                return;
            }
            if(MessageBox.Show("Xác nhận thêm tài khoản cho khách hàng này?","Xác nhận",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                String sql = string.Format("INSERT INTO TaiKhoan(CMND,MACN) VALUES ('{0}','{1}')", txtCMND.Text, macn);
                if (Program.ExecSqlNonQuery(sql) == 0)
                {
                    this.taiKhoanTableAdapter.Fill(this.nGANHANG_ChiNhanh.TaiKhoan);
                    MessageBox.Show("Thêm tài khoản thành công");
                }

            }
        }

        private void toolStripMenuItemXoa_Click(object sender, EventArgs e)
        {
            String tmp = ((DataRowView)bdsTaiKhoan.Current)["MACN"].ToString().Trim();
            if (tmp != macn)
            {
                MessageBox.Show("Không thể xóa tài khoản được mở ở chi nhánh khác");
                return;
            }

            if (MessageBox.Show("Bạn chắc chắn muốn xóa tài khoản này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                String sotk = ((DataRowView)bdsTaiKhoan.Current)["SOTK"].ToString();
                String sql = string.Format("EXEC dbo.SP_XOATAIKHOAN '{0}'", sotk);
                Program.serverName = cmbChiNhanh.SelectedValue.ToString();
                if(Program.ConnectSql() == 1)
                {
                    if(Program.ExecSqlNonQuery(sql) == 0)
                    {
                        bdsTaiKhoan.RemoveCurrent();
                        MessageBox.Show("Xóa thành công");
                    }
                }
            }    
        }
    }
}
