using Spire.Pdf;
using Spire.Pdf.Fields;
using Spire.Pdf.Widget;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RecognizeRequiredField
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Load a pdf document
            string input = @"..\..\..\..\..\..\Data\RecognizeRequiredField.pdf";
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(input);
            //Get pdf forms
            PdfFormWidget formWidget = doc.Form as PdfFormWidget;

            for (int i = 0; i < formWidget.FieldsWidget.List.Count; i++)
            {
                PdfField field = formWidget.FieldsWidget.List[i] as PdfField;
                //Judge if the field is required
                if (field.Required)
                {
                    MessageBox.Show("The field named: "+ field.Name + " is required");                   
                }
            }

        }
    }
}
