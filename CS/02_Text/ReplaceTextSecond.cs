using System;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Texts;

namespace ReplaceTextSecond
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Input file path
            String input = @"..\..\..\..\..\..\Data\ReplaceTextInPage.pdf";

            // Create a new PdfDocument
            PdfDocument doc = new PdfDocument();

            // Load the pdf file from disk
            doc.LoadFromFile(input);

            // Get the first page of the pdf file
            PdfPageBase page = doc.Pages[0];

            // Create a PdfTextReplacer using the first page
            PdfTextReplacer replacer = new PdfTextReplacer(page);

            // Replace all occurrences of "Spire.PDF" with "E-iceblue" in this page
            replacer.ReplaceAllText("Spire.PDF", "E-iceblue");

            // Replace the first occurrence of "Adobe Acrobat" with "PDF editors"
            replacer.ReplaceText("Adobe Acrobat", "PDF editors");

            // Output file path
            String result = "ReplaceTextInPage_out.pdf";

            // Save the modified document to the output file path
            doc.SaveToFile(result);

            //Launch the Pdf file
            PDFDocumentViewer(result);
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
