using System;
using System.IO;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Interchange.Metadata;

namespace AddCustomMetaDataFromXml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Load the input Pdf file
            PdfDocument doc = new PdfDocument(@"..\..\..\..\..\..\Data\Template_Pdf_4.pdf");

            //Load the xml file of metadata
            Stream stream = new FileStream(@"..\..\..\..\..\..\Data\MetaData.xml", FileMode.Open);

            //Set the metadata from xml file to Pdf file
            doc.Metadata = PdfXmpMetadata.Parse(stream);

            //Save the result Pdf file
            string resultPath = @"CustomMetaFromXml_result.pdf";
            doc.SaveToFile(resultPath);

            //Launch the Pdf file
            PDFDocumentViewer(resultPath);
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
