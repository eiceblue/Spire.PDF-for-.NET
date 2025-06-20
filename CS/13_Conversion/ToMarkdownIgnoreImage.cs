using Spire.Pdf.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToMarkdownIgnoreImage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Specify the path of the input OFD file
            string inputFile = @"..\..\..\..\..\..\Data\SampleB_1.pdf";

            // Create an instance of the PdfToMarkdownConverter
            PdfToMarkdownConverter converter = new PdfToMarkdownConverter(inputFile);

            // Set the option to ignore images 
            converter.MarkdownOptions.IgnoreImage = true;

            // Define the output file name for the converted Markdown
            string outputFile = "ToMarkdownIgnoreImage.md";

            // Convert the PDF to Markdown
            converter.ConvertToMarkdown(outputFile);

            // Launch the result file
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
