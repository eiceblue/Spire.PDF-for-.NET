using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Tables;

namespace ImageWatermarkFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a PDF document and load a file from the disk.
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\ImageWaterMark.pdf");

            // Get the first page from the document.
            PdfPageBase page = doc.Pages[0];

            // Load the image from a file.
            Image img = Image.FromFile(@"..\..\..\..\..\..\Data\Background.png");

            // Set the loaded image as the background image of the page.
            page.BackgroundImage = img;

            // Save the modified PDF file.
            doc.SaveToFile("ImageWaterMark.pdf");
            doc.Close();

            //Launch the Pdf file
            PDFDocumentViewer("ImageWaterMark.pdf");
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
