using Spire.Pdf;
using Spire.Pdf.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetLinkAnnotation
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
            PdfAnnotationCollection annotations = page.AnnotationsWidget;

            //Create StringBuilder to save 
            StringBuilder content = new StringBuilder();
             
            //Verify whether widgetCollection is not null or not
            if (annotations.Count > 0)
            {
                //traverse the PdfAnnotationCollection
                foreach (PdfAnnotation pdfAnnotation in annotations)
                {
                    //if it is PdfTextWebLinkAnnotationWidget
                    if (pdfAnnotation is PdfTextWebLinkAnnotationWidget)
                    {

                        //Get the Url
                        PdfTextWebLinkAnnotationWidget WebLinkAnnotation = pdfAnnotation as PdfTextWebLinkAnnotationWidget;
                        string url = WebLinkAnnotation.Url;

                        //Add strings to StringBuilder
                        content.AppendLine("The url of link annotation is "+ url);
                        content.AppendLine("The text of link annotation is " + WebLinkAnnotation.Text);
                    }
                }
            }

            String result = "GetLinkAnnotation_out.txt";

            //Save them to a txt file
            File.WriteAllText(result, content.ToString());

            //Launch the file
            DocumentViewer(result);
        }
        private void DocumentViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }
    }
}