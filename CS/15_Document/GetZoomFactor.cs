using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Actions;


namespace GetZoomFactor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new instance of the PdfDocument class
            PdfDocument doc = new PdfDocument();

            // Load a PDF document from the specified file path
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\GetZoomFactor.pdf");

            // Get the AfterOpenAction of the loaded document as a PdfGoToAction object
            PdfGoToAction action = doc.AfterOpenAction as PdfGoToAction;

            // Get the zoom factor value from the destination of the action
            float zoomvalue = action.Destination.Zoom;

            // Display a message box showing the zoom factor of the document
            MessageBox.Show("The zoom factor of the document is " + zoomvalue * 100 + "%.");
        }

    }
}
