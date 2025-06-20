using Spire.Pdf.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OFDToPDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Specify the path of the input OFD file
            string inputFile = @"..\..\..\..\..\..\Data\Sample.ofd";

            // Create a new OfdConverter object with the input OFD file path
            OfdConverter converter = new OfdConverter(inputFile);

            // Convert the OFD file to PDF
            string result = "OFDToPDF.pdf";
            converter.ToPdf(result);

            //Launch the result file
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
