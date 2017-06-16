using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace AddImageInFooter
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
            PdfImage footerImage = PdfImage.FromFile(path + "logo2.png");

            float x=0;     
            float y=0;

            //draw footer image into pages
            foreach (PdfPageBase page in doc.Pages)
            {
                x = page.Canvas.ClientSize.Width - footerImage.PhysicalDimension.Width - 10;
                y = page.Canvas.ClientSize.Height - footerImage.PhysicalDimension.Height - 10;
                page.Canvas.DrawImage(footerImage, new PointF(x, y));
            }

            string output = "AddImageInFooter.pdf";
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
