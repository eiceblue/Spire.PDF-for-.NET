using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Utilities;

namespace DeleteImageFirstApproach
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // File path of the PDF to be processed
            String file = @"..\..\..\..\..\..\Data\DeleteImage.pdf";

            // Create a new PdfDocument instance
            PdfDocument pdf = new PdfDocument();

            // Load the PDF document from the specified file
            pdf.LoadFromFile(file);

            // Get the first page of the PDF document
            PdfPageBase page = pdf.Pages[0];

            // Create a PdfImageHelper instance for working with images in the PDF
            PdfImageHelper helper = new PdfImageHelper();

            // Get information about the images on the page
            Spire.Pdf.Utilities.PdfImageInfo[] images = helper.GetImagesInfo(page);

            // Delete the first image on the page
            helper.DeleteImage(images[0]);

            // Specify the output file name for the modified PDF
            String result = "DeleteImage_out.pdf";

            // Save the modified PDF document to a file
            pdf.SaveToFile(result);

            //Launch the Pdf file
            PDFDocumentViewer(result);
        }
        private void PDFDocumentViewer(string filename)
        {
            try
            {
                System.Diagnostics.Process.Start(filename);
            }
            catch { }
        }

    }
}
