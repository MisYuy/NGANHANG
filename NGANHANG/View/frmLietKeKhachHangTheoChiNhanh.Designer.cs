namespace NGANHANG.View
{
    partial class frmLietKeKhachHangTheoChiNhanh
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
            this.cmbChiNhanh = new System.Windows.Forms.ComboBox();
            this.getSubscribesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnXem = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            //this.nGANHANGDataSetkhachhang = new NGANHANG.NGANHANGDataSetkhachhang();
            this.nGANHANGDataSetkhachhangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.khachHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            //this.khachHangTableAdapter = new NGANHANG.NGANHANG_KhachHangTableAdapters.KhachHangTableAdapter();
            this.spLietKeKhachHangTheoChiNhanhBindingSource = new System.Windows.Forms.BindingSource(this.components);
            //this.sp_LietKeKhachHangTheoChiNhanhTableAdapter = new NGANHANG.NGANHANG_KhachHangTableAdapters.sp_LietKeKhachHangTheoChiNhanhTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.getSubscribesBindingSource)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.nGANHANGDataSetkhachhang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGANHANGDataSetkhachhangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.khachHangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spLietKeKhachHangTheoChiNhanhBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbChiNhanh
            // 
            this.cmbChiNhanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChiNhanh.FormattingEnabled = true;
            this.cmbChiNhanh.Location = new System.Drawing.Point(260, 182);
            this.cmbChiNhanh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbChiNhanh.Name = "cmbChiNhanh";
            this.cmbChiNhanh.Size = new System.Drawing.Size(292, 28);
            this.cmbChiNhanh.TabIndex = 0;
            this.cmbChiNhanh.SelectedIndexChanged += new System.EventHandler(this.cmbChiNhanh_SelectedIndexChanged);
            // 
            // getSubscribesBindingSource
            // 
            this.getSubscribesBindingSource.DataMember = "Get_Subscribes";
            // 
            // nGANHANGDataSet1BindingSource
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(161, 329);
            this.btnXem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(129, 51);
            this.btnXem.TabIndex = 1;
            this.btnXem.Text = "XEM";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(462, 329);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(130, 51);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "THOÁT";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "CHỌN CHI NHÁNH";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(320, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "LIỆT KÊ KHÁCH HÀNG THEO CHI NHÁNH";
            // 
            // nGANHANGDataSetkhachhang
            // 
           // this.nGANHANGDataSetkhachhang.DataSetName = "NGANHANGDataSetkhachhang";
           // this.nGANHANGDataSetkhachhang.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nGANHANGDataSetkhachhangBindingSource
            // 
           // this.nGANHANGDataSetkhachhangBindingSource.DataSource = this.nGANHANGDataSetkhachhang;
         //   this.nGANHANGDataSetkhachhangBindingSource.Position = 0;
            // 
            // khachHangBindingSource
            // 
            this.khachHangBindingSource.DataMember = "KhachHang";
            this.khachHangBindingSource.DataSource = this.nGANHANGDataSetkhachhangBindingSource;
            // 
            // khachHangTableAdapter
            // 
            //this.khachHangTableAdapter.ClearBeforeFill = true;
            // 
            // spLietKeKhachHangTheoChiNhanhBindingSource
            // 
            this.spLietKeKhachHangTheoChiNhanhBindingSource.DataMember = "sp_LietKeKhachHangTheoChiNhanh";
            this.spLietKeKhachHangTheoChiNhanhBindingSource.DataSource = this.nGANHANGDataSetkhachhangBindingSource;
            // 
            // sp_LietKeKhachHangTheoChiNhanhTableAdapter
            // 
            //this.sp_LietKeKhachHangTheoChiNhanhTableAdapter.ClearBeforeFill = true;
            // 
            // get_SubscribesTableAdapter
            // 
            // 
            // frmLietKeKhachHangTheoChiNhanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 562);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.cmbChiNhanh);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmLietKeKhachHangTheoChiNhanh";
            this.Text = "Liệt kê khách hàng";
            this.Load += new System.EventHandler(this.frmLietKeKhachHangTheoChiNhanh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.getSubscribesBindingSource)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.nGANHANGDataSetkhachhang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGANHANGDataSetkhachhangBindingSource)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.khachHangBindingSource)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.spLietKeKhachHangTheoChiNhanhBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbChiNhanh;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource nGANHANGDataSetkhachhangBindingSource;
        //private NGANHANGDataSetkhachhang nGANHANGDataSetkhachhang;
        private System.Windows.Forms.BindingSource khachHangBindingSource;
        //private NGANHANG_KhachHangTableAdapters.KhachHangTableAdapter khachHangTableAdapter;
        private System.Windows.Forms.BindingSource spLietKeKhachHangTheoChiNhanhBindingSource;
        //private NGANHANG_KhachHangTableAdapters.sp_LietKeKhachHangTheoChiNhanhTableAdapter sp_LietKeKhachHangTheoChiNhanhTableAdapter;
        private System.Windows.Forms.BindingSource getSubscribesBindingSource;
    }
}