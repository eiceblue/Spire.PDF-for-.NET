using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;


namespace Decryption
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a pdf document.
            String encryptedPdf = @"..\..\..\..\..\..\Data\Encrypted.pdf";
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(encryptedPdf, "test");

            //extract image
            Image image = doc.Pages[0].ImagesInfo[0].Image;

            doc.Close();

            //Save image file.
            image.Save("Wikipedia_Science.png", System.Drawing.Imaging.ImageFormat.Png);

            //Launching the image file.
            ImageViewer("Wikipedia_Science.png");
        }

        private void ImageViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }
    }
}
