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
            //Pdf file path
            string input = @"..\..\..\..\..\..\Data\FormField.pdf";
            //Open pdf document
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(input);

            PdfFormWidget form = pdf.Form as PdfFormWidget;
            for (int i = 0; i < form.FieldsWidget.List.Count; i++)
            {
                PdfField field = form.FieldsWidget.List[i] as PdfField;
                if (field is PdfTextBoxFieldWidget)
                {
                    PdfTextBoxFieldWidget textbox = field as PdfTextBoxFieldWidget;

                    //Find the textbox named total
                    if (textbox.Name == "TextBox1")
                    {
                        // Change field location
                        textbox.Location = new PointF(390, 525);
                    }
                }
            }


            String result = "ChangeFormFieldLocation_out.pdf";

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
