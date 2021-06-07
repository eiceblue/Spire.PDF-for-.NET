using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;


namespace ConvertImageStreamToPDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a pdf document with a section and page added.
            PdfDocument pdf = new PdfDocument();
            PdfSection section = pdf.Sections.Add();
            PdfPageBase page = section.Pages.Add();

            // Create a FileStream object to read the imag file
            FileStream fs = File.OpenRead(@"..\..\..\..\..\..\Data\bg.png");
            // Read the image into Byte array
            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, data.Length);
            // Create a MemoryStream object from image Byte array
            MemoryStream ms = new MemoryStream(data);
            // Specify the image source as MemoryStream
            PdfImage image = PdfImage.FromStream(ms);

            //Set image display location and size in PDF
            //Calculate rate
            float widthFitRate = image.PhysicalDimension.Width / page.Canvas.ClientSize.Width;
            float heightFitRate = image.PhysicalDimension.Height / page.Canvas.ClientSize.Height;
            float fitRate = Math.Max(widthFitRate, heightFitRate);
            //Calculate the size of image 
            float fitWidth = image.PhysicalDimension.Width / fitRate;
            float fitHeight = image.PhysicalDimension.Height / fitRate;
            //Draw image
            page.Canvas.DrawImage(image, 0, 30, fitWidth, fitHeight);

            //save and launch the file
            string output = "ConvertImageStreamToPDF.pdf";
            pdf.SaveToFile(output);
            System.Diagnostics.Process.Start(output);
        }
    }
}
