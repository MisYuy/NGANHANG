using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using NGANHANG.View;

namespace NGANHANG
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
            Form f = new frmLogin();
            f.MdiParent = this;
            f.Show();
        }
        private Form checkExists(Type t)
        {
            foreach(Form f in MdiChildren)
            {
                if (f.GetType() == t) return f;
            }
            return null;
        }

        public void SetWorkingSpace(String role)
        {
            if(role == "LogOut")
            {
                this.MaNV.Text = "MANV";
                this.HoTen.Text = "HOTEN";
                this.Nhom.Text = "NHOM";
                this.QuanTriPage.Visible = false;
                this.NghiepVuPage.Visible = false;
                this.ThongKePage.Visible = false;
                this.btnLogin.Enabled = true;
                this.btnChangePassword.Enabled = false;
                this.btnLogout.Enabled = false;
                this.btnEmployee.Enabled = false;
                this.btnCustomer.Enabled = false;
                
            }
            else if (role == "ChiNhanh" || role == "NganHang")
            {
                this.MaNV.Text = Program.userName;
                this.HoTen.Text = Program.name;
                this.Nhom.Text = Program.group;
                this.QuanTriPage.Visible = this.NghiepVuPage.Visible = this.ThongKePage.Visible = true;
                this.btnLogin.Enabled = false;
                this.btnChangePassword.Enabled = true;
                this.btnLogout.Enabled = true;
                this.btnEmployee.Enabled = true;
                this.btnCustomer.Enabled = true;
                this.PGSK.Visible = this.PGKH.Visible = this.PGTK.Visible = true;
            }
            else if (role == "KhachHang")
            {
                this.MaNV.Text = Program.userName;
                this.HoTen.Text = Program.name;
                this.Nhom.Text = Program.group;
                this.btnLogin.Enabled = false;
                this.btnChangePassword.Enabled = true;
                this.btnLogout.Enabled = true;
                this.ThongKePage.Visible = true;
                this.PGSK.Visible = true;
                this.PGKH.Visible = this.PGTK.Visible = false;
            }
            
            else
            {
                MessageBox.Show("Chưa xác định phân quyền người dùng");
            }
        }

        // Event Action
        private void btnLogin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.checkExists(typeof(frmLogin));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                f = new frmLogin();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnLogout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult res = MessageBox.Show("Xác nhận đăng xuất tài khoản?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(res == DialogResult.Yes)
            {
                Program.LogOut();
                foreach (Form f in MdiChildren)
                {
                    f.Dispose();
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
           

        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnEmployee_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.checkExists(typeof(frmEmployee));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                f = new frmEmployee();
                f.MdiParent = this;
                f.Show();
            }
        }


        private void btnChangePassword_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.checkExists(typeof(frmChangePassword));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                f = new frmChangePassword();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnCustomer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.checkExists(typeof(frmCustomer));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                f = new frmCustomer();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnAccount_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void btnTransaction_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.checkExists(typeof(frmService));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                f = new frmService();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.checkExists(typeof(frmLietKeKhachHangTheoChiNhanh));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                f = new frmLietKeKhachHangTheoChiNhanh();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItem1_ItemClick_2(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.checkExists(typeof(frmLietKeTaiKhoanMocs));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                f = new frmLietKeTaiKhoanMocs();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.checkExists(typeof(frmSaoKeGiaoDich));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                f = new frmSaoKeGiaoDich();
                f.MdiParent = this;
                f.Show();
            }
        }
    }
}
