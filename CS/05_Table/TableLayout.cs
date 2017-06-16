using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Tables;

namespace TableLayout
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
            PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, margin);

            float y = 10;

            //title
            PdfBrush brush1 = PdfBrushes.Black;
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 16f, FontStyle.Bold));
            PdfStringFormat format1 = new PdfStringFormat(PdfTextAlignment.Center);
            page.Canvas.DrawString("Part List", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1);
            y = y + font1.MeasureString("Part List", format1).Height;
            y = y + 5;

            //create data table
            PdfTable table = new PdfTable();
            table.Style.CellPadding = 1;
            table.Style.BorderPen = new PdfPen(brush1, 0.75f);
            table.Style.DefaultStyle.BackgroundBrush = PdfBrushes.SkyBlue;
            table.Style.DefaultStyle.Font = new PdfTrueTypeFont(new Font("Arial", 10f), true);
            table.Style.HeaderSource = PdfHeaderSource.ColumnCaptions;
            table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.CadetBlue;
            table.Style.HeaderStyle.Font = new PdfTrueTypeFont(new Font("Arial", 11f, FontStyle.Bold), true);
            table.Style.HeaderStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center);
            table.Style.ShowHeader = true;
            table.Style.RepeatHeader = true;
            using (OleDbConnection conn = new OleDbConnection())
            {
                conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\..\..\..\..\Data\demo.mdb";
                OleDbCommand command = new OleDbCommand();
                command.CommandText
                    = " select * from parts ";
                command.Connection = conn;
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataTable.Columns.RemoveAt(1);
                    table.DataSourceType = PdfTableDataSourceType.TableDirect;
                    table.DataSource = dataTable;
                }
            }
            float width
                = page.Canvas.ClientSize.Width
                    - (table.Columns.Count + 1) * table.Style.BorderPen.Width;
            for(int i = 0; i < table.Columns.Count; i++)
            {
                if (i == 1)
                {
                    table.Columns[i].Width = width * 0.4f * width;
                    table.Columns[i].StringFormat
                        = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
                }
                else
                {
                    table.Columns[i].Width = width * 0.12f * width;
                    table.Columns[i].StringFormat
                        = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);
                }
            }
            table.BeginRowLayout += new BeginRowLayoutEventHandler(table_BeginRowLayout);

            PdfTableLayoutFormat tableLayout = new PdfTableLayoutFormat();
            tableLayout.Break = PdfLayoutBreakType.FitElement;
            tableLayout.Layout = PdfLayoutType.Paginate;
            PdfLayoutResult result = table.Draw(page, new PointF(0, y), tableLayout);
            y = result.Bounds.Bottom + 5;

            PdfBrush brush2 = PdfBrushes.Gray;
            PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 9f));
            result.Page.Canvas.DrawString(String.Format("* All {0} parts in the list", table.Rows.Count), 
                font2, brush2, 5, y);

            //Save pdf file.
            doc.SaveToFile("TableLayout.pdf");
            doc.Close();

            //Launching the Pdf file.
            PDFDocumentViewer("TableLayout.pdf");
        }

        void table_BeginRowLayout(object sender, BeginRowLayoutEventArgs args)
        {
            if (args.RowIndex < 0)
            {
                //header
                return;
            }
            if (args.RowIndex % 3 == 0)
            {
                args.CellStyle.BackgroundBrush = PdfBrushes.LightYellow;
            }
            else
            {
                args.CellStyle.BackgroundBrush = PdfBrushes.SkyBlue;
            }
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
