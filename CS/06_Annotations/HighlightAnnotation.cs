using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Interactive.Annotations;

namespace HighlightAnnotation
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

            // Draw some text on the page
            PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 20f);
            PdfSolidBrush brush = new PdfSolidBrush(Color.Blue);
            page.Canvas.DrawString("Highlight", font, brush, 100, 100);

            // Define a rectangle that covers the text
            RectangleF rect = new RectangleF(135, 140, 90, 25);

            // Create a highlight annotation
            PdfHighlightAnnotation annotation = new PdfHighlightAnnotation(page, rect);

            // Set the annotation properties
            annotation.Title = "HighlightTitle";
            annotation.Contents = "A highlight markup annotation.";
            annotation.Name = "HighlightName";
            annotation.Subject = "Highlight";
            annotation.Color = new PdfRGBColor(Color.Yellow);
            annotation.StrokingOpacity = 0.8f;
            annotation.NonstrokingOpacity = 0.8f;
            annotation.Intent = "Highlight";
            annotation.Border.Width = 2f;
            annotation.Flags = PdfAnnotationFlags.Print;

            // Add the annotation to the page and refresh its appearance
            PdfAnnotationCollection.Create(page).Add(annotation);
            annotation.RefreshAppearances();

            // Save the document
            string output = "HighlightAnnotation.pdf";
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
