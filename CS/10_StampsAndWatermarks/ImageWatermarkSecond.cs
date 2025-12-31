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
            // Load a PDF document from the disk.
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile("../../../../../../Data/PDFTemplate_N.pdf");

            // Load an image from a file.
            Image image = Image.FromFile("../../../../../../Data/E-logo.png");

            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
             System.IO.FileStream fs = System.IO.File.OpenRead(TestUtil.DataPath + "Demo/E-logo.png");
            PdfImage pdfImage = PdfImage.FromStream(fs);
            */

            // Adjust the size of the image.
            int width = image.Width;
            int height = image.Height;
            float scale = 1.5f;
            Size size = new Size((int)(width * scale), (int)(height * scale));
            Bitmap scaledImage = new Bitmap(image, size);

            // Convert the scaled image to a PDF image.
            PdfImage pdfImage = PdfImage.FromImage(scaledImage);

            // Get the first page from the document.
            PdfPageBase page = doc.Pages[0];

            // Specify the position on the page to insert the image.
            PointF position = new PointF(160, 260);

            // Save the current state of the canvas and set transparency for the image.
            page.Canvas.Save();
            page.Canvas.SetTransparency(0.5f, 0.5f, PdfBlendMode.Multiply);

            // Draw the image on the page using the specified position.
            page.Canvas.DrawImage(pdfImage, position);

            // Restore the previous state of the canvas.
            page.Canvas.Restore();

            // Save the modified PDF document to a file.
            string output = "ImageWatermarkSecondApproach_out.pdf";
            doc.SaveToFile(output, FileFormat.PDF);

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
