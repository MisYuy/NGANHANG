using System;
using System.Data;
using System.Data.SqlClient;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;

public class TransactionReport : XtraReport
{
    public TransactionReport(string connectionString, string sotk, DateTime ngaybd, DateTime ngaykt)
    {
        // Create parameters for balance information
        Parameter soduDau = new Parameter();
        soduDau.Name = "SODU_DAU";
        soduDau.Type = typeof(decimal);
        soduDau.Value = 0;

        Parameter soduCuoi = new Parameter();
        soduCuoi.Name = "SODU_CUOI";
        soduCuoi.Type = typeof(decimal);
        soduCuoi.Value = 0;

        this.Parameters.AddRange(new Parameter[] { soduDau, soduCuoi });

        // Create bands
        DetailBand detailBand = new DetailBand();
        TopMarginBand topMarginBand = new TopMarginBand();
        BottomMarginBand bottomMarginBand = new BottomMarginBand();
        ReportHeaderBand reportHeaderBand = new ReportHeaderBand();
        PageHeaderBand pageHeaderBand = new PageHeaderBand();
        ReportFooterBand reportFooterBand = new ReportFooterBand(); // Add footer band

        // Add bands to the report
        this.Bands.AddRange(new Band[] { detailBand, topMarginBand, bottomMarginBand, reportHeaderBand, pageHeaderBand, reportFooterBand });
        reportHeaderBand.HeightF = 60;
        pageHeaderBand.HeightF = 30;

        // Create report title
        XRLabel reportTitle = new XRLabel();
        reportTitle.Text = "Sao Kê Giao Dịch";
        reportTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
        reportTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        reportTitle.BoundsF = new System.Drawing.RectangleF(0, 0, this.PageWidth - this.Margins.Left - this.Margins.Right, 50);
        reportHeaderBand.Controls.Add(reportTitle);

        // Create table for the header
        XRTable headerTable = new XRTable();
        headerTable.WidthF = this.PageWidth - this.Margins.Left - this.Margins.Right;
        XRTableRow headerTableRow = new XRTableRow();
        headerTable.Rows.Add(headerTableRow);

        // Define header cells
        string[] headers = { "Số dư đầu", "Ngày", "Loại Giao Dịch", "Số Tiền", "Số Dư Sau" };
        float[] columnWidths = { 150f, 400f, 200f, 150f, 150f }; // Adjust column widths
        for (int i = 0; i < headers.Length; i++)
        {
            XRTableCell headerTableCell = new XRTableCell();
            headerTableCell.Text = headers[i];
            headerTableCell.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            headerTableCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            headerTableCell.Borders = DevExpress.XtraPrinting.BorderSide.All;
            headerTableCell.WidthF = columnWidths[i];
            headerTableRow.Cells.Add(headerTableCell);
        }
        pageHeaderBand.Controls.Add(headerTable);
        headerTable.HeightF = 5f; // increased header row height

        // Create table for the detail
        XRTable detailTable = new XRTable();
        detailTable.WidthF = this.PageWidth - this.Margins.Left - this.Margins.Right;
        XRTableRow detailTableRow = new XRTableRow();
        detailTableRow.HeightF = 5f; //
        detailTable.Rows.Add(detailTableRow);

        string[] detailFields = { "SODUDAU", "NGAYGD", "LOAIGD", "SOTIEN", "SODUSAU" };
        for (int i = 0; i < detailFields.Length; i++)
        {
            XRTableCell detailTableCell = new XRTableCell();
            detailTableCell.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", $"[{detailFields[i]}]"));
            detailTableCell.Font = new System.Drawing.Font("Arial", 10F);
            detailTableCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            detailTableCell.Borders = DevExpress.XtraPrinting.BorderSide.All;
            detailTableCell.WidthF = columnWidths[i];

            // Format số tiền
            if (detailFields[i] == "SOTIEN" || detailFields[i] == "SODUDAU" || detailFields[i] == "SODUSAU")
            {
                detailTableCell.TextFormatString = "{0:n0}";
            }
            detailTableRow.Cells.Add(detailTableCell);
        }

        detailBand.Controls.Add(detailTable);

        // Add summary information to the report footer
        XRTable footerTable = new XRTable();
        footerTable.WidthF = this.PageWidth - this.Margins.Left - this.Margins.Right;
        XRTableRow footerTableRow1 = new XRTableRow();
        XRTableRow footerTableRow2 = new XRTableRow();
 
        footerTable.Rows.Add(footerTableRow1);
        footerTable.Rows.Add(footerTableRow2);

        // Add labels for "Số dư ban đầu" and "Số dư sau cùng"
        XRTableCell soduDauLabel = new XRTableCell();
        soduDauLabel.Text = "Số dư ban đầu";
        soduDauLabel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
        soduDauLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
       // soduDauLabel.BoundsF = new System.Drawing.RectangleF(0, footerTable.HeightF, footerTable.WidthF / 2, 25);
        footerTableRow1.Controls.Add(soduDauLabel);

        XRTableCell soduCuoiLabel = new XRTableCell();
        soduCuoiLabel.Text = "Số dư sau cùng";
        soduCuoiLabel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
        soduCuoiLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
       // soduCuoiLabel.BoundsF = new System.Drawing.RectangleF(footerTable.WidthF / 2, footerTable.HeightF, footerTable.WidthF / 2, 25);
        footerTableRow2.Controls.Add(soduCuoiLabel);

        XRTableCell soduDauCell = new XRTableCell();
        soduDauCell.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "?SODU_DAU"));
        soduDauCell.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
        soduDauCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        footerTableRow1.Cells.Add(soduDauCell);

        XRTableCell soduCuoiCell = new XRTableCell();
        soduCuoiCell.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "?SODU_CUOI"));
        soduCuoiCell.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
        soduCuoiCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        footerTableRow2.Cells.Add(soduCuoiCell);

        soduDauCell.TextFormatString = "{0:n0}";
        soduCuoiCell.TextFormatString = "{0:n0}";
        soduDauLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        soduDauCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        soduCuoiLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        soduCuoiCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;

        reportFooterBand.Controls.Add(footerTable);

        footerTable.LocationF = new System.Drawing.PointF(0, -110); // Move footer table down
        footerTable.AnchorVertical = VerticalAnchorStyles.Bottom;

        footerTableRow1.HeightF = 25f; // Chiều cao cho hàng đầu tiên
        footerTableRow2.HeightF = 25f; // Chiều cao cho hàng thứ hai

        // Retrieve data using ADO.NET
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand("SP_SAO_KE_GIAO_DICH", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@SOTK", sotk);
            command.Parameters.AddWithValue("@NGAYBD", ngaybd);
            command.Parameters.AddWithValue("@NGAYKT", ngaykt);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                this.Parameters["SODU_DAU"].Value = dataSet.Tables[0].Rows[0]["SODU_DAU"];
                this.Parameters["SODU_CUOI"].Value = dataSet.Tables[0].Rows[0]["SODU_CUOI"];
            }

            this.DataSource = dataSet.Tables[0];
        }

        // Automatically generate the report document
        this.CreateDocument();
    }
}
