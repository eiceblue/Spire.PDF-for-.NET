using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Annotations;
using Spire.Pdf.ColorSpace;
using Spire.Pdf.Conversion;
using Spire.Pdf.Graphics;


namespace EmbedFontToPdf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            // Creating an instance of the PdfEmbeddedFontConverter class and specifying the path to the source PDF file
            PdfEmbeddedFontConverter converter = new PdfEmbeddedFontConverter(@"..\..\..\..\..\..\Data\UnEmbed.pdf");

            // Specifying the output file path where the converted PDF with embedded fonts will be saved
            string output = @"EmbedFontToPdf.pdf";

            // Calling the ToEmbeddedFontDocument method of the converter object to convert the PDF and embed fonts
            converter.ToEmbeddedFontDocument(output);

            //Launch the Pdf file
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
