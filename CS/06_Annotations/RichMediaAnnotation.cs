using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Interactive.Annotations;
using Spire.Pdf.Multimedia.RichMedia;

namespace RichMediaAnnotation
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

            // Define a rectangle for the rich media annotation
            RectangleF rect = new RectangleF(100, 100, 300, 200);

            // Create a rich media content and a rich media annotation
            PdfRichMediaContent content = new PdfRichMediaContent();
            PdfRichMediaAnnotation annotation = new PdfRichMediaAnnotation(page, rect, content);
            annotation.Content = new PdfRichMediaContent();

            // Set the annotation properties
            annotation.Color = Color.Green;
            annotation.Flags = PdfAnnotationFlags.Print;
            annotation.Border.Width = 2f;
            annotation.Contents = "Contents";
            annotation.Name = "Name";

            // Add the annotation to the page and refresh its appearance
            PdfAnnotationCollection.Create(page).Add(annotation);
            annotation.RefreshAppearances();

            // Save the document
            string output = "RichMediaAnnotation.pdf";
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
