using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Interactive.Annotations;

namespace TextAnnotation
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
            RectangleF rect = new RectangleF(100, 100, 20, 20);

            // Create a text annotation
            PdfTextAnnotation annotation = new PdfTextAnnotation(page, rect);

            // Set the annotation properties
            annotation.Icon = PdfTextIcon.Note;
            annotation.Title = "TextAnnotation";
            annotation.Contents = "A text annotation with a note icon.";
            annotation.Name = "TextName";
            annotation.Subject = "Text";
            annotation.Open = true;
            annotation.Color = Color.Yellow;
            annotation.Border.Width = 2f;
            annotation.Flags = PdfAnnotationFlags.Print;

            // Add the annotation to the page and refresh its appearance
            PdfAnnotationCollection.Create(page).Add(annotation);
            annotation.RefreshAppearances();

            // Add several text annotations with different icons
            PdfTextIcon[] icons = new PdfTextIcon[]
            {
                PdfTextIcon.Comment, PdfTextIcon.Key, PdfTextIcon.Help,
                PdfTextIcon.NewParagraph, PdfTextIcon.Paragraph, PdfTextIcon.Insert
            };
            for (int i = 0; i < icons.Length; i++)
            {
                RectangleF iconRect = new RectangleF(100 + (i % 3) * 200, 200 + (i / 3) * 100, 20, 20);
                PdfTextAnnotation iconAnnotation = new PdfTextAnnotation(page, iconRect);
                iconAnnotation.Icon = icons[i];
                iconAnnotation.Title = "Icon_" + icons[i];
                iconAnnotation.Contents = "Text annotation with the " + icons[i] + " icon.";
                PdfAnnotationCollection.Create(page).Add(iconAnnotation);
                iconAnnotation.RefreshAppearances();
            }

            // Save the document
            string output = "TextAnnotation.pdf";
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
