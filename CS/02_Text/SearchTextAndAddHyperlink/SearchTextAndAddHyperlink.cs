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
            PdfTextFindCollection collection = page.FindText("e-iceblue", TextFindParameter.IgnoreCase);

            // hyperlink url
            String url = "http://www.e-iceblue.com";
         
            foreach (PdfTextFind find in collection.Finds)
            {
                // Create a PdfUriAnnotation object to add hyperlink for the searched text 
                PdfUriAnnotation uri = new PdfUriAnnotation(find.Bounds);
                uri.Uri = url;
                uri.Border = new PdfAnnotationBorder(1f);
                uri.Color = Color.Blue;
                page.AnnotationsWidget.Add(uri);
            }

            String result = "SearchTextAndAddHyperlink_out.pdf";
  
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
