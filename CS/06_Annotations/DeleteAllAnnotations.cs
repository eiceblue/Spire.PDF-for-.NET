using Spire.Pdf;
using Spire.Pdf.Interactive.Annotations;
using System;
using System.Windows.Forms;

namespace DeleteAllAnnotations
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
            PdfDocument document = new PdfDocument();

            //Load the file from disk
            document.LoadFromFile(@"..\..\..\..\..\..\Data\Template_Pdf_3.pdf");

            //Remove all annotations
            PdfAnnotationCollection.Create(document.Pages[0]).Clear();

            String result = "DeleteAllAnnotations.pdf";

            //Save the document
            document.SaveToFile(result);
            document.Close();

            //Launch the Pdf file
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
