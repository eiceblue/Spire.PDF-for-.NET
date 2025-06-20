using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace ToHTMLFilesSplittedByPages
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
            String file = @"..\..\..\..\..\..\..\Data\SampleB_3.pdf";

            // Open the PDF document using PdfDocument
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(file);

            // Set the conversion options to split the PDF into HTML files based on pages
            // Here, each page will be converted to a separate HTML file
            doc.ConvertOptions.SetPdfToHtmlOptions(false, true, 1);

            // Specify the output file name pattern for the split HTML files
            string output = "ToHTMLFilesSplittedByPages_out.html";

            // Convert the PDF document to HTML files
            doc.SaveToFile(output, FileFormat.HTML);

            // Close the PDF document
            doc.Close();

            //Launch result file
            PDFDocumentViewer(output);
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
