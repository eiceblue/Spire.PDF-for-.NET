using Spire.Pdf;
using Spire.Pdf.Widget;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FillXFAFields
{
    public partial class Form1 : Form
    { 
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Load a Pdf file
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\XFASample.pdf");

            PdfFormWidget formWidget = doc.Form as PdfFormWidget;
            List<XfaField> xfafields = formWidget.XFAForm.XfaFields;

            // Iterate through each XFA field in the form
            foreach (XfaField xfaField in xfafields)
            {
                if (xfaField is XfaTextField)
                {
                    XfaTextField textField = xfaField as XfaTextField;
                    textField.Value = "E-iceblue";
                }
                if (xfaField is XfaDateTimeField)
                {
                    XfaDateTimeField datetimeField = xfaField as XfaDateTimeField;
                    datetimeField.Value = DateTime.Now.ToString();
                }
                if (xfaField is XfaCheckButtonField)
                {
                    XfaCheckButtonField checkButtonField = xfaField as XfaCheckButtonField;
                    checkButtonField.Checked = true;
                }
                if (xfaField is XfaChoiceListField)
                {
                    XfaChoiceListField choiceListField = xfaField as XfaChoiceListField;
                    choiceListField.SelectedItem = choiceListField.Items[0];
                    choiceListField.SelectedItems.Add("NewItem");
                    
                }
                if (xfaField is XfaDoubleField)
                {
                    XfaDoubleField doubleField = xfaField as XfaDoubleField;
                    doubleField.Value = 2.14;
                }

            }

            // Save the result pdf file
            doc.SaveToFile("FillXfaField.pdf", FileFormat.PDF);

            PDFDocumentViewer("FillXfaField.pdf");
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
