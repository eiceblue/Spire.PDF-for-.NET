using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Actions;
using Spire.Pdf.Annotations;

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
            label = "Web Link: ";
            page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format);
            x = font.MeasureString(label, format).Width;

            // Set text and properties for the second web link.
            String text = "E-iceblue home";
            PdfTextWebLink link2 = new PdfTextWebLink();
            link2.Text = text;
            link2.Url = url1;
            link2.Font = font1;
            link2.Brush = PdfBrushes.CadetBlue;

            // Draw the second web link on the page.
            link2.DrawTextWebLink(page.Canvas, new PointF(x, y));
            y = y + font1.MeasureString(text).Height + 30;

            // Set font and label for the URI annotation.
            label = "URI Annotation: ";
            page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format);
            x = font.MeasureString(label, format).Width;
            text = "Google";
            PointF location = new PointF(x, y);
            SizeF size = font1.MeasureString(text);
            RectangleF linkBounds = new RectangleF(location, size);

            // Create a URI annotation and set its properties.
            PdfUriAnnotation link3 = new PdfUriAnnotation(linkBounds);
            link3.Border = new PdfAnnotationBorder(0);
            link3.Uri = "http://www.google.com";

            // Add the URI annotation to the page's annotations collection.
            (page as PdfNewPage).Annotations.Add(link3);

            // Draw the text for the URI annotation.
            page.Canvas.DrawString(text, font1, PdfBrushes.CadetBlue, x, y);
            y = y + size.Height + 30;

            // Set font and label for the URI annotation with an action.
            label = "URI Annotation Action: ";
            page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format);
            x = font.MeasureString(label, format).Width;
            text = "JavaScript Action (Click Me)";
            location = new PointF(x - 2, y - 2);
            size = font1.MeasureString(text);
            size = new SizeF(size.Width + 5, size.Height + 5);
            linkBounds = new RectangleF(location, size);

            // Create a URI annotation with border and color.
            PdfUriAnnotation link4 = new PdfUriAnnotation(linkBounds);
            link4.Border = new PdfAnnotationBorder(0.75f);
            link4.Color = Color.CadetBlue;

            // Define JavaScript action script.
            String script = "app.alert({" +
                "cMsg: \"Hello.\"," +
                "nIcon: 3," +
                "cTitle: \"JavaScript Action\"" +
                "});";

            // Create a JavaScript action and assign it to the URI annotation.
            PdfJavaScriptAction action = new PdfJavaScriptAction(script);
            link4.Action = action;

            // Add the URI annotation with the JavaScript action to the page's annotations collection.
            (page as PdfNewPage).Annotations.Add(link4);

            // Draw the text for the URI annotation with the JavaScript action.
            page.Canvas.DrawString(text, font1, PdfBrushes.CadetBlue, x, y);
            y = y + size.Height + 30;

            label = "Need Help:  ";
            page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format);
            x = font.MeasureString(label, format).Width;
            text = "Go to forum to ask questions";
            link2 = new PdfTextWebLink();
            link2.Text = text;
            link2.Url = "https://www.e-iceblue.com/forum/components-f5.html";
            link2.Font = font1;
            link2.Brush = PdfBrushes.CadetBlue;
            link2.DrawTextWebLink(page.Canvas, new PointF(x, y));
            y = y + font1.MeasureString(text).Height + 30;

            label = "Contct us:  ";
            page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format);
            x = font.MeasureString(label, format).Width;
            text = "Send an email";
            link2 = new PdfTextWebLink();
            link2.Text = text;
            link2.Url = "mailto:support@e-iceblue.com";
            link2.Font = font1;
            link2.Brush = PdfBrushes.CadetBlue;
            link2.DrawTextWebLink(page.Canvas, new PointF(x, y));
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
