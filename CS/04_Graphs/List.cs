using System;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Lists;

namespace List
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a pdf document
            PdfDocument doc = new PdfDocument();

            //Margin
            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
            PdfMargins margin = new PdfMargins();
            margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Bottom = margin.Top;
            margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Right = margin.Left;

            //Create one page
            PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, margin);

            float y = 10;

            //Title
            PdfBrush brush1 = PdfBrushes.Black;
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 16f, FontStyle.Bold), true);
            PdfStringFormat format1 = new PdfStringFormat(PdfTextAlignment.Center);
            page.Canvas.DrawString("Categories List", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1);
            y = y + font1.MeasureString("Categories List", format1).Height;
            y = y + 5;

            RectangleF rctg = new RectangleF(new PointF(0, 0), page.Canvas.ClientSize);
            PdfLinearGradientBrush brush
                = new PdfLinearGradientBrush(rctg, Color.Navy, Color.OrangeRed, PdfLinearGradientMode.Vertical);
            PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 12f, PdfFontStyle.Bold);
            String formatted
                = "Beverages\nCondiments\nConfections\nDairy Products\nGrains/Cereals\nMeat/Poultry\nProduce\nSeafood";

            //Create a list
            PdfList list = new PdfList(formatted);
            list.Font = font;
            list.Indent = 8;
            list.TextIndent = 5;
            list.Brush = brush;

            //Draw the list on the page
            PdfLayoutResult result = list.Draw(page, 0, y);
            y = result.Bounds.Bottom;

            //Create another list
            PdfSortedList sortedList = new PdfSortedList(formatted);
            sortedList.Font = font;
            sortedList.Indent = 8;
            sortedList.TextIndent = 5;
            sortedList.Brush = brush;
            //Draw the list on the page
            PdfLayoutResult result2 = sortedList.Draw(page, 0, y);

            y = result2.Bounds.Bottom;
            PdfOrderedMarker marker1 = new PdfOrderedMarker(PdfNumberStyle.LowerRoman, new PdfFont(PdfFontFamily.Helvetica, 12f));
            PdfSortedList list2 = new PdfSortedList(formatted);
            list2.Font = font;
            list2.Marker = marker1;
            list2.Indent = 8;
            list2.TextIndent = 5;
            list2.Brush = brush;
            PdfLayoutResult result3 = list2.Draw(page, 0, y);
            y = result3.Bounds.Bottom;

            PdfOrderedMarker marker2 = new PdfOrderedMarker(PdfNumberStyle.LowerLatin, new PdfFont(PdfFontFamily.Helvetica, 12f));
            PdfSortedList list3 = new PdfSortedList(formatted);
            list3.Font = font;
            list3.Marker = marker2;
            list3.Indent = 8;
            list3.TextIndent = 5;
            list3.Brush = brush;
            list3.Draw(page, 0, y);

            //Save pdf file
            doc.SaveToFile("List.pdf");
            doc.Close();

            //Launch the Pdf file
            PDFDocumentViewer("List.pdf");
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
