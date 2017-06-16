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
            //pdf file
            String file = @"..\..\..\..\..\..\Data\Sample4.pdf";

            //open pdf document
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(file);

            //save to images
            for (int i = 0; i < doc.Pages.Count; i++)
            {
                String fileName = String.Format("Sample4-img-{0}.png", i);
                using (Image image = doc.SaveAsImage(i))
                {
                    image.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                    System.Diagnostics.Process.Start(fileName);
                }
            }

            doc.Close();
        }
    }
}
