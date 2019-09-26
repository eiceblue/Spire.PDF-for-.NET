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
            //Load Pdf document from disk
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile("../../../../../../Data/PDFTemplate_N.pdf");

            //Get the first page
            PdfPageBase page = doc.Pages[0];

            //Create a new Pdf
            PdfDocument newPdf = new PdfDocument();

            //Remove all the margins
            newPdf.PageSettings.Margins.All = 0;

            //Set the page size of new Pdf
            newPdf.PageSettings.Width = page.Size.Width;
            newPdf.PageSettings.Height = page.Size.Height / 2;

            //Add a new page
            PdfPageBase newPage = newPdf.Pages.Add();

            PdfTextLayout format = new PdfTextLayout();
            format.Break = PdfLayoutBreakType.FitPage;
            format.Layout = PdfLayoutType.Paginate;

            //Draw the page in the new page
            page.CreateTemplate().Draw(newPage, new PointF(0, 0), format);

            //Save the Pdf document
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
