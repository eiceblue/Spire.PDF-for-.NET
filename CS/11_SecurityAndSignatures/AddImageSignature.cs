using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Interactive.DigitalSignatures;

namespace AddImageSignature
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load a PDF document.
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\AddImageSignature.pdf");

            // Load the X509 certificate for signature.
            X509Certificate2 x509 = new X509Certificate2(@"..\..\..\..\..\..\Data\gary.pfx", "e-iceblue");

            // Create an instance of PdfOrdinarySignatureMaker using the loaded document and certificate.
            PdfOrdinarySignatureMaker signatureMaker = new PdfOrdinarySignatureMaker(doc, x509);

            // Create an instance of PdfCustomSignatureAppearance as the appearance for the signature.
            IPdfSignatureAppearance signatureAppearance = new PdfCustomSignatureAppearance();

            // Make the signature with a specified name and the custom appearance.
            signatureMaker.MakeSignature("Signature", signatureAppearance);

            string output = "output.pdf";
            // Save the resulting document.
            doc.SaveToFile(output, Spire.Pdf.FileFormat.PDF);
            doc.Close();

            //Launch the result Pdf file
            PDFDocumentViewer(output);
        }

        public class PdfCustomSignatureAppearance : IPdfSignatureAppearance
        {
            public void Generate(PdfCanvas g)
            {
                // Load an image for the signature appearance.
                Image image = Image.FromFile(@"..\..\..\..\..\..\Data\AddImageSignature.png");

                // Draw the image on the canvas at the specified position.
                g.DrawImage(PdfImage.FromImage(image), new PointF(0, 0));
            }
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
