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
            // Specify the input and output file paths
            string input = @"..\..\..\..\..\..\Data\DigitalSignature.pdf";
            string output = "externalServicesDesign.pdf";

            // Load a PDF document from the input file
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(input);

            // Load a certificate for digital signature
            X509Certificate2 cert = new X509Certificate2(@"..\..\..\..\..\..\Data\gary.pfx", "e-iceblue");

            // Create a custom PKCS7 signature formatter using the certificate
            CustomPKCS7SignatureFormatter customPKCS7SignatureFormatter = new CustomPKCS7SignatureFormatter(cert);

            // Create a PdfSignature object with the document, the first page of the document, the custom signature formatter, and an identifier
            PdfSignature signature = new PdfSignature(doc, doc.Pages[0], customPKCS7SignatureFormatter, "signature0");
            signature.Bounds = new RectangleF(new PointF(90, 550), new SizeF(270, 90));
            signature.GraphicsMode = GraphicMode.SignDetail;
            signature.NameLabel = "Signer:";
            signature.Name = "Test";
            signature.Reason = "The certificate of this document";
            signature.DistinguishedNameLabel = "DN: ";
            signature.DocumentPermissions = PdfCertificationFlags.AllowFormFill | PdfCertificationFlags.ForbidChanges;

            // Set the font for sign details and sign name
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 15f));
            signature.SignDetailsFont = font;
            signature.SignNameFont = font;
            signature.SignImageLayout = SignImageLayout.None;

            // Save the modified PDF document to the output file in PDF format
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
