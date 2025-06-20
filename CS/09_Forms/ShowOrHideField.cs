using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Actions;
using Spire.Pdf.Annotations;
using Spire.Pdf.ColorSpace;
using Spire.Pdf.Conversion;
using Spire.Pdf.Fields;
using Spire.Pdf.Graphics;
using Spire.Pdf.Widget;

namespace ShowOrHideField
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new instance of PdfDocument
            PdfDocument pdf = new PdfDocument();

            // Load the PDF document from the specified file path
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\FormField.pdf");

            // Iterate through all the pages in the PDF document
            for (int c = 0; c < pdf.Pages.Count; c++)
            {
                // Get the form widget from the PDF document
                PdfFormWidget formWidget = pdf.Form as PdfFormWidget;

                // Iterate through all the fields in the form
                for (int i = 0; i < formWidget.FieldsWidget.List.Count; i++)
                {
                    // Get the current field from the FieldsWidget list
                    PdfField field = formWidget.FieldsWidget.List[i] as PdfField;

                    // Check if the field is a TextBoxField
                    if (field is PdfTextBoxFieldWidget)
                    {
                        // Cast the field to PdfTextBoxFieldWidget
                        PdfTextBoxFieldWidget widget = field as PdfTextBoxFieldWidget;

                        // Create a new hide action for the field
                        PdfHideAction hideAction = new PdfHideAction(widget.Name, true);

                        // Set the mouse down action of the TextBoxField to the hide action
                        widget.MouseDown = hideAction;
                    }
                }
            }

            // Save the modified PDF document to the specified file
            string output = @"ShowOrHideField.pdf";
            pdf.SaveToFile(output);

            // Dispose the PdfDocument object
            pdf.Dispose();

            //Launch the Pdf file
            PDFDocumentViewer(output);
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
