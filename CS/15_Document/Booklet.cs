using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;


namespace Booklet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new instance of the PdfDocument class
            PdfDocument doc = new PdfDocument();

            // Specify the path of the source PDF file
            String srcPdf = @"..\..\..\..\..\..\Data\Booklet.pdf";

            // Set the width and height for the booklet, which is double the width of A4 size and the same height as A4
            float width = PdfPageSize.A4.Width * 2;
            float height = PdfPageSize.A4.Height;

            // Create a booklet by using the CreateBooklet method with the specified source PDF, width, height, and duplex printing mode (true)
            doc.CreateBooklet(srcPdf, width, height, true);

            // Save the modified PDF document to a new file named "Booklet-result.pdf"
            doc.SaveToFile("Booklet-result.pdf");

            // Close the PdfDocument object
            doc.Close();

            //Launch the Pdf file
            PDFDocumentViewer("Booklet-result.pdf");
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
