using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Security;
using System.Security.Cryptography.X509Certificates;
using Spire.Pdf.Graphics;

namespace SignedByLTV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputFile = @"..\..\..\..\..\..\Data\DigitalSignature.pdf";

            // Load a PDF document
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(inputFile);

            // Get the first page
            PdfPageBase page = doc.Pages[0];

            // Load a certificate .pfx file
            String pfxPath = @"..\..\..\..\..\..\Data\gary.pfx";
            PdfCertificate cer = new PdfCertificate(pfxPath, "e-iceblue", X509KeyStorageFlags.Exportable);

            // Add a signature to the specified position
            PdfSignature signature = new PdfSignature(doc, page, cer, "signature");
            signature.Bounds = new RectangleF(new PointF(90, 550), new SizeF(180, 90));

            // Set the signature content
            signature.NameLabel = "Digitally signed by: Gary";
            signature.LocationInfoLabel = "Location:";
            signature.LocationInfo = "CN";
            signature.ReasonLabel = "Reason: ";
            signature.Reason = "Ensure authenticity";
            signature.ContactInfoLabel = "Contact Number: ";
            signature.ContactInfo = "028-81705109";
            signature.DocumentPermissions = PdfCertificationFlags.AllowFormFill | PdfCertificationFlags.ForbidChanges;
            signature.GraphicsMode = GraphicMode.SignImageAndSignDetail;
            signature.SignImageSource = PdfImage.FromFile(@"..\..\..\..\..\..\Data\logo.png");

            // Configure OCSP (Online Certificate Status Protocol)
            signature.ConfigureHttpOCSP(null, null);

            // Save the PDF file
            string outputFile = "result.pdf";
            doc.SaveToFile(outputFile, FileFormat.PDF);

            //Launch the file
            PDFDocumentViewer(outputFile); 
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
