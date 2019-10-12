using Spire.Pdf;
using Spire.Pdf.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RemoveHyperlinks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Load an existing PDF file
            PdfDocument document = new PdfDocument();
            document.LoadFromFile(@"..\..\..\..\..\..\Data\RemoveHyperlinks.pdf");

            //Get the first page
            PdfPageBase page = document.Pages[0];

            //Get the annotation collection
            PdfAnnotationCollection widgetCollection = page.AnnotationsWidget;

            //Verify whether widgetCollection is null or not
            if (widgetCollection.Count > 0)
            {
                for (int i = widgetCollection.Count - 1; i >= 0; i--)
                {
                    PdfAnnotation annotation = widgetCollection[i];
                    //Get the TextWebLink Annotation
                    if (annotation is PdfTextWebLinkAnnotationWidget)
                    {
                        PdfTextWebLinkAnnotationWidget link = annotation as PdfTextWebLinkAnnotationWidget;
                        //Remove the TextWebLink annotation
                        widgetCollection.Remove(link);
                    }
                }
            }

            string output = "RemoveHyperlinks-result.pdf";

            document.SaveToFile(output);

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
