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
            // Create a new PDF document
            PdfDocument doc = new PdfDocument();

            // Load a PDF file from disk
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\Sample.pdf");

            // Get the second page
            PdfPageBase page = doc.Pages[1];

            // Create a PdfDestination object with specific page,location (0, 100)
            PdfDestination dest = new PdfDestination(page, new PointF(0, 100));

            // Create a PdfGoToAction object with the destination
            PdfGoToAction action = new PdfGoToAction(dest);

            // Set the open action of the document to the created action
            doc.AfterOpenAction = action;

            // Specify the output file path for saving the modified document
            string result = "SpecifyPageToView_out.pdf";

            // Save the modified document to the specified file
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
