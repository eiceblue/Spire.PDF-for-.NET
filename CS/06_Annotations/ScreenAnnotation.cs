using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Interactive.Annotations;

namespace ScreenAnnotation
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

            // Define a rectangle for the screen annotation
            RectangleF rect = new RectangleF(100, 100, 200, 100);

            // Create a screen annotation
            PdfScreenAnnotation annotation = new PdfScreenAnnotation(page, rect);

            // Set the annotation properties
            annotation.Title = "My Screen";
            annotation.Color = Color.Red;
            annotation.Flags = PdfAnnotationFlags.Print;
            annotation.Border.Width = 2f;
            annotation.Border.Style = PdfBorderStyle.Dashed;
            annotation.Contents = "Contents";
            annotation.Name = "Name";

            // Add the annotation to the page and refresh its appearance
            PdfAnnotationCollection.Create(page).Add(annotation);
            annotation.RefreshAppearances();

            // Save the document
            string output = "ScreenAnnotation.pdf";
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
