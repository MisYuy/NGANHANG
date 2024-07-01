namespace NGANHANG.View
{
    partial class frmSaoKeGiaoDich
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtSoTaiKhoan = new DevExpress.XtraEditors.TextEdit();
            this.dateBatDau = new DevExpress.XtraEditors.DateEdit();
            this.dateKetThuc = new DevExpress.XtraEditors.DateEdit();
            this.btnView = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblSoTaiKhoan = new System.Windows.Forms.Label();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.lblChonTK = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.bdsVIEW_TAIKHOAN = new System.Windows.Forms.BindingSource(this.components);
            this.gridControl_taikhoan = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCMND = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOTEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOTK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSODU = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTaiKhoan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBatDau.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBatDau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKetThuc.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKetThuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsVIEW_TAIKHOAN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_taikhoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSoTaiKhoan
            // 
            this.txtSoTaiKhoan.Location = new System.Drawing.Point(1200, 50);
            this.txtSoTaiKhoan.Margin = new System.Windows.Forms.Padding(17, 19, 17, 19);
            this.txtSoTaiKhoan.Name = "txtSoTaiKhoan";
            this.txtSoTaiKhoan.Properties.ReadOnly = true;
            this.txtSoTaiKhoan.Size = new System.Drawing.Size(477, 26);
            this.txtSoTaiKhoan.TabIndex = 0;
            // 
            // dateBatDau
            // 
            this.dateBatDau.EditValue = null;
            this.dateBatDau.Location = new System.Drawing.Point(1200, 110);
            this.dateBatDau.Margin = new System.Windows.Forms.Padding(17, 19, 17, 19);
            this.dateBatDau.Name = "dateBatDau";
            this.dateBatDau.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBatDau.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBatDau.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateBatDau.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateBatDau.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateBatDau.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateBatDau.Size = new System.Drawing.Size(294, 26);
            this.dateBatDau.TabIndex = 1;
            // 
            // dateKetThuc
            // 
            this.dateKetThuc.EditValue = null;
            this.dateKetThuc.Location = new System.Drawing.Point(1200, 170);
            this.dateKetThuc.Margin = new System.Windows.Forms.Padding(21, 24, 21, 24);
            this.dateKetThuc.Name = "dateKetThuc";
            this.dateKetThuc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateKetThuc.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateKetThuc.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateKetThuc.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateKetThuc.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateKetThuc.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateKetThuc.Size = new System.Drawing.Size(294, 26);
            this.dateKetThuc.TabIndex = 2;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(1000, 240);
            this.btnView.Margin = new System.Windows.Forms.Padding(14, 15, 14, 15);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(150, 40);
            this.btnView.TabIndex = 3;
            this.btnView.Text = "Xem";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.BackColor = System.Drawing.Color.Blue; // Set the background color to red
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1350, 240);
            this.btnExit.Margin = new System.Windows.Forms.Padding(14, 15, 14, 15);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(150, 40);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = false; // Ensure this is set to false to customize color
            this.btnExit.BackColor = System.Drawing.Color.Red; // Set the background color to red
            this.btnExit.ForeColor = System.Drawing.Color.White; 
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // 
            // lblSoTaiKhoan
            // 
            this.lblSoTaiKhoan.AutoSize = true;
            this.lblSoTaiKhoan.Location = new System.Drawing.Point(1000, 50);
            this.lblSoTaiKhoan.Margin = new System.Windows.Forms.Padding(14, 0, 14, 0);
            this.lblSoTaiKhoan.Name = "lblSoTaiKhoan";
            this.lblSoTaiKhoan.Size = new System.Drawing.Size(97, 19);
            this.lblSoTaiKhoan.TabIndex = 5;
            this.lblSoTaiKhoan.Text = "Số tài khoản";
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(1000, 110);
            this.lblTuNgay.Margin = new System.Windows.Forms.Padding(14, 0, 14, 0);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(68, 19);
            this.lblTuNgay.TabIndex = 6;
            this.lblTuNgay.Text = "Từ ngày";
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(1000, 170);
            this.lblDenNgay.Margin = new System.Windows.Forms.Padding(14, 0, 14, 0);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(72, 19);
            this.lblDenNgay.TabIndex = 7;
            this.lblDenNgay.Text = "Đến ngày";
            // 
            // lblChonTK
            // 
            this.lblChonTK.AutoSize = true;
            this.lblChonTK.Location = new System.Drawing.Point(1200, 10);
            this.lblChonTK.Margin = new System.Windows.Forms.Padding(14, 0, 14, 0);
            this.lblChonTK.Name = "lblChonTK";
            this.lblChonTK.Size = new System.Drawing.Size(126, 19);
            this.lblChonTK.TabIndex = 8;
            this.lblChonTK.Text = "Chọn tài khoản";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblChonTK);
            this.panelControl1.Controls.Add(this.lblDenNgay);
            this.panelControl1.Controls.Add(this.lblTuNgay);
            this.panelControl1.Controls.Add(this.lblSoTaiKhoan);
            this.panelControl1.Controls.Add(this.btnExit);
            this.panelControl1.Controls.Add(this.btnView);
            this.panelControl1.Controls.Add(this.dateKetThuc);
            this.panelControl1.Controls.Add(this.dateBatDau);
            this.panelControl1.Controls.Add(this.txtSoTaiKhoan);
            this.panelControl1.Location = new System.Drawing.Point(29, 17);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(17, 19, 17, 19);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1500, 300);
            this.panelControl1.TabIndex = 9;
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            // 
            // nGANHANGDataSet_ADMIN
            // 
            // bdsVIEW_TAIKHOAN
            // 
            // 
            // vIEW_TAIKHOANTableAdapter
            // 
            // 
            // tableAdapterManager
            // 
          //  this.tableAdapterManager.GD_CHUYENTIENTableAdapter = null;
          //  this.tableAdapterManager.GD_GOIRUTTableAdapter = null;
           // this.tableAdapterManager.KhachHangTableAdapter = null;
          //  this.tableAdapterManager.NhanVienTableAdapter = null;
//this.tableAdapterManager.TaiKhoanTableAdapter = null;
           // this.tableAdapterManager.UpdateOrder = NGANHANG.NGANHANGDataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // vIEW_TAIKHOANGridControl
            // 
            this.gridControl_taikhoan.DataSource = this.bdsVIEW_TAIKHOAN;
            this.gridControl_taikhoan.Location = new System.Drawing.Point(1000, 360);
            this.gridControl_taikhoan.MainView = this.gridView2;
            this.gridControl_taikhoan.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.gridControl_taikhoan.Name = "taikhoan";
            this.gridControl_taikhoan.Size = new System.Drawing.Size(1500, 650);
            this.gridControl_taikhoan.TabIndex = 10;
            this.gridControl_taikhoan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            this.gridControl_taikhoan.Dock = System.Windows.Forms.DockStyle.Bottom;
            //  this.vIEW_TAIKHOANGridControl.Click += new System.EventHandler(this.vIEW_TAIKHOANGridControl_Click);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCMND,
            this.colHOTEN,
            this.colSOTK,
            this.colSODU});
            this.gridView2.DetailHeight = 755;
            this.gridView2.FixedLineWidth = 4;
            this.gridView2.GridControl = this.gridControl_taikhoan;
            this.gridView2.Name = "gridView2";
            // 
            // colCMND
            // 
            this.colCMND.FieldName = "CMND";
            this.colCMND.MinWidth = 27;
            this.colCMND.Name = "colCMND";
            this.colCMND.Visible = true;
            this.colCMND.VisibleIndex = 0;
            this.colCMND.Width = 100;
            // 
            // colHOTEN
            // 
            this.colHOTEN.FieldName = "HOTEN";
            this.colHOTEN.MinWidth = 27;
            this.colHOTEN.Name = "colHOTEN";
            this.colHOTEN.Visible = true;
            this.colHOTEN.VisibleIndex = 1;
            this.colHOTEN.Width = 100;
            // 
            // colSOTK
            // 
            this.colSOTK.FieldName = "SOTK";
            this.colSOTK.MinWidth = 27;
            this.colSOTK.Name = "colSOTK";
            this.colSOTK.Visible = true;
            this.colSOTK.VisibleIndex = 2;
            this.colSOTK.Width = 100;
            // 
            // colSODU
            // 
            this.colSODU.FieldName = "SODU";
            this.colSODU.MinWidth = 27;
            this.colSODU.Name = "colSODU";
            this.colSODU.Visible = true;
            this.colSODU.VisibleIndex = 3;
            this.colSODU.Width = 100;
            // 
            // frmSaoKeGiaoDich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 660);
            this.Controls.Add(this.gridControl_taikhoan);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmSaoKeGiaoDich";
            this.Text = "Sao kê giao dịch";
            this.Load += new System.EventHandler(this.frmSaoKeGiaoDich_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTaiKhoan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBatDau.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBatDau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKetThuc.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKetThuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsVIEW_TAIKHOAN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_taikhoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtSoTaiKhoan;
        private DevExpress.XtraEditors.DateEdit dateBatDau;
        private DevExpress.XtraEditors.DateEdit dateKetThuc;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblSoTaiKhoan;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.Label lblChonTK;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.BindingSource bdsVIEW_TAIKHOAN;
        private DevExpress.XtraGrid.GridControl gridControl_taikhoan;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colCMND;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTEN;
        private DevExpress.XtraGrid.Columns.GridColumn colSOTK;
        private DevExpress.XtraGrid.Columns.GridColumn colSODU;
    }
}
