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
            }

            pdf.Close();
        }

    }
}
