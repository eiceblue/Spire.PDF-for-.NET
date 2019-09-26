using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace ZoomToPageContents
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

            //Create a newDoc
            PdfDocument newDoc = new PdfDocument();

            foreach (PdfPageBase page in doc.Pages)
            {
                //Add new page with 'A3' size
                PdfPageBase newPage = newDoc.Pages.Add(PdfPageSize.A3, new PdfMargins(0,0));

                //Zoom content to the new page
                newPage.Canvas.ScaleTransform(newPage.ActualSize.Width / page.ActualSize.Width,
                                             (newPage.ActualSize.Height / page.ActualSize.Height));

                //Draw the page to new page
                newPage.Canvas.DrawTemplate(page.CreateTemplate(), new PointF(0, 0));
            }

            //Save the Pdf document
            string output = "ZoomToPageContents_result.pdf";
            newDoc.SaveToFile(output, FileFormat.PDF);

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
