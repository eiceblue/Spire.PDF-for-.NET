using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Fields;
using Spire.Pdf.Graphics;

namespace AddTextBoxField
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

            string text = "TexBox: ";

            //Draw a text into page
            page.Canvas.DrawString(text, font, brush, x, y);

            //Add a textBox field
            tempX = font.MeasureString(text).Width + x + 15;
            PdfTextBoxField textbox = new PdfTextBoxField(page, "TextBox");
            textbox.Bounds = new RectangleF(tempX, y, 100, 15);
            textbox.BorderWidth = 0.75f;
            textbox.BorderStyle = PdfBorderStyle.Solid;
            pdf.Form.Fields.Add(textbox);

            String result = "AddTextBoxField_out.pdf";

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
