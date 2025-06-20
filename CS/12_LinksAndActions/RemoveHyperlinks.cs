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
            // Load an existing PDF file.
            PdfDocument document = new PdfDocument();
            document.LoadFromFile(@"..\..\..\..\..\..\Data\RemoveHyperlinks.pdf");

            // Get the first page of the document.
            PdfPageBase page = document.Pages[0];

            // Get the collection of annotations on the page.
            PdfAnnotationCollection widgetCollection = page.Annotations;

            // Check if the widgetCollection is not null and contains annotations.
            if (widgetCollection.Count > 0)
            {
                // Iterate over the annotations in reverse order.
                for (int i = widgetCollection.Count - 1; i >= 0; i--)
                {
                    // Get the current annotation.
                    PdfAnnotation annotation = widgetCollection[i];

                    // Check if the annotation is a TextWebLink Annotation.
                    if (annotation is PdfTextWebLinkAnnotationWidget)
                    {
                        // Cast the annotation to TextWebLink Annotation.
                        PdfTextWebLinkAnnotationWidget link = annotation as PdfTextWebLinkAnnotationWidget;

                        // Remove the TextWebLink annotation from the collection.
                        widgetCollection.Remove(link);
                    }
                }
            }

            // Specify the output file name.
            string output = "RemoveHyperlinks-result.pdf";

            // Save the modified document to a new file.
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
