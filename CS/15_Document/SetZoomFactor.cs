using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Actions;
using Spire.Pdf.General;
namespace SetZoomFactor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Define the path of the PDF file
            string input = "..\\..\\..\\..\\..\\..\\Data\\SetZoomFactor.pdf";

            // Create a new PDF document object
            PdfDocument doc = new PdfDocument();

            // Load the PDF file from the specified path into the document object
            doc.LoadFromFile(input);

            // Get the first page of the PDF document
            PdfPageBase page = doc.Pages[0];

            // Set the destination for the PDF document
            PdfDestination dest = new PdfDestination(page);

            // Set the mode of the destination to location
            dest.Mode = PdfDestinationMode.Location;

            // Set the location of the destination to (-40, -40)
            dest.Location = new PointF(-40f, -40f);

            // Set the zoom factor of the destination to 0.6
            dest.Zoom = 0.6f;

            // Create a new GoTo action with the specified destination
            PdfGoToAction gotoAction = new PdfGoToAction(dest);

            // Set the after open action of the document to the GoTo action
            doc.AfterOpenAction = gotoAction;

            // Define the output path for the modified PDF document
            string output = "SetZoomFactor.pdf";

            // Save the modified PDF document to the specified output path
            doc.SaveToFile(output);

            //Launch the Pdf file
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
