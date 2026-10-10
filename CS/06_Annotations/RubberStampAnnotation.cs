using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Interactive.Annotations;

namespace RubberStampAnnotation
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

            // Define a rectangle for the rubber stamp annotation
            RectangleF rect = new RectangleF(100, 100, 120, 30);

            // Create a rubber stamp annotation
            PdfRubberStampAnnotation annotation = new PdfRubberStampAnnotation(page, rect);

            // Set the annotation properties
            annotation.Icon = PdfStampIcon.Confidential;
            annotation.Intent = PdfStampIntent.Stamp;
            annotation.Subject = "Subj";
            annotation.Title = "Title";
            annotation.Contents = "Contents";
            annotation.Name = "Name";
            annotation.Color = new PdfRGBColor(200, 0, 0);
            annotation.Border.Width = 1f;
            annotation.Flags = PdfAnnotationFlags.Print;

            DateTime date = new DateTime(2024, 1, 15, 10, 30, 0);
            annotation.CreationDate = date;
            annotation.ModifiedDate = date;
            annotation.StrokingOpacity = 0.5f;
            annotation.NonstrokingOpacity = 0.8f;

            // Add the annotation to the page and refresh its appearance
            PdfAnnotationCollection.Create(page).Add(annotation);
            annotation.RefreshAppearances();

            // Save the document
            string output = "RubberStampAnnotation.pdf";
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
