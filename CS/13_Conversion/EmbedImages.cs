using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EmbedImages
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Specify the path of the input PDF file
            String file = @"..\..\..\..\..\..\..\Data\EmbedImagesInHTML.pdf";

            // Open the PDF document using PdfDocument
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(file);

            // Set the conversion options to embed images in HTML
            doc.ConvertOptions.SetPdfToHtmlOptions(true, true);

            // Specify the result file name for the converted HTML file
            String result = "ToHTMLWithEmbedImages_out.html";

            // Convert the PDF document to an HTML file
            doc.SaveToFile(result, FileFormat.HTML);

            // Close the PDF document
            doc.Close();

            //Launch the reuslt file
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
