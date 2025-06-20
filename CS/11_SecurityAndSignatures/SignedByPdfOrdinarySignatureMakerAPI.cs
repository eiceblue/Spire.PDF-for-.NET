using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Interactive.DigitalSignatures;
using Spire.Pdf.Security;

namespace SignedByPdfOrdinarySignatureMakerAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new PDF document
            PdfDocument pdf = new PdfDocument();

            // Add a page to the document
            PdfPageBase pdfPage = pdf.Pages.Add();

            // Load the certificate from the specified PFX file and password
            PdfCertificate cert = new PdfCertificate(@"..\..\..\..\..\..\Data\gary.pfx", "e-iceblue");

            // Create a new instance of PdfOrdinarySignatureMaker using the PDF document and certificate
            PdfOrdinarySignatureMaker signatureMaker = new PdfOrdinarySignatureMaker(pdf, cert);

            // Set details for the signature
            Spire.Pdf.Interactive.DigitalSignatures.PdfSignature signature = signatureMaker.Signature;
            signature.Name = "E-iceblue";
            signature.ContactInfo = "028-81705109";
            signature.Location = "Chengdu";
            signature.Reason = "The certificate of this document";

            // Create a new PdfSignatureAppearance object for the signature appearance
            PdfSignatureAppearance appearance = new PdfSignatureAppearance(signature);
            appearance.NameLabel = "Signer: ";
            appearance.ContactInfoLabel = "ContactInfo: ";
            appearance.LocationLabel = "Location: ";
            appearance.ReasonLabel = "Reason: ";
            appearance.SignatureImage = PdfImage.FromFile(@"..\..\..\..\..\..\Data\E-iceblueLogo.png");
            appearance.GraphicMode = Spire.Pdf.Interactive.DigitalSignatures.GraphicMode.SignImageAndSignDetail;

            // Make the signature with the specified name, on the specified page at position (100, 600) with a size of 200x100
            signatureMaker.MakeSignature("signName", pdfPage, 100, 600, 200, 100, appearance);

            // Save the document to PDF format
            String result = "SignedByPdfOrdinarySignatureMakerAPI_result.pdf";
            pdf.SaveToFile(result);

            // Close the PDF document
            pdf.Close();


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
