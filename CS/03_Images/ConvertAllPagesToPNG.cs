using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Spire.Pdf;


namespace ConvertAllPagesToPNG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String file = @"..\..\..\..\..\..\Data\ToImage.pdf";

            //Open pdf document
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(file);

            // Iterate through each page
            for (int i = 0; i < pdf.Pages.Count; i++)
            {
                String fileName = String.Format("ToPNG-img-{0}.png", i);

                //Save page to images in PNG type
                using (Image image = pdf.SaveAsImage(i, 300, 300))
                {
                    image.Save(fileName, ImageFormat.Png);
                }

                //////////////////Use the following code for netstandard dlls/////////////////////////
                /*
                using (var image = pdf.SaveAsImage(i, PdfImageType.Bitmap))
                {
                    string filename = String.Format(outputFile + i + ".bmp");
                    System.IO.FileStream fileStream = new System.IO.FileStream(filename, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                    
                    image.CopyTo(fileStream);
                    fileStream.Flush();
                }

                */
            }

            pdf.Close();
        }

    }
}
