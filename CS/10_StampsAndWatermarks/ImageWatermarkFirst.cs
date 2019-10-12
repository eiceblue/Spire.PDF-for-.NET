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
            //Create a pdf document and load file from disk
            PdfDocument doc = new PdfDocument();
	    doc.LoadFromFile(@"..\..\..\..\..\..\Data\ImageWaterMark.pdf");

            //Get the first page
            PdfPageBase page = doc.Pages[0];

            //Load image
            Image img = Image.FromFile(@"..\..\..\..\..\..\Data\Background.png");

            //Set background image
            page.BackgroundImage = img;

            //Save pdf file
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
