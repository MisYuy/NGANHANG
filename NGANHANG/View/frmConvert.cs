using DevExpress.XtraEditors;
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
    public partial class frmConvert : Form
    {
        public static String macn;
        public static String manv;
        public frmConvert(String x)
        {
            InitializeComponent();
            manv = x;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có xác nhận chuyển nhân viên?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                int excute = Program.ExecSqlNonQuery("EXEC SP_CHUYENNHANVIEN '" + manv + "','" + macn + "'");
                if (excute == 0)
                {
                    MessageBox.Show("Chuyển thành công");
                }
                this.Dispose();
            }
            else this.Dispose();

        }

        private void ChonChiNhanh_Load(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemComboBox properties = cmbChonChiNhanh.Properties;
            properties.Items.AddRange(new string[] {"BENTHANH","TANDINH"});
            cmbChonChiNhanh.SelectedIndex = Program.branch;
            properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmbChonChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            macn = cmbChonChiNhanh.SelectedItem.ToString();
        }
    }
}
