using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Interactive.DigitalSignatures;

namespace AddMultipleDigitalSignatures
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create PDF document
            PdfDocument document = new PdfDocument();

            //Load the PDF document 
            document.LoadFromFile(@"..\..\..\..\..\..\Data\AddMultipleSignatures.pdf");

            //Create X509Certificate2
            X509Certificate2 x509 = new X509Certificate2(@"..\..\..\..\..\..\Data\gary.pfx", "e-iceblue");


            //Create PdfOrdinarySignatureMaker
            PdfOrdinarySignatureMaker signatureMaker = new PdfOrdinarySignatureMaker(document, x509);

            //Set signature appearance
            PdfSignatureAppearance signatureAppearance = new PdfSignatureAppearance(signatureMaker.Signature);
            signatureAppearance.NameLabel = "Signer:";
            signatureAppearance.ContactInfoLabel = "ContactInfo:";
            signatureAppearance.LocationLabel = "Location:";
            signatureAppearance.ReasonLabel = "Reason:";

            //Set details for the signature1
            PdfSignature signature1 = signatureMaker.Signature;
            signature1.Name = "Tom";
            signature1.ContactInfo = "Tom Tang";
            signature1.Location = "China";
            signature1.Reason = "protect document data";

            //Add the first signature 
            signatureMaker.MakeSignature("Signature1", document.Pages[0], 100, 300, 120, 70, signatureAppearance);


            //Set details for the signature2
            PdfSignature signature2 = signatureMaker.Signature;
            signature2.Name = "Bob";
            signature2.ContactInfo = "Bob Li";
            signature2.Location = "China";
            signature2.Reason = "protect document data";

            //Add the second signature
            signatureMaker.MakeSignature("Signature2", document.Pages[0], 400, 300, 120, 70, signatureAppearance);

            //Save the PDF document
            string outpdf = "AddMultipleSignatures_result.pdf";
            document.SaveToFile(outpdf, FileFormat.PDF);

            PDFDocumentViewer(outpdf);
        }
        private static void PDFDocumentViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }

    }
}
