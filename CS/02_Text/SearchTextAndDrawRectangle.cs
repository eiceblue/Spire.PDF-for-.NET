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
using Spire.Pdf.Texts;

namespace SearchTextAndDrawRectangle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String input = @"..\..\..\..\..\..\Data\SearchReplaceTemplate.pdf";
            PdfDocument doc = new PdfDocument();

            // Read a pdf file
            doc.LoadFromFile(input);

            // Get the first page of pdf file
            PdfPageBase page = doc.Pages[0];

            // Create a PdfTextFinder object for searching text within the first page
            PdfTextFinder finder = new PdfTextFinder(page);
            finder.Options.Parameter = Spire.Pdf.Texts.TextFindParameter.IgnoreCase;

            // Find occurrences of the specified text within the first page
            List<PdfTextFragment> finds = finder.Find("Spire.PDF for .NET");

            // Iterate through each found text fragment
            foreach (PdfTextFragment find in finds)
            {
                // Draw a rectangle with red pen
                page.Canvas.DrawRectangle(new PdfPen(PdfBrushes.Red, 0.9f), find.Bounds[0]);
            }

            String result = "SearchTextAndDrawRectangle_out.pdf";

            //Save the document
            doc.SaveToFile(result);

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
