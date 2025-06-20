using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.ColorSpace;
using Spire.Pdf.Graphics;


namespace SetSeparationColorSpace
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a pdf document
            PdfDocument pdf = new PdfDocument();

            // Add page
            PdfPageBase page = pdf.Pages.Add();

            // Initialize an instance of PdfSeparationColorSpace with RGB color
            PdfRGBColor c = Color.Purple;
            PdfSeparationColorSpace rgb = new PdfSeparationColorSpace("MySpotColor", new PdfRGBColor(c.R, c.G, c.B));

            //color space CMYK
            //PdfSeparationColorSpace cmyk = new PdfSeparationColorSpace("MySpotColor", new PdfRGBColor(c.C, c.M, c.Y, c.K));
            //color space Grayscale
            //PdfSeparationColorSpace grayscale = new PdfSeparationColorSpace("MySpotColor", new PdfRGBColor(c.Gray));

            // Set tint = 1 for the color space
            PdfSeparationColor color = new PdfSeparationColor(rgb, 1f);

            // Create a brush with spot color
            PdfSolidBrush brush = new PdfSolidBrush(color);

            // Draw pie with tint=1.0
            page.Canvas.DrawPie(brush, 10, 30, 60, 60, 360, 360);
            page.Canvas.DrawString("Tint=1.0", new PdfFont(PdfFontFamily.Helvetica, 10f), brush, new PointF(22, 100));

            // Change tint to 0.5
            color = new PdfSeparationColor(rgb, 0.5f);
            brush = new PdfSolidBrush(color);

            // Draw pie with tint=0.5
            page.Canvas.DrawPie(brush, 80, 30, 60, 60, 360, 360);
            page.Canvas.DrawString("Tint=0.5", new PdfFont(PdfFontFamily.Helvetica, 10f), brush, new PointF(92, 100));

            // Change tint to 0.25
            color = new PdfSeparationColor(rgb, 0.25f);
            brush = new PdfSolidBrush(color);

            // Draw pie with tint=0.25
            page.Canvas.DrawPie(brush, 150, 30, 60, 60, 360, 360);
            page.Canvas.DrawString("Tint=0.25", new PdfFont(PdfFontFamily.Helvetica, 10f), brush, new PointF(162, 100));

            // Save the document
            string output = "result.pdf";
            pdf.SaveToFile(output);

            //View the pdf document
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
