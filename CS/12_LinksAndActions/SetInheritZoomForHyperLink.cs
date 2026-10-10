using Spire.Pdf;
using Spire.Pdf.Actions;
using Spire.Pdf.Destinations;
using Spire.Pdf.General;
using Spire.Pdf.Interactive.Annotations;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace SetInheritZoomForHyperLink
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputFile = @"..\..\..\..\..\..\Data\SetInheritZoomForHyperLink.pdf";
            string outputFile = @"output.pdf";

            // Load the PDF file
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(inputFile);

            // Get the PdfAnnotationCollection of the first page
            PdfAnnotationCollection annotations = PdfAnnotationCollection.Create(pdf.Pages[0]);

            // Iterate through each annotation in the collection
            for (int i = 0; i < annotations.Count; i++)
            {
                // Cast the current annotation to a PdfDocumentLinkAnnotationWidget
                PdfLinkAnnotation anno = annotations[i] as PdfLinkAnnotation;

                // Get the destination of the annotation
                PdfXYZExplicitDestination dest = anno.Destination as PdfXYZExplicitDestination;
                if (dest != null)
                {
                    dest.Zoom = 0;
                }
                else
                {
                    anno.Destination = new PdfXYZExplicitDestination(((anno.Action as PdfGoToAction).Destination as PdfExplicitDestination).Page, 0, 0, 0);
                }
            }

            // Save the modified PDF file to the specified output file
            pdf.SaveToFile(outputFile, FileFormat.PDF);

            // Close the PDF document
            pdf.Close();


            //Launch the Pdf file
            PDFDocumentViewer(outputFile);
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
