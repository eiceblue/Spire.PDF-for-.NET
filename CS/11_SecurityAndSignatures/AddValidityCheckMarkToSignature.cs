
using Spire.Pdf;
using Spire.Pdf.Interactive.DigitalSignatures;
using Spire.Pdf.Security;
using System;
using System.Windows.Forms;

namespace AddValidityCheckMarkToSignature
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Input, output, and certificate files path
            string pfxPath = @"..\..\..\..\..\..\Data\gary.pfx";
            string inputPdf = @"..\..\..\..\..\..\Data\AddValidityCheckMarkToSignature.pdf";
            string outputPdf = "AddValidityCheckMarkToSignature_result.pdf";

            // Create a new PDF document
            PdfDocument pdf = new PdfDocument();

            // Load the PDF file from the specified path
            pdf.LoadFromFile(inputPdf);

            // Create a PdfCertificate object using the PFX file and its password
            PdfCertificate cert = new PdfCertificate(pfxPath, "e-iceblue");

            // Create a PdfOrdinarySignatureMaker object with the loaded PDF document and the certificate
            PdfOrdinarySignatureMaker signatureMaker = new PdfOrdinarySignatureMaker(pdf, cert);

            // Set Acro6 layers to false
            signatureMaker.SetAcro6Layers(false);

            // Create a signature with the specified signer name on the first page of the PDF document,
            // positioned at coordinates (100, 100) with a width of 120 and height of 160
            signatureMaker.MakeSignature("signName", pdf.Pages[0], 100, 100, 120, 160);

            // Save the modified PDF document to the specified output file path in PDF format
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
