using System;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Widget;
using Spire.Pdf.Fields;
namespace RemoveFormField
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Input and output file paths
            string input = @"..\..\..\..\..\..\Data\RemoveFormField.pdf";
            string output = "RemoveFormField_result.pdf";
            //Create a PdfDocument
            PdfDocument pdf = new PdfDocument();
            //Load the input file from disk
            pdf.LoadFromFile(input);
            //Get form from the document
            PdfFormWidget formWidget = pdf.Form as PdfFormWidget;
            if (formWidget != null)
            {
                for (int i = 0; i <= formWidget.FieldsWidget.List.Count - 1; i++)
                {
                    //Case 1: Remove the first form field
                    if (i == 0)
                    {
                        PdfField field = formWidget.FieldsWidget.List[i] as PdfField;
                        formWidget.FieldsWidget.Remove(field);
                        break;
                    }
                }
                //Case 2: Remove all form fields
                //formWidget.FieldsWidget.Clear();

                //Save the pdf file
                pdf.SaveToFile(output);
            }
            //Launch the Pdf files
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
