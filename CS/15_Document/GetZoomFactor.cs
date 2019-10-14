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
            //Create a pdf document
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\GetZoomFactor.pdf");
            PdfGoToAction action = doc.AfterOpenAction as PdfGoToAction;
            float zoomvalue = action.Destination.Zoom;
            MessageBox.Show("The zoom factor of the document is "+ zoomvalue*100 +"%.");
        }

    }
}
