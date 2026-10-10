using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Interactive.Annotations;

namespace CaretAnnotation
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
            page.Canvas.DrawString("Caret", font, brush, 100, 100);

            // Define a rectangle for the caret annotation
            RectangleF rect = new RectangleF(150, 112, 20, 20);

            // Create a caret annotation
            PdfCaretAnnotation annotation = new PdfCaretAnnotation(page, rect);

            // Set the annotation properties
            annotation.Title = "CaretTest";
            annotation.Contents = "A caret annotation with a paragraph symbol.";
            annotation.Name = "CaretName";
            annotation.Subject = "Caret";
            annotation.Color = Color.Red;
            annotation.Border.Width = 2f;
            annotation.Flags = PdfAnnotationFlags.Print;
            annotation.Intent = "ParaCaret";
            annotation.RectangleDifferences = new PdfRectangleDifferences(5, 5, 3, 3);

            // Add the annotation to the page and refresh its appearance
            PdfAnnotationCollection.Create(page).Add(annotation);
            annotation.RefreshAppearances();

            // Save the document
            string output = "CaretAnnotation.pdf";
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
