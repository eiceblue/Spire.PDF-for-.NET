using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Security;

namespace ExternalServicesDesign
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = @"..\..\..\..\..\..\Data\DigitalSignature.pdf";
            string output = "externalServicesDesign.pdf";

            //Load Pdf document from disk
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(input);

            //Load certificate
            X509Certificate2 cert = new X509Certificate2(@"..\..\..\..\..\..\Data\gary.pfx", "e-iceblue");

            //Create CustomPKCS7SignatureFormatter 
            CustomPKCS7SignatureFormatter customPKCS7SignatureFormatter = new CustomPKCS7SignatureFormatter(cert);
            PdfSignature signature = new PdfSignature(doc, doc.Pages[0], customPKCS7SignatureFormatter, "signature0");
            signature.Bounds = new RectangleF(new PointF(90, 550), new SizeF(270, 90));
            signature.GraphicsMode = GraphicMode.SignDetail;
            signature.NameLabel = "Signer:";
            signature.Name = "Test";
            signature.Reason = "The certificate of this document";
            signature.DistinguishedNameLabel = "DN: ";
            signature.DocumentPermissions = PdfCertificationFlags.AllowFormFill | PdfCertificationFlags.ForbidChanges;
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 15f));
            signature.SignDetailsFont = font;
            signature.SignNameFont = font;
            signature.SignImageLayout = SignImageLayout.None;

            //Save pdf file.
            doc.SaveToFile(output, Spire.Pdf.FileFormat.PDF);

            PDFDocumentViewer(output);
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
