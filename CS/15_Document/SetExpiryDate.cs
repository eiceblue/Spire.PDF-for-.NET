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
using Spire.Pdf.General.Find;
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
            String input = "..\\..\\..\\..\\..\\..\\Data\\PDFTemplate-Az.pdf";
            PdfDocument doc = new PdfDocument();

            // Read a pdf file
            doc.LoadFromFile(input);

            string javaScript = "var rightNow = new Date();"

                          + "var endDate = new Date('October 20, 2015 23:59:59');"

                          + "if(rightNow.getTime() > endDate)"

                          + "app.alert('This document has expired, please contact us for a new one.',1);"

                          + "this.closeDoc();";

            PdfJavaScriptAction js = new PdfJavaScriptAction(javaScript);

            doc.AfterOpenAction = js;


            String result = "SetExpiryDate_out.pdf";

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
