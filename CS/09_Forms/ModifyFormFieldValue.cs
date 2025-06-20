using System;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Widget;
using Spire.Pdf.Fields;
namespace ModifyFormFieldValue
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Specify the path to the input PDF file.
            string input = @"..\..\..\..\..\..\Data\FormField.pdf";

            // Open the PDF document.
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(input);

            // Get the form widget from the PDF document.
            PdfFormWidget form = pdf.Form as PdfFormWidget;

            // Iterate through each field in the form.
            for (int i = 0; i < form.FieldsWidget.List.Count; i++)
            {
                // Get the current field.
                PdfField field = form.FieldsWidget.List[i] as PdfField;

                // Check if the field is a TextBox field.
                if (field is PdfTextBoxFieldWidget)
                {
                    // Convert the field to a TextBox field.
                    PdfTextBoxFieldWidget textbox = field as PdfTextBoxFieldWidget;

                    // Check if the TextBox field has a specific name.
                    if (textbox.Name == "TextBox1")
                    {
                        // Modify the text value of TextBox1.
                        textbox.Text = "New value";
                    }
                }
            }

            // Specify the path for the output PDF file.
            String result = "ModifyFormFieldValue_out.pdf";

            // Save the modified PDF document to the output file.
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
