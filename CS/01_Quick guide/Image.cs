using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;


namespace Image
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
            //Draw the image
            PdfImage image = PdfImage.FromFile(@"..\..\..\..\..\..\Data\SalesReportChart.png");
            float width = image.Width * 0.75f;
            float height = image.Height * 0.75f;
            float x = (page.Canvas.ClientSize.Width - width) / 2;

            page.Canvas.DrawImage(image, x, 60, width, height);

            //Save pdf file.
            doc.SaveToFile("Image.pdf");
            doc.Close();

            //Launching the Pdf file.
            PDFDocumentViewer("Image.pdf");
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
