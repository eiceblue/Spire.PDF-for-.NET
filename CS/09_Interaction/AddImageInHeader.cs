using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace AddImageInHeader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = "..\\..\\..\\..\\..\\..\\Data\\";
            //pdf file 
            string input = path + "Sample4.pdf";

            //open pdf document
            PdfDocument doc = new PdfDocument(input);

            //create a pdf image
            PdfImage headerImage = PdfImage.FromFile(path + "E-iceblue logo.png");

            //draw header image into pages
            foreach (PdfPageBase page in doc.Pages)
            {
                page.Canvas.DrawImage(headerImage, new PointF(10, 2));
            }

            string output = "AddImageInHeader.pdf";
            //Save pdf file.
            doc.SaveToFile(output);
            doc.Close();

            //Launching the Pdf file.
            PDFDocumentViewer(output);
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
