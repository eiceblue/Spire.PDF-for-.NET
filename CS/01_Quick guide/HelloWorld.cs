using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;


namespace HelloWorld
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

            // Create one page
            PdfPageBase page = doc.Pages.Add();            

            //Draw the text
            page.Canvas.DrawString("Hello, World!",
                                   new PdfFont(PdfFontFamily.Helvetica, 30f),
                                   new PdfSolidBrush(Color.Black),
                                   10, 10);

            //Save pdf file.
            doc.SaveToFile("HelloWorld.pdf");
            doc.Close();

            //Launching the Pdf file.
            PDFDocumentViewer("HelloWorld.pdf");

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
