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
            // Specify the input and output file paths
            string input = @"..\..\..\..\..\..\Data\DigitalSignature.pdf";
            string output = "addSelfDefineSignaturePic.pdf";

            // Load the PDF document from the disk
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(input);

            // Get the first page of the document
            PdfPageBase page = doc.Pages[0];

            // Load the certificate for the digital signature
            PdfCertificate cert = new PdfCertificate(@"..\..\..\..\..\..\Data\gary.pfx", "e-iceblue");

            // Create a new PdfSignature object with the document, page, certificate, and identifier
            PdfSignature signature = new PdfSignature(doc, page, cert, "demo");

            // Set the bounds (position and size) of the signature on the page
            signature.Bounds = new RectangleF(50, 600, 200, 200);

            // Configure custom graphics for the signature area using the DrawGraphics method defined below
            signature.ConfigureCustomGraphics(DrawGraphics);

            // Save the modified document to the specified output file path in PDF format
            doc.SaveToFile(output, FileFormat.PDF);

            PDFDocumentViewer(output);
        }
        // Method to draw custom graphics within the signature area
        private void DrawGraphics(PdfCanvas g)
        {
            // Create a PdfTrueTypeFont object with Arial font and size 18
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 18f));
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
             PdfTrueTypeFont font = new PdfTrueTypeFont("Arial", 18f);
            */

            // Specify the text to be drawn
            string text = "Signature information";

            // Measure the height of the font
            float heightY = font.MeasureString(text).Height;

            // Define the starting point for drawing the string
            PointF point1 = new PointF(0, 0);

            // Draw the string using the specified font, brush color, and position
            g.DrawString(text, font, PdfBrushes.Red, point1);

            // Define the starting point for drawing the image
            PointF point2 = new PointF(0, heightY + 10);

            // Draw the image using the specified image file and position
            g.DrawImage(PdfImage.FromFile(@"..\..\..\..\..\..\Data\E-iceblueLogo.png"), point2);
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
