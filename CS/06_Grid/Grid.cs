using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Grid;

namespace Grid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a pdf document.
            PdfDocument doc = new PdfDocument();

            //margin
            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
            PdfMargins margin = new PdfMargins();
            margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Bottom = margin.Top;
            margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Right = margin.Left;

            // Create one page
            PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, margin, PdfPageRotateAngle.RotateAngle0, PdfPageOrientation.Landscape);

            float y = 10;
            float x1 = page.Canvas.ClientSize.Width;

            //title
            PdfBrush brush1 = PdfBrushes.Black;
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 16f, FontStyle.Bold), true);
            PdfStringFormat format1 = new PdfStringFormat(PdfTextAlignment.Center);
            page.Canvas.DrawString("Vendor List", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1);
            y = y + font1.MeasureString("Vendor List", format1).Height;
            y = y + 5;

            String[] data
                = {
                    "VendorName;Address1;City;State;Country",
                    "Cacor Corporation;161 Southfield Rd;Southfield;OH;U.S.A.",
                    "Underwater;50 N 3rd Street;Indianapolis;IN;U.S.A.",
                    "J.W.  Luscher Mfg.;65 Addams Street;Berkely;MA;U.S.A.",
                    "Scuba Professionals;3105 East Brace;Rancho Dominguez;CA;U.S.A.",
                    "Divers'  Supply Shop;5208 University Dr;Macon;GA;U.S.A.",
                    "Techniques;52 Dolphin Drive;Redwood City;CA;U.S.A.",
                    "Perry Scuba;3443 James Ave;Hapeville;GA;U.S.A.",
                    "Beauchat, Inc.;45900 SW 2nd Ave;Ft Lauderdale;FL;U.S.A.",
                    "Amor Aqua;42 West 29th Street;New York;NY;U.S.A.",
                    "Aqua Research Corp.;P.O. Box 998;Cornish;NH;U.S.A.",
                    "B&K Undersea Photo;116 W 7th Street;New York;NY;U.S.A.",
                    "Diving International Unlimited;1148 David Drive;San Diego;DA;U.S.A.",
                    "Nautical Compressors;65 NW 167 Street;Miami;FL;U.S.A.",
                    "Glen Specialties, Inc.;17663 Campbell Lane;Huntington Beach;CA;U.S.A.",
                    "Dive Time;20 Miramar Ave;Long Beach;CA;U.S.A.",
                    "Undersea Systems, Inc.;18112 Gotham Street;Huntington Beach;CA;U.S.A.",
                    "Felix Diving;310 S Michigan Ave;Chicago;IL;U.S.A.",
                    "Central Valley Skin Divers;160 Jameston Ave;Jamaica;NY;U.S.A.",
                    "Parkway Dive Shop;241 Kelly Street;South Amboy;NJ;U.S.A.",
                    "Marine Camera & Dive;117 South Valley Rd;San Diego;CA;U.S.A.",
                    "Dive Canada;275 W Ninth Ave;Vancouver;British Columbia;Canada",
                    "Dive & Surf;P.O. Box 20210;Indianapolis;IN;U.S.A.",
                    "Fish Research Labs;29 Wilkins Rd Dept. SD;Los Banos;CA;U.S.A."
                };
            PdfGrid grid = new PdfGrid();
            grid.Style.CellPadding = new PdfPaddings(1, 1, 1, 1);

            String[] header = data[0].Split(';');
            grid.Columns.Add(header.Length);
            float width
                = page.Canvas.ClientSize.Width - (grid.Columns.Count + 1);
            grid.Columns[0].Width = width * 0.25f;
            grid.Columns[1].Width = width * 0.25f;
            grid.Columns[2].Width = width * 0.25f;
            grid.Columns[3].Width = width * 0.15f;
            grid.Columns[4].Width = width * 0.10f;
            PdfGridRow headerRow = grid.Headers.Add(1)[0];
            headerRow.Style.Font = new PdfTrueTypeFont(new Font("Arial", 11f, FontStyle.Bold), true);
            headerRow.Style.BackgroundBrush
                = new PdfLinearGradientBrush(new PointF(0, 0), new PointF(x1, 0), Color.Red, Color.Blue);
            for (int i = 0; i < header.Length; i++)
            {
                headerRow.Cells[i].Value = header[i];
                headerRow.Cells[i].StringFormat
                    = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
                if (i == 0)
                {
                    headerRow.Cells[i].Style.BackgroundBrush = PdfBrushes.Gray;
                }
            }

            Random random = new Random();
            Dictionary<String, int> groupByCountry = new Dictionary<String, int>();
            for (int r = 1; r < data.Length; r++)
            {
                PdfGridRow row = grid.Rows.Add();
                row.Style.Font = new PdfTrueTypeFont(new Font("Arial", 10f), true);
                byte[] buffer = new byte[6];
                random.NextBytes(buffer);
                PdfRGBColor color1 = new PdfRGBColor(buffer[0], buffer[1], buffer[2]);
                PdfRGBColor color2 = new PdfRGBColor(buffer[3], buffer[4], buffer[5]);
                row.Style.BackgroundBrush
                    = new PdfLinearGradientBrush(new PointF(0, 0), new PointF(x1, 0), color1, color2);
                String[] rowData = data[r].Split(';');
                for (int c = 0; c < rowData.Length; c++)
                {
                    row.Cells[c].Value = rowData[c];
                    if (c == 0)
                    {
                        row.Cells[c].Style.BackgroundBrush = PdfBrushes.Gray;
                    }
                    if(c < 3)
                    {
                        row.Cells[c].StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
                    }
                    else
                    {
                        row.Cells[c].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
                    }
                    if (c == 4)
                    {
                        if (groupByCountry.ContainsKey(rowData[c]))
                        {
                            groupByCountry[rowData[c]] = groupByCountry[rowData[c]] + 1;
                        }
                        else
                        {
                            groupByCountry[rowData[c]] = 1;
                        }
                    }
                }
            }
            StringBuilder totalAmount = new StringBuilder();
            foreach (KeyValuePair<String, int> country in groupByCountry)
            {
                totalAmount.AppendFormat("{0}:\t{1}", country.Key, country.Value);
                totalAmount.AppendLine();
            }

            PdfGridRow totalAmountRow = grid.Rows.Add();
            totalAmountRow.Style.BackgroundBrush = PdfBrushes.Plum;
            totalAmountRow.Cells[0].Value = "Total Amount";
            totalAmountRow.Cells[0].Style.Font = new PdfTrueTypeFont(new Font("Arial", 10f, FontStyle.Bold), true);
            totalAmountRow.Cells[0].StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
            totalAmountRow.Cells[1].ColumnSpan = 4;
            totalAmountRow.Cells[1].Value = totalAmount.ToString();
            totalAmountRow.Cells[1].Style.Font = new PdfTrueTypeFont(new Font("Arial", 10f, FontStyle.Bold | FontStyle.Italic), true);
            totalAmountRow.Cells[1].StringFormat = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);

            //append product list
            PdfGrid productList = new PdfGrid();
            productList.Style.Font = new PdfTrueTypeFont(new Font("Arial", 8f), true);
            using (OleDbConnection conn = new OleDbConnection())
            {
                conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\..\..\..\..\Data\demo.mdb";
                OleDbCommand command = new OleDbCommand();
                command.CommandText
                    = " select p.Description "
                    + " from vendors v "
                    + "     inner join parts p "
                    + "     on v.VendorNo = p.VendorNo "
                    + " where v.VendorName = 'Cacor Corporation'";
                command.Connection = conn;
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    productList.DataSource = dataTable;
                }
            }
            productList.Headers[0].Cells[0].Value = "Cacor Corporation";
            productList.Headers[0].Cells[0].Style.Font = new PdfTrueTypeFont(new Font("Arial", 8f, FontStyle.Bold), true);
            productList.Headers[0].Cells[0].Style.Borders.All = new PdfPen(new PdfTilingBrush(new SizeF(1, 1)), 0);
            grid.Rows[0].Cells[0].Value = productList;
            grid.Rows[0].Cells[0].StringFormat.Alignment = PdfTextAlignment.Left;

            PdfLayoutResult result = grid.Draw(page, new PointF(0, y));
            y = y + result.Bounds.Height + 5;

            PdfBrush brush2 = PdfBrushes.Gray;
            PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 9f));
            result.Page.Canvas.DrawString(String.Format("* All {0} vendors in the list", grid.Rows.Count - 1),
                font2, brush2, 5, y);

            //Save pdf file.
            doc.SaveToFile("Grid.pdf");
            doc.Close();

            //Launching the Pdf file.
            PDFDocumentViewer("Grid.pdf");
        }

        private void PDFDocumentViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }

    }
}
