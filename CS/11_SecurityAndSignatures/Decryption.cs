using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Security;


namespace Decryption
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Load a pdf document
            String encryptedPdf = @"..\..\..\..\..\..\Data\Decryption.pdf";
            PdfDocument doc = new PdfDocument();

            //Open the document
            doc.LoadFromFile(encryptedPdf, "test");

            //Decrypt the document
            doc.Decrypt();

            //Save Pdf file
            doc.SaveToFile("Decryption.pdf", FileFormat.PDF);

            DocumentViewer("Decryption.pdf");
        }

        private void DocumentViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }
    }
}
