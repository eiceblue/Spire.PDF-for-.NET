using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;


namespace TextLayout
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

            //Create one page
            PdfPageBase page = doc.Pages.Add();
            float pageWidth = page.Canvas.ClientSize.Width;
            float y = 0;

            //Page header
            PdfPen pen1 = new PdfPen(Color.LightGray, 1f);
            PdfBrush brush1 = new PdfSolidBrush(Color.LightGray);

            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 8f, FontStyle.Italic));

            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
              PdfTrueTypeFont font1 = new PdfTrueTypeFont(new System.Drawing.Font("Arial", 8f, FontStyle.Italic));
            */

            PdfStringFormat format1 = new PdfStringFormat(PdfTextAlignment.Right);
            String text = "Demo of Spire.Pdf";

            //Draw text
            page.Canvas.DrawString(text, font1, brush1, pageWidth - 2, y, format1);

            //Measure the size of text
            SizeF size = font1.MeasureString(text, format1);
            y = y + size.Height + 1;

            //Draw the text of header
            page.Canvas.DrawLine(pen1, 0, y, pageWidth, y);

            //Title
            y = y + 25;
            PdfBrush brush2 = new PdfSolidBrush(Color.Black);
            PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 18f, FontStyle.Bold));
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 8f, FontStyle.Italic));

            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
              PdfTrueTypeFont font2 = new PdfTrueTypeFont("Arial", 18f, PdfFontStyle.Bold, true);
            */

            PdfStringFormat format2 = new PdfStringFormat(PdfTextAlignment.Center);
            format2.CharacterSpacing = 1f;
            text = "Summary of Science";
            page.Canvas.DrawString(text, font2, brush2, pageWidth / 2, y, format2);
            size = font2.MeasureString(text, format2);
            y = y + size.Height + 16;

            //Icon
            PdfImage image = PdfImage.FromFile(@"..\..\..\..\..\..\Data\Wikipedia_Science.png");
            page.Canvas.DrawImage(image, new PointF(pageWidth - image.PhysicalDimension.Width, y));
            float imageLeftSpace = pageWidth - image.PhysicalDimension.Width - 2;
            float imageBottom = image.PhysicalDimension.Height + y;

            //Refenrence content
            //Define the font style
            PdfTrueTypeFont font3 = new PdfTrueTypeFont(new Font("Arial", 12f));
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
              PdfTrueTypeFont font3 = new PdfTrueTypeFont("Arial", 18f, PdfFontStyle.Regular, true);
            */

            //Define string format
            PdfStringFormat format3 = new PdfStringFormat();
            format3.ParagraphIndent = font3.Size * 2;
            format3.MeasureTrailingSpaces = true;
            format3.LineSpacing = font3.Size * 1.5f;
            String text1 = "(All text and picture from ";
            String text2 = "Wikipedia";
            String text3 = ", the free encyclopedia)";

            //Draw text
            page.Canvas.DrawString(text1, font3, brush2, 0, y, format3);

            //Meature the size of text
            size = font3.MeasureString(text1, format3);
            float x1 = size.Width;
            format3.ParagraphIndent = 0;
            PdfTrueTypeFont font4 = new PdfTrueTypeFont(new Font("Arial", 12f, FontStyle.Underline));

            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
               PdfTrueTypeFont font4 = new PdfTrueTypeFont("Arial", 12f, PdfFontStyle.Underline, true);
            */


            PdfBrush brush3 = PdfBrushes.Blue;
            page.Canvas.DrawString(text2, font4, brush3, x1, y, format3);

            //Measure the size of text
            size = font4.MeasureString(text2, format3);
            x1 = x1 + size.Width;

            //Draw text
            page.Canvas.DrawString(text3, font3, brush2, x1, y, format3);
            y = y + size.Height;

            //Content
            //Define the format of string
            PdfStringFormat format4 = new PdfStringFormat();
            text = System.IO.File.ReadAllText(@"..\..\..\..\..\..\Data\Summary_of_Science.txt");

            //Define the font style
            PdfTrueTypeFont font5 = new PdfTrueTypeFont(new Font("Arial", 12f));

            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
               PdfTrueTypeFont font5 = new PdfTrueTypeFont("Arial", 12f, PdfFontStyle.Regular, true);
            */

            format4.LineSpacing = font5.Size * 1.5f;

            PdfStringLayouter textLayouter = new PdfStringLayouter();
            float imageLeftBlockHeight = imageBottom - y;
            PdfStringLayoutResult result = textLayouter.Layout(text, font5, format4, new SizeF(imageLeftSpace, imageLeftBlockHeight));
            if (result.ActualSize.Height < imageBottom - y)
            {
                imageLeftBlockHeight = imageLeftBlockHeight + result.LineHeight;
                result = textLayouter.Layout(text, font5, format4, new SizeF(imageLeftSpace, imageLeftBlockHeight));
            }
            foreach (LineInfo line in result.Lines)
            {
                //Draw text
                page.Canvas.DrawString(line.Text, font5, brush2, 0, y, format4);
                y = y + result.LineHeight + 2;
            }
            PdfTextWidget textWidget = new PdfTextWidget(result.Remainder, font5, brush2);
            PdfTextLayout textLayout = new PdfTextLayout();
            textLayout.Break = PdfLayoutBreakType.FitPage;
            textLayout.Layout = PdfLayoutType.Paginate;
            RectangleF bounds = new RectangleF(new PointF(0, y), page.Canvas.ClientSize);
            textWidget.StringFormat = format4;
            textWidget.Draw(page, bounds, textLayout);

            //Save the document
            doc.SaveToFile("TextLayout.pdf");
            doc.Close();

            //Launch the Pdf file
            PDFDocumentViewer("TextLayout.pdf");
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
