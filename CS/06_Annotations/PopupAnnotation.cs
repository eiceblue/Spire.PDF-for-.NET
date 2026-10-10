using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Interactive.Annotations;

namespace PopupAnnotation
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

            // Create a parent text annotation
            RectangleF textRect = new RectangleF(100, 100, 200, 100);
            PdfTextAnnotation parent = new PdfTextAnnotation(page, textRect);
            parent.Icon = PdfTextIcon.Note;
            parent.Title = "ParentNote";
            parent.Contents = "This is the parent text annotation.";
            parent.Color = new PdfRGBColor(255, 255, 0);

            // Define a rectangle for the popup annotation
            RectangleF popupRect = new RectangleF(330, 80, 200, 120);

            // Create a popup annotation and link it to the parent
            PdfPopupAnnotation annotation = new PdfPopupAnnotation(page, popupRect);
            annotation.Parent = parent;
            annotation.Open = true;
            annotation.Contents = "Contents";
            annotation.Name = "Name";
            annotation.Color = Color.Red;
            annotation.Border.Width = 2f;
            annotation.Flags = PdfAnnotationFlags.Print;

            // Add the parent and the popup annotation to the page
            PdfAnnotationCollection.Create(page).Add(parent);
            PdfAnnotationCollection.Create(page).Add(annotation);

            // Save the document
            string output = "PopupAnnotation.pdf";
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
