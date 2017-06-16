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
            //create a pdf document
            PdfDocument doc = new PdfDocument();

            //add a new page
            PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, new PdfMargins(0));

            //create a new pdf font
            PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 12f, PdfFontStyle.Bold);

            //create a pdf brush
            PdfBrush brush = PdfBrushes.Black;

            float x = 50;
            float y = 50;
            float tempX = 0;

            string text = "E-mail: ";
            
            //draw a text into page
            page.Canvas.DrawString(text, font, brush, x, y);

            tempX = font.MeasureString(text).Width + x + 15;

            //create a pdf textbox field
            PdfTextBoxField textbox = new PdfTextBoxField(page, "TextBox");

            //set the bounds of textbox field
            textbox.Bounds = new RectangleF(tempX, y, 100, 15);

            //set the border width of textbox field
            textbox.BorderWidth = 0.75f;

            //set the border style of textbox field
            textbox.BorderStyle = PdfBorderStyle.Solid;

            //add the textbox field into pdf document
            doc.Form.Fields.Add(textbox);

            //add a tooltip for the textbox field
            doc.Form.Fields["TextBox"].ToolTip = "Please insert a valid email address";

            string output = "AddTooltipForFormField.pdf";

            //save pdf document
            doc.SaveToFile(output);

            //Launching the Pdf file
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
