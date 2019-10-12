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
            //Load a pdf document
            string input = @"..\..\..\..\..\..\Data\RadioButton.pdf";
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(input);

            //Get pdf forms
            PdfFormWidget formWidget = pdf.Form as PdfFormWidget;

            //Find the radio button field and select the second item
            for (int i = 0; i < formWidget.FieldsWidget.List.Count; i++)
            {
                PdfField field = formWidget.FieldsWidget.List[i] as PdfField;

                if (field is PdfRadioButtonListFieldWidget)
                {
                    PdfRadioButtonListFieldWidget radioButton = field as PdfRadioButtonListFieldWidget;
                    if (radioButton.Name == "RadioButton")
                    {
                        radioButton.SelectedIndex = 1;
                    }
                }
            }

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
