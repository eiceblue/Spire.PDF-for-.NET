using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;

namespace ToXLSX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String result = "ToXLSX.xlsx";
            //Create a pdf document
            using (PdfDocument doc = new PdfDocument())
            {
                doc.LoadFromFile(@"..\..\..\..\..\..\Data\ChartSample.pdf");

                //Save to XLSX
                doc.SaveToFile(result, FileFormat.XLSX);

            }
            //Launch the result file
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
