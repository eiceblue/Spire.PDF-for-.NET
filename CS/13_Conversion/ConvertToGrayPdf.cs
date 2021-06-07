
using Spire.Pdf.Conversion;
using System;
using System.Windows.Forms;

namespace ConvertToGrayPdf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Output file path
            string output = "ConvertToGrayPdf-result.pdf";
            //Create a PdfGrayConverter with an pdf file
            PdfGrayConverter converter = new PdfGrayConverter(@"..\..\..\..\..\..\Data\ConvertToGrayPdf.pdf");
            //Convert the file to gray pdf
            converter.ToGrayPdf(output);
            //Launch the Pdf file
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
