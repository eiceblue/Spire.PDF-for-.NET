using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Security;
using Spire.Pdf.Fields;
using Spire.Pdf.Widget;

namespace LockDocumentAfterSigning
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

            // Specify the path to the certificate file
            String pfxPath = @"..\..\..\..\..\..\Data\gary.pfx";

            // Create a PdfCertificate object using the certificate file and its password
            PdfCertificate cert = new PdfCertificate(pfxPath, "e-iceblue");

            // Create a PdfSignature object for the first page of the document with the specified certificate and signature name
            PdfSignature signature = new PdfSignature(doc, doc.Pages[0], cert, "signature0");

            // Set the position and size of the signature appearance on the page
            signature.Bounds = new RectangleF(new PointF(90, 550), new SizeF(270, 90));

            // Load an image file as the sign image source
            signature.SignImageSource = PdfImage.FromFile(@"..\..\..\..\..\..\Data\E-iceblueLogo.png");

            // Set the display mode of graphics for the signature appearance
            signature.GraphicsMode = GraphicMode.SignImageAndSignDetail;

            // Set the label and value for the signer's name in the signature details
            signature.NameLabel = "Signer:";
            signature.Name = "Gary";

            // Set the label and value for the contact information in the signature details
            signature.ContactInfoLabel = "ContactInfo:";
            signature.ContactInfo = signature.Certificate.GetNameInfo(System.Security.Cryptography.X509Certificates.X509NameType.SimpleName, true);

            // Set the label and value for the date in the signature details
            signature.DateLabel = "Date:";
            signature.Date = DateTime.Now;

            // Set the label and value for the location information in the signature details
            signature.LocationInfoLabel = "Location:";
            signature.LocationInfo = "Chengdu";

            // Set the label and value for the reason in the signature details
            signature.ReasonLabel = "Reason: ";
            signature.Reason = "The certificate of this document";

            // Set the label and value for the distinguished name in the signature details
            signature.DistinguishedNameLabel = "DN: ";
            signature.DistinguishedName = signature.Certificate.IssuerName.Name;

            // Specify the document permissions for the certified PDF
            signature.DocumentPermissions = PdfCertificationFlags.AllowFormFill | PdfCertificationFlags.ForbidChanges;

            // Set the fonts to be used for the signature details and signer's name
            signature.SignDetailsFont = new PdfFont(PdfFontFamily.TimesRoman, 10f);
            signature.SignNameFont = new PdfFont(PdfFontFamily.Courier, 15);

            // Set the layout mode for the sign image
            signature.SignImageLayout = SignImageLayout.None;

            // Lock the document after applying the signature
            signature.Lock = true;

            // Save the modified PDF document with the applied digital signature
            doc.SaveToFile("DigitalSignature.pdf");
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
