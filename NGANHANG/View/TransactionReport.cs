using DevExpress.XtraReports.UI;

public class TransactionReport : XtraReport
{
    public TransactionReport()
    {
        // Create bands
        DetailBand detailBand = new DetailBand();
        TopMarginBand topMarginBand = new TopMarginBand();
        BottomMarginBand bottomMarginBand = new BottomMarginBand();
        ReportHeaderBand reportHeaderBand = new ReportHeaderBand();
        PageHeaderBand pageHeaderBand = new PageHeaderBand();

        // Add bands to the report
        this.Bands.AddRange(new Band[] { detailBand, topMarginBand, bottomMarginBand, reportHeaderBand, pageHeaderBand });

        // Create report title
        XRLabel reportTitle = new XRLabel();
        reportTitle.Text = "Sao Kê Giao Dịch";
        reportTitle.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
        reportTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        reportTitle.Dock = DevExpress.XtraReports.UI.XRDockStyle.Top;
        reportHeaderBand.Controls.Add(reportTitle);

        // Create table for the header
        XRTable headerTable = new XRTable();
        headerTable.WidthF = this.PageWidth - this.Margins.Left - this.Margins.Right;
        XRTableRow headerTableRow = new XRTableRow();
        headerTable.Rows.Add(headerTableRow);

        // Define header cells
        string[] headers = { "Ngày", "Loại Giao Dịch", "Số Tiền", "Số Dư Sau" };
        foreach (string header in headers)
        {
            XRTableCell headerTableCell = new XRTableCell();
            headerTableCell.Text = header;
            headerTableCell.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            headerTableCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            headerTableRow.Cells.Add(headerTableCell);
        }

        pageHeaderBand.Controls.Add(headerTable);

        // Create table for the detail
        XRTable detailTable = new XRTable();
        detailTable.WidthF = this.PageWidth - this.Margins.Left - this.Margins.Right;
        XRTableRow detailTableRow = new XRTableRow();
        detailTable.Rows.Add(detailTableRow);

        // Define detail cells
        string[] detailFields = { "Ngay", "LoaiGiaoDich", "SoTien", "SoDuSau" };
        foreach (string field in detailFields)
        {
            XRTableCell detailTableCell = new XRTableCell();
            detailTableCell.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", $"[{field}]"));
            detailTableCell.Font = new System.Drawing.Font("Arial", 10F);
            detailTableCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            detailTableRow.Cells.Add(detailTableCell);
        }

        detailBand.Controls.Add(detailTable);
    }
}
