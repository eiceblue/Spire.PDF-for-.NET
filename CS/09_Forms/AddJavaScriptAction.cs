using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.XPath;
using Spire.Pdf;
using Spire.Pdf.Actions;
using Spire.Pdf.AutomaticFields;
using Spire.Pdf.Fields;
using Spire.Pdf.Graphics;

namespace AddJavaScriptAction
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

            // Allow creation of form fields in the document
            pdf.AllowCreateForm = true;

            // Create a font object with Helvetica family, font size 12, and bold style
            PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 12f, PdfFontStyle.Bold);

            // Create a brush object for drawing black color
            PdfBrush brush = PdfBrushes.Black;

            // Specify the starting coordinates for drawing text on the page
            float x = 50;
            float y = 550;
            float tempX = 0;

            // Draw a text string on the page
            string text1 = "Enter a number, such as 12345: ";
            page.Canvas.DrawString(text1, font, brush, x, y);

            // Add a textBox field to the page
            tempX = font.MeasureString(text1).Width + x + 15;
            PdfTextBoxField textbox = new PdfTextBoxField(page, "Number-TextBox");
            textbox.Bounds = new RectangleF(tempX, y, 100, 15);
            textbox.BorderWidth = 0.75f;
            textbox.BorderStyle = PdfBorderStyle.Solid;

            // Set a JavaScript action for handling key press events in the text field
            string js = PdfJavaScript.GetNumberKeystrokeString(2, 0, 0, 0, "$", true);
            PdfJavaScriptAction jsAction = new PdfJavaScriptAction(js);
            textbox.Actions.KeyPressed = jsAction;

            // Add a JavaScript action to format the value of the text field
            js = PdfJavaScript.GetNumberFormatString(2, 0, 0, 0, "$", true);
            jsAction = new PdfJavaScriptAction(js);
            textbox.Actions.Format = jsAction;

            // Add the text box field to the form fields collection of the PDF document
            pdf.Form.Fields.Add(textbox);

            // Specify the output file path for saving the modified PDF document
            string output = "AddJavaScriptAction_out.pdf";

            // Save the PDF document to the specified output file
            pdf.SaveToFile(output);


            //Launch the Pdf file
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
