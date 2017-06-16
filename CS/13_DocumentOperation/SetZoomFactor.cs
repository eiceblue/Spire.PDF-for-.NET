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
            //pdf file 
            string input = "..\\..\\..\\..\\..\\..\\Data\\Sample5.pdf";

            //open a pdf document
            PdfDocument doc = new PdfDocument(input);

            //get the first page
            PdfPageBase page = doc.Pages[0];

            //set pdf destination
            PdfDestination dest = new PdfDestination(page);
            dest.Mode = PdfDestinationMode.Location;
            dest.Location = new PointF(-40f, -40f);
            dest.Zoom = 0.6f;

            //set action
            PdfGoToAction gotoAction = new PdfGoToAction(dest);
            doc.AfterOpenAction = gotoAction;

            string output = "SetZoomFactor.pdf";

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
