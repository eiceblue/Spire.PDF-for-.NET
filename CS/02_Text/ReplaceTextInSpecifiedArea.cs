using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Texts;


namespace ReplaceTextInSpecifiedArea
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

            // Get all pages of the document
            for (int i = 0; i < pdf.Pages.Count; i++)
            {
                PdfPageBase page = pdf.Pages[i];

                // Create an instance of PdfTextReplacer to replace text
                PdfTextReplacer replacer = new PdfTextReplacer(page);

                // Set the replacement area for the text replacer
                replacer.Options.SetReplacementArea(new RectangleF(10, 0, 841, 150));

                // Specify the type of replacement to be performed
                replacer.Options.ReplaceType = PdfTextReplaceOptions.ReplaceActionType.WholeWord; 

                // Replace the text in the document
                replacer.ReplaceAllText("PDF", "Pdf");
            }

            string result = "ReplaceTextInSpecifiedArea_out.pdf";

            // Save the modified document to a file
            pdf.SaveToFile(result);

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
