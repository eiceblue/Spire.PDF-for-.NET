using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PDFAToPDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Specify the path of the input PDF file
            String input = @"..\..\..\..\..\..\Data\SamplePDFA.pdf";

            // Open the PDF document using PdfDocument
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(input);

            // Create a new PDF document to draw content on a new file
            PdfNewDocument newDoc = new PdfNewDocument();
            newDoc.CompressionLevel = PdfCompressionLevel.None;

            // Iterate through each page in the original document
            foreach (PdfPageBase page in doc.Pages)
            {
                // Get the size of the current page
                SizeF size = page.Size;

                // Add a new page to the new document with the same size and no margins
                PdfPageBase p = newDoc.Pages.Add(size, new Spire.Pdf.Graphics.PdfMargins(0));

                // Draw the contents of the original page onto the new page
                page.CreateTemplate().Draw(p, 0, 0);
            }

            // Specify the output file name
            string output = "PDFAToPdf-result.pdf";

            // Save the new document as a PDF file
            newDoc.Save(output);

            // Close the new document
            newDoc.Close();

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
