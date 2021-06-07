using Spire.Pdf;
using Spire.Pdf.Fields;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AddCheckBox
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
            
            //Create checkbox
            PdfCheckBoxField checkboxField = new PdfCheckBoxField(doc.Pages[0], "fieldID");
            float checkboxWidth = 40;
            float checkboxHeight = 40;
            checkboxField.Bounds = new RectangleF(60, 300, checkboxWidth, checkboxHeight);
            checkboxField.BorderWidth = 0.75f;
            checkboxField.Checked = true;
            checkboxField.Style = PdfCheckBoxStyle.Check;
            checkboxField.Required = true;

            //Add in form
            doc.Form.Fields.Add(checkboxField);

            String result = "AddCheckBox-result.pdf";

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
