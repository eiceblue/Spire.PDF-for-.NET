using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Security;

namespace CustomSignature
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
            string output = "addSelfDefineSignaturePic.pdf";

            //Load document from disk
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(input);

            //Create the first page
            PdfPageBase page = doc.Pages[0];

            //Load the certificate
            PdfCertificate cert = new PdfCertificate(@"..\..\..\..\..\..\Data\gary.pfx", "e-iceblue");

            //Define signatrure
            PdfSignature signature = new PdfSignature(doc, page, cert, "demo");
            signature.Bounds = new RectangleF(50, 600, 200, 200);

            //Custom signature area
            signature.ConfigureCustomGraphics(DrawGraphics);

            //Save the document
            doc.SaveToFile(output, FileFormat.PDF);
            PDFDocumentViewer(output);
        }
        private void DrawGraphics(PdfCanvas g)
        {
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 18f));
            string text = "Signature information";
            float heightY = font.MeasureString(text).Height;
            PointF point1 = new PointF(0, 0);
            //Draw string
            g.DrawString(text, font, PdfBrushes.Red, point1);
            PointF point2 = new PointF(0, heightY+10);
            //Draw image
            g.DrawImage(PdfImage.FromFile(@"..\..\..\..\..\..\Data\E-iceblueLogo.png"),point2);
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
