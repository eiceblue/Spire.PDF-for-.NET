using System;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Widget;
using Spire.Pdf.Fields;
using System.Drawing;
using Spire.Pdf.Graphics;

namespace AddRadioButtonCaption
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

            //Find the radio button field and add capture
            for (int i = 0; i < formWidget.FieldsWidget.List.Count; i++)
            {
                PdfField field = formWidget.FieldsWidget.List[i] as PdfField;

                if (field is PdfRadioButtonListFieldWidget)
                {
                    PdfRadioButtonListFieldWidget radioButton = field as PdfRadioButtonListFieldWidget;
                    if (radioButton.Name == "RadioButton")
                    {
                        //Get the page
                        PdfPageBase page = radioButton.Page;

                        //Set capture name
                        string text = "Radio button caption";
                        //Set font, pen and brush
                        PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 12f);
                        PdfPen pen = new PdfPen(Color.Red, 0.02f);
                        PdfSolidBrush brush = new PdfSolidBrush(Color.Red);
                        //Set the capture location
                        float x = radioButton.Location.X;
                        float y = radioButton.Location.Y - font.MeasureString(text).Height - 10; ;
                        //Draw capture
                        page.Canvas.DrawString(text, font, pen, brush, x, y);
                    }
                }
            }

            String result = "AddRadioButtonCaption_out.pdf";

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
