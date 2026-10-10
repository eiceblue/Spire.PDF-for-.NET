using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Interactive.Annotations;

namespace UnknownAnnotation
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

            // Define a rectangle for the text annotation
            RectangleF rect = new RectangleF(100, 100, 200, 100);

            // Create a text annotation
            PdfTextAnnotation annotation = new PdfTextAnnotation(page, rect);
            annotation.Contents = "Contents";
            annotation.Name = "Name";
            annotation.Color = Color.Red;
            annotation.Border.Width = 1f;
            annotation.Flags = PdfAnnotationFlags.Print;

            // Add the annotation to the page
            PdfAnnotationCollection.Create(page).Add(annotation);

            // Read the annotations back from the page. Annotation types that
            // are not recognized by Spire.Pdf are exposed as unknown annotations.
            PdfAnnotation retrieved = PdfAnnotationCollection.Create(page)[0] as PdfAnnotation;

            // Save the document
            string output = "UnknownAnnotation.pdf";
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
