using Spire.Pdf;
using Spire.Pdf.Fields;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AddComboBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\SampleB_1.pdf");

            doc.AllowCreateForm = true;
            
            //Create comboBox
            PdfComboBoxField comboBoxField = new PdfComboBoxField(doc.Pages[0], "Combox1");
            comboBoxField.Bounds = new RectangleF(60, 300, 70, 30);
            comboBoxField.BorderWidth = 0.75f;
            comboBoxField.Font = new PdfFont(PdfFontFamily.Helvetica, 9f);
            comboBoxField.Required = true;

            //Add items in comboBox
            comboBoxField.Items.Add(new PdfListFieldItem( "Apple","itme1"));
            comboBoxField.Items.Add(new PdfListFieldItem( "Banana","itme2"));
            comboBoxField.Items.Add(new PdfListFieldItem("Pear", "itme3"));
            comboBoxField.Items.Add(new PdfListFieldItem("Peach", "itme4"));
            comboBoxField.Items.Add(new PdfListFieldItem("Grape", "itme5"));

            //Add in form
            doc.Form.Fields.Add(comboBoxField);

            string output="AddComboBox-result.pdf";

            //Save to file
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
