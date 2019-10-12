using Spire.Pdf;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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

            //Load a image
            PdfImage image = PdfImage.FromFile(@"..\..\..\..\..\..\Data\E-iceblueLogo.png");

            //Replace the first image on the page.
            page.ReplaceImage(0, image);

            String result = "Output.pdf";

            //Save the document
            doc.SaveToFile(result);

            //Launch the Pdf file
            PDFDocumentViewer("Output.pdf");
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
