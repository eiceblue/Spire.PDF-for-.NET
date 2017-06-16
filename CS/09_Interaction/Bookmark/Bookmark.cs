using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Actions;
using Spire.Pdf.Bookmarks;
using Spire.Pdf.General;
using Spire.Pdf.Graphics;
using Spire.Pdf.Grid;
using Spire.Pdf.Tables;

namespace Bookmark
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

            //create section
            PdfSection section = doc.Sections.Add();
            section.PageSettings.Size = PdfPageSize.A4;
            section.PageSettings.Margins = margin;

            // Create one page
            PdfPageBase page = section.Pages.Add();

            float y = 10;

            //title
            PdfBrush brush1 = PdfBrushes.Black;
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 16f, FontStyle.Bold));
            PdfStringFormat format1 = new PdfStringFormat(PdfTextAlignment.Center);
            page.Canvas.DrawString("Sales Report", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1);
            y = y + font1.MeasureString("Sales Report", format1).Height;
            y = y + 5;

            PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 11f, FontStyle.Bold));
            PdfTrueTypeFont font3 = new PdfTrueTypeFont(new Font("Arial", 10f, FontStyle.Bold));
            using (OleDbConnection conn = new OleDbConnection())
            {
                conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\..\..\..\..\..\Data\demo.mdb";
                conn.Open();

                OleDbCommand partQueryCommand = PreparePartQueryCommand(conn);
                OleDbCommand orderItemQueryCommand = PrepareOrderItemQueryCommand(conn);

                DataTable vendors = GetVendors(conn);
                for (int i = 0;  i < vendors.Rows.Count; i++)
                {
                    if (i > 0)
                    {
                        //next page
                        page = section.Pages.Add();
                        y = 0;
                    }
                    //draw vendor
                    String vendorTitle = String.Format("{0}. {1}", i + 1, vendors.Rows[i].ItemArray[1]);
                    PdfLayoutResult drawVendorLayoutResult = DrawVendor(page, vendors, i, vendorTitle, y);

                    //add vendor bookmark
                    PdfDestination vendorBookmarkDest = new PdfDestination(page, new PointF(0, y));
                    PdfBookmark vendorBookmark = doc.Bookmarks.Add(vendorTitle);
                    vendorBookmark.Color = Color.SaddleBrown;
                    vendorBookmark.DisplayStyle = PdfTextStyle.Bold;
                    vendorBookmark.Action = new PdfGoToAction(vendorBookmarkDest);

                    y = drawVendorLayoutResult.Bounds.Bottom + 5;
                    page = drawVendorLayoutResult.Page;

                    //get parts of vendor
                    DataTable parts = GetParts(partQueryCommand, (double)vendors.Rows[i].ItemArray[0]);
                    for (int j = 0; j < parts.Rows.Count; j++)
                    {
                        if (j > 0)
                        {
                            //next page
                            page = section.Pages.Add();
                            y = 0;
                        }
                        //draw part
                        String partTitle = String.Format("{0}.{1}. {2}", i + 1, j + 1, parts.Rows[j].ItemArray[1]);
                        PdfLayoutResult drawPartLayoutResult = DrawPart(page, parts, j, partTitle, y);

                        //add part bookmark
                        PdfDestination partBookmarkDest = new PdfDestination(page, new PointF(0, y));
                        PdfBookmark partBookmark = vendorBookmark.Add(partTitle);
                        partBookmark.Color = Color.Coral;
                        partBookmark.DisplayStyle = PdfTextStyle.Italic;
                        partBookmark.Action = new PdfGoToAction(partBookmarkDest);

                        y = drawPartLayoutResult.Bounds.Bottom + 5;
                        page = drawPartLayoutResult.Page;

                        //get order items
                        String orderItemsTitle = String.Format("{0} - Order Items", parts.Rows[j].ItemArray[1]);
                        DataTable orderItems = GetOrderItems(orderItemQueryCommand, (double)parts.Rows[j].ItemArray[0]);
                        DrawOrderItems(page, orderItems, orderItemsTitle, y);
                    }
                }
            }

            //Save pdf file.
            doc.SaveToFile("Bookmark.pdf");
            doc.Close();

            //Launching the Pdf file.
            PDFDocumentViewer("Bookmark.pdf");
        }

        private DataTable GetVendors(OleDbConnection conn)
        {
            String query
                = " SELECT VendorNo, VendorName, Address1, City, State, Zip, Country, Phone, FAX "
                + " FROM vendors ";
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        private DataTable GetParts(OleDbCommand query, double vendorId)
        {
            query.Parameters[0].Value = vendorId;
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(query))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        private DataTable GetOrderItems(OleDbCommand query, double partId)
        {
            query.Parameters[0].Value = partId;
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(query))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        private PdfLayoutResult DrawVendor(PdfPageBase page, DataTable vendors, int index, String title, float y)
        {
            //draw title
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 11f, FontStyle.Bold));
            DataRow row = vendors.Rows[index];
            page.Canvas.DrawString(title, font1, PdfBrushes.Black, 0, y);
            y = y + font1.MeasureString(title).Height + 1;

            //draw table
            Object[][] data = new Object[vendors.Columns.Count][];
            for (int i = 0; i < vendors.Columns.Count; i++)
            {
                data[i] = new Object[2];
                data[i][0] = vendors.Columns[i].ColumnName;
                data[i][1] = vendors.Rows[index].ItemArray[i];
            }

            PdfGrid grid = new PdfGrid();
            grid.Style.CellPadding = new PdfPaddings(2, 2, 1, 1);
            grid.DataSource = data;

            float width
                = page.Canvas.ClientSize.Width
                    - (grid.Columns.Count + 1) * 0.75f;
            grid.Columns[0].Width = width * 0.20f;
            grid.Columns[1].Width = width * 0.80f;

            PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 10f, FontStyle.Bold));
            PdfTrueTypeFont font3 = new PdfTrueTypeFont(new Font("Arial", 10f));
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                grid.Rows[i].Style.Font = font2;
                grid.Rows[i].Cells[0].Style.BackgroundBrush = PdfBrushes.CadetBlue;
                grid.Rows[i].Cells[1].Style.BackgroundBrush = PdfBrushes.SkyBlue;
            }

            PdfGridLayoutFormat layout = new PdfGridLayoutFormat();
            layout.Break = PdfLayoutBreakType.FitPage;
            layout.Layout = PdfLayoutType.Paginate;

            return grid.Draw(page, new PointF(0, y), layout);
        }

        private PdfLayoutResult DrawPart(PdfPageBase page, DataTable parts, int index, String title, float y)
        {
            //draw title
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 10f, FontStyle.Bold));
            DataRow row = parts.Rows[index];
            page.Canvas.DrawString(title, font1, PdfBrushes.Black, 0, y);
            y = y + font1.MeasureString(title).Height + 1;

            //draw table
            Object[][] data = new Object[2][];
            data[0] = new String[parts.Columns.Count];
            for (int i = 0; i < parts.Columns.Count; i++)
            {
                data[0][i] = parts.Columns[i].ColumnName;
            }
            data[1] = row.ItemArray;

            PdfTable table = new PdfTable();
            table.Style.CellPadding = 2;
            table.Style.BorderPen = new PdfPen(PdfBrushes.Black, 0.75f);
            table.Style.DefaultStyle.BackgroundBrush = PdfBrushes.GreenYellow;
            table.Style.DefaultStyle.Font = new PdfTrueTypeFont(new Font("Arial", 9f));
            table.Style.HeaderSource = PdfHeaderSource.Rows;
            table.Style.HeaderRowCount = 1;
            table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.ForestGreen;
            table.Style.HeaderStyle.Font = new PdfTrueTypeFont(new Font("Arial", 9f, FontStyle.Bold));
            table.Style.HeaderStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center);
            table.Style.ShowHeader = true;
            table.DataSource = data;

            float width
                = page.Canvas.ClientSize.Width
                    - (table.Columns.Count + 1) * table.Style.BorderPen.Width;
            for (int i = 0; i < table.Columns.Count; i++)
            {
                table.Columns[i].Width = i == 1 ? width * 0.35f : width * 0.13f;
            }

            PdfTableLayoutFormat tableLayout = new PdfTableLayoutFormat();
            tableLayout.Break = PdfLayoutBreakType.FitPage;
            tableLayout.Layout = PdfLayoutType.Paginate;

            return table.Draw(page, new PointF(0, y), tableLayout);
        }

        private PdfLayoutResult DrawOrderItems(PdfPageBase page, DataTable orderItems, String title, float y)
        {
            //draw title
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 9f, FontStyle.Bold));
            page.Canvas.DrawString(title, font1, PdfBrushes.Black, 0, y);
            y = y + font1.MeasureString(title).Height + 1;

            PdfTable table = new PdfTable();
            table.Style.CellPadding = 2;
            table.Style.BorderPen = new PdfPen(PdfBrushes.Black, 0.75f);
            table.Style.DefaultStyle.BackgroundBrush = PdfBrushes.MediumTurquoise;
            table.Style.DefaultStyle.Font = new PdfTrueTypeFont(new Font("Arial", 8f));
            table.Style.AlternateStyle = new PdfCellStyle();
            table.Style.AlternateStyle.BackgroundBrush = PdfBrushes.PaleTurquoise;
            table.Style.AlternateStyle.Font = new PdfTrueTypeFont(new Font("Arial", 8f));
            table.Style.HeaderSource = PdfHeaderSource.ColumnCaptions;
            table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.Teal;
            table.Style.HeaderStyle.Font = new PdfTrueTypeFont(new Font("Arial", 8f, FontStyle.Bold));
            table.Style.HeaderStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center);
            table.Style.ShowHeader = true;
            table.DataSource = orderItems;
            for (int i = 2; i < table.Columns.Count; i++)
            {
                table.Columns[0].StringFormat = new PdfStringFormat(PdfTextAlignment.Right);
            }

            PdfTableLayoutFormat tableLayout = new PdfTableLayoutFormat();
            tableLayout.Break = PdfLayoutBreakType.FitPage;
            tableLayout.Layout = PdfLayoutType.Paginate;

            return table.Draw(page, new PointF(0, y), tableLayout);
        }

        private OleDbCommand PreparePartQueryCommand(OleDbConnection conn)
        {
            OleDbCommand command = new OleDbCommand();
            command.CommandText
                = " SELECT PartNo, Description, OnHand, OnOrder, Cost, ListPrice "
                + " FROM parts WHERE VendorNo = @VendorNo";
            OleDbParameter param = new OleDbParameter("@VendorNo", OleDbType.Double);
            command.Parameters.Add(param);
            command.Connection = conn;
            return command;
        }

        private OleDbCommand PrepareOrderItemQueryCommand(OleDbConnection conn)
        {
            OleDbCommand command = new OleDbCommand();
            command.CommandText
                = " SELECT OrderNo, ItemNo, Qty, Discount "
                + " FROM items WHERE PartNo = @PartNo";
            OleDbParameter param = new OleDbParameter("@PartNo", OleDbType.Double);
            command.Parameters.Add(param);
            command.Connection = conn;
            return command;
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
