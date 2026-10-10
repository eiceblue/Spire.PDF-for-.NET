using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Interactive.Annotations;
using Spire.Pdf.Graphics;
using Spire.Pdf.Actions;

namespace Link
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new PDF document.
            PdfDocument doc = new PdfDocument();

            // Set margins for the document.
            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
            PdfMargins margin = new PdfMargins();
            margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Bottom = margin.Top;
            margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Right = margin.Left;

            // Create a new page with specified size and margins.
            PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, margin);

            float y = 100;
            float x = 10;

            // Set font and label for the first text link.
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Lucida Sans Unicode", 14));
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
             PdfTrueTypeFont font = new PdfTrueTypeFont("Lucida Sans Unicode", 14, PdfFontStyle.Regular, true);
            */
            String label = "Simple Text Link: ";

            // Draw the label on the page.
            PdfStringFormat format = new PdfStringFormat();
            format.MeasureTrailingSpaces = true;
            page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format);

            x = font.MeasureString(label, format).Width;

            // Set font and URL for the first text link.
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Lucida Sans Unicode", 14, FontStyle.Underline));
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
            PdfTrueTypeFont font1 = new PdfTrueTypeFont("Lucida Sans Unicode", 14, PdfFontStyle.Underline, true);
            */
            String url1 = "http://www.e-iceblue.com";

            // Draw the URL on the page.
            page.Canvas.DrawString(url1, font1, PdfBrushes.CadetBlue, x, y);
            y = y + font1.MeasureString(url1).Height + 25;

            // Set font and label for the second web link.
            String text = "E-iceblue home";
            PdfURIAction action2 = new PdfURIAction(url1);
            PdfLinkAnnotation link2 = new PdfLinkAnnotation(page, new RectangleF(x + margin.Left, y + margin.Top, 50, 20), action2);
            link2.Border.Width = 0;
            link2.Contents = text;
            page.Canvas.DrawString(text, font1, PdfBrushes.CadetBlue, new PointF(x, y));
            PdfAnnotationCollection.Create(page).Add(link2);
            y = y + font1.MeasureString(text).Height + 30;

            label = "URI Annonation: ";
            page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format);
            x = font.MeasureString(label, format).Width;
            text = "Google";
            PointF location = new PointF(x + margin.Left, y + margin.Top);
            SizeF size = font1.MeasureString(text);
            RectangleF linkBounds = new RectangleF(location, size);
            PdfURIAction action3 = new PdfURIAction("http://www.google.com");
            PdfLinkAnnotation link3 = new PdfLinkAnnotation(page, linkBounds, action3);

            link3.Border.Width = 0;
            PdfAnnotationCollection.Create(page).Add(link3);
            page.Canvas.DrawString(text, font1, PdfBrushes.CadetBlue, x, y);
            y = y + size.Height + 30;

            label = "URI Annonation Action: ";
            page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format);
            x = font.MeasureString(label, format).Width;
            text = "JavaScript Action (Click Me)";
            location = new PointF(x - 2 + margin.Left, y - 2 + margin.Top);
            size = font1.MeasureString(text);
            size = new SizeF(size.Width + 5, size.Height + 5);
            linkBounds = new RectangleF(location, size);
            //Script
            String script
                = "app.alert({"
                + "    cMsg: \"Hello.\","
                + "    nIcon: 3,"
                + "    cTitle: \"JavaScript Action\""
                + "});";
            PdfJavaScriptAction action4 = new PdfJavaScriptAction(script);
            PdfLinkAnnotation link4 = new PdfLinkAnnotation(page, linkBounds, action4);
            link4.Border.Width = 0.75f;
            link4.Color = Color.CadetBlue;


            PdfAnnotationCollection.Create(page).Add(link4);
            page.Canvas.DrawString(text, font1, PdfBrushes.CadetBlue, x, y);
            y = y + size.Height + 30;

            label = "Need Help:  ";
            page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format);
            x = font.MeasureString(label, format).Width;
            text = "Go to forum to ask questions";
            PdfURIAction action5 = new PdfURIAction("https://www.e-iceblue.com/forum/components-f5.html");
            link2 = new PdfLinkAnnotation(page, new RectangleF(x + margin.Left, y + margin.Top, 100, 20), action5);
            link2.Border.Width = 0;
            link2.Contents = text;
            page.Canvas.DrawString(text, font1, PdfBrushes.CadetBlue, new PointF(x, y));
            PdfAnnotationCollection.Create(page).Add(link2);
            y = y + font1.MeasureString(text).Height + 30;

            label = "Contct us:  ";
            page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format);
            x = font.MeasureString(label, format).Width;
            text = "Send an email";
            PdfURIAction action6 = new PdfURIAction("mailto:support@e-iceblue.com");
            link2 = new PdfLinkAnnotation(page, new RectangleF(x + margin.Left, y + margin.Top, 50, 20), action6);
            link2.Border.Width = 0;
            link2.Contents = text;
            page.Canvas.DrawString(text, font1, PdfBrushes.CadetBlue, new PointF(x, y));
            PdfAnnotationCollection.Create(page).Add(link2);
            y = y + font1.MeasureString(text).Height + 30;



            //Save pdf file.
            doc.SaveToFile("Link.pdf");
            doc.Close();

            //Launch the file.
            PDFDocumentViewer("Link.pdf");
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
