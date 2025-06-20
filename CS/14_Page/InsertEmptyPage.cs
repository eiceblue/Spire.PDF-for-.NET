using Spire.Pdf;
using Spire.Pdf.Actions;
using Spire.Pdf.General;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InsertEmptyPage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new PdfDocument object.
            PdfDocument doc = new PdfDocument();

            // Load an existing PDF document from the specified file path.
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\Sample.pdf");

            // Insert a blank page as the second page in the document.
            doc.Pages.Insert(1);

            // Specify the output file name for saving the modified document.
            String result = "InsertEmptyPage_out.pdf";

            // Save the modified document to the specified file name.
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