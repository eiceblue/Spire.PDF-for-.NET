using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SaveMultiplePagesToOneSvg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Load the PDF document
            PdfDocument pdfDocument = new PdfDocument();
            pdfDocument.LoadFromFile(@"..\..\..\..\..\..\Data\GetPageInfo.pdf");

            // Set the conversion option to output a single SVG file for multi-page PDF documents
            pdfDocument.ConvertOptions.OutputToOneSvg = true;

            // Save the converted SVG file
            string result = "output.svg";
            pdfDocument.SaveToFile(result, FileFormat.SVG);

            // Close the PDF document
            pdfDocument.Close();

            //Launch the Svg file
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
