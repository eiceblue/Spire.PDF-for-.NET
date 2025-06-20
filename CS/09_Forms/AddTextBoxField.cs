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
            // Specify the input file path
            string input = @"..\..\..\..\..\..\Data\FormFieldTemplate.pdf";

            // Create a new PdfDocument object
            PdfDocument pdf = new PdfDocument();

            // Load the PDF document from the specified input file
            pdf.LoadFromFile(input);

            // Get the first page of the PDF document
            PdfPageBase page = pdf.Pages[0];

            // Set the AllowCreateForm property to true for existing PDF documents
            // This allows the creation of form fields in the document
            pdf.AllowCreateForm = true;

            // Create a new PdfFont using the Helvetica font family, size 12, and bold style
            PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 12f, PdfFontStyle.Bold);

            // Create a PdfBrush for drawing black color
            PdfBrush brush = PdfBrushes.Black;

            // Specify the starting coordinates for drawing text on the page
            float x = 50;
            float y = 550;
            float tempX = 0;

            // Specify the text to be drawn on the page
            string text = "TexBox: ";

            // Draw the text on the page using the specified font, brush, and coordinates
            page.Canvas.DrawString(text, font, brush, x, y);

            // Calculate the X coordinate for placing the text box field next to the drawn text
            tempX = font.MeasureString(text).Width + x + 15;

            // Create a PdfTextBoxField with a unique name and associate it with the current PDF page
            PdfTextBoxField textbox = new PdfTextBoxField(page, "TextBox");
            textbox.Bounds = new RectangleF(tempX, y, 100, 15);
            textbox.BorderWidth = 0.75f;
            textbox.BorderStyle = PdfBorderStyle.Solid;

            // Add the text box field to the form fields collection of the PDF document
            pdf.Form.Fields.Add(textbox);

            // Specify the output file path for saving the modified PDF document
            string result = "AddTextBoxField_out.pdf";

            // Save the PDF document to the specified output file
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
