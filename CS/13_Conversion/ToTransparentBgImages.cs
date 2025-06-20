using Spire.Pdf;
using Spire.Pdf.Attachments;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToTransparentBgImages
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new PdfDocument object and load the PDF document from the specified file path.
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\ToTransparentBackgroundImages.pdf");

            // Set the conversion options for converting the PDF document to an image. In this case, it sets the background of the image to transparent.
            doc.ConvertOptions.SetPdfToImageOptions(0);

            // Convert the first page of the PDF document to an image of type Bitmap using the SaveAsImage method.
            Image image = doc.SaveAsImage(0, PdfImageType.Bitmap);

            //Write image to file
            string output = "ToTransparentBackgroundImages_output.png";
            image.Save(output, ImageFormat.Png);

            //Lacunch output
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
