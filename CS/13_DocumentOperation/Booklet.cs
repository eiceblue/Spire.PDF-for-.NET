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
            //Create a pdf document.
            PdfDocument doc = new PdfDocument();

            String srcPdf = @"..\..\..\..\..\..\Data\Sample2.pdf";
            float width = PdfPageSize.A4.Width * 2;
            float height = PdfPageSize.A4.Height;
            doc.CreateBooklet(srcPdf, width, height, true);

            //Save pdf file.
            doc.SaveToFile("Booklet.pdf");
            doc.Close();

            //Launching the Pdf file.
            PDFDocumentViewer("Booklet.pdf");
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
