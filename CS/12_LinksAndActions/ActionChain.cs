using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Actions;
using Spire.Pdf.General;
using Spire.Pdf.Graphics;
using Spire.Pdf.Tables;


namespace ActionChain
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a PDF document
            PdfDocument doc = new PdfDocument();

            // Draw pages and get the last page
            PdfPageBase lastPage = DrawPages(doc);

            // Define JavaScript action for after the document is opened
            String script = "app.alert({"
                + "    cMsg: \"I'll lead; you must follow me.\","
                + "    nIcon: 3,"
                + "    cTitle: \"JavaScript Action\""
                + "});";
            PdfJavaScriptAction action1 = new PdfJavaScriptAction(script);
            doc.AfterOpenAction = action1;

            // Define JavaScript action for the next action after action1
            script = "app.alert({"
                + "    cMsg: \"The first page!\","
                + "    nIcon: 3,"
                + "    cTitle: \"JavaScript Action\""
                + "});";
            PdfJavaScriptAction action2 = new PdfJavaScriptAction(script);
            action1.NextAction = action2;

            // Define a destination to navigate to the last page
            PdfDestination dest = new PdfDestination(lastPage);
            dest.Zoom = 1;
            PdfGoToAction action3 = new PdfGoToAction(dest);
            action2.NextAction = action3;

            // Define JavaScript action for the next action after action3
            script = "app.alert({"
                + "    cMsg: \"Oh sorry, it's the last page. I'm missing!\","
                + "    nIcon: 3,"
                + "    cTitle: \"JavaScript Action\""
                + "});";
            PdfJavaScriptAction action4 = new PdfJavaScriptAction(script);
            action3.NextAction = action4;

            // Save the PDF file
            doc.SaveToFile("ActionChain.pdf");
            doc.Close();

            //Launch the Pdf file
            PDFDocumentViewer("ActionChain.pdf");
        }

        private PdfPageBase DrawPages(PdfDocument doc)
        {
            // Set margins
            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
            PdfMargins margin = new PdfMargins();
            margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Bottom = margin.Top;
            margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Right = margin.Left;

            // Create a new page with specified size and margins
            PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, margin);

            float y = 10;

            // Draw the title on the page
            PdfBrush brush1 = PdfBrushes.Black;
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 16f, FontStyle.Bold));
            PdfStringFormat format1 = new PdfStringFormat(PdfTextAlignment.Center);
            page.Canvas.DrawString("Part List", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1);
            y = y + font1.MeasureString("Part List", format1).Height;
            y = y + 5;

            // Create a data table
            PdfTable table = new PdfTable();
            table.Style.CellPadding = 2;
            table.Style.BorderPen = new PdfPen(brush1, 0.75f);
            table.Style.DefaultStyle.BackgroundBrush = PdfBrushes.SkyBlue;
            table.Style.DefaultStyle.Font = new PdfTrueTypeFont(new Font("Arial", 10f));
            table.Style.AlternateStyle = new PdfCellStyle();
            table.Style.AlternateStyle.BackgroundBrush = PdfBrushes.LightYellow;
            table.Style.AlternateStyle.Font = new PdfTrueTypeFont(new Font("Arial", 10f));
            table.Style.HeaderSource = PdfHeaderSource.ColumnCaptions;
            table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.CadetBlue;
            table.Style.HeaderStyle.Font = new PdfTrueTypeFont(new Font("Arial", 11f, FontStyle.Bold));
            table.Style.HeaderStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center);
            table.Style.ShowHeader = true;

            using (OleDbConnection conn = new OleDbConnection())
            {
                // Connect to the database
                conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\..\..\..\..\Data\demo.mdb";
                OleDbCommand command = new OleDbCommand();
                command.CommandText = " select Description, OnHand, OnOrder, Cost, ListPrice from parts ";
                command.Connection = conn;

                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    // Fill the datatable with data from the database
                    dataAdapter.Fill(dataTable);

                    // Set table's data source and type
                    table.DataSourceType = PdfTableDataSourceType.TableDirect;
                    table.DataSource = dataTable;
                }
            }

            float width = page.Canvas.ClientSize.Width - (table.Columns.Count + 1) * table.Style.BorderPen.Width;
            for (int i = 0; i < table.Columns.Count; i++)
            {
                if (i == 0)
                {
                    // Set the width and alignment of the first column
                    table.Columns[i].Width = width * 0.40f * width;
                    table.Columns[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
                }
                else
                {
                    // Set the width and alignment of the remaining columns
                    table.Columns[i].Width = width * 0.15f * width;
                    table.Columns[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);
                }
            }

            // Set the table layout format
            PdfTableLayoutFormat tableLayout = new PdfTableLayoutFormat();
            tableLayout.Break = PdfLayoutBreakType.FitElement;
            tableLayout.Layout = PdfLayoutType.Paginate;

            // Draw the table on the page and get the layout result
            PdfLayoutResult result = table.Draw(page, new PointF(0, y), tableLayout);
            y = result.Bounds.Bottom + 3;

            // Add additional information below the table
            PdfBrush brush2 = PdfBrushes.Gray;
            PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 9f));
            result.Page.Canvas.DrawString(String.Format("* {0} parts in the list.", table.Rows.Count),
                font2, brush2, 5, y);

            return result.Page;
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
