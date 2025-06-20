using System;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Widget;

namespace SetExportValueForCheckbox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Input and output file paths
            string input = @"..\..\..\..\..\..\Data\SetExportValueForCheckbox.pdf";
            string result = "SetExportValueForCheckbox_result.pdf";

            // Create a new instance of PdfDocument
            PdfDocument pdf = new PdfDocument();

            // Load the PDF document from the specified file path
            pdf.LoadFromFile(input);

            // Get the form widget from the loaded PDF document
            PdfFormWidget formWidget = pdf.Form as PdfFormWidget;

            // Initialize a counter variable
            int count = 1;

            // Traverse all fields in the FieldsWidget
            foreach (PdfFieldWidget field in formWidget.FieldsWidget)
            {
                // Check if the field is a checkbox
                if (field is PdfCheckBoxWidgetFieldWidget)
                {
                    // Cast the field to PdfCheckBoxWidgetFieldWidget
                    PdfCheckBoxWidgetFieldWidget checkbox = field as PdfCheckBoxWidgetFieldWidget;

                    // Set the export value for the checkbox
                    checkbox.SetExportValue("True" + (count++));
                }
            }

            // Save the modified PDF document to the specified file in PDF format
            pdf.SaveToFile(result, FileFormat.PDF);

            //Show the result file
            PDFDocumentViewer(result);
        }
        private void PDFDocumentViewer(string filename)
        {
            try
            {
                System.Diagnostics.Process.Start(filename);
            }
            catch { }
        }
    }
}
