using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Windows.Forms;
using Spire.Pdf;
using System.Drawing.Imaging;

namespace ToTiff
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load a pdf document
            string input = @"..\..\..\..\..\..\Data\ToTiff.pdf";
            PdfDocument document = new PdfDocument();
            document.LoadFromFile(input);

            // Convert the pdf document to images and save them
            JoinTiffImages(SaveAsImage(document), "result.tiff", EncoderValue.CompressionLZW);

        }

        private static Image[] SaveAsImage(PdfDocument document)
        {
            Image[] images = new Image[document.Pages.Count];
            for (int i = 0; i < document.Pages.Count; i++)
            {
                // Use the document.SaveAsImage() method to save the pdf page as an image
                images[i] = document.SaveAsImage(i);
            }
            return images;
        }

        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            // Get the image encoders available on the system
            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();

            // Find the encoder that matches the specified MIME type
            for (int j = 0; j < encoders.Length; j++)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }

            // Throw an exception if the specified MIME type is not found
            throw new Exception(mimeType + " mime type not found in ImageCodecInfo");
        }

        public static void JoinTiffImages(Image[] images, string outFile, EncoderValue compressEncoder)
        {
            // Use the save encoder
            System.Drawing.Imaging.Encoder enc = System.Drawing.Imaging.Encoder.SaveFlag;
            EncoderParameters ep = new EncoderParameters(2);

            // Set the parameters for saving the images as a multi-frame TIFF file with specified compression
            ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.MultiFrame);
            ep.Param[1] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)compressEncoder);

            Image pages = images[0];
            int frame = 0;

            // Get the encoder info for TIFF format
            ImageCodecInfo info = GetEncoderInfo("image/tiff");

            foreach (Image img in images)
            {
                if (frame == 0)
                {
                    pages = img;
                    // Save the first frame
                    pages.Save(outFile, info, ep);
                }
                else
                {
                    // Save the intermediate frames as additional pages in the TIFF file
                    ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.FrameDimensionPage);
                    pages.SaveAdd(img, ep);
                }

                if (frame == images.Length - 1)
                {
                    // Flush and close the TIFF file after saving all frames
                    ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.Flush);
                    pages.SaveAdd(ep);
                }

                frame++;
            }
        }
    }
}
