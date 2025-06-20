using Spire.Pdf;
using Spire.Pdf.Actions;
using Spire.Pdf.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SetMagnificationToFitHeight
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Create a pdf document and load file from disk
            PdfDocument myPdf = new PdfDocument();
            myPdf.LoadFromFile(@"..\..\..\..\..\..\Data\SampleB_1.pdf");

            // Get the first page
            PdfPageBase page = myPdf.Pages[0];

            // Create a PdfDestination with specific page, location
            PdfDestination dest = new PdfDestination(page, new PointF(-40f, -40f));

            // Set the Magnification to Fit-Height
            dest.Mode = PdfDestinationMode.FitV;

            //Create GoToAction with dest
            PdfGoToAction gotoaction = new PdfGoToAction(dest);

            // Set open action
            myPdf.AfterOpenAction = gotoaction;
            myPdf.ViewerPreferences.PageMode = PdfPageMode.UseOutlines;

            // Save the file
            myPdf.SaveToFile("FitHeight.pdf");
            myPdf.Close();

            // Launch the pdf file
            PDFDocumentViewer("FitHeight.pdf");
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
