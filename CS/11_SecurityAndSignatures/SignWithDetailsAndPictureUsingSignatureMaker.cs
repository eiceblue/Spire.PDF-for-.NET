using System;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Security;
using Spire.Pdf.Interactive.DigitalSignatures;

namespace SignWithDetailsAndPictureUsingSignatureMaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Specify the input and output file paths
            string input = @"..\..\..\..\..\..\Data\SignWithDetailsAndPictureUsingSignatureMaker.pdf";
            string imagePath = @"..\..\..\..\..\..\Data\logo.png";
            string result = "SignWithDetailsAndPictureUsingSignatureMaker_result.pdf";
            string pfxPath = @"..\..\..\..\..\..\Data\gary.pfx";

            // Load the PDF document
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(input);

            // Create a PdfCertificate object using the certificate file (.pfx) and password
            PdfCertificate cert = new PdfCertificate(pfxPath, "e-iceblue");

            // Create a PdfOrdinarySignatureMaker object using the document and certificate
            PdfOrdinarySignatureMaker signatureMaker = new PdfOrdinarySignatureMaker(doc, cert);

            // Get the PdfSignature object for signing
            Spire.Pdf.Interactive.DigitalSignatures.PdfSignature signature = signatureMaker.Signature;

            // Set the details for the signature
            signature.Name = "E-iceblue";
            signature.ContactInfo = "028-81705109";
            signature.Location = "Chengdu";
            signature.Reason = "The certificate of this document";

            // Create a PdfSignatureAppearance object for customizing the appearance of the signature
            PdfSignatureAppearance appearance = new PdfSignatureAppearance(signature);
            appearance.NameLabel = "Signer: ";
            appearance.ContactInfoLabel = "ContactInfo: ";
            appearance.LocationLabel = "Location: ";
            appearance.ReasonLabel = "Reason: ";

            // Set the picture for the signature
            appearance.SignatureImage = PdfImage.FromFile(imagePath);
            appearance.GraphicMode = Spire.Pdf.Interactive.DigitalSignatures.GraphicMode.SignImageAndSignDetail;

            // Use the signature maker to make the signature at the specified position on the first page of the document
            signatureMaker.MakeSignature("signName", doc.Pages[0], 100, 600, 200, 100, appearance);

            // Save the modified document to a file
            doc.SaveToFile(result, FileFormat.PDF);

            //Show the result file
            FileViewer(result);
        }
        private void FileViewer(string filename)
        {
            try
            {
                System.Diagnostics.Process.Start(filename);
            }
            catch { }
        }
    }
}
