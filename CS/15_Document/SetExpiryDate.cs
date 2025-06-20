using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Fields;
using Spire.Pdf.Annotations;
using Spire.Pdf.Graphics;
using Spire.Pdf.Actions;
using Spire.Pdf.General;
namespace SetExpiryDate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Define the input file path for the PDF document
            String input = "..\\..\\..\\..\\..\\..\\Data\\PDFTemplate-Az.pdf";

            // Create a new PdfDocument object
            PdfDocument doc = new PdfDocument();

            // Read the PDF file from the specified input file path
            doc.LoadFromFile(input);

            // Define a JavaScript code snippet to check if the document has expired
            string javaScript = "var rightNow = new Date();"

                              + "var endDate = new Date('October 20, 2015 23:59:59');"

                              + "if(rightNow.getTime() > endDate)"

                              + "app.('This document has expired, please contact us for a new one.',1);"

                              + "this.closeDoc();";

            // Create a new PdfJavaScriptAction object with the defined JavaScript code
            PdfJavaScriptAction js = new PdfJavaScriptAction(javaScript);

            // Set the AfterOpenAction property of the PdfDocument object to the created PdfJavaScriptAction object
            doc.AfterOpenAction = js;

            // Define the output file path for the modified PDF document
            String result = "SetExpiryDate_out.pdf";

            // Save the modified PDF document to the specified output file path
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
