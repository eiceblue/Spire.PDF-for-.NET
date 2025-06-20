using Spire.Pdf;
using Spire.Pdf.Fields;
using Spire.Pdf.Widget;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RecognizeRequiredField
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
           // Load a PDF document
            string input = @"..\..\..\..\..\..\Data\RecognizeRequiredField.pdf";

            // Create a new instance of PdfDocument
            PdfDocument doc = new PdfDocument();

            // Load the PDF document from the specified file path
            doc.LoadFromFile(input);

            // Get the form widget from the loaded PDF document
            PdfFormWidget formWidget = doc.Form as PdfFormWidget;

            // Iterate through all the fields in the form
            for (int i = 0; i < formWidget.FieldsWidget.List.Count; i++)
            {
                // Get the current field from the FieldsWidget list
                PdfField field = formWidget.FieldsWidget.List[i] as PdfField;

                // Check if the field is required
                if (field.Required)
                {
                    MessageBox.Show("The field named: " + field.Name + " is required");
                }
            }

        }
    }
}
