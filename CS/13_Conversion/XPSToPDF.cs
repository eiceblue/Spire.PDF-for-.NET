using System;
using System.Windows.Forms;
using Spire.Pdf;

namespace XPSToPDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Specify the file path of the XPS document.
            String file = @"..\..\..\..\..\..\Data\XPStoPDF.xps";

            // Create a new PdfDocument object.
            PdfDocument doc = new PdfDocument();

            // Load the XPS document into the PdfDocument object from the specified file path.
            doc.LoadFromXPS(file);

            // Convert the XPS document to a PDF file and save it with the output file name "XPStoPDF-result.pdf".
            doc.SaveToFile("XPStoPDF-result.pdf");

            // Close the PdfDocument object.
            doc.Close();

            //Launch the Pdf file
            PDFDocumentViewer("XPStoPDF-result.pdf");
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
