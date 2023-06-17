namespace NGANHANG.View
{
    partial class frmLietKeTaiKhoanMocs
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
            this.cmbChiNhanh = new System.Windows.Forms.ComboBox();
            this.btnXem = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnXemTatCa = new DevExpress.XtraEditors.SimpleButton();
            this.dateBD = new DevExpress.XtraEditors.DateEdit();
            this.dateKT = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dateBD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBD.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKT.Properties.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbChiNhanh
            // 
            this.cmbChiNhanh.FormattingEnabled = true;
            this.cmbChiNhanh.Location = new System.Drawing.Point(344, 359);
            this.cmbChiNhanh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbChiNhanh.Name = "cmbChiNhanh";
            this.cmbChiNhanh.Size = new System.Drawing.Size(272, 28);
            this.cmbChiNhanh.TabIndex = 0;
            this.cmbChiNhanh.SelectedIndexChanged += new System.EventHandler(this.cmbChiNhanh_SelectedIndexChanged);
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(322, 591);
            this.btnXem.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(208, 70);
            this.btnXem.TabIndex = 1;
            this.btnXem.Text = "Xem";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(761, 591);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(217, 70);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXemTatCa
            // 
            this.btnXemTatCa.Location = new System.Drawing.Point(747, 316);
            this.btnXemTatCa.Margin = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.btnXemTatCa.Name = "btnXemTatCa";
            this.btnXemTatCa.Size = new System.Drawing.Size(385, 88);
            this.btnXemTatCa.TabIndex = 3;
            this.btnXemTatCa.Text = "XEM TẤT CẢ CHI NHÁNH";
            this.btnXemTatCa.Click += new System.EventHandler(this.btnXemTatCa_Click);
            // 
            // dateBD
            // 
            this.dateBD.EditValue = null;
            this.dateBD.Location = new System.Drawing.Point(344, 474);
            this.dateBD.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.dateBD.Name = "dateBD";
            this.dateBD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBD.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBD.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateBD.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateBD.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateBD.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateBD.Size = new System.Drawing.Size(274, 26);
            this.dateBD.TabIndex = 4;
            // 
            // dateKT
            // 
            this.dateKT.EditValue = null;
            this.dateKT.Location = new System.Drawing.Point(836, 474);
            this.dateKT.Margin = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.dateKT.Name = "dateKT";
            this.dateKT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateKT.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateKT.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateKT.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateKT.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateKT.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateKT.Properties.MaskSettings.Set("mask", "dd/MM/yyyy");
            this.dateKT.Size = new System.Drawing.Size(343, 26);
            this.dateKT.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(191, 368);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(111, 19);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Chọn chi nhánh";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(213, 481);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(59, 19);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Từ ngày";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(747, 481);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(67, 19);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "Đến ngày";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Location = new System.Drawing.Point(513, 152);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(691, 37);
            this.labelControl4.TabIndex = 9;
            this.labelControl4.Text = "TÀI KHOẢN MỞ TRONG KHOẢNG THỜI GIAN";
            // 
            // frmLietKeTaiKhoanMocs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 875);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.dateKT);
            this.Controls.Add(this.dateBD);
            this.Controls.Add(this.btnXemTatCa);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.cmbChiNhanh);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmLietKeTaiKhoanMocs";
            this.Text = "Liệt kê tài khoản mở";
            this.Load += new System.EventHandler(this.frmLietKeTaiKhoanMocs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dateBD.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKT.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKT.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbChiNhanh;
        private DevExpress.XtraEditors.SimpleButton btnXem;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnXemTatCa;
        private DevExpress.XtraEditors.DateEdit dateBD;
        private DevExpress.XtraEditors.DateEdit dateKT;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}