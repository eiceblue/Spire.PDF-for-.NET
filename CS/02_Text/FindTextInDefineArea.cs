using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Texts;

namespace FindTextInDefineArea
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Set the input file path
            string input = @"..\..\..\..\..\..\Data\SampleB_1.pdf";

            // Set the output file name
            string output = "FindTextInDefinePlace.pdf";

            // Create a new PdfDocument object
            PdfDocument doc = new PdfDocument();

            // Load the PDF document from the specified input file path
            doc.LoadFromFile(input);

            // Define a rectangle to specify the search area
            RectangleF rctg = new RectangleF(0, 0, 300, 300);

            //Get the first page
            PdfPageBase pdfPageBase = doc.Pages[0];

            // Create a PdfTextFinder object for the first page
            PdfTextFinder finder = new PdfTextFinder(pdfPageBase);
            finder.Options.Parameter = Spire.Pdf.Texts.TextFindParameter.WholeWord;
            finder.Options.Area = rctg;

            //Find text in the rectangle
            List<PdfTextFragment> finds = finder.Find("Spire");
            List<PdfTextFragment> findouts = finder.Find("PDF");

            //Highlight the found text
            foreach (PdfTextFragment find in finds)
            {
                find.HighLight(Color.Green);
            }

            foreach (PdfTextFragment findOut in findouts)
            {
                findOut.HighLight(Color.Yellow);
            }

            //Save the document
            doc.SaveToFile(output, FileFormat.PDF);
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
