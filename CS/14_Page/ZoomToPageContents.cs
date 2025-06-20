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
            // Load an existing PDF document from disk
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile("../../../../../../Data/PDFTemplate_N.pdf");

            // Create a new PDF document
            PdfDocument newDoc = new PdfDocument();

            // Iterate through each page in the original document
            foreach (PdfPageBase page in doc.Pages)
            {
                // Add a new page to the new document with 'A3' size and no margins
                PdfPageBase newPage = newDoc.Pages.Add(PdfPageSize.A3, new PdfMargins(0, 0));

                // Zoom the content of the original page to fit within the boundaries of the new page
                newPage.Canvas.ScaleTransform(newPage.ActualSize.Width / page.ActualSize.Width,
                                              (newPage.ActualSize.Height / page.ActualSize.Height));

                // Draw the content of the original page onto the new page
                newPage.Canvas.DrawTemplate(page.CreateTemplate(), new PointF(0, 0));
            }

            // Save the modified PDF document to a new file
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
