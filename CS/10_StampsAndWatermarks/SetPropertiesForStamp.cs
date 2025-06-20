using Spire.Pdf;
using Spire.Pdf.Annotations;
using System;
using System.Windows.Forms;

namespace SetPropertiesForStamp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load an existing PDF document from the disk.
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\TextStamp.pdf");

            // Get the first page from the document.
            PdfPageBase page = pdf.Pages[0];

            // Traverse through each annotation widget on the page.
            foreach (PdfAnnotation annotation in page.Annotations.List)
            {
                // Check if the current annotation is a rubber stamp annotation.
                if (annotation is PdfRubberStampAnnotationWidget)
                {
                    // Cast the annotation to a PdfRubberStampAnnotationWidget.
                    PdfRubberStampAnnotationWidget stamp = annotation as PdfRubberStampAnnotationWidget;

                    // Set properties for the rubber stamp annotation.
                    stamp.Author = "TestUser";
                    stamp.Subject = "E-iceblue";
                    stamp.CreationDate = DateTime.Now;
                    stamp.ModifiedDate = DateTime.Now;
                }
            }

            // Save the modified PDF document to a file.
            string result = "SetPropertiesForStamp.pdf";
            pdf.SaveToFile(result, Spire.Pdf.FileFormat.PDF);

            //Launch the file
            DocumentViewer(result);
        }
        private void DocumentViewer(string filename)
        {
            try
            {
                System.Diagnostics.Process.Start(filename);
            }
            catch { }
        }
    }
}
