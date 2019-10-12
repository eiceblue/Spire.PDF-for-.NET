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
namespace DeleteFormField
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Load a pdf document
            string input = @"..\..\..\..\..\..\Data\DeleteFormField.pdf";
            PdfDocument doc = new PdfDocument();
	    doc.LoadFromFile(input);

            //Get pdf forms
            PdfFormWidget formWidget = doc.Form as PdfFormWidget;

            //Find the particular form field and delete it
            for (int i = 0; i < formWidget.FieldsWidget.List.Count; i++)
            {
                PdfField field = formWidget.FieldsWidget.List[i] as PdfField;

                if (field is PdfTextBoxFieldWidget)
                {
                    PdfTextBoxFieldWidget textbox = field as PdfTextBoxFieldWidget;
                    if (textbox.Name == "password2")
                    {
                        formWidget.FieldsWidget.Remove(textbox);
                    }
                }
            }
            string output = "DeleteFormField.pdf";

            //Save the pdf document
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
