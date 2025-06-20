using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace ConvertImageToPDF

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a pdf document with a section and page added.
            PdfDocument pdf = new PdfDocument();
            PdfSection section = pdf.Sections.Add();
            PdfPageBase page = pdf.Pages.Add();

            //Load a tiff image from system
            PdfImage image = PdfImage.FromFile(@"..\..\..\..\..\..\Data\bg.png");

            //Set image display location and size in PDF
            //Calculate rate
            float widthFitRate = image.PhysicalDimension.Width / page.Canvas.ClientSize.Width;
            float heightFitRate = image.PhysicalDimension.Height / page.Canvas.ClientSize.Height;
            float fitRate = Math.Max(widthFitRate, heightFitRate);

            //Calculate the size of image 
            float fitWidth = image.PhysicalDimension.Width / fitRate;
            float fitHeight = image.PhysicalDimension.Height / fitRate;

            //Draw image
            page.Canvas.DrawImage(image, 0, 30, fitWidth, fitHeight);

            //Save the result pdf 
            string output = "ConvertImageToPDF-result.pdf";
            pdf.SaveToFile(output);
            pdf.Close();

            //Launch the Pdf file
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
