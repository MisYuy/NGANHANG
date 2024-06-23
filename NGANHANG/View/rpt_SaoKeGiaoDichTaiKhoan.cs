using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace NGANHANG.View
{
    public partial class rpt_SaoKeGiaoDichTaiKhoan : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_SaoKeGiaoDichTaiKhoan(string sotaikhoan, String ngaybatdau, String ngayketthuc)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connectionString;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = sotaikhoan;
            this.sqlDataSource1.Queries[0].Parameters[1].Value =ngaybatdau;
            this.sqlDataSource1.Queries[0].Parameters[2].Value =ngayketthuc;
            this.sqlDataSource1.Fill();

        }

    }
}
