using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf.Actions;
using Spire.Pdf.General;
using Spire.Pdf;
namespace SpecifyPageToView
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
            string input = "..\\..\\..\\..\\..\\..\\Data\\Sample3.pdf";

            //open pdf document
            PdfDocument doc = new PdfDocument(input);

            //get the fourth page
            PdfPageBase page = doc.Pages[3];

            //create a destination
            PdfDestination destination = new PdfDestination(page);

            //create GoToAction instance
            PdfGoToAction action = new PdfGoToAction(destination);

            //set the action to execute when the document is opened.
            doc.AfterOpenAction = action;

            string output = "SpecifyPageToView.pdf";

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
