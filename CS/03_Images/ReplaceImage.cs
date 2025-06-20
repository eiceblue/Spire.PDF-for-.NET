using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReplaceImage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Create a pdf document
            PdfDocument doc = new PdfDocument();

            //Load file from disk.
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\ReplaceImage.pdf");

            //Get the first page.
            PdfPageBase page = doc.Pages[0];

            //Create PdfImageHelper object to get Image from page
            PdfImageHelper helper = new PdfImageHelper();
            Spire.Pdf.Utilities.PdfImageInfo[] images = helper.GetImagesInfo(page);

            //Replace the first image on the page.
            helper.ReplaceImage(images[0], PdfImage.FromFile(@"..\..\..\..\..\..\Data\E-iceblueLogo.png"));

            String result = "ReplaceImage_out.pdf";

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
