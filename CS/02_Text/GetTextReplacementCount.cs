using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Texts;
using System.IO;

namespace GetTextReplacementCount
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a PDF document
            PdfDocument pdf = new PdfDocument();

            // Load the PDF file from disk
            pdf.LoadFromFile("..\\..\\..\\..\\..\\..\\Data\\ReplaceTextInPage.pdf");

            // Get the first page
            PdfPageBase page = pdf.Pages[0];

            // Create an instance of PdfTextReplacer to replace text
            PdfTextReplacer replacer = new PdfTextReplacer(page);

            // Specify the type of replacement to be performed
            replacer.Options.ReplaceType = PdfTextReplaceOptions.ReplaceActionType.WholeWord;

            // Replace the text in the document
            int count = replacer.ReplaceAllText("PDF", "Pdf");


            string result = "GetTextReplacementCount.txt";

            // Save the modified document to a file
            File.WriteAllText(result, "The count of text replacements: "+count);

            // Close the PDF document
            pdf.Close();

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
