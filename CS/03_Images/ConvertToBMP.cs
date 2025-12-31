using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Spire.Pdf;


namespace ConvertToBMP
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

            //Iterate through each page
            for (int i = 0; i < pdf.Pages.Count; i++)
            {
                //Save page to images in Bmp type
                String fileName = String.Format("ToBMP-img-{0}.bmp", i);
                using (Image image = pdf.SaveAsImage(i, 300, 300))
                {
                    image.Save(fileName, ImageFormat.Bmp);
                }

                //////////////////Use the following code for netstandard dlls/////////////////////////
                /*
                using (var image = pdf.SaveAsImage(i))
                {
                    string filename = String.Format(outputFile + i + ".bmp");
                    System.IO.FileStream fileStream = new System.IO.FileStream(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                    
                    image.CopyTo(fileStream);
                    fileStream.Flush();
                }

                */
            }



            pdf.Close();
        }

    }
}
