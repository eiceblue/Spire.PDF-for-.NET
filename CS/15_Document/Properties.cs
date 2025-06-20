using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;


namespace Properties
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load PDF document
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\Properties.pdf");

            // Set document information
            doc.DocumentInformation.Author = "E-iceblue";
            doc.DocumentInformation.Creator = "E-iceblue";
            doc.DocumentInformation.Keywords = "pdf, demo, document information";
            doc.DocumentInformation.Producer = "Spire.Pdf";
            doc.DocumentInformation.Subject = "Demo of Spire.Pdf";
            doc.DocumentInformation.Title = "Document Information";

            // Set file info
            doc.FileInfo.CrossReferenceType = PdfCrossReferenceType.CrossReferenceStream;
            doc.FileInfo.IncrementalUpdate = false;

            // Save the PDF file
            doc.SaveToFile("Properties_result.pdf");

            // Close the document
            doc.Close();

            //Launch the Pdf file
            PDFDocumentViewer("Properties_result.pdf");
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
