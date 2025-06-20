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
            //Create a pdf document
            PdfDocument doc = new PdfDocument();            

            //Create one page
            PdfPageBase page = doc.Pages.Add();

            TransformText(page);
            DrawImage(page);
            TransformImage(page);

            //Save the document
            doc.SaveToFile("DrawImage.pdf");
            doc.Close();

            //Launch the Pdf file
            PDFDocumentViewer("DrawImage.pdf");
        }

        private void TransformText(PdfPageBase page)
        {
            // Save graphics state
            PdfGraphicsState state = page.Canvas.Save();

            // Draw the text - transform
            PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 18f);
            PdfSolidBrush brush1 = new PdfSolidBrush(Color.Blue);
            PdfSolidBrush brush2 = new PdfSolidBrush(Color.CadetBlue);
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Center);

            // Translate the canvas to the center of the page with an offset of 20 pixels from the top
            page.Canvas.TranslateTransform(page.Canvas.ClientSize.Width / 2, 20);
            page.Canvas.DrawString("Chart image", font, brush1, 0, 0, format);

            // Scale the canvas horizontally by 1 and vertically by -0.8
            page.Canvas.ScaleTransform(1f, -0.8f);

            // Draw the transformed text with a different brush and at a specific position
            page.Canvas.DrawString("Chart image", font, brush2, 0, -2 * 18 * 1.2f, format);

            // Restore graphics state to the previously saved state
            page.Canvas.Restore(state);
        }

        // Method for drawing an image on the specified page
        private void DrawImage(PdfPageBase page)
        {
            // Load an image from file
            PdfImage image = PdfImage.FromFile(@"..\..\..\..\..\..\Data\ChartImage.png");

            // Calculate the scaled width and height of the image
            float width = image.Width * 0.75f;
            float height = image.Height * 0.75f;

            // Calculate the x-coordinate to center the image horizontally on the page
            float x = (page.Canvas.ClientSize.Width - width) / 2;

            // Draw the image on the page at the specified position and size
            page.Canvas.DrawImage(image, x, 60, width, height);
        }

        // Method for transforming the image and drawing it on the page
        private void TransformImage(PdfPageBase page)
        {
            // Load an image from file
            PdfImage image = PdfImage.FromFile(@"..\..\..\..\..\..\Data\ChartImage.png");

            // Define the skew angles and scaling factors
            int skewX = 20;
            int skewY = 20;
            float scaleX = 0.2f;
            float scaleY = 0.6f;

            // Calculate the transformed width and height of the image
            int width = (int)((image.Width + image.Height * Math.Tan(Math.PI * skewX / 180)) * scaleX);
            int height = (int)((image.Height + image.Width * Math.Tan(Math.PI * skewY / 180)) * scaleY);

            // Create a template with the transformed dimensions
            PdfTemplate template = new PdfTemplate(width, height);

            // Apply scale and skew transformations to the graphics of the template
            template.Graphics.ScaleTransform(scaleX, scaleY);
            template.Graphics.SkewTransform(skewX, skewY);

            // Draw the image onto the template
            template.Graphics.DrawImage(image, 0, 0);

            // Save the current graphics state
            PdfGraphicsState state = page.Canvas.Save();

            // Adjust the position and transparency for multiple repetitions of the template
            page.Canvas.TranslateTransform(page.Canvas.ClientSize.Width - 50, 260);
            float offset = (page.Canvas.ClientSize.Width - 100) / 12;

            // Repeat the template drawing with varying transparency levels
            for (int i = 0; i < 12; i++)
            {
                page.Canvas.TranslateTransform(-offset, 0);
                page.Canvas.SetTransparency(i / 12.0f);
                page.Canvas.DrawTemplate(template, new PointF(0, 0));
            }

            // Restore the graphics state to its original settings
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