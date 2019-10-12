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

            //Draw a text into page
            string text1 = "Enter a number, such as 12345: ";
            //Draw a text into page
            page.Canvas.DrawString(text1, font, brush, x, y);
            
            //Add a textBox field 
            tempX = font.MeasureString(text1).Width + x + 15;
            PdfTextBoxField textbox = new PdfTextBoxField(page, "Number-TextBox");
            textbox.Bounds = new RectangleF(tempX, y, 100, 15);
            textbox.BorderWidth = 0.75f;
            textbox.BorderStyle = PdfBorderStyle.Solid;

            //Add a JavaScript action to be performed when uses type a keystroke into a text field
            string js = PdfJavaScript.GetNumberKeystrokeString(2, 0, 0, 0, "$", true);
            PdfJavaScriptAction jsAction = new PdfJavaScriptAction(js);
            textbox.Actions.KeyPressed = jsAction;

            //Add a JavaScript action to format the value of text field
            js = PdfJavaScript.GetNumberFormatString(2, 0, 0, 0, "$", true);
            jsAction = new PdfJavaScriptAction(js);
            textbox.Actions.Format = jsAction;
            pdf.Form.Fields.Add(textbox);

            //Save and launch the result file
            string output = "AddJavaScriptAction_out.pdf";
            //Save to file
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
