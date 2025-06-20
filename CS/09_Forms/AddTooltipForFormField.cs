using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Fields;

namespace AddTooltipForFormField
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
            string input = @"..\..\..\..\..\..\Data\AddTooltipForFormField.pdf";

            //Open pdf document
            PdfDocument doc = new PdfDocument();
	        doc.LoadFromFile(input);

            //Get the first page
            PdfPageBase page = doc.Pages[0];

            //As for existing pdf, the property needs to be set as true
            doc.AllowCreateForm = true;

            //Create a new pdf font
            PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 12f, PdfFontStyle.Bold);

            //Create a pdf brush
            PdfBrush brush = PdfBrushes.Black;

            float x = 50;
            float y = 590;
            float tempX = 0;

            string text = "E-mail: ";
            
            //Draw a text into page
            page.Canvas.DrawString(text, font, brush, x, y);

            tempX = font.MeasureString(text).Width + x + 15;

            //Create a pdf textbox field
            PdfTextBoxField textbox = new PdfTextBoxField(page, "TextBox");

            //Set the bounds of textbox field
            textbox.Bounds = new RectangleF(tempX, y, 100, 15);

            //Set the border width of textbox field
            textbox.BorderWidth = 0.75f;

            //Set the border style of textbox field
            textbox.BorderStyle = PdfBorderStyle.Solid;

            //Add the textbox field into pdf document
            doc.Form.Fields.Add(textbox);

            //Add a tooltip for the textbox field
            doc.Form.Fields["TextBox"].ToolTip = "Please insert a valid email address";

            string output = "AddTooltipForFormField.pdf";

            //Save pdf document
            doc.SaveToFile(output);

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
