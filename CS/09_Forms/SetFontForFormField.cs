using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Widget;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SetFontForFormField
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a pdf document
            PdfDocument doc = new PdfDocument();

            //Load from file
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\TextBoxSampleB.pdf");

            //Get form fields
            PdfFormWidget formWidget = doc.Form as PdfFormWidget;

            //Get textbox
            PdfTextBoxFieldWidget textbox = formWidget.FieldsWidget["Text1"] as PdfTextBoxFieldWidget;
            
            //Set the font for textbox
            textbox.Font = new PdfTrueTypeFont(new Font("Tahoma", 12), true);

            //Set text
            textbox.Text = "Hello World";

            string result = "SetFontForFormField-result.pdf";
            //Save to file
            doc.SaveToFile(result);

            //Launch the Pdf file
            PDFDocumentViewer(result);
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
