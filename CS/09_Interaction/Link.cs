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
            float x = 0;
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12));
            String label = "Simple Link: ";
            PdfStringFormat format = new PdfStringFormat();
            format.MeasureTrailingSpaces = true;
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, 0, y, format);
            x = font.MeasureString(label, format).Width;
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 12, FontStyle.Underline));
            String url1 = "http://www.e-iceblue.com";
            page.Canvas.DrawString(url1, font1, PdfBrushes.Blue, x, y);
            y = y + font1.MeasureString(url1).Height;

            label = "Web Link: ";
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, 0, y, format);
            x = font.MeasureString(label, format).Width;
            String text = "e-iceblue";
            PdfTextWebLink link2 = new PdfTextWebLink();
            link2.Text = text;
            link2.Url = url1;
            link2.Font = font1;
            link2.Brush = PdfBrushes.Blue;
            link2.DrawTextWebLink(page.Canvas, new PointF(x, y));
            y = y + font1.MeasureString(text).Height;

            label = "URI Annonationa: ";
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, 0, y, format);
            x = font.MeasureString(label, format).Width;
            text = "Google";
            PointF location = new PointF(x, y);
            SizeF size = font1.MeasureString(text);
            RectangleF linkBounds = new RectangleF(location, size);
            PdfUriAnnotation link3 = new PdfUriAnnotation(linkBounds);
            link3.Border = new PdfAnnotationBorder(0);
            link3.Uri = "http://www.google.com";
            (page as PdfNewPage).Annotations.Add(link3);
            page.Canvas.DrawString(text, font1, PdfBrushes.Blue, x, y);
            y = y + size.Height;

            label = "URI Annonationa Action: ";
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, 0, y, format);
            x = font.MeasureString(label, format).Width;
            text = "JavaScript Action (Click Me)";
            location = new PointF(x, y);
            size = font1.MeasureString(text);
            linkBounds = new RectangleF(location, size);
            PdfUriAnnotation link4 = new PdfUriAnnotation(linkBounds);
            link4.Border = new PdfAnnotationBorder(0.75f);
            link4.Color = Color.LightGray;
            //script
            String script
                = "app.alert({"
                + "    cMsg: \"Hello.\","
                + "    nIcon: 3,"
                + "    cTitle: \"JavaScript Action\""
                + "});";
            PdfJavaScriptAction action = new PdfJavaScriptAction(script);
            link4.Action = action;
            (page as PdfNewPage).Annotations.Add(link4);
            page.Canvas.DrawString(text, font1, PdfBrushes.Blue, x, y);
            y = y + size.Height;

            //Save pdf file.
            doc.SaveToFile("Link.pdf");
            doc.Close();

            //Launching the Pdf file.
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
