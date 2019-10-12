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
            //Create a pdf document.
            PdfDocument doc = new PdfDocument();

            //Set margins
            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
            PdfMargins margin = new PdfMargins();
            margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Bottom = margin.Top;
            margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Right = margin.Left;

            //Create one page
            PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, margin);

            float y = 100;
            float x = 10;
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Lucida Sans Unicode", 14));

            String label = "Simple Text Link: ";
            PdfStringFormat format = new PdfStringFormat();
            format.MeasureTrailingSpaces = true;
            page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format);
            x = font.MeasureString(label, format).Width;
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Lucida Sans Unicode", 14, FontStyle.Underline));
            String url1 = "http://www.e-iceblue.com";
            page.Canvas.DrawString(url1, font1, PdfBrushes.CadetBlue, x, y);
            y = y + font1.MeasureString(url1).Height + 25;

            label = "Web Link: ";
            page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format);
            x = font.MeasureString(label, format).Width;
            String text = "E-iceblue home";
            PdfTextWebLink link2 = new PdfTextWebLink();
            link2.Text = text;
            link2.Url = url1;
            link2.Font = font1;
            link2.Brush = PdfBrushes.CadetBlue;
            link2.DrawTextWebLink(page.Canvas, new PointF(x, y));
            y = y + font1.MeasureString(text).Height + 30;

            label = "URI Annonation: ";
            page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format);
            x = font.MeasureString(label, format).Width;
            text = "Google";
            PointF location = new PointF(x, y);
            SizeF size = font1.MeasureString(text);
            RectangleF linkBounds = new RectangleF(location, size);
            PdfUriAnnotation link3 = new PdfUriAnnotation(linkBounds);
            link3.Border = new PdfAnnotationBorder(0);
            link3.Uri = "http://www.google.com";
            (page as PdfNewPage).Annotations.Add(link3);
            page.Canvas.DrawString(text, font1, PdfBrushes.CadetBlue, x, y);
            y = y + size.Height + 30;

            label = "URI Annonation Action: ";
            page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format);
            x = font.MeasureString(label, format).Width;
            text = "JavaScript Action (Click Me)";
            location = new PointF(x-2, y-2);
            size = font1.MeasureString(text);
            size=new SizeF(size.Width+5,size.Height+5);
            linkBounds = new RectangleF(location,size);
            PdfUriAnnotation link4 = new PdfUriAnnotation(linkBounds);
            link4.Border = new PdfAnnotationBorder(0.75f);
            link4.Color = Color.CadetBlue;
            //Script
            String script
                = "app.alert({"
                + "    cMsg: \"Hello.\","
                + "    nIcon: 3,"
                + "    cTitle: \"JavaScript Action\""
                + "});";
            PdfJavaScriptAction action = new PdfJavaScriptAction(script);
            link4.Action = action;
            (page as PdfNewPage).Annotations.Add(link4);
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
