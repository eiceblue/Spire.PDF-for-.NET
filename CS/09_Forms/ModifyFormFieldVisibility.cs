using System;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Widget;
using Spire.Pdf.Fields;
namespace ModifyFormFieldVisibility
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Specify the file path for the input PDF document
            string input = @"..\..\..\..\..\..\Data\FormField.pdf";

            // Create a new instance of PdfDocument
            PdfDocument pdf = new PdfDocument();

            // Load the PDF document from the specified file path
            pdf.LoadFromFile(input);

            // Get the form widget from the loaded PDF document
            PdfFormWidget form = pdf.Form as PdfFormWidget;

            // Get the first field in the form
            PdfField field = form.FieldsWidget.List[0] as Spire.Pdf.Fields.PdfField;

            // Set the annotation flags for the field to the default value
            field.AnnotationFlags = Spire.Pdf.Annotations.PdfAnnotationFlags.Default;

            // Uncomment the following line if you want to set the field as hidden
            // field.AnnotationFlags = Spire.Pdf.Annotations.PdfAnnotationFlags.Hidden; 

            // Specify the file name for the modified PDF document
            string result = "ModifyFormFieldVisibility_out.pdf";

            // Save the modified PDF document to the specified file
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
