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
            //pdf file 
            string input = "..\\..\\..\\..\\..\\..\\..\\Data\\FormField.pdf";

            //open pdf document
            PdfDocument doc = new PdfDocument(input);

            //get pdf form
            PdfFormWidget formWidget = doc.Form as PdfFormWidget;

            //find the particular form field and delete it
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

            //save pdf document
            doc.SaveToFile(output);

            //Launching the Pdf file
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
