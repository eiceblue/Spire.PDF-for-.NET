using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EmbedSVG
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
            String file = @"..\..\..\..\..\..\..\Data\SampleB_1.pdf";

            // Open the PDF document using PdfDocument
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(file);

            // Set the boolean option to embed SVG when converting to HTML
            doc.ConvertOptions.SetPdfToHtmlOptions(true);

            // Specify the result file name for the converted HTML file
            String result = "ToHTMLWithEmbedingSVG_out.html";

            // Convert the PDF document to an HTML file
            doc.SaveToFile(result, FileFormat.HTML);

            // Close the PDF document
            doc.Close();

            //Launch result file
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
