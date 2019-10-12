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
            string inputFile = @"..\..\..\..\..\..\Data\DigitalSignature.pdf";

            //load a PDF document
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(inputFile);

            //Load a certificate .pfx file
            String pfxPath = @"..\..\..\..\..\..\Data\gary.pfx";
            PdfCertificate cert = new PdfCertificate(pfxPath, "e-iceblue", System.Security.Cryptography.X509Certificates.X509KeyStorageFlags.Exportable);

            //Add a signature to the specified position
            PdfSignature signature = new PdfSignature(doc, doc.Pages[0], cert, "signature");
            signature.Bounds = new RectangleF(new PointF(90, 550), new SizeF(180, 90));

            //Set the signature content
            signature.NameLabel = "Digitally signed by:Gary";
            signature.LocationInfoLabel = "Location:";
            signature.LocationInfo = "CN";
            signature.ReasonLabel = "Reason: ";
            signature.Reason = "Ensure authenticity";
            signature.ContactInfoLabel = "Contact Number: ";
            signature.ContactInfo = "028-81705109";
            signature.DocumentPermissions = PdfCertificationFlags.AllowFormFill | PdfCertificationFlags.ForbidChanges;
            signature.GraphicsMode = GraphicMode.SignImageAndSignDetail;
            signature.SignImageSource = PdfImage.FromFile(@"..\..\..\..\..\..\Data\logo.png");

            //Configure a timestamp server
            string url = "https://freetsa.org/tsr";
            signature.ConfigureTimestamp(url);

            //Save to file
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
