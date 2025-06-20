using Spire.Pdf;
using Spire.Pdf.Fields;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AddComboBox
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

            // Create a combo box field on the first page of the document with the field name "Combox1"
            PdfComboBoxField comboBoxField = new PdfComboBoxField(doc.Pages[0], "Combox1");

            // Set the size and position of the combo box field
            comboBoxField.Bounds = new RectangleF(60, 300, 70, 30);

            // Set the border width of the combo box field
            comboBoxField.BorderWidth = 0.75f;

            // Set the font of the combo box field to Helvetica with a font size of 9
            comboBoxField.Font = new PdfFont(PdfFontFamily.Helvetica, 9f);

            // Set the combo box field as a required field
            comboBoxField.Required = true;

            // Add items to the combo box field
            comboBoxField.Items.Add(new PdfListFieldItem("Apple", "item1"));
            comboBoxField.Items.Add(new PdfListFieldItem("Banana", "item2"));
            comboBoxField.Items.Add(new PdfListFieldItem("Pear", "item3"));
            comboBoxField.Items.Add(new PdfListFieldItem("Peach", "item4"));
            comboBoxField.Items.Add(new PdfListFieldItem("Grape", "item5"));

            // Add the combo box field to the form fields collection of the PDF document
            doc.Form.Fields.Add(comboBoxField);

            // Specify the output file name
            string output = "AddComboBox-result.pdf";

            // Save the PDF document to the specified file
            doc.SaveToFile(output);

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
