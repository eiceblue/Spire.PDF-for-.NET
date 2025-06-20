using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Security;
using Spire.Pdf.Fields;
using Spire.Pdf.Widget;

namespace DigitalSignature
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load a PDF document from the specified file path
            String input = @"..\..\..\..\..\..\Data\DigitalSignature.pdf";
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(input);

            // Load the certificate for digital signature
            String pfxPath = @"..\..\..\..\..\..\Data\gary.pfx";
            PdfCertificate cert = new PdfCertificate(pfxPath, "e-iceblue");

            // Create a PdfSignature object with the document, the first page of the document, the certificate, and an identifier
            PdfSignature signature = new PdfSignature(doc, doc.Pages[0], cert, "signature0");
            signature.Bounds = new RectangleF(new PointF(90, 550), new SizeF(270, 90));

            // Load the sign image source
            signature.SignImageSource = PdfImage.FromFile(@"..\..\..\..\..\..\Data\E-iceblueLogo.png");

            // Set the display mode of graphics for the signature
            signature.GraphicsMode = GraphicMode.SignImageAndSignDetail;

            // Set the label and value for signer's name
            signature.NameLabel = "Signer:";
            signature.Name = "Gary";

            // Set the label and value for contact information
            signature.ContactInfoLabel = "ContactInfo:";
            signature.ContactInfo = signature.Certificate.GetNameInfo(System.Security.Cryptography.X509Certificates.X509NameType.SimpleName, true);

            // Set the label and value for the signing date
            signature.DateLabel = "Date:";
            signature.Date = DateTime.Now;

            // Set the label and value for the location information
            signature.LocationInfoLabel = "Location:";
            signature.LocationInfo = "Chengdu";

            // Set the label and value for the reason of signing
            signature.ReasonLabel = "Reason: ";
            signature.Reason = "The certificate of this document";

            // Set the label and value for the distinguished name (DN)
            signature.DistinguishedNameLabel = "DN: ";
            signature.DistinguishedName = signature.Certificate.IssuerName.Name;

            // Set the document permissions and certification status
            signature.DocumentPermissions = PdfCertificationFlags.AllowFormFill | PdfCertificationFlags.ForbidChanges;
            signature.Certificated = true;

            // Set the fonts for sign details and sign name
            signature.SignDetailsFont = new PdfFont(PdfFontFamily.TimesRoman, 10f);
            signature.SignNameFont = new PdfFont(PdfFontFamily.Courier, 15);

            // Set the sign image layout mode
            signature.SignImageLayout = SignImageLayout.None;

            // Save the PDF file with the digital signature
            doc.SaveToFile("DigitalSignature.pdf");

            // Close the PDF document
            doc.Close();

            //Launch the file.
            PDFDocumentViewer("DigitalSignature.pdf");
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
