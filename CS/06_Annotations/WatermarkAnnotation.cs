using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Interactive.Annotations;

namespace WatermarkAnnotation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new PDF document
            PdfDocument doc = new PdfDocument();

            // Add a page
            PdfPageBase page = doc.Pages.Add();

            // Define a rectangle for the watermark annotation
            RectangleF rect = new RectangleF(100, 100, 300, 300);

            // Create a watermark annotation
            PdfWatermarkAnnotation annotation = new PdfWatermarkAnnotation(page, rect);

            // Set the annotation properties
            annotation.Color = Color.Red;
            annotation.Flags = PdfAnnotationFlags.Print;
            annotation.Contents = "Contents";
            annotation.Name = "Name";

            // Configure the FixedPrint settings
            PdfFixedPrint fixedPrint = new PdfFixedPrint();
            fixedPrint.HorizontalTranslation = 50;
            fixedPrint.VerticalTranslation = 30;
            annotation.FixedPrint = fixedPrint;

            // Set the normal appearance of the annotation
            annotation.Appearances.SetNormalAppearance(CreateAppearance(300, 300));

            // Add the annotation to the page
            PdfAnnotationCollection.Create(page).Add(annotation);

            // Save the document
            string output = "WatermarkAnnotation.pdf";
            doc.SaveToFile(output);
            doc.Close();

            // Launch the Pdf file
            PDFDocumentViewer(output);
        }

        private PdfAppearance CreateAppearance(float width, float height)
        {
            // Create a true type font for the watermark text
            System.Drawing.Font font = new System.Drawing.Font("Arial", 15);
            PdfTrueTypeFont trueTypeFont = new PdfTrueTypeFont(font, true);

            // Create a template with the specified size
            PdfTemplate template = new PdfTemplate(width, height);

            // Create a tiling brush and draw the watermark text in it
            SizeF size = new SizeF(100, 100);
            PdfTilingBrush brush = new PdfTilingBrush(size);

            brush.Graphics.SetTransparency(0.3f);
            brush.Graphics.Save();
            brush.Graphics.TranslateTransform((float)brush.Size.Width / 2, (float)brush.Size.Height / 2);
            brush.Graphics.RotateTransform(-45);
            brush.Graphics.DrawString("watermark", trueTypeFont, PdfBrushes.Gray, 0, 0, new PdfStringFormat(PdfTextAlignment.Center));
            brush.Graphics.Restore();
            brush.Graphics.SetTransparency(1);

            // Fill the template with the tiling brush
            template.Graphics.DrawRectangle(brush, new RectangleF(0, 0, width, height));

            // Return the appearance built from the template
            return new PdfAppearance(template);
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
