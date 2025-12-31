using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace PageToPNG
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

            //Convert a particular page to png
            //Set page index and image name
            int pageIndex = 1;
            String fileName = "PageToPNG.png";
            //Save page to image
            using (Image image = pdf.SaveAsImage(pageIndex, 300, 300))
            {
                image.Save(fileName, ImageFormat.Png);
            }

            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
            using (var image = pdf.SaveAsImage(pageIndex, PdfImageType.Bitmap))
            {                
                System.IO.FileStream fileStream = new System.IO.FileStream(outputFile + fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                
                image.CopyTo(fileStream);
                fileStream.Flush();
            }
            */

            //////////////////Use the following code for NET Core dlls/////////////////////////
            /*
            using (Image image = pdf.SaveAsImage(pageIndex, PdfImageType.Bitmap, 300, 300))
            {
                image.Save(outputFile + fileName, ImageFormat.Png);
            }
            */

            pdf.Close();
        }

    }
}
