using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Actions;
using Spire.Pdf.Annotations;
using Spire.Pdf.General;
using Spire.Pdf.Graphics;
using Spire.Pdf.Tables;

namespace Action
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
            y = y + 2;

            //table top
            PdfDestination tableTopDest = new PdfDestination(page);
            tableTopDest.Location = new PointF(0, y);
            tableTopDest.Mode = PdfDestinationMode.Location;
            tableTopDest.Zoom = 1f;

            //Draw table            
            PdfTrueTypeFont buttonFont = new PdfTrueTypeFont(new Font("Arial", 10f, FontStyle.Bold));
            float buttonWidth = 70;
            float buttonHeight = buttonFont.Height * 1.5f;
            float tableTop = y;
            PdfLayoutResult tableLayoutResult = DrawTable(page, y + buttonHeight + 5);

            //table bottom
            PdfDestination tableBottomDest = new PdfDestination(tableLayoutResult.Page);
            tableBottomDest.Location = new PointF(0, tableLayoutResult.Bounds.Bottom);
            tableBottomDest.Mode = PdfDestinationMode.Location;
            tableBottomDest.Zoom = 1f;

            //go to table bottom
            float x = page.Canvas.ClientSize.Width - buttonWidth;
            PdfStringFormat format2 = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            RectangleF buttonBounds = new RectangleF(x, tableTop, buttonWidth, buttonHeight);
            page.Canvas.DrawRectangle(PdfBrushes.DarkGray, buttonBounds);
            page.Canvas.DrawString("To Bottom", buttonFont, PdfBrushes.CadetBlue, buttonBounds, format2);
            PdfGoToAction action1 = new PdfGoToAction(tableBottomDest);
            PdfActionAnnotation annotation1
                = new PdfActionAnnotation(buttonBounds, action1);
            annotation1.Border = new PdfAnnotationBorder(0.75f);
            annotation1.Color = Color.LightGray;
            (page as PdfNewPage).Annotations.Add(annotation1);

            //go to table top
            float tableBottom = tableLayoutResult.Bounds.Bottom + 5;
            buttonBounds = new RectangleF(x, tableBottom, buttonWidth, buttonHeight);
            tableLayoutResult.Page.Canvas.DrawRectangle(PdfBrushes.DarkGray, buttonBounds);
            tableLayoutResult.Page.Canvas.DrawString("To Top", buttonFont, PdfBrushes.CadetBlue, buttonBounds, format2);
            PdfGoToAction action2 = new PdfGoToAction(tableTopDest);
            PdfActionAnnotation annotation2
                = new PdfActionAnnotation(buttonBounds, action2);
            annotation2.Border = new PdfAnnotationBorder(0.75f);
            annotation2.Color = Color.LightGray;
            (tableLayoutResult.Page as PdfNewPage).Annotations.Add(annotation2);

            //goto last page
            PdfNamedAction action3 = new PdfNamedAction(PdfActionDestination.LastPage);
            doc.AfterOpenAction = action3;

            //script
            String script
                = "app.alert({"
                + "    cMsg: \"Oh no, you want to leave me.\","
                + "    nIcon: 3,"
                + "    cTitle: \"JavaScript Action\""
                + "});";
            PdfJavaScriptAction action4 = new PdfJavaScriptAction(script);
            doc.BeforeCloseAction = action4;

            //Save pdf file.
            doc.SaveToFile("Action.pdf");
            doc.Close();

            //Launching the Pdf file.
            PDFDocumentViewer("Action.pdf");
        }

        private PdfLayoutResult DrawTable(PdfPageBase page, float y)
        {
            PdfBrush brush1 = PdfBrushes.Black;

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
                    = " select Description, OnHand, OnOrder, Cost, ListPrice from parts ";
                command.Connection = conn;
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    table.DataSourceType = PdfTableDataSourceType.TableDirect;
                    table.DataSource = dataTable;
                }
            }
            float width
                = page.Canvas.ClientSize.Width
                    - (table.Columns.Count + 1) * table.Style.BorderPen.Width;
            for (int i = 0; i < table.Columns.Count; i++)
            {
                if (i == 0)
                {
                    table.Columns[i].Width = width * 0.40f * width;
                    table.Columns[i].StringFormat
                        = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
                }
                else
                {
                    table.Columns[i].Width = width * 0.15f * width;
                    table.Columns[i].StringFormat
                        = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);
                }
            }

            PdfTableLayoutFormat tableLayout = new PdfTableLayoutFormat();
            tableLayout.Break = PdfLayoutBreakType.FitElement;
            tableLayout.Layout = PdfLayoutType.Paginate;

            PdfLayoutResult result = table.Draw(page, new PointF(0, y), tableLayout);
            y = result.Bounds.Bottom + 3;

            PdfBrush brush2 = PdfBrushes.Gray;
            PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 9f));
            result.Page.Canvas.DrawString(String.Format("* {0} parts in the list.", table.Rows.Count),
                font2, brush2, 5, y);

            return result;
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
