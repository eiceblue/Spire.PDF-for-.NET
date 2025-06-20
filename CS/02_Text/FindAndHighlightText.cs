using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Texts;

namespace FindAndHighlightText
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load the document from disk
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\FindAndHighlightText.pdf");

            // Iterate through each page of the document
            foreach (PdfPageBase page in pdf.Pages)
            {
                // Create a PdfTextFinder object for the current page
                PdfTextFinder finder = new PdfTextFinder(page);
                finder.Options.Parameter = Spire.Pdf.Texts.TextFindParameter.WholeWord;

                // Find the occurrences of the specified text
                List<PdfTextFragment> finds = finder.Find("science");

                // Highlight the found text
                foreach (PdfTextFragment find in finds)
                {
                    find.HighLight();
                }
            }

            // Save the modified document
            string output = "FindAndHighlightText_out.pdf";
            pdf.SaveToFile(output, FileFormat.PDF);

            //Launch the result file
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
