using Spire.Pdf;
using Spire.Pdf.Actions;
using Spire.Pdf.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            //Create a pdf document
            PdfDocument doc = new PdfDocument();

            //Load file from disk.
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\Sample.pdf");

            //Create a PdfDestination with specific page, location and 50% zoom factor
            PdfDestination dest = new PdfDestination(2, new PointF(0, 100), 0.5f);

            //Create GoToAction with dest
            PdfGoToAction action = new PdfGoToAction(dest);

            //Set open action
            doc.AfterOpenAction = action;

            String result = "SpecifyPageToView_out.pdf";

            //Save the document
            doc.SaveToFile(result);
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
