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
using Spire.Pdf.Graphics;
namespace AddRadioButtonField
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = @"..\..\..\..\..\..\Data\FormFieldTemplate.pdf";

            //Open pdf document
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(input);

            //Get the first page
            PdfPageBase page = pdf.Pages[0];

            //As for existing pdf, the property needs to be set as true
            pdf.AllowCreateForm = true;

            //Create a new pdf font
            PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 12f, PdfFontStyle.Bold);

            //Create a pdf brush
            PdfBrush brush = PdfBrushes.Black;

            float x = 50;
            float y = 550;
            float tempX = 0;

            string text = "RadioButton: ";

            //Draw a text into page
            page.Canvas.DrawString(text, font, brush, x, y);

            tempX = font.MeasureString(text).Width + x + 15;

            //Create a pdf radio button field
            PdfRadioButtonListField radioButton = new PdfRadioButtonListField(page, "RadioButton");
            radioButton.Required = true;
            PdfRadioButtonListItem fieldItem = new PdfRadioButtonListItem();
            fieldItem.BorderWidth = 0.75f;
            fieldItem.Bounds = new RectangleF(tempX, y, 15, 15);
            radioButton.Items.Add(fieldItem);

            //Add the radio button field into pdf document
            pdf.Form.Fields.Add(radioButton);

            String result = "AddRadioButtonField_out.pdf";

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
