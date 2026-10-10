using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Interactive.Annotations;

namespace CircleAnnotation
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

            // Create a circle annotation with a cloudy border effect
            RectangleF rect = new RectangleF(100, 100, 150, 150);
            PdfCircleAnnotation annotation = new PdfCircleAnnotation(page, rect);

            // Set the annotation properties
            annotation.Title = "CircleWithEffect";
            annotation.Contents = "A circle annotation with a cloudy border effect.";
            annotation.Name = "CircleName";
            annotation.Subject = "Circle";
            annotation.Color = new PdfRGBColor(128, 0, 128);
            annotation.InteriorColor = new PdfRGBColor(255, 255, 200);
            annotation.Border.Width = 2f;
            annotation.Border.Style = PdfBorderStyle.Solid;
            annotation.Border.Effect = PdfBorderEffect.Cloudy;
            annotation.Border.EffectIntensity = 2;
            annotation.Flags = PdfAnnotationFlags.Print;
            annotation.RectangleDifferences = new PdfRectangleDifferences(5, 5, 5, 5);

            // Add the annotation to the page and refresh its appearance
            PdfAnnotationCollection.Create(page).Add(annotation);
            annotation.RefreshAppearances();

            // Create a second circle annotation with a different interior color
            RectangleF rect2 = new RectangleF(300, 300, 200, 100);
            PdfCircleAnnotation annotation2 = new PdfCircleAnnotation(page, rect2);
            annotation2.Title = "Circle2";
            annotation2.Contents = "A circle annotation with a green interior.";
            annotation2.Color = Color.Red;
            annotation2.InteriorColor = new PdfRGBColor(0, 255, 0);
            annotation2.Border.Width = 2f;
            annotation2.RectangleDifferences = new PdfRectangleDifferences(15, 25, 5, 5);
            PdfAnnotationCollection.Create(page).Add(annotation2);
            annotation2.RefreshAppearances();

            // Save the document
            string output = "CircleAnnotation.pdf";
            doc.SaveToFile(output);
            doc.Close();

            // Launch the Pdf file
            PDFDocumentViewer(output);
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
