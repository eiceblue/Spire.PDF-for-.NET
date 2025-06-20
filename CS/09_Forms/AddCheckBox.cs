using Spire.Pdf;
using Spire.Pdf.Fields;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AddCheckBox
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

            // Load an existing PDF file into the document
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\SampleB_1.pdf");

            // Allow the document to create form fields
            doc.AllowCreateForm = true;

            // Create a checkbox field on the first page of the document with the field name "fieldID"
            PdfCheckBoxField checkboxField = new PdfCheckBoxField(doc.Pages[0], "fieldID");

            // Set the size and position of the checkbox field
            float checkboxWidth = 40;
            float checkboxHeight = 40;
            checkboxField.Bounds = new RectangleF(60, 300, checkboxWidth, checkboxHeight);

            // Set the border width of the checkbox field
            checkboxField.BorderWidth = 0.75f;

            // Set the initial checked state of the checkbox field to true
            checkboxField.Checked = true;

            // Set the style of the checkbox field to "Check"
            checkboxField.Style = PdfCheckBoxStyle.Check;

            // Set the checkbox field as a required field
            checkboxField.Required = true;

            // Add the checkbox field to the form fields collection of the PDF document
            doc.Form.Fields.Add(checkboxField);

            // Specify the output file name
            String result = "AddCheckBox-result.pdf";

            //Save to file
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
