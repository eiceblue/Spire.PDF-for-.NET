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
namespace AddRadioButtonFieldWithOptions
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

            float x = 150;
            float y = 550;
            float temX = 0;

            //Create a pdf radio button list
            PdfRadioButtonListField radioButton = new PdfRadioButtonListField(page, "RadioButton");
            radioButton.Required = true;

            //Add items into radio button list.
            for (int i = 0; i < 3; i++)
            {
                // Set its style
                PdfRadioButtonListItem item = new PdfRadioButtonListItem(string.Format("item{0}", i));
                item.BorderWidth = 0.75f;
                item.Bounds = new RectangleF(x, y, 15, 15);
                item.BorderColor = Color.Red;
                item.ForeColor = Color.Red;
                radioButton.Items.Add(item);
                temX = x + 20;
                page.Canvas.DrawString(string.Format("Item{0}", i), font, brush, temX, y);
                x = temX + 100;
            }

            //Add the radio button list field into pdf document
            pdf.Form.Fields.Add(radioButton);

            String result = "AddRadioButtonFieldWithOptions_out.pdf";

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
