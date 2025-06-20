
using Spire.Pdf;
using Spire.Pdf.Interactive.DigitalSignatures;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace AddInvisibleSignature
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Input, output, and certificate file paths.
            string pfxPath = @"..\..\..\..\..\..\Data\gary.pfx";
            string inputPdf = @"..\..\..\..\..\..\Data\AddInvisibleSignature.pdf";
            string outputPdf = "AddInvisibleSignature_result.pdf";

            // Create a new PDF document.
            PdfDocument pdf = new PdfDocument();

            // Load the input PDF file from the disk.
            pdf.LoadFromFile(inputPdf);

            // Create an X509Certificate2 object by loading the certificate file with the specified password.
            X509Certificate2 x509 = new X509Certificate2(pfxPath, "e-iceblue");

            // Create an instance of PdfOrdinarySignatureMaker using the loaded document and certificate.
            PdfOrdinarySignatureMaker signatureMaker = new PdfOrdinarySignatureMaker(pdf, x509);

            // Create an invisible signature with the specified name.
            signatureMaker.MakeSignature("signName");

            // Save the modified PDF document to the specified output file.
            pdf.SaveToFile(outputPdf, FileFormat.PDF);

            //Open the pdf file
            FileViewer(outputPdf);
        }
        private void FileViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }
    }
}
