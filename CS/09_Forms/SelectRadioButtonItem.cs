using System;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Widget;
using Spire.Pdf.Fields;
namespace SelectRadioButtonItem
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
            string input = @"..\..\..\..\..\..\Data\RadioButton.pdf";

            // Create a new instance of PdfDocument
            PdfDocument pdf = new PdfDocument();

            // Load the PDF document from the specified file path
            pdf.LoadFromFile(input);

            // Get the form widget from the loaded PDF document
            PdfFormWidget formWidget = pdf.Form as PdfFormWidget;

            // Iterate through all the fields in the form
            for (int i = 0; i < formWidget.FieldsWidget.List.Count; i++)
            {
                // Get the current field from the FieldsWidget list
                PdfField field = formWidget.FieldsWidget.List[i] as PdfField;

                // Check if the field is a radio button list field
                if (field is PdfRadioButtonListFieldWidget)
                {
                    // Cast the field to PdfRadioButtonListFieldWidget
                    PdfRadioButtonListFieldWidget radioButton = field as PdfRadioButtonListFieldWidget;

                    // Check if the radio button field name matches "RadioButton"
                    if (radioButton.Name == "RadioButton")
                    {
                        // Select the second item in the radio button list
                        radioButton.SelectedIndex = 1;
                    }
                }
            }

            // Specify the file name for the modified PDF document
            String result = "SelectRadioButtonItem_out.pdf";

            //Save the document
            pdf.SaveToFile(result);

            //Launch the Pdf file
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
