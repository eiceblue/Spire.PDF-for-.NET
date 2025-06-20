using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Widget;
using Spire.Pdf.Fields;

namespace DetermineRequiredField
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load a pdf document
            string input = @"..\..\..\..\..\..\Data\DetermineRequiredField.pdf";
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(input);

            // Get pdf forms
            PdfFormWidget formWidget = doc.Form as PdfFormWidget;

            // Find the particular form field and determine if it is marked as required or not
            for (int i = 0; i < formWidget.FieldsWidget.List.Count; i++)
            {
                PdfField field = formWidget.FieldsWidget.List[i] as PdfField;

                // Check if the field is a textbox field
                if (field is PdfTextBoxFieldWidget)
                {
                    // Cast the field to a textbox field
                    PdfTextBoxFieldWidget textbox = field as PdfTextBoxFieldWidget;

                    // Check if the field name matches "username"
                    if (textbox.Name == "username")
                    {
                        // Mark the field as required
                        textbox.Required = true;
                    }

                    // Check if the field name matches "password2"
                    if (textbox.Name == "password2")
                    {
                        // Mark the field as not required
                        textbox.Required = false;
                    }
                }
            }

            string output = "DetermineRequiredField.pdf";

            // Save the modified pdf document
            doc.SaveToFile(output);

            //Launch the file
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
