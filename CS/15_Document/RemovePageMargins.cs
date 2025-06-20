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
namespace RemovePageMargins
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Declare a string variable to store the input file path of the PDF document
            String input = "..\\..\\..\\..\\..\\..\\Data\\PDFTemplate-Az.pdf";

            // Create a new PdfDocument object to load and manipulate the PDF document
            PdfDocument doc = new PdfDocument();

            // Load the content of the input PDF file into the PdfDocument object
            doc.LoadFromFile(input);

            // Create a new PdfDocument object to create a new PDF document with page margins removed
            PdfDocument newDoc = new PdfDocument();

            // Get the page margins of the source PDF document
            PdfMargins margins = doc.PageSettings.Margins;

            // Extract the top, bottom, left, and right margin values from the PdfMargins object
            float top = margins.Left;
            float bottom = margins.Bottom;
            float left = margins.Left;
            float right = margins.Right;

            // Iterate through each page in the source PDF document
            foreach (PdfPageBase page in doc.Pages)
            {
                // Add a new page to the new PdfDocument object with adjusted size and margins
                PdfPageBase newPage = newDoc.Pages.Add(new SizeF(page.Size.Width - left - right, page.Size.Height - top - bottom), new PdfMargins(0));

                // Draw the content of the source page onto the new page in the new PdfDocument object
                newPage.Canvas.DrawTemplate(page.CreateTemplate(), new PointF(-left, -top));
            }

            // Declare a string variable to store the output file path of the modified PDF document
            String result = "RemovePageMargins_out.pdf";

            // Save the modified PDF document to the specified output file path
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
