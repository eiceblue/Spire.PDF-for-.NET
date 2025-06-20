using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;

namespace SetXMPMetadata
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Specify the path to the PDF file.
            string input = "..\\..\\..\\..\\..\\..\\Data\\SetXMPMetadata.pdf";

            // Open a PDF document.
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(input);

            // Set XMP metadata for the document.
            doc.DocumentInformation.Author = "E-iceblue";
            doc.DocumentInformation.Creator = "Spire.PDF";
            doc.DocumentInformation.Keywords = "XMP";
            doc.DocumentInformation.Producer = "E-icenlue Co,.Ltd";
            doc.DocumentInformation.Subject = "XMP Metadata";
            doc.DocumentInformation.Title = "Set XMP Metadata in PDF";

            // Specify the output file name for the modified PDF.
            string output = "SetXMPMetadata.pdf";

            // Save the PDF document with the updated XMP metadata.
            doc.SaveToFile(output);

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
