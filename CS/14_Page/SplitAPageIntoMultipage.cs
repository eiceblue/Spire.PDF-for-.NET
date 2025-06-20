using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace SplitAPageIntoMultipage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load an existing PDF document from disk
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile("../../../../../../Data/PDFTemplate_N.pdf");

            // Get the first page of the document
            PdfPageBase page = doc.Pages[0];

            // Create a new PDF document
            PdfDocument newPdf = new PdfDocument();

            // Remove all the margins for the new document
            newPdf.PageSettings.Margins.All = 0;

            // Set the page size of the new PDF to match the width and half the height of the original page
            newPdf.PageSettings.Width = page.Size.Width;
            newPdf.PageSettings.Height = page.Size.Height / 2;

            // Add a new page to the new PDF document
            PdfPageBase newPage = newPdf.Pages.Add();

            // Specify the text layout settings for drawing the page content
            PdfTextLayout format = new PdfTextLayout();
            format.Break = PdfLayoutBreakType.FitPage;
            format.Layout = PdfLayoutType.Paginate;

            // Draw the content of the original page onto the new page using a template
            page.CreateTemplate().Draw(newPage, new PointF(0, 0), format);

            // Save the modified PDF document to a new file
            string output = "SplitAPageIntoMultipage_out.pdf";
            newPdf.SaveToFile(output);

            //Launch the document
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
