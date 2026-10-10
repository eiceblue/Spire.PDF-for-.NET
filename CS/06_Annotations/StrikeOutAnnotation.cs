using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Interactive.Annotations;

namespace StrikeOutAnnotation
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

            // Draw a sample text that will be marked by the annotation
            PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 20f);
            PdfSolidBrush brush = new PdfSolidBrush(Color.Blue);
            page.Canvas.DrawString("Highlight", font, brush, 100, 100);

            // Define a rectangle for the strikeout annotation
            RectangleF rect = new RectangleF(130, 135, 100, 25);

            // Create a strikeout annotation
            PdfStrikeOutAnnotation annotation = new PdfStrikeOutAnnotation(page, rect);

            // Set the annotation properties
            annotation.Color = Color.Red;
            annotation.StrokingOpacity = 1f;
            annotation.NonstrokingOpacity = 0.8f;
            annotation.Flags = PdfAnnotationFlags.Print;
            annotation.Border.Width = 2f;
            annotation.Subject = "Subj";
            annotation.Title = "Title";
            annotation.Contents = "Contents";
            annotation.Name = "Name";
            annotation.ModifiedDate = new DateTime(2024, 1, 15, 10, 30, 0);
            annotation.CreationDate = annotation.ModifiedDate;

            // Add the annotation to the page and refresh its appearance
            PdfAnnotationCollection.Create(page).Add(annotation);
            annotation.RefreshAppearances();

            // Save the document
            string output = "StrikeOutAnnotation.pdf";
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
