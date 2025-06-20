using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChangePdfVersion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Open a PDF document
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\ChangePdfVersion.pdf");

            // Change the PDF version to Version 1.6
            doc.FileInfo.Version = PdfVersion.Version1_6;

            // Save the modified PDF document to a new file
            doc.SaveToFile("ChangePdfVersion_result.pdf");

            //Launch the Pdf file.
            PDFDocumentViewer("ChangePdfVersion_result.pdf");
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
