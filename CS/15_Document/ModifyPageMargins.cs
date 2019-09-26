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
using Spire.Pdf.General.Find;
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
            String input = "..\\..\\..\\..\\..\\..\\Data\\ModifyPageMargins.pdf";
            PdfDocument doc = new PdfDocument();

            // Read a pdf file
            doc.LoadFromFile(input);
            
            // Creates a new pdf document
            PdfDocument newDoc = new PdfDocument();

            // Defines the page margins of the new document
            float top = 50;
            float bottom = 50;
            float left = 50;
            float right = 50;

            foreach (PdfPageBase page in doc.Pages)
            {
                // Adds a new page to the new document and set the page size to be the same as the source document
                PdfPageBase newPage = newDoc.Pages.Add(page.Size, new PdfMargins(0));
                // Set the scale of the new document content
                newPage.Canvas.ScaleTransform((page.ActualSize.Width - left - right) / page.ActualSize.Width,
                                             (page.ActualSize.Height - top - bottom) / page.ActualSize.Height);
                // Draws the content of the source page onto the new document page
                newPage.Canvas.DrawTemplate(page.CreateTemplate(), new PointF(left, top));
            }


            String result = "ModifyPageMargins_out.pdf";
  
            //Save the document
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
