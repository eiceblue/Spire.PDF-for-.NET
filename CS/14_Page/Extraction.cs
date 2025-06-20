using Spire.Pdf;
using Spire.Pdf.Texts;
using Spire.Pdf.Utilities;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Extraction
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new PdfDocument object.
            PdfDocument doc = new PdfDocument();

            // Load the PDF document from the specified file path.
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\Extraction.pdf");

            // Create a StringBuilder to store extracted text and a list to store extracted images.
            StringBuilder buffer = new StringBuilder();
            IList<Image> images = new List<Image>();

            // Create PdfImageHelper
            PdfImageHelper imageHelper = new PdfImageHelper();

            // Iterate through each page of the document.
            foreach (PdfPageBase page in doc.Pages)
            {
                // Extract text from the current page.
                PdfTextExtractor pdfTextExtractor = new PdfTextExtractor(page);
                PdfTextExtractOptions pdfTextExtractOptions = new PdfTextExtractOptions();
                pdfTextExtractOptions.IsExtractAllText = true;
                buffer.Append(pdfTextExtractor.ExtractText(pdfTextExtractOptions));

                //Get images information 
                PdfImageInfo[] imageInfos = imageHelper.GetImagesInfo(page);

                // Extract images from the current page and add them to the images list
                foreach (PdfImageInfo info in imageInfos)
                {
                    images.Add(info.Image);
                }
            }

            // Close the PDF document.
            doc.Close();

            // Save the extracted text to a file with the specified file name.
            String fileName = "TextInPdf.txt";
            File.WriteAllText(fileName, buffer.ToString());

            // Save the extracted images to files.
            int index = 0;
            foreach (Image image in images)
            {
                String imageFileName = String.Format("Image-{0}.png", index++);
                image.Save(imageFileName, ImageFormat.Png);
            }

            //launch the Pdf file.
            PDFDocumentViewer(fileName);
        }

        private void PDFDocumentViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }

    }
}
