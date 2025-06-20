using System;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Widget;
using Spire.Pdf.Fields;
using System.Drawing;

namespace ChangeFormFieldLocation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Pdf file path
            string input = @"..\..\..\..\..\..\Data\FormField.pdf";

            // Open pdf document
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(input);

            PdfFormWidget form = pdf.Form as PdfFormWidget;

            // Iterate through each field in the form
            for (int i = 0; i < form.FieldsWidget.List.Count; i++)
            {
                // Get the current field
                PdfField field = form.FieldsWidget.List[i] as PdfField;

                // Check if the field is a textbox field
                if (field is PdfTextBoxFieldWidget)
                {
                    // Cast the field to a textbox field
                    PdfTextBoxFieldWidget textbox = field as PdfTextBoxFieldWidget;

                    // Find the textbox named "TextBox1"
                    if (textbox.Name == "TextBox1")
                    {
                        // Change the location of the field
                        textbox.Location = new PointF(390, 525);
                    }
                }
            }

            // Output file path
            String result = "ChangeFormFieldLocation_out.pdf";

            // Save the modified document
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
