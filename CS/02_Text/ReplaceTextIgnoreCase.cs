using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Texts;

namespace ReplaceTextIgnoreCase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load the Pdf file
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\ReplaceTextIgnoreCase.pdf");

            // Get the first page of the pdf file
            PdfPageBase page = doc.Pages[0];

            // Create a PdfTextReplacer using the first page
            PdfTextReplacer replacer = new PdfTextReplacer(page);

            // Set options for text replacement
            PdfTextReplaceOptions option = new PdfTextReplaceOptions();
            option.ReplaceType = PdfTextReplaceOptions.ReplaceActionType.IgnoreCase;
            replacer.Options = option;

            // Only replace the first occurrence of "text" with "This is a test" in this page
            replacer.ReplaceText("text", "This is a test");

            // Replace all occurrences of "pdf" with "Spire.Pdf for Net" in this page
            replacer.ReplaceAllText("pdf", "Spire.Pdf for Net");

            // Save the document to "output.pdf" in PDF format
            doc.SaveToFile("output.pdf", FileFormat.PDF);

            //Launch the Pdf file
            PDFDocumentViewer("output.pdf");
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
