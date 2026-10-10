using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Interactive.Annotations;

namespace MovieAnnotation
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

            // Define a rectangle for the movie annotation
            RectangleF rect = new RectangleF(100, 100, 300, 200);

            // Create a file specification that references the movie file
            PdfFileSpecification fileSpec = new PdfFileSpecification(@"..\..\..\..\..\..\Data\Video.mp4");

            // Create a movie annotation with the file specification
            PdfMovieAnnotation annotation = new PdfMovieAnnotation(page, rect, fileSpec);

            // Set the annotation properties
            annotation.Title = "Movie";
            annotation.Contents = "Movie annotation";
            annotation.Name = "MovieName";
            annotation.Color = Color.Red;
            annotation.Border.Width = 2f;
            annotation.Flags = PdfAnnotationFlags.Print;

            // Add the annotation to the page and refresh its appearance
            PdfAnnotationCollection.Create(page).Add(annotation);
            annotation.RefreshAppearances();

            // Save the document
            string output = "MovieAnnotation.pdf";
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
