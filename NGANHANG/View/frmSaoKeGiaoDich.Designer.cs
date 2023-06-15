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
            this.vIEW_TAIKHOANBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.vIEW_TAIKHOANBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vIEW_TAIKHOANGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSoTaiKhoan
            // 
            this.txtSoTaiKhoan.Location = new System.Drawing.Point(274, 49);
            this.txtSoTaiKhoan.Margin = new System.Windows.Forms.Padding(15, 15, 15, 15);
            this.txtSoTaiKhoan.Name = "txtSoTaiKhoan";
            this.txtSoTaiKhoan.Properties.ReadOnly = true;
            this.txtSoTaiKhoan.Size = new System.Drawing.Size(424, 22);
            this.txtSoTaiKhoan.TabIndex = 0;
            // 
            // dateBatDau
            // 
            this.dateBatDau.EditValue = null;
            this.dateBatDau.Location = new System.Drawing.Point(274, 175);
            this.dateBatDau.Margin = new System.Windows.Forms.Padding(15, 15, 15, 15);
            this.dateBatDau.Name = "dateBatDau";
            this.dateBatDau.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBatDau.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBatDau.Size = new System.Drawing.Size(261, 22);
            this.dateBatDau.TabIndex = 1;
            // 
            // dateKetThuc
            // 
            this.dateKetThuc.EditValue = null;
            this.dateKetThuc.Location = new System.Drawing.Point(880, 180);
            this.dateKetThuc.Margin = new System.Windows.Forms.Padding(19, 19, 19, 19);
            this.dateKetThuc.Name = "dateKetThuc";
            this.dateKetThuc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateKetThuc.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateKetThuc.Size = new System.Drawing.Size(261, 22);
            this.dateKetThuc.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 288);
            this.button1.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(302, 76);
            this.button1.TabIndex = 3;
            this.button1.Text = "Xem";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(514, 298);
            this.button2.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(355, 68);
            this.button2.TabIndex = 4;
            this.button2.Text = "Thoát";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nhập số tài khoản";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 185);
            this.label2.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Từ ngày";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(680, 185);
            this.label3.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
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
            this.label4.Size = new System.Drawing.Size(475, 33);
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
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panelControl1.Location = new System.Drawing.Point(0, 253);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(15, 15, 15, 15);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1372, 394);
            this.panelControl1.TabIndex = 9;
            // 
            // nGANHANGDataSet_ADMIN
            // 
            this.nGANHANGDataSet_ADMIN.DataSetName = "NGANHANGDataSet_ADMIN";
            this.nGANHANGDataSet_ADMIN.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vIEW_TAIKHOANBindingSource
            // 
            this.vIEW_TAIKHOANBindingSource.DataMember = "VIEW_TAIKHOAN";
            this.vIEW_TAIKHOANBindingSource.DataSource = this.nGANHANGDataSet_ADMIN;
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
            this.vIEW_TAIKHOANGridControl.DataSource = this.vIEW_TAIKHOANBindingSource;
            this.vIEW_TAIKHOANGridControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.vIEW_TAIKHOANGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.vIEW_TAIKHOANGridControl.Location = new System.Drawing.Point(0, 33);
            this.vIEW_TAIKHOANGridControl.MainView = this.gridView2;
            this.vIEW_TAIKHOANGridControl.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.vIEW_TAIKHOANGridControl.Name = "vIEW_TAIKHOANGridControl";
            this.vIEW_TAIKHOANGridControl.Size = new System.Drawing.Size(1372, 570);
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
            this.gridView2.DetailHeight = 1065;
            this.gridView2.GridControl = this.vIEW_TAIKHOANGridControl;
            this.gridView2.Name = "gridView2";
            // 
            // colCMND
            // 
            this.colCMND.FieldName = "CMND";
            this.colCMND.MinWidth = 76;
            this.colCMND.Name = "colCMND";
            this.colCMND.Visible = true;
            this.colCMND.VisibleIndex = 0;
            this.colCMND.Width = 284;
            // 
            // colHOTEN
            // 
            this.colHOTEN.FieldName = "HOTEN";
            this.colHOTEN.MinWidth = 76;
            this.colHOTEN.Name = "colHOTEN";
            this.colHOTEN.Visible = true;
            this.colHOTEN.VisibleIndex = 1;
            this.colHOTEN.Width = 284;
            // 
            // colSOTK
            // 
            this.colSOTK.FieldName = "SOTK";
            this.colSOTK.MinWidth = 76;
            this.colSOTK.Name = "colSOTK";
            this.colSOTK.Visible = true;
            this.colSOTK.VisibleIndex = 2;
            this.colSOTK.Width = 284;
            // 
            // colSODU
            // 
            this.colSODU.FieldName = "SODU";
            this.colSODU.MinWidth = 76;
            this.colSODU.Name = "colSODU";
            this.colSODU.Visible = true;
            this.colSODU.VisibleIndex = 3;
            this.colSODU.Width = 284;
            // 
            // frmSaoKeGiaoDich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1372, 647);
            this.Controls.Add(this.vIEW_TAIKHOANGridControl);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.label4);
            this.Name = "frmSaoKeGiaoDich";
            this.Text = "frmSaoKeGiaoDich";
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
            ((System.ComponentModel.ISupportInitialize)(this.vIEW_TAIKHOANBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource vIEW_TAIKHOANBindingSource;
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