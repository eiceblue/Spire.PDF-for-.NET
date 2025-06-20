using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Graphics.Layer;

namespace SetLayerPrintProperties
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a Pdf document object
            PdfDocument pdf = new PdfDocument();

            // Load the original Pdf from the specified path
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\AddLayers.pdf");

            // Get the first page
            PdfPageBase page = pdf.Pages[0];

            // Create a layer named "red line" within the Pdf document
            PdfLayer layer = pdf.Layers.AddLayer("red line", PdfVisibility.On);

            // Set the print state of the layer as "Nerver"
            layer.PrintState = LayerPrintState.Nerver;

            // Draw a red line on the layer using the graphics of the page canvas
            PdfCanvas pcA = layer.CreateGraphics(page.Canvas);
            pcA.DrawLine(new PdfPen(PdfBrushes.Red, 2), new PointF(100, 350), new PointF(300, 350));

            // Save the modified document to the specified path and name it as "SetLayerPrintProperties_result.pdf"
            String result = "SetLayerPrintProperties_result.pdf";
            pdf.SaveToFile(result);

            // Close the Pdf document object
            pdf.Close();

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
