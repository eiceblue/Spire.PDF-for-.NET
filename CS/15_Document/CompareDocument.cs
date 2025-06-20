using Spire.Pdf;
using Spire.Pdf.Comparison;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompareDocument
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load the first PDF file
            PdfDocument pdf1 = new PdfDocument(@"..\..\..\..\..\..\Data\Template_Pdf_2.pdf");

            // Load the second PDF file
            PdfDocument pdf2 = new PdfDocument(@"..\..\..\..\..\..\Data\Template_Pdf_5.pdf");

            // Create a PDF comparer object
            PdfComparer compare = new PdfComparer(pdf1, pdf2);

            // Set the comparison range for the pages to be compared
            compare.Options.SetPageRanges(0, pdf1.Pages.Count - 1, 0, pdf2.Pages.Count - 1);

            // Save the result of the comparison to a new PDF document
            compare.Compare("CompareDocument-Result.pdf");

            //Launch the Pdf file.
            PDFDocumentViewer("CompareDocument-Result.pdf");
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
