using Spire.Pdf;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SetImageSize
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

            //Create one page
            PdfPageBase page = doc.Pages.Add();

            //Load an image
            PdfImage image = PdfImage.FromFile(@"..\..\..\..\..\..\Data\ChartImage.png");

            //Set the width and height of image
            float width = image.Width * 0.75f;
            float height = image.Height * 0.75f;

            //Define a position to draw image
            float x = (page.Canvas.ClientSize.Width - width) / 2;
            float y = 60f;

            //Draw image on page canvas
            page.Canvas.DrawImage(image, x, y, width, height);

            String result = "SetImageSize_out.pdf";

            //Save the document
            doc.SaveToFile(result);

            //Launch the Pdf file
            PDFDocumentViewer(result);
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
