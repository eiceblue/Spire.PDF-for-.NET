using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf.Conversion;

namespace ToPdfA2B
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Load a standard pdf document
            PdfStandardsConverter converter_1 = new PdfStandardsConverter(@"..\..\..\..\..\..\Data\ToPdfA2B.pdf");

            //Convert Pdf to PdfA2B 
            converter_1.ToPdfA2B("ToPdfA2B_result.pdf"); 

            //Launch the result file
            PDFDocumentViewer("ToPdfA2B_result.pdf");
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
