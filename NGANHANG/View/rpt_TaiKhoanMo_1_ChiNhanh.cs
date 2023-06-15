using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace NGANHANG.View
{
    public partial class rpt_TaiKhoanMo_1_ChiNhanh : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_TaiKhoanMo_1_ChiNhanh(string machinhanh,string ngaybatdau, string ngayketthuc)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connPublisherString;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = machinhanh;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = ngaybatdau;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = ngayketthuc;
            this.sqlDataSource1.Fill();
        }

    }
}
