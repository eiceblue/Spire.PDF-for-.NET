using System;
using System.Windows.Forms;
using Spire.Pdf.Conversion;


namespace ToLinearizedPdf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Specify the path of the input PDF file.
            string input = "../../../../../../Data/PDFTemplate_N.pdf";

            // Specify the desired file name for the resulting linearized PDF.
            string result = "toLinearizedPdf.pdf";

            // Create an instance of the PdfToLinearizedPdfConverter class with the input PDF file path.
            PdfToLinearizedPdfConverter converter = new PdfToLinearizedPdfConverter(input);

            // Convert the input PDF file to a linearized PDF and save it using the specified result file name.
            converter.ToLinearizedPdf(result);

            //Launch the Pdf file
            PDFDocumentViewer(result);
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
