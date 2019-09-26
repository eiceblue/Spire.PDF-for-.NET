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
            String input = "..\\..\\..\\..\\..\\..\\Data\\PDFTemplate-Az.pdf";
            PdfDocument doc = new PdfDocument();

            // Read a pdf file
            doc.LoadFromFile(input);

            // Creates a new page
            PdfDocument newDoc = new PdfDocument();

            // Get page margins of source pdf page
            PdfMargins margins = doc.PageSettings.Margins;
            float top = margins.Left;
            float bottom = margins.Bottom;
            float left = margins.Left;
            float right = margins.Right;

            foreach (PdfPageBase page in doc.Pages)
            {
                // Adds a new page to the new document
                PdfPageBase newPage = newDoc.Pages.Add(new SizeF(page.Size.Width - left - right, page.Size.Height - top - bottom), new PdfMargins(0));

                // Draws the content of the source page onto the new document page
                newPage.Canvas.DrawTemplate(page.CreateTemplate(), new PointF(-left, -top));
            }

            String result = "RemovePageMargins_out.pdf";
  
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
