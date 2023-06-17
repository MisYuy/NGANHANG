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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.nGANHANGDataSet_ADMIN = new NGANHANG.NGANHANGDataSet1();
            this.bdsVIEW_TAIKHOAN = new System.Windows.Forms.BindingSource(this.components);
            this.vIEW_TAIKHOANTableAdapter = new NGANHANG.NGANHANGDataSet1TableAdapters.VIEW_TAIKHOANTableAdapter();
            this.tableAdapterManager = new NGANHANG.NGANHANGDataSet1TableAdapters.TableAdapterManager();
            this.vIEW_TAIKHOANGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCMND = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOTEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOTK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSODU = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTaiKhoan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBatDau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBatDau.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKetThuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKetThuc.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nGANHANGDataSet_ADMIN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsVIEW_TAIKHOAN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vIEW_TAIKHOANGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSoTaiKhoan
            // 
            this.txtSoTaiKhoan.Location = new System.Drawing.Point(308, 61);
            this.txtSoTaiKhoan.Margin = new System.Windows.Forms.Padding(17, 19, 17, 19);
            this.txtSoTaiKhoan.Name = "txtSoTaiKhoan";
            this.txtSoTaiKhoan.Properties.ReadOnly = true;
            this.txtSoTaiKhoan.Size = new System.Drawing.Size(477, 26);
            this.txtSoTaiKhoan.TabIndex = 0;
            // 
            // dateBatDau
            // 
            this.dateBatDau.EditValue = null;
            this.dateBatDau.Location = new System.Drawing.Point(308, 159);
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
            this.dateKetThuc.Location = new System.Drawing.Point(308, 229);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(102, 362);
            this.button1.Margin = new System.Windows.Forms.Padding(14, 15, 14, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(340, 95);
            this.button1.TabIndex = 3;
            this.button1.Text = "Xem";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(613, 362);
            this.button2.Margin = new System.Windows.Forms.Padding(14, 15, 14, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(399, 95);
            this.button2.TabIndex = 4;
            this.button2.Text = "Thoát";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(14, 0, 14, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Số tài khoản";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 162);
            this.label2.Margin = new System.Windows.Forms.Padding(14, 0, 14, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "Từ ngày";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 232);
            this.label3.Margin = new System.Windows.Forms.Padding(14, 0, 14, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Đến ngày";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(574, 37);
            this.label4.TabIndex = 8;
            this.label4.Text = "SAO KÊ GIAO DỊCH CỦA TÀI KHOẢN";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtSoTaiKhoan);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.button2);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.button1);
            this.panelControl1.Controls.Add(this.dateBatDau);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.dateKetThuc);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panelControl1.Location = new System.Drawing.Point(0, 235);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(17, 19, 17, 19);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1544, 574);
            this.panelControl1.TabIndex = 9;
            // 
            // nGANHANGDataSet_ADMIN
            // 
            this.nGANHANGDataSet_ADMIN.DataSetName = "nGANHANGDataSet_ADMIN";
            this.nGANHANGDataSet_ADMIN.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsVIEW_TAIKHOAN
            // 
            this.bdsVIEW_TAIKHOAN.DataMember = "VIEW_TAIKHOAN";
            this.bdsVIEW_TAIKHOAN.DataSource = this.nGANHANGDataSet_ADMIN;
            // 
            // vIEW_TAIKHOANTableAdapter
            // 
            this.vIEW_TAIKHOANTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = NGANHANG.NGANHANGDataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // vIEW_TAIKHOANGridControl
            // 
            this.vIEW_TAIKHOANGridControl.DataSource = this.bdsVIEW_TAIKHOAN;
            this.vIEW_TAIKHOANGridControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.vIEW_TAIKHOANGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(14, 15, 14, 15);
            this.vIEW_TAIKHOANGridControl.Location = new System.Drawing.Point(0, 37);
            this.vIEW_TAIKHOANGridControl.MainView = this.gridView2;
            this.vIEW_TAIKHOANGridControl.Margin = new System.Windows.Forms.Padding(14, 15, 14, 15);
            this.vIEW_TAIKHOANGridControl.Name = "vIEW_TAIKHOANGridControl";
            this.vIEW_TAIKHOANGridControl.Size = new System.Drawing.Size(1544, 198);
            this.vIEW_TAIKHOANGridControl.TabIndex = 11;
            this.vIEW_TAIKHOANGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            this.vIEW_TAIKHOANGridControl.Click += new System.EventHandler(this.vIEW_TAIKHOANGridControl_Click);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCMND,
            this.colHOTEN,
            this.colSOTK,
            this.colSODU});
            this.gridView2.DetailHeight = 1331;
            this.gridView2.GridControl = this.vIEW_TAIKHOANGridControl;
            this.gridView2.Name = "gridView2";
            // 
            // colCMND
            // 
            this.colCMND.FieldName = "CMND";
            this.colCMND.MinWidth = 85;
            this.colCMND.Name = "colCMND";
            this.colCMND.OptionsColumn.ReadOnly = true;
            this.colCMND.Visible = true;
            this.colCMND.VisibleIndex = 0;
            this.colCMND.Width = 319;
            // 
            // colHOTEN
            // 
            this.colHOTEN.FieldName = "HOTEN";
            this.colHOTEN.MinWidth = 85;
            this.colHOTEN.Name = "colHOTEN";
            this.colHOTEN.OptionsColumn.ReadOnly = true;
            this.colHOTEN.Visible = true;
            this.colHOTEN.VisibleIndex = 1;
            this.colHOTEN.Width = 319;
            // 
            // colSOTK
            // 
            this.colSOTK.FieldName = "SOTK";
            this.colSOTK.MinWidth = 85;
            this.colSOTK.Name = "colSOTK";
            this.colSOTK.OptionsColumn.ReadOnly = true;
            this.colSOTK.Visible = true;
            this.colSOTK.VisibleIndex = 2;
            this.colSOTK.Width = 319;
            // 
            // colSODU
            // 
            this.colSODU.FieldName = "SODU";
            this.colSODU.MinWidth = 85;
            this.colSODU.Name = "colSODU";
            this.colSODU.OptionsColumn.ReadOnly = true;
            this.colSODU.Visible = true;
            this.colSODU.VisibleIndex = 3;
            this.colSODU.Width = 319;
            // 
            // frmSaoKeGiaoDich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1544, 809);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.vIEW_TAIKHOANGridControl);
            this.Controls.Add(this.label4);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            ((System.ComponentModel.ISupportInitialize)(this.nGANHANGDataSet_ADMIN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsVIEW_TAIKHOAN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vIEW_TAIKHOANGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtSoTaiKhoan;
        private DevExpress.XtraEditors.DateEdit dateBatDau;
        private DevExpress.XtraEditors.DateEdit dateKetThuc;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private NGANHANGDataSet1 nGANHANGDataSet_ADMIN;
        private System.Windows.Forms.BindingSource bdsVIEW_TAIKHOAN;
        private NGANHANGDataSet1TableAdapters.VIEW_TAIKHOANTableAdapter vIEW_TAIKHOANTableAdapter;
        private NGANHANGDataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl vIEW_TAIKHOANGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colCMND;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTEN;
        private DevExpress.XtraGrid.Columns.GridColumn colSOTK;
        private DevExpress.XtraGrid.Columns.GridColumn colSODU;
    }
}