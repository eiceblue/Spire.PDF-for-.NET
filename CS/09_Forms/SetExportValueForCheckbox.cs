using System;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Widget;

namespace SetExportValueForCheckbox
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
            string input = @"..\..\..\..\..\..\Data\SetExportValueForCheckbox.pdf";
            string result = "SetExportValueForCheckbox_result.pdf";

            PdfDocument pdf = new PdfDocument();
            //Load from disk
            pdf.LoadFromFile(input);
            PdfFormWidget formWidget = pdf.Form as PdfFormWidget;
            int count = 1;
            //Traverse all FieldsWidget
            foreach (PdfFieldWidget field in formWidget.FieldsWidget)
            {
                //Find the checkbox
                if (field is PdfCheckBoxWidgetFieldWidget)
                {
                    PdfCheckBoxWidgetFieldWidget checkbox = field as PdfCheckBoxWidgetFieldWidget;
                    //Set export value for checkbox
                    checkbox.SetExportValue("True" + (count++));
                }
            }
            //Save the pdf file
            pdf.SaveToFile(result, FileFormat.PDF);
            //Show the result file
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
