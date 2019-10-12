using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FlattenFormField
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Pdf file path
            string input = @"..\..\..\..\..\..\Data\FlattenFormField.pdf";

            //Open pdf document
            PdfDocument doc = new PdfDocument();
	    doc.LoadFromFile(input);
            //Flatten form fields
            doc.Form.IsFlatten = true;

            string output = "FlattenFormField.pdf";

            //Save pdf document
            doc.SaveToFile(output);

            //Launch the pdf file
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
