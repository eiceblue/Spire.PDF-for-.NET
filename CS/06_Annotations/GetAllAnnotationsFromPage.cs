using System;
using System.Windows.Forms;
using Spire.Pdf;
using System.IO;
using System.Text;
using Spire.Pdf.Interactive.Annotations;

namespace GetAllAnnotationsFromPage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Create a new PDF document.
            PdfDocument pdf = new PdfDocument();

            //Load the file from disk.
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\Template_Pdf_3.pdf");

            //Get all annotations from the first page.
            PdfAnnotationCollection annotations = PdfAnnotationCollection.Create(pdf.Pages[0]);

            StringBuilder content = new StringBuilder();

            for (int i = 0; i < annotations.Count; i++)
            {
                //A text annotation will attach a popup annotation since they are father-son relationship.
                //The annotation information exists in the text annotation, so here we mask the blank popup annotation.
                if (annotations[i] is PdfPopupAnnotation)
                    continue;
                content.AppendLine("Annotation information: ");
                content.AppendLine("Text: " + annotations[i].Contents);
                string modifiedDate = annotations[i].ModifiedDate.ToString();
                content.AppendLine("ModifiedDate: " + modifiedDate);
            }

            String result = "Result-GetAllAnnotationsFromPage.txt";

            //Save to file.
            File.WriteAllText(result, content.ToString());

            pdf.Close();

            //Launch the file.
            PDFDocumentViewer(result);
        }

        private void PDFDocumentViewer(string filename)
        {
            try
            {
                System.Diagnostics.Process.Start(filename);
            }
            catch { }
        }
    }
}
