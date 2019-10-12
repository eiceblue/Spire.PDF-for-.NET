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

            //Save to images
            for (int i = 0; i < pdf.Pages.Count; i++)
            {
                String fileName = String.Format("ToEMF-img-{0}.emf", i);
                //Save page to images in metafile type
                using (Image image = pdf.SaveAsImage(i, PdfImageType.Metafile, 300, 300))
                {
                    image.Save(fileName, ImageFormat.Emf);
                }
            }

            pdf.Close();
        }
    }
}
