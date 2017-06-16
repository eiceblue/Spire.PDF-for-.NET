using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;


namespace DrawImage
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

            // Create one page
            PdfPageBase page = doc.Pages.Add();

            TransformText(page);
            DrawImage(page);
            TransformImage(page);

            //Save pdf file.
            doc.SaveToFile("DrawImage.pdf");
            doc.Close();

            //Launching the Pdf file.
            PDFDocumentViewer("DrawImage.pdf");
        }

        private void TransformText(PdfPageBase page)
        {
            //save graphics state
            PdfGraphicsState state = page.Canvas.Save();

            //Draw the text - transform           
            PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 18f);
            PdfSolidBrush brush1 = new PdfSolidBrush(Color.Blue);
            PdfSolidBrush brush2 = new PdfSolidBrush(Color.CadetBlue);
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Center);

            page.Canvas.TranslateTransform(page.Canvas.ClientSize.Width / 2, 20);
            page.Canvas.DrawString("Sales Report Chart", font, brush1, 0, 0, format);

            page.Canvas.ScaleTransform(1f, -0.8f);
            page.Canvas.DrawString("Sales Report Chart", font, brush2, 0, -2 * 18 * 1.2f, format);
            //restor graphics
            page.Canvas.Restore(state);
        }

        private void DrawImage(PdfPageBase page)
        {
            PdfImage image = PdfImage.FromFile(@"..\..\..\..\..\..\Data\SalesReportChart.png");
            float width = image.Width * 0.75f;
            float height = image.Height * 0.75f;
            float x = (page.Canvas.ClientSize.Width - width) / 2;

            page.Canvas.DrawImage(image, x, 60, width, height);
        }

        private void TransformImage(PdfPageBase page)
        {
            PdfImage image = PdfImage.FromFile(@"..\..\..\..\..\..\Data\SalesReportChart.png");
            int skewX = 20;
            int skewY = 20;
            float scaleX = 0.2f;
            float scaleY = 0.6f;
            int width = (int)((image.Width + image.Height * Math.Tan(Math.PI * skewX/ 180)) * scaleX);
            int height = (int)((image.Height + image.Width * Math.Tan(Math.PI * skewY/ 180)) * scaleY);
            PdfTemplate template = new PdfTemplate(width, height);
            template.Graphics.ScaleTransform(scaleX, scaleY);
            template.Graphics.SkewTransform(skewX, skewY);
            template.Graphics.DrawImage(image, 0, 0);

            //save graphics state
            PdfGraphicsState state = page.Canvas.Save();
            page.Canvas.TranslateTransform(page.Canvas.ClientSize.Width - 50, 260);
            float offset = (page.Canvas.ClientSize.Width - 100) / 12;
            for (int i = 0; i < 12; i++)
            {
                page.Canvas.TranslateTransform(-offset, 0);
                page.Canvas.SetTransparency(i / 12.0f);
                page.Canvas.DrawTemplate(template, new PointF(0, 0));
            }

            //restor graphics
            page.Canvas.Restore(state);
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