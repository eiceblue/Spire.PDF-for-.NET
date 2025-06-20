using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Conversion;

namespace ToPDFA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Specify the file path of the input PDF file.
            String input = @"..\..\..\..\..\..\Data\ToPDFA.pdf";

            // Create an instance of the PdfStandardsConverter class, passing the input PDF file path as a parameter.
            PdfStandardsConverter converter = new PdfStandardsConverter(input);

            // Specify the desired file name for the resulting PDFA-1b compliant PDF.
            string output = "ToPDFA-result.pdf";

            // Convert the input PDF file to PDFA-1b format and save it using the specified output file name.
            converter.ToPdfA1B(output);

            //Launch the result file.
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
