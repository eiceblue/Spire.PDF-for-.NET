using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace ResetPageSize
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = "..\\..\\..\\..\\..\\..\\Data\\ResetPageSize.pdf";

            string output = "ResetPageSize.pdf";

            // Load the document from disk
            PdfDocument originalDoc = new PdfDocument();
            originalDoc.LoadFromFile(input);

            // Set the margins for the new document
            PdfMargins margins = new PdfMargins(0);

            // Create a new PDF document to store the reset page size version
            using (PdfDocument newDoc = new PdfDocument())
            {
                // Set the scale factor for resizing the pages
                float scale = 0.8f;

                // Iterate through each page of the original document
                for (int i = 0; i < originalDoc.Pages.Count; i++)
                {
                    PdfPageBase page = originalDoc.Pages[i];

                    // Calculate the new width and height based on the scale factor
                    float width = page.Size.Width * scale;
                    float height = page.Size.Height * scale;

                    // Add a new page to the new document with the expected width, height, and margins
                    PdfPageBase newPage = newDoc.Pages.Add(new SizeF(width, height), margins);

                    // Apply the scale transformation to the new page
                    newPage.Canvas.ScaleTransform(scale, scale);

                    // Copy the content of the original page into the new page
                    newPage.Canvas.DrawTemplate(page.CreateTemplate(), PointF.Empty);
                }

                // Save the new document with the reset page size to the specified output file
                newDoc.SaveToFile(output);
            }

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
