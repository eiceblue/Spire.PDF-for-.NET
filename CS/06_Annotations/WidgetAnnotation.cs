using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Interactive.Annotations;

namespace WidgetAnnotation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load an existing PDF document that contains a form field
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\AllFields.pdf");

            // Get the first page and its first annotation as a widget annotation
            PdfPageBase page = doc.Pages[0];
            PdfWidgetAnnotation annotation = PdfAnnotationCollection.Create(page)[0] as PdfWidgetAnnotation;

            if (annotation != null)
            {
                // Set the annotation properties
                annotation.Color = Color.Red;
                annotation.Flags = PdfAnnotationFlags.Print;
                annotation.Border.Width = 3f;
                annotation.RefreshAppearances();
            }

            // Save the document
            string output = "WidgetAnnotation.pdf";
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
