using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignedByTimestamp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Specify the input file path
            string inputFile = @"..\..\..\..\..\..\Data\DigitalSignature.pdf";

            // Load a PDF document
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(inputFile);

            // Specify the path of the certificate file (.pfx)
            String pfxPath = @"..\..\..\..\..\..\Data\gary.pfx";
            // Create a PdfCertificate object by loading the certificate from the .pfx file and providing the password
            PdfCertificate cert = new PdfCertificate(pfxPath, "e-iceblue", System.Security.Cryptography.X509Certificates.X509KeyStorageFlags.Exportable);

            // Add a signature to the specified position on the first page of the document
            PdfSignature signature = new PdfSignature(doc, doc.Pages[0], cert, "signature");
            // Set the position and size of the signature bounds
            signature.Bounds = new RectangleF(new PointF(90, 550), new SizeF(180, 90));

            // Set the content for the signature
            signature.NameLabel = "Digitally signed by: Gary";
            signature.LocationInfoLabel = "Location:";
            signature.LocationInfo = "CN";
            signature.ReasonLabel = "Reason: ";
            signature.Reason = "Ensure authenticity";
            signature.ContactInfoLabel = "Contact Number: ";
            signature.ContactInfo = "028-81705109";
            signature.DocumentPermissions = PdfCertificationFlags.AllowFormFill | PdfCertificationFlags.ForbidChanges;
            signature.GraphicsMode = GraphicMode.SignImageAndSignDetail;
            // Set the source of the signature image
            signature.SignImageSource = PdfImage.FromFile(@"..\..\..\..\..\..\Data\logo.png");

            // Configure a timestamp server for the signature
            string url = "https://freetsa.org/tsr";
            signature.ConfigureTimestamp(url);

            // Save the modified document to a file
            string output = "result.pdf";
            doc.SaveToFile(output, FileFormat.PDF);

            //Launch the file
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
