using Spire.Pdf;
using Spire.Pdf.Annotations;
using System;
using System.Windows.Forms;

namespace SetPropertiesForStamp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Load old PDF from disk.
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\TextStamp.pdf");

            //Get the first page
            PdfPageBase page = pdf.Pages[0];

            //Traverse annotations widget
            foreach (PdfAnnotation annotation in page.AnnotationsWidget.List)
            {
                //If it is PdfRubberStampAnnotationWidget
                if (annotation is PdfRubberStampAnnotationWidget)
                {
                    PdfRubberStampAnnotationWidget stamp = annotation as PdfRubberStampAnnotationWidget;
                    stamp.Author = "TestUser";
                    stamp.Subject = "E-iceblue";
                    stamp.CreationDate = DateTime.Now;
                    stamp.ModifiedDate = DateTime.Now;
                }
            } 
            //Save to a pdf file
            String result = "SetPropertiesForStamp.pdf";
            pdf.SaveToFile(result, Spire.Pdf.FileFormat.PDF);

            //Launch the file
            DocumentViewer(result);
        }
        private void DocumentViewer(string filename)
        {
            try
            {
                System.Diagnostics.Process.Start(filename);
            }
            catch { }
        }
    }
}
