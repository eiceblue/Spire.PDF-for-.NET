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

namespace SearchTextAndAddHyperlink
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

            // Get the first page of the pdf file
            PdfPageBase page = doc.Pages[0];

            // Create a PdfTextFinder using the first page
            PdfTextFinder finder = new PdfTextFinder(page);

            // Set the search parameter to ignore case
            finder.Options.Parameter = Spire.Pdf.Texts.TextFindParameter.IgnoreCase;

            // Find all occurrences of "e-iceblue" in the PDF and store them in a list
            List<PdfTextFragment> finds = finder.Find("e-iceblue");

            // Define the hyperlink URL
            String url = "http://www.e-iceblue.com";

            // Iterate through each found text fragment
            foreach (PdfTextFragment find in finds)
            {
                // Create a PdfUriAnnotation object to add a hyperlink for the searched text
                PdfUriAnnotation uri = new PdfUriAnnotation(find.Bounds[0]);
                uri.Uri = url;
                uri.Border = new PdfAnnotationBorder(1f);
                uri.Color = Color.Blue;

                // Add the annotation to the page's annotation widget
                page.Annotations.Add(uri);
            }

            String result = "SearchTextAndAddHyperlink_out.pdf";

            // Save the modified document to the output file path
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
