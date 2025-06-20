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
            // Create a new PdfDocument object
            PdfDocument doc = new PdfDocument();

            // Load an existing PDF document from the specified file path
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\AddLayers.pdf");

            // Get the first page of the loaded document
            PdfPageBase page = doc.Pages[0];

            // Create a new layer named "red line" with visibility set to "On"
            PdfLayer layer = doc.Layers.AddLayer("red line", PdfVisibility.On);

            // Create a graphics context for drawing on the specified page's canvas using the created layer
            PdfCanvas pcA = layer.CreateGraphics(page.Canvas);

            // Draw a red line on the graphics context using a pen with thickness 2, starting from (100, 350) to (300, 350)
            pcA.DrawLine(new PdfPen(PdfBrushes.Red, 2), new PointF(100, 350), new PointF(300, 350));

            // Create a new layer named "blue line" without specifying visibility (default is "Off")
            layer = doc.Layers.AddLayer("blue line");

            // Create a graphics context for drawing on the first page's canvas using the newly created layer
            PdfCanvas pcB = layer.CreateGraphics(doc.Pages[0].Canvas);

            // Draw a blue line on the graphics context using a pen with thickness 2, starting from (100, 400) to (300, 400)
            pcB.DrawLine(new PdfPen(PdfBrushes.Blue, 2), new PointF(100, 400), new PointF(300, 400));

            // Create a new layer named "green line" without specifying visibility (default is "Off")
            layer = doc.Layers.AddLayer("green line");

            // Create a graphics context for drawing on the first page's canvas using the newly created layer
            PdfCanvas pcC = layer.CreateGraphics(doc.Pages[0].Canvas);

            // Draw a green line on the graphics context using a pen with thickness 2, starting from (100, 450) to (300, 450)
            pcC.DrawLine(new PdfPen(PdfBrushes.Green, 2), new PointF(100, 450), new PointF(300, 450));

            // Specify the output file name for the modified PDF
            string output = "AddLayers.pdf";

            // Save the modified PDF document to the specified output file
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
