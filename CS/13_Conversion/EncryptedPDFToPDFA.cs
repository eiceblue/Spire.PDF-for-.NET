using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.ColorSpace;
using Spire.Pdf.Conversion;
using Spire.Pdf.Graphics;


namespace EncryptedPDFToPDFA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new PdfStandardsConverter object with the input file path ("Decryption.pdf") and password ("test")
            PdfStandardsConverter converter = new PdfStandardsConverter(@"..\..\..\..\..\..\Data\Decryption.pdf", "test");

            // Convert the input PDF to PDF/A-2A standard and save it as "EncryptedPDFToPDFA.pdf"
            converter.ToPdfA2A("EncryptedPDFToPDFA.pdf");

            //Launch the result file.
            PDFDocumentViewer("EncryptedPDFToPDFA.pdf");
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
