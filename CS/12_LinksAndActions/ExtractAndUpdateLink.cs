using Spire.Pdf;
using Spire.Pdf.Actions;
using Spire.Pdf.Interactive.Annotations;
using System;
using System.Windows.Forms;

namespace ExtractAndUpdateLink
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a pdf document
            PdfDocument doc = new PdfDocument();

            //Load file from disk
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\LinkAnnotation.pdf");

            //Get the first page
            PdfPageBase page = doc.Pages[0];

            //Get the annotation collection
            PdfAnnotationCollection annotations = PdfAnnotationCollection.Create(page);

            //Verify whether widgetCollection is not null or not
            if (annotations.Count > 0)
            {
                //traverse the PdfAnnotationCollection
                foreach (PdfAnnotation pdfAnnotation in annotations)
                {
                    //if it is PdfTextWebLinkAnnotationWidget
                    if (pdfAnnotation is PdfLinkAnnotation)
                    {

                        //Get the link annotation
                        PdfLinkAnnotation annotation = pdfAnnotation as PdfLinkAnnotation;

                        //Change the url
                        (annotation.Action as PdfURIAction).URI = "http://www.e-iceblue.com/Introduce/pdf-for-net-introduce.html";

                    }
                }
            }

            String result = "ExtractAndUpdateLink_out.pdf";

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





