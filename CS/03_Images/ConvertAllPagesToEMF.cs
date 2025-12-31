using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace ConvertAllPagesToEMF
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
            String file = @"..\..\..\..\..\..\Data\ToImage.pdf";

            //Open pdf document
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(file);

            // Iterate through each page
            for (int i = 0; i < pdf.Pages.Count; i++)
            {
                String fileName = String.Format("ToEMF-img-{0}.emf", i);

                //Save page to images in metafile type
                using (Image image = pdf.SaveAsImage(i, PdfImageType.Metafile, 300, 300))
                {
                    image.Save(fileName, ImageFormat.Emf);
                }


                //////////////////Use the following code for netstandard dlls/////////////////////////
                /*
                using (var image = pdf.SaveAsImage(i, PdfImageType.Bitmap))
                {
                    System.IO.FileStream fileStream = new System.IO.FileStream(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                    image.CopyTo(fileStream);
                    fileStream.Flush();
                }
                */

                //////////////////Use the following code for NET Core dlls/////////////////////////
                /*
                using (Image image = pdf.SaveAsImage(i, PdfImageType.Bitmap, 300, 300))
                {
                    image.Save(fileName, ImageFormat.Emf);
                }
                */
            }

            pdf.Close();
        }
    }
}
