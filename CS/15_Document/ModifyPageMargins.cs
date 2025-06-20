using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Fields;
using Spire.Pdf.Annotations;
using Spire.Pdf.Graphics;
using Spire.Pdf.Actions;
using Spire.Pdf.General;
namespace ModifyPageMargins
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Define the input PDF file path
            String input = "..\\..\\..\\..\\..\\..\\Data\\ModifyPageMargins.pdf";

            // Create a new PdfDocument object
            PdfDocument doc = new PdfDocument();

            // Read the content of the input PDF file into the PdfDocument object
            doc.LoadFromFile(input);

            // Create a new PdfDocument object for storing the modified page margins
            PdfDocument newDoc = new PdfDocument();

            // Define the top, bottom, left, and right margins of the new document
            float top = 50;
            float bottom = 50;
            float left = 50;
            float right = 50;

            // Iterate through each page in the original document
            foreach (PdfPageBase page in doc.Pages)
            {
                // Add a new page to the new document with the same size as the source page and no margins
                PdfPageBase newPage = newDoc.Pages.Add(page.Size, new PdfMargins(0));

                // Set the scale of the new document content based on the actual size of the source page
                newPage.Canvas.ScaleTransform((page.ActualSize.Width - left - right) / page.ActualSize.Width,
                                                 (page.ActualSize.Height - top - bottom) / page.ActualSize.Height);

                // Draw the content of the source page onto the new document page at the specified margin positions
                newPage.Canvas.DrawTemplate(page.CreateTemplate(), new PointF(left, top));
            }

            // Define the output PDF file path
            String result = "ModifyPageMargins_out.pdf";

            // Save the modified document to the specified output file path
            newDoc.SaveToFile(result);

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
