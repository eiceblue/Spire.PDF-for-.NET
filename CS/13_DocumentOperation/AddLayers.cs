using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace AddLayers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //create a pdf document
            PdfDocument doc = new PdfDocument();

            //add a new page
            PdfPageBase page = doc.Pages.Add();

            //create a layer named "red line"
            PdfPageLayer layer = page.PageLayers.Add("red line");
            layer.Graphics.DrawLine(new PdfPen(PdfBrushes.Red, 1), new PointF(0, 100), new PointF(100, 100));

            //create a layer named "blue line"
            layer = page.PageLayers.Add("blue line");
            layer.Graphics.DrawLine(new PdfPen(PdfBrushes.Blue, 1), new PointF(0, 150), new PointF(100, 150));

            //create a layer named "green line"
            layer = page.PageLayers.Add("green line");
            layer.Graphics.DrawLine(new PdfPen(PdfBrushes.Green, 1), new PointF(0, 200), new PointF(100, 200));

            string output = "AddLayers.pdf";

            //save pdf document
            doc.SaveToFile(output);

            //Launching the Pdf file
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
