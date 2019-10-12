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
 		    //Load a pdf document
            String input = @"..\..\..\..\..\..\Data\DigitalSignature.pdf";
            PdfDocument doc = new PdfDocument();
	    doc.LoadFromFile(input);
            //Load the certificate
            String pfxPath = @"..\..\..\..\..\..\Data\gary.pfx";
            PdfCertificate cert = new PdfCertificate(pfxPath, "e-iceblue");

            PdfSignature signature = new PdfSignature(doc, doc.Pages[0], cert, "signature0");
            signature.Bounds = new RectangleF(new PointF(90,550), new SizeF(270, 90));

            //Load sign image source.
            signature.SignImageSource = PdfImage.FromFile(@"..\..\..\..\..\..\Data\E-iceblueLogo.png");

            //Set the dispay mode of graphics, if not set any, the default one will be applied
            signature.GraphicsMode = GraphicMode.SignImageAndSignDetail;
            signature.NameLabel = "Signer:";

            signature.Name = "Gary";

            signature.ContactInfoLabel = "ContactInfo:";
            signature.ContactInfo = signature.Certificate.GetNameInfo(System.Security.Cryptography.X509Certificates.X509NameType.SimpleName, true);

            signature.DateLabel = "Date:";
            signature.Date = DateTime.Now;

            signature.LocationInfoLabel = "Location:";
            signature.LocationInfo = "Chengdu";

            signature.ReasonLabel = "Reason: ";
            signature.Reason = "The certificate of this document";

            signature.DistinguishedNameLabel = "DN: ";
            signature.DistinguishedName = signature.Certificate.IssuerName.Name;

            signature.DocumentPermissions = PdfCertificationFlags.AllowFormFill | PdfCertificationFlags.ForbidChanges;
            signature.Certificated = true;

            //Set fonts. if not set, default ones will be applied. 
            signature.SignDetailsFont = new PdfFont(PdfFontFamily.TimesRoman, 10f);
            signature.SignNameFont = new PdfFont(PdfFontFamily.Courier, 15);
          
            //Set the sign image layout mode
            signature.SignImageLayout = SignImageLayout.None;

            //Save pdf file.
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
