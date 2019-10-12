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
			//Load a pdf document
            string input = @"..\..\..\..\..\..\Data\ToTiff.pdf";
            PdfDocument document = new PdfDocument();
			document.LoadFromFile(input);
            JoinTiffImages(SaveAsImage(document), "result.tiff", EncoderValue.CompressionLZW);
            System.Diagnostics.Process.Start("result.tiff");
        }

        private static Image[] SaveAsImage(PdfDocument document)
        {
            Image[] images = new Image[document.Pages.Count];
            for (int i = 0; i < document.Pages.Count; i++)
            {
                //Use the document.SaveAsImage() method save the pdf as image
                images[i] = document.SaveAsImage(i);
            }
            return images;
        }

        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
            for (int j = 0; j < encoders.Length; j++)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            throw new Exception(mimeType + " mime type not found in ImageCodecInfo");
        }
        public static void JoinTiffImages(Image[] images, string outFile, EncoderValue compressEncoder)
        {
            //Use the save encoder
            System.Drawing.Imaging.Encoder enc = System.Drawing.Imaging.Encoder.SaveFlag;
            EncoderParameters ep = new EncoderParameters(2);
            ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.MultiFrame);
            ep.Param[1] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)compressEncoder);
            Image pages = images[0];
            int frame = 0;
            ImageCodecInfo info = GetEncoderInfo("image/tiff");
            foreach (Image img in images)
            {
                if (frame == 0)
                {
                    pages = img;
                    //Save the first frame
                    pages.Save(outFile, info, ep);
                }
                else
                {
                    //Save the intermediate frames
                    ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.FrameDimensionPage);
                    pages.SaveAdd(img, ep);
                }
                if (frame == images.Length - 1)
                {
                    //Flush and close.
                    ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.Flush);
                    pages.SaveAdd(ep);
                }
                frame++;
            }
        }
    }
}
