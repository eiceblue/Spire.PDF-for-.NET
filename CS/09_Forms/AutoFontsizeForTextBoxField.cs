using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Fields;
using Spire.Pdf.Graphics;
using Spire.Pdf.Widget;

namespace AutoFontsizeForTextBoxField
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            // Create a new PdfDocument object
            PdfDocument pdf = new PdfDocument();

            // Load the PDF document from the specified file
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\FormField.pdf");

            // Get the form widget from the loaded PDF document
            PdfFormWidget formWidget = pdf.Form as PdfFormWidget;

            // Iterate through each field in the form
            foreach (PdfField field in formWidget.FieldsWidget.List)
            {
                // Check if the field is a text box field
                if (field is PdfTextBoxFieldWidget)
                {
                    // Cast the field to a PdfTextBoxFieldWidget
                    PdfTextBoxFieldWidget textBoxField = field as PdfTextBoxFieldWidget;

                    // Set the font of the text box field to Arial with a size of 16
                    textBoxField.Font = new PdfTrueTypeFont(new Font("Arial", 16), true);

                    // The "true" value for FontSizeAuto ensures that the font size is automatically adjusted based on the available space
                    textBoxField.FontSizeAuto = true;

                    // Set the text value of the text box field to "e-iceblue"
                    textBoxField.Text = "e-iceblue";
                }
            }

            // Save the modified PDF document to the specified file in PDF format
            pdf.SaveToFile("setAutoFontSize.pdf", FileFormat.PDF);

            PDFDocumentViewer("setAutoFontSize.pdf");
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
