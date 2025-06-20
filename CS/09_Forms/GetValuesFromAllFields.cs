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
            // Create a StringBuilder object to store the result.
            StringBuilder sb = new StringBuilder();

            // Specify the path to the input PDF file.
            string input = @"..\..\..\..\..\..\Data\AllFields.pdf";

            // Create a new PdfDocument object and load the PDF file.
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(input);

            // Get the form widget from the loaded PDF document.
            PdfFormWidget formWidget = doc.Form as PdfFormWidget;

            // Iterate through each field in the form.
            for (int i = 0; i < formWidget.FieldsWidget.List.Count; i++)
            {
                // Get the current field.
                PdfField field = formWidget.FieldsWidget.List[i] as PdfField;

                // Check if the field is a TextBox field.
                if (field is PdfTextBoxFieldWidget)
                {
                    // Convert the field to a TextBox field.
                    PdfTextBoxFieldWidget textBoxField = field as PdfTextBoxFieldWidget;

                    // Get the text value of the TextBox.
                    string text = textBoxField.Text;

                    // Append the text value to the StringBuilder.
                    sb.Append("The text in the textbox is " + text + "\r\n");
                }

                // Check if the field is a ListBox field.
                if (field is PdfListBoxWidgetFieldWidget)
                {
                    // Convert the field to a ListBox field.
                    PdfListBoxWidgetFieldWidget listBoxField = field as PdfListBoxWidgetFieldWidget;

                    // Append a label for the ListBox items.
                    sb.Append("Listbox items are \r\n");

                    // Get the values of the ListBox.
                    PdfListWidgetItemCollection items = listBoxField.Values;

                    // Iterate through each item in the ListBox.
                    foreach (PdfListWidgetItem item in items)
                    {
                        // Append the value of each item to the StringBuilder.
                        sb.Append(item.Value + "\r\n");
                    }

                    // Get the selected value of the ListBox.
                    string selectedValue = listBoxField.SelectedValue;

                    // Append the selected value to the StringBuilder.
                    sb.Append("The selected value in the listbox is " + selectedValue + "\r\n");
                }

                // Check if the field is a ComboBox field.
                if (field is PdfComboBoxWidgetFieldWidget)
                {
                    // Convert the field to a ComboBox field.
                    PdfComboBoxWidgetFieldWidget comBoxField = field as PdfComboBoxWidgetFieldWidget;

                    // Append a label for the ComboBox items.
                    sb.Append("ComboBox items are \r\n");

                    // Get the values of the ComboBox.
                    PdfListWidgetItemCollection items = comBoxField.Values;

                    // Iterate through each item in the ComboBox.
                    foreach (PdfListWidgetItem item in items)
                    {
                        // Append the value of each item to the StringBuilder.
                        sb.Append(item.Value + "\r\n");
                    }

                    // Get the selected value of the ComboBox.
                    string selectedValue = comBoxField.SelectedValue;

                    // Append the selected value to the StringBuilder.
                    sb.Append("The selected value in the ComboBox is " + selectedValue + "\r\n");
                }

                // Check if the field is a RadioButtonList field.
                if (field is PdfRadioButtonListFieldWidget)
                {
                    // Convert the field to a RadioButtonList field.
                    PdfRadioButtonListFieldWidget radioBtnField = field as PdfRadioButtonListFieldWidget;

                    // Get the value of the selected radio button.
                    string value = radioBtnField.Value;

                    // Append the value to the StringBuilder.
                    sb.Append("The value in the radioButtonField is " + value + "\r\n");
                }

                // Check if the field is a CheckBox field.
                if (field is PdfCheckBoxWidgetFieldWidget)
                {
                    // Convert the field to a CheckBox field.
                    PdfCheckBoxWidgetFieldWidget checkBoxField = field as PdfCheckBoxWidgetFieldWidget;

                    // Get the checked state of the CheckBox.
                    bool state = checkBoxField.Checked;

                    // Append the checked state to the StringBuilder.
                    sb.Append("If the checkBox is checked: " + state + "\r\n");
                }
            }

            // Specify the path for the output text file.
            string result = "GetAllValues.txt";

            // Write the contents of the StringBuilder to the output file.
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
