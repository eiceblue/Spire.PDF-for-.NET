using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
namespace ImageWatermarkSecond
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Load Pdf document from disk
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile("../../../../../../Data/PDFTemplate_N.pdf");

            //Load an image
            Image image = Image.FromFile("../../../../../../Data/E-logo.png");

            //Adjust image size
            int width = image.Width;
            int height = image.Height;
            float schale = 1.5f;
            Size size = new Size((int)(width * schale), (int)(height * schale));
            Bitmap schaleImage = new Bitmap(image, size);

            //Insert an image into the first PDF page at specific position
            PdfImage pdfImage = PdfImage.FromImage(schaleImage);
            PdfPageBase page = doc.Pages[0];
            PointF position = new PointF(160, 260);
            page.Canvas.Save();
            page.Canvas.SetTransparency(0.5f, 0.5f, PdfBlendMode.Multiply);
            page.Canvas.DrawImage(pdfImage, position);
            page.Canvas.Restore();

            //Save the Pdf document
            string output = "ImageWatermarkSecondApproach_out.pdf";
            doc.SaveToFile(output,FileFormat.PDF);

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
