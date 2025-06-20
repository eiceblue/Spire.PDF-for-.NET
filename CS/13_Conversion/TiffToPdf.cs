using Spire.Pdf;
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

namespace TiffToPdf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             using (PdfDocument pdfDocument = new PdfDocument())
            {
                // Load Tiff file.
                Image tiffImage = Image.FromFile(@"..\..\..\..\..\..\Data\TiffToPdf.tiff");

                // Split Tiff to images.
                Image[] images = SplitTIFFImage(tiffImage);

                for (int i = 0; i < images.Length; i++)
                {
                    // Convert the image to PdfImage.
                    PdfImage pdfImg = PdfImage.FromImage(images[i]);

                    // Add a page to the PDF document.
                    PdfPageBase page = pdfDocument.Pages.Add();

                    // Scale the image.
                    float width = pdfImg.Width * 0.7f;
                    float height = pdfImg.Height * 0.7f;
                    float x = (page.Canvas.ClientSize.Width - width) / 2;

                    // Draw the image on the page.
                    page.Canvas.DrawImage(pdfImg, x, 0, width, height);
                }

                string result = "TiffToPdf-result.pdf";

                // Save the PDF document to a file.
                pdfDocument.SaveToFile(result);

                //Launch the result file
                PDFDocumentViewer(result);
            }
        }
        public static Image[] SplitTIFFImage(Image tiffImage)
        {
            int frameCount = tiffImage.GetFrameCount(FrameDimension.Page);
            Image[] images = new Image[frameCount];
            Guid objGuid = tiffImage.FrameDimensionsList[0];
            FrameDimension objDimension = new FrameDimension(objGuid);

            for (int i = 0; i < frameCount; i++)
            {
                // Select the active frame from the TIFF image.
                tiffImage.SelectActiveFrame(objDimension, i);

                using (MemoryStream ms = new MemoryStream())
                {
                    // Save the active frame as a separate TIFF image.
                    tiffImage.Save(ms, ImageFormat.Tiff);

                    // Create an Image object from the saved frame.
                    images[i] = Image.FromStream(ms);
                }
            }

            return images;
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
