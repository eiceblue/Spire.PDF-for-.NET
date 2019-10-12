using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Spire.Pdf;

namespace PageToTIFF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Pdf file
            String file = @"..\..\..\..\..\..\Data\PageToImage.pdf";

            //Open pdf document
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(file);

            //Convert a particular page to tiff
            //Set page index and image name
            int pageIndex = 1;
            String fileName = "PageToTIFF.tiff";
            JoinTiffImages(pdf.SaveAsImage(pageIndex), fileName, EncoderValue.CompressionLZW);
            pdf.Close();
        }

        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            //Get encoder information of all image type
            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
            //Find the information of tiff type
            for (int j = 0; j < encoders.Length; j++)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            throw new Exception(mimeType + " mime type not found in ImageCodecInfo");
        }
        public static void JoinTiffImages(Image image, string outFile, EncoderValue compressEncoder)
        {
            //Use the save encoder
            Encoder enc = Encoder.SaveFlag;
            EncoderParameters ep = new EncoderParameters(2);
            ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.MultiFrame);
            ep.Param[1] = new EncoderParameter(Encoder.Compression, (long)compressEncoder);
            //Get the information of tiff type
            ImageCodecInfo info = GetEncoderInfo("image/tiff");
            //Save to image
            image.Save(outFile, info, ep);
        }
    }
}
