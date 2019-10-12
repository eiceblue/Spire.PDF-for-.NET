using Spire.Pdf;
using Spire.Pdf.Fields;
using Spire.Pdf.Widget;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetValuesFromAllFields
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            //Load a pdf document
            string input = @"..\..\..\..\..\..\Data\AllFields.pdf";
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(input);

            //Get pdf forms
            PdfFormWidget formWidget = doc.Form as PdfFormWidget;

            //Find pdf form fields
            for (int i = 0; i < formWidget.FieldsWidget.List.Count; i++)
            {
                PdfField field = formWidget.FieldsWidget.List[i] as PdfField;              
                if (field is PdfTextBoxFieldWidget)
                {
                    PdfTextBoxFieldWidget textBoxField = field as PdfTextBoxFieldWidget;
                    //Get text of textbox
                    string text = textBoxField.Text;
                    sb.Append("The text in textbox is " + text + "\r\n");
                }

                if (field is PdfListBoxWidgetFieldWidget)
                {
                    PdfListBoxWidgetFieldWidget listBoxField = field as PdfListBoxWidgetFieldWidget;
                    sb.Append("Listbox items are \r\n");
                    //Get values of listbox
                    PdfListWidgetItemCollection items = listBoxField.Values;

                    foreach (PdfListWidgetItem item in items)
                    {
                        sb.Append(item.Value + "\r\n");
                    }
                    //Get selected value
                    string selectedValue = listBoxField.SelectedValue;
                    sb.Append("The selected value in the listbox is " + selectedValue + "\r\n");

                }

                if (field is PdfComboBoxWidgetFieldWidget)
                {
                    PdfComboBoxWidgetFieldWidget comBoxField = field as PdfComboBoxWidgetFieldWidget;
                    sb.Append("comBoxField items are \r\n");
                    //Get values of comboBox
                    PdfListWidgetItemCollection items = comBoxField.Values;

                    foreach (PdfListWidgetItem item in items)
                    {
                        sb.Append(item.Value + "\r\n");
                    }
                    //Get selected value
                    string selectedValue = comBoxField.SelectedValue;
                    sb.Append("The selected value in the comBoxField is " + selectedValue + "\r\n");

                }

                if (field is PdfRadioButtonListFieldWidget)
                {
                    PdfRadioButtonListFieldWidget radioBtnField = field as PdfRadioButtonListFieldWidget;
                    //Get value of radio button
                    string value = radioBtnField.Value;

                    sb.Append("The text in radioButtonField is " + value + "\r\n");
                }

                if (field is PdfCheckBoxWidgetFieldWidget)
                {
                    PdfCheckBoxWidgetFieldWidget checkBoxField = field as PdfCheckBoxWidgetFieldWidget;
                    //Get the checked state of the checkbox
                    bool state = checkBoxField.Checked;
                    sb.Append("If the checkBox is checked: " + state + "\r\n");
                }
            }
            string result = "GetAllValues.txt";

            File.WriteAllText(result, sb.ToString());

            //Launch file
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
