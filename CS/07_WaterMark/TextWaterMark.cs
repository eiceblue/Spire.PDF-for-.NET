using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Tables;

namespace TextWaterMark
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

            PdfTilingBrush brush
                = new PdfTilingBrush(new SizeF(page.Canvas.ClientSize.Width / 2, page.Canvas.ClientSize.Height / 3));
            brush.Graphics.SetTransparency(0.3f);
            brush.Graphics.Save();
            brush.Graphics.TranslateTransform(brush.Size.Width / 2, brush.Size.Height / 2);
            brush.Graphics.RotateTransform(-45);
            brush.Graphics.DrawString("Spire.Pdf Demo",
                new PdfFont(PdfFontFamily.Helvetica, 24), PdfBrushes.Violet, 0, 0,
                new PdfStringFormat(PdfTextAlignment.Center));
            brush.Graphics.Restore();
            brush.Graphics.SetTransparency(1);
            page.Canvas.DrawRectangle(brush, new RectangleF(new PointF(0, 0), page.Canvas.ClientSize));

            //Draw the page
            DrawPage(page);

            //Save pdf file.
            doc.SaveToFile("TextWaterMark.pdf");
            doc.Close();

            //Launching the Pdf file.
            PDFDocumentViewer("TextWaterMark.pdf");
        }

        private void DrawPage(PdfPageBase page)
        {
            float y = 10;

            //title
            PdfBrush brush1 = PdfBrushes.Black;
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 16f, FontStyle.Bold));
            PdfStringFormat format1 = new PdfStringFormat(PdfTextAlignment.Center);
            page.Canvas.DrawString("Category Sales by Year", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1);
            y = y + font1.MeasureString("Category Sales by Year", format1).Height;
            y = y + 5;

            String[][] data
                = {
                    new String[]{"Category Name", "1994 Sale Amount", "1995 Sale Amount", "1996 Sale Amount"},
                    new String[]{"Beverages", "38,487.20", "102,479.46", "126,901.53"},
                    new String[]{"Condiments", "16,402.95", "51,041.83", "38,602.31"},
                    new String[]{"Confections", "23,812.90", "79,752.25", "63,792.07"},
                    new String[]{"Dairy Products", "30,027.79", "116,495.45", "87,984.05"},
                    new String[]{"Grains/Cereals", "7,313.92", "53,823.48", "34,607.19"},
                    new String[]{"Meat/Poultry", "19,856.86", "77,164.75", "66,000.75"},
                    new String[]{"Produce", "10,694.96", "45,973.69", "43,315.93"},
                    new String[]{"Seafood", "16,247.77", "64,195.51", "50,818.46"}
                };

            PdfTable table = new PdfTable();
            table.Style.CellPadding = 2;
            table.Style.BorderPen = new PdfPen(brush1, 0.75f);
            table.Style.DefaultStyle.BackgroundBrush = PdfBrushes.SkyBlue;
            table.Style.DefaultStyle.Font = new PdfTrueTypeFont(new Font("Arial", 10f));
            table.Style.HeaderSource = PdfHeaderSource.Rows;
            table.Style.HeaderRowCount = 1;
            table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.CadetBlue;
            table.Style.HeaderStyle.Font = new PdfTrueTypeFont(new Font("Arial", 11f, FontStyle.Bold));
            table.Style.HeaderStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center);
            table.Style.ShowHeader = true;
            table.DataSource = data;

            PdfLayoutResult result = table.Draw(page, new PointF(0, y));
            y = y + result.Bounds.Height + 5;

            PdfBrush brush2 = PdfBrushes.LightGray;
            PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 9f));
            page.Canvas.DrawString("* All data from NorthWind", font2, brush2, 5, y);
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
