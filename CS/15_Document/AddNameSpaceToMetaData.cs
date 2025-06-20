using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Interchange.Metadata;


namespace AddNameSpaceToMetaData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Load input Pdf file
            PdfDocument pdfDocument= new PdfDocument();
            pdfDocument.LoadFromFile(@"..\..\..\..\..\..\Data\Template_Pdf_4.pdf");

            //Add new namespace to metadata
            PdfXmpNamespace.RegisterNamespace("http://myRandomNamespace", "zf");

            //Add custom property to new namespace
            pdfDocument.Metadata.SetPropertyString("http://myRandomNamespace", "test1", "my test");

            //Reset namespace
            PdfXmpNamespace.ResetNamespaces();

            //Save the result Pdf file
            string result_path = @"AddNameSpaceToMetaData.pdf";
            pdfDocument.SaveToFile(result_path);       
             
            //Launch the Pdf file
            PDFDocumentViewer(result_path);
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
