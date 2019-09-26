using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics.Layer;
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
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\AddLayers.pdf");

            PdfPageBase page = doc.Pages[0];

            //create a layer named "red line"
            PdfLayer layer = doc.Layers.AddLayer("red line",PdfVisibility.On);
            PdfCanvas pcA = layer.CreateGraphics(page.Canvas);
            pcA.DrawLine(new PdfPen(PdfBrushes.Red, 2), new PointF(100, 350), new PointF(300, 350));

            //create a layer named "blue line"
            layer = doc.Layers.AddLayer("blue line");
            PdfCanvas pcB = layer.CreateGraphics(doc.Pages[0].Canvas);
            pcB.DrawLine(new PdfPen(PdfBrushes.Blue, 2), new PointF(100, 400), new PointF(300, 400));

            //create a layer named "green line"
            layer = doc.Layers.AddLayer("green line");
            PdfCanvas pcC = layer.CreateGraphics(doc.Pages[0].Canvas);
            pcC.DrawLine(new PdfPen(PdfBrushes.Green, 2), new PointF(100, 450), new PointF(300, 450));

            string output = "AddLayers.pdf";

            //save the pdf document
            doc.SaveToFile(output);

            //view the document
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
