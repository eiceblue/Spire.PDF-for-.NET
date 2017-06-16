using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Tables;

namespace ImageTable
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
            page.Canvas.DrawString("Country List", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1);
            y = y + font1.MeasureString("Country List", format1).Height;
            y = y + 5;

            //create data table
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
                conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\..\..\..\..\Data\demo.mdb";
                OleDbCommand command = new OleDbCommand();
                command.CommandText
                    = " select Name, '' as Flag, Capital, Continent, Area, Population, Flag as FlagData from country ";
                command.Connection = conn;
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataTable.Columns.Add(new DataColumn("FlagImage", typeof(PdfImage)));
                    table.DataSourceType = PdfTableDataSourceType.TableDirect;
                    table.DataSource = dataTable;
                }
            }
            float width
                = page.Canvas.ClientSize.Width
                    - (table.Columns.Count + 1) * table.Style.BorderPen.Width;
            table.Columns[0].Width = width * 0.21f;
            table.Columns[0].StringFormat
                = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
            table.Columns[1].Width = width * 0.10f;
            table.Columns[1].StringFormat
                = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
            table.Columns[2].Width = width * 0.19f;
            table.Columns[2].StringFormat
                = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
            table.Columns[3].Width = width * 0.21f;
            table.Columns[3].StringFormat
                = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
            table.Columns[4].Width = width * 0.12f;
            table.Columns[4].StringFormat
                = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);
            table.Columns[5].Width = width * 0.17f;
            table.Columns[5].StringFormat
                = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);

            table.BeginRowLayout += new BeginRowLayoutEventHandler(table_BeginRowLayout);
            table.EndCellLayout += new EndCellLayoutEventHandler(table_EndCellLayout);

            PdfTableLayoutFormat tableLayout = new PdfTableLayoutFormat();
            tableLayout.Break = PdfLayoutBreakType.FitElement;
            tableLayout.Layout = PdfLayoutType.Paginate;
            tableLayout.EndColumnIndex = table.Columns.Count - 2 - 1;

            PdfLayoutResult result = table.Draw(page, new PointF(0, y), tableLayout);
            y = y + result.Bounds.Height + 5;

            PdfBrush brush2 = PdfBrushes.Gray;
            PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 9f));
            page.Canvas.DrawString(String.Format("* {0} countries in the list.", table.Rows.Count),
                font2, brush2, 5, y);

            //Save pdf file.
            doc.SaveToFile("ImageTable.pdf");
            doc.Close();

            //Launching the Pdf file.
            PDFDocumentViewer("ImageTable.pdf");
        }

        void table_EndCellLayout(object sender, EndCellLayoutEventArgs args)
        {
            if (args.RowIndex < 0)
            {
                //header
                return;
            }
            if (args.CellIndex == 1)
            {
                DataTable dataTable = (sender as PdfTable).DataSource as DataTable;
                PdfImage image = dataTable.Rows[args.RowIndex][7] as PdfImage;
                float x = (args.Bounds.Width - image.PhysicalDimension.Width) / 2 + args.Bounds.X;
                float y = (args.Bounds.Height - image.PhysicalDimension.Height) / 2 + args.Bounds.Y;
                args.Graphics.DrawImage(image, x, y);
            }
        }

        void table_BeginRowLayout(object sender, BeginRowLayoutEventArgs args)
        {
            if (args.RowIndex < 0)
            {
                //header
                return;
            }
            DataTable dataTable = (sender as PdfTable).DataSource as DataTable;
            byte[] imageData = dataTable.Rows[args.RowIndex][6] as byte[];
            using (MemoryStream stream = new MemoryStream(imageData))
            {
                PdfImage image = PdfImage.FromStream(stream);
                args.MinimalHeight = 4 + image.PhysicalDimension.Height;
                dataTable.Rows[args.RowIndex][7] = image;
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
