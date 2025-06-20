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
            // Specify the path of the PDF file to be processed.
            String file = @"..\..\..\..\..\..\Data\ToImage.pdf";

            // Create a new PdfDocument object.
            PdfDocument doc = new PdfDocument();

            // Load the PDF document from the specified file.
            doc.LoadFromFile(file);

            // Save each page of the PDF document as an image.
            for (int i = 0; i < doc.Pages.Count; i++)
            {
                // Generate a unique file name for each image.
                String fileName = String.Format("ToImage-img-{0}.png", i);

                // Convert the current page to an image with a resolution of 300x300 pixels.
                using (Image image = doc.SaveAsImage(i, 300, 300))
                {
                    // Save the image as a PNG file.
                    image.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);

                    // Open the saved image file using the default associated program.
                    System.Diagnostics.Process.Start(fileName);
                }
            }

            // Close the PDF document.
            doc.Close();
        }
    }
}
