using Spire.Pdf;
using System;
using System.Windows.Forms;

namespace RemoveDocumentJavaScript
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
            PdfDocument document = new PdfDocument();

            //Load an existing pdf from disk
            document.LoadFromFile(@"..\..\..\..\..\..\Data\DocumentJavaScript.pdf");

            //Remove document javascript
            document.RemoveDocumentJavaScript();

            String result = "Output.pdf";

            //Save the document
            document.SaveToFile(result);

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