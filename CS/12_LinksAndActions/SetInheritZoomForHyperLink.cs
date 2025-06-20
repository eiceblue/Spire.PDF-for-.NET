using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Annotations;
using Spire.Pdf.General;
using Spire.Pdf.Graphics;


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
            PdfAnnotationCollection annotations = pdf.Pages[0].Annotations;

            // Iterate through each annotation in the collection
            for (int i = 0; i < annotations.Count; i++)
            {
                // Cast the current annotation to a PdfDocumentLinkAnnotationWidget
                PdfDocumentLinkAnnotationWidget anno = annotations[i] as PdfDocumentLinkAnnotationWidget;

                // Get the destination of the annotation
                PdfDestination dest = anno.Destination;

                // Set the mode of the destination to Location
                dest.Mode = PdfDestinationMode.Location;

                // Set the zoom level of the destination to 0
                dest.Zoom = 0;

                // Set the new destination for the annotation
                anno.Destination = dest;
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
