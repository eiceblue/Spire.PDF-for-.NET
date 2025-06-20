using Spire.Pdf;
using Spire.Pdf.Attachments;
using Spire.Pdf.Graphics;
using Spire.Pdf.Interactive.DigitalSignatures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace SignatureMakerWithTimestamp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string inputFile_pfx = @"..\..\..\..\..\..\Data\gary.pfx";
            string output = "SignatureMakerWithTimestamp_output.pdf";

            // Load pdf document
            PdfDocument doc = new PdfDocument();
            doc.AppendPage();

            X509Certificate2 x509 = new X509Certificate2(inputFile_pfx, "e-iceblue");
            PdfPKCS7Formatter formatter = new PdfPKCS7Formatter(x509, false);
            formatter.TimestampService = new TSAHttpService("http://time.certum.pl");

            // Create a signature maker using the loaded document and formatter
            PdfOrdinarySignatureMaker signatureMaker = new PdfOrdinarySignatureMaker(doc, formatter);

            // Create a custom signature appearance for the signature
            IPdfSignatureAppearance signatureAppearance = new PdfCustomSignatureAppearance();

            // Make the signature on the first page of the document at position (100, 100) with a size of 100x100
            signatureMaker.MakeSignature("sign", doc.Pages[0], 100, 100, 100, 100, signatureAppearance);

            // Save the result pdf file
            doc.SaveToFile(output, FileFormat.PDF);
            doc.Close();

            PDFDocumentViewer(output);
        }
        public class PdfCustomSignatureAppearance : IPdfSignatureAppearance
        {
            // This method is used to generate a custom signature appearance on a PdfCanvas object.
            public void Generate(PdfCanvas g)
            {
                // Set the font size for the signature appearance to 10.
                float fontSize = 10;

                // Create a TrueType font object using the Arial font with the specified font size.
                PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", fontSize), true);

                // Draw the string "E-iceblue" on the PdfCanvas object 'g' using the specified font and color (red) at coordinates (0, 0).
                g.DrawString("E-iceblue", font, PdfBrushes.Red, new PointF(0, 0));
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
