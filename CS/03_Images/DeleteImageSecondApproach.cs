using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DeleteImageSecondApproach
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
            
            //Load the document from disk
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\DeleteImage.pdf");

            //Get the first page
            PdfPageBase page = doc.Pages[0];

            //Delete the first image on the page
            page.DeleteImage(0);

            //Save the document
            doc.SaveToFile("Output.pdf");

            //Launch the Pdf file
            PDFDocumentViewer("Output.pdf");
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
