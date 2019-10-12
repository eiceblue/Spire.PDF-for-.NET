using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;

namespace ToImage
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
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(file);

            //Save to images
            for (int i = 0; i < doc.Pages.Count; i++)
            {
                String fileName = String.Format("ToImage-img-{0}.png", i);
                using (Image image = doc.SaveAsImage(i,300,300))
                {
                    image.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                    System.Diagnostics.Process.Start(fileName);
                }
            }

            doc.Close();
        }
    }
}
