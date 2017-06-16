using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;

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
            //Create a pdf document.
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\Sample2.pdf");

            StringBuilder buffer = new StringBuilder();
            IList<Image> images = new List<Image>();

            foreach (PdfPageBase page in doc.Pages)
            {
                buffer.Append(page.ExtractText());
                foreach (Image image in page.ExtractImages())
                {
                    images.Add(image);
                }
            }

            doc.Close();

            //save text
            String fileName = "TextInPdf.txt";
            File.WriteAllText(fileName, buffer.ToString());

            //save image
            int index = 0;
            foreach (Image image in images)
            {
                String imageFileName
                    = String.Format("Image-{0}.png", index++);
                image.Save(imageFileName, ImageFormat.Png);
            }

            //Launching the Pdf file.
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
