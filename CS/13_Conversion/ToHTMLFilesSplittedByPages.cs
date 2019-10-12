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
            //Pdf file
            String file = @"..\..\..\..\..\..\..\Data\SampleB_3.pdf";

            //Open pdf document
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(file);

            //Split to HTML file according to pages, here one page will convert to a HTML file.
            doc.ConvertOptions.SetPdfToHtmlOptions(false, true, 1);

            string output = "ToHTMLFilesSplittedByPages_out.html";

            //Convert to html file
            doc.SaveToFile(output, FileFormat.HTML);
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
