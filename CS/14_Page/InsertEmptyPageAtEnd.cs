using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace InsertEmptyPageAtEnd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Load Pdf document from disk
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile("../../../../../../Data/MultipagePDF.pdf");

            //Add an empty page at the end 
            doc.Pages.Add(PdfPageSize.A4, new PdfMargins(0, 0));

            //Save the Pdf document
            string output = "InsertEmptyPageAtEnd_result.pdf";
            doc.SaveToFile(output, FileFormat.PDF);

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
