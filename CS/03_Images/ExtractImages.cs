using Spire.Pdf;
using Spire.Pdf.Utilities;
using System;
using System.Windows.Forms;


namespace ExtractImages
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Create a PDF document
            PdfDocument doc = new PdfDocument();

            // Load a file from disk
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\ExtractImges.pdf");

            // Get the first page of the document
            PdfPageBase page = doc.Pages[0];

            // Create an instance of PdfImageHelper to work with images
            PdfImageHelper imageHelper = new PdfImageHelper();

            // Get information about the images on the page
            PdfImageInfo[] imageInfos = imageHelper.GetImagesInfo(page);

            // Extract images from the page
            int index = 0;
            foreach (PdfImageInfo info in imageInfos)
            {
                // Save each image as a PNG file with a unique name
                info.Image.Save(string.Format("Image-{0}.png", index));
                index++;
            }

            // Dispose the PDF document to release resources
            doc.Dispose();
        }
    }
}
