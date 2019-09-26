using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;


namespace Booklet
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
            PdfDocument doc = new PdfDocument();

            String srcPdf = @"..\..\..\..\..\..\Data\Booklet.pdf";
            float width = PdfPageSize.A4.Width * 2;
            float height = PdfPageSize.A4.Height;
            doc.CreateBooklet(srcPdf, width, height, true);

            //Save pdf file
            doc.SaveToFile("Booklet-result.pdf");
            doc.Close();

            //Launch the Pdf file
            PDFDocumentViewer("Booklet-result.pdf");
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
