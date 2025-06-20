using Spire.Pdf;
using Spire.Pdf.Conversion.Compression;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompressDocumentSecondApproach
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Create a new instance of PdfCompressor with the specified input PDF file path
            PdfCompressor compressor = new PdfCompressor(@"..\..\..\..\..\..\Data\CompressDocument.pdf");

            // Alternatively, if the input PDF file is password-protected, use the following line to load the file with the password
            // PdfCompressor compressor = new PdfCompressor("input.pdf", "password");

            // Set compression options for the compressor
            compressor.Options.ImageCompressionOptions.ResizeImages = true;
            compressor.Options.ImageCompressionOptions.ImageQuality = ImageQuality.Low;

            // Compress the PDF document and save the result to a new PDF file named "CompressDocument_result.pdf"
            compressor.CompressToFile("CompressDocument_result.pdf");

            // Alternatively, you can compress the PDF document and save it to a stream (MemoryStream in this example)
            // MemoryStream ms = new MemoryStream();
            // compressor.CompressToStream(ms);

            //View the pdf document
            PDFDocumentViewer("CompressDocument_result.pdf");
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
