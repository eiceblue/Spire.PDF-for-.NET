using Spire.Pdf;
using Spire.Pdf.ColorSpace;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DrawContentWithSpotColor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Load the document from disk
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\DrawContentWithSpotColor.pdf");

            //Get the first page
            PdfPageBase page = pdf.Pages[0];

            //Initialize an instance of PdfSeparationColorSpace
            PdfSeparationColorSpace cs = new PdfSeparationColorSpace("MySpotColor", Color.DarkViolet);

            //Set tini = 1 for the cs
            PdfSeparationColor color = new PdfSeparationColor(cs, 1f);

            //Create a brush with spot color
            PdfSolidBrush brush = new PdfSolidBrush(color);

            //Draw a string
            page.Canvas.DrawString("Tint=1.0", new PdfFont(PdfFontFamily.Helvetica, 10f), brush, new PointF(160, 160));

            //Draw pie with spot color(DarkViolet)
            page.Canvas.DrawPie(brush, 148, 200, 60, 60, 360, 360);

            page.Canvas.DrawString("Tint=0.7", new PdfFont(PdfFontFamily.Helvetica, 10f), brush, new PointF(230, 160));
            color = new PdfSeparationColor(cs, 0.7f);
            brush = new PdfSolidBrush(color);
            page.Canvas.DrawPie(brush, 218, 200, 60, 60, 360, 360);         

            page.Canvas.DrawString("Tint=0.4", new PdfFont(PdfFontFamily.Helvetica, 10f), brush, new PointF(300, 160));
            color = new PdfSeparationColor(cs, 0.4f);
            brush = new PdfSolidBrush(color);
            page.Canvas.DrawPie(brush, 288, 200, 60, 60, 360, 360);

            page.Canvas.DrawString("Tint=0.1", new PdfFont(PdfFontFamily.Helvetica, 10f), brush, new PointF(370, 160));
            color = new PdfSeparationColor(cs, 0.1f);
            brush = new PdfSolidBrush(color);
            page.Canvas.DrawPie(brush, 358, 200, 60, 60, 360, 360);

            //Draw pie with spot color(Purple)
            cs = new PdfSeparationColorSpace("MySpotColor", Color.Purple);
            color = new PdfSeparationColor(cs, 1f);
            brush = new PdfSolidBrush(color);
            page.Canvas.DrawPie(brush, 148, 280, 60, 60, 360, 360);

            color = new PdfSeparationColor(cs, 0.7f);
            brush = new PdfSolidBrush(color);
            page.Canvas.DrawPie(brush, 218, 280, 60, 60, 360, 360);

            color = new PdfSeparationColor(cs, 0.4f);
            brush = new PdfSolidBrush(color);
            page.Canvas.DrawPie(brush, 288, 280, 60, 60, 360, 360);

            color = new PdfSeparationColor(cs, 0.1f);
            brush = new PdfSolidBrush(color);
            page.Canvas.DrawPie(brush, 358, 280, 60, 60, 360, 360);

            //Draw pie with spot color(DarkSlateBlue)
            cs = new PdfSeparationColorSpace("MySpotColor", Color.DarkSlateBlue);
            color = new PdfSeparationColor(cs, 1f);
            brush = new PdfSolidBrush(color);

            page.Canvas.DrawPie(brush, 148, 360, 60, 60, 360, 360);

            color = new PdfSeparationColor(cs, 0.7f);
            brush = new PdfSolidBrush(color);
            page.Canvas.DrawPie(brush, 218, 360, 60, 60, 360, 360);

            color = new PdfSeparationColor(cs, 0.4f);
            brush = new PdfSolidBrush(color);
            page.Canvas.DrawPie(brush, 288, 360, 60, 60, 360, 360);

            color = new PdfSeparationColor(cs, 0.1f);
            brush = new PdfSolidBrush(color);
            page.Canvas.DrawPie(brush, 358, 360, 60, 60, 360, 360);

            //Save the document
            pdf.SaveToFile("SpotColor.pdf");

            //View the pdf document
            PDFDocumentViewer("SpotColor.pdf");
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
