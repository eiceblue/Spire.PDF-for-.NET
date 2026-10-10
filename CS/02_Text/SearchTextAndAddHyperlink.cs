using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Actions;
using Spire.Pdf.Interactive.Annotations;
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

            // Get the first page of pdf file
            PdfPageBase page = doc.Pages[0];

            // Create PdfTextFindCollection object to find all the matched phrases
            PdfTextFinder finds = new PdfTextFinder(doc.Pages[0]);
            finds.Options.Parameter = Spire.Pdf.Texts.TextFindParameter.IgnoreCase;
            List<PdfTextFragment> result = finds.Find("e-iceblue");

            // hyperlink url
            String url = "http://www.e-iceblue.com";

            foreach (PdfTextFragment find in result)
            {
                RectangleF rect = new RectangleF(find.Positions[0].X, find.Positions[0].Y, find.Sizes[0].Width, find.Sizes[0].Height);
                // Create a PdfUriAnnotation object to add hyperlink for the searched text 
                PdfURIAction action = new PdfURIAction(url);
                PdfLinkAnnotation annotation = new PdfLinkAnnotation(page, rect, action);
                annotation.Border.Width = 1f;
                annotation.Color = Color.Blue;
                PdfAnnotationCollection.Create(page).Add(annotation);
            }

            String outputFile = "SearchTextAndAddHyperlink_out.pdf";

            // Save the modified document to the output file path
            doc.SaveToFile(outputFile);

            //Launch the Pdf file
            PDFDocumentViewer(outputFile);
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
