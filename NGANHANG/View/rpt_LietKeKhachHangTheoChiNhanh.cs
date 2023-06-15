using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace NGANHANG.View
{
    public partial class rpt_LietKeKhachHangTheoChiNhanh : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_LietKeKhachHangTheoChiNhanh()
        {
            
        }

        public rpt_LietKeKhachHangTheoChiNhanh(string machinnhanh)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connString;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = machinnhanh;
            this.sqlDataSource1.Fill();
        }

    }
}
