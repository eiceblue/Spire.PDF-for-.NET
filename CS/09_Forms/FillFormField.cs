using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Fields;
using Spire.Pdf.Widget;

namespace FillFormField
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
            string input = @"..\..\..\..\..\..\Data\FillFormField.pdf";
            PdfDocument doc = new PdfDocument();
	    doc.LoadFromFile(input);
            //Get pdf forms
            PdfFormWidget formWidget = doc.Form as PdfFormWidget;

            //Fill pdf form fields
            for (int i = 0; i < formWidget.FieldsWidget.List.Count; i++)
            {
                PdfField field = formWidget.FieldsWidget.List[i] as PdfField;
                if (field is PdfTextBoxFieldWidget)
                {
                    PdfTextBoxFieldWidget textBoxField = field as PdfTextBoxFieldWidget;
                    switch (textBoxField.Name)
                    {
                        case "email":
                            textBoxField.Text = "support@e-iceblue.com";
                            break;

                        case "username":
                            textBoxField.Text = "E-iceblue";
                            break;

                        case "password":
                            textBoxField.Password = true;
                            textBoxField.Text = "e-iceblue";
                            break;

                        case "password2":
                            textBoxField.Password = true;
                            textBoxField.Text = "e-iceblue";
                            break;

                        case "company_name ":
                            textBoxField.Text = "E-iceblue";
                            break;

                        case "first_name":
                            textBoxField.Text = "James";
                            break;

                        case "last_name":
                            textBoxField.Text = "Chen";
                            break;

                        case "middle_name":
                            textBoxField.Text = "J";
                            break;

                        case "address1":
                            textBoxField.Text = "Chengdu";
                            break;

                        case "address2":
                            textBoxField.Text = "Beijing";
                            break;

                        case "city":
                            textBoxField.Text = "Shanghai";
                            break;

                        case "postal_code":
                            textBoxField.Text = "11111";
                            break;

                        case "state":
                            textBoxField.Text = "Shanghai";
                            break;

                        case "phone":
                            textBoxField.Text = "1234567901";
                            break;

                        case "mobile_phone":
                            textBoxField.Text = "123456789";
                            break;

                        case "fax":
                            textBoxField.Text = "12121212";
                            break;
                    }
                }

                if (field is PdfListBoxWidgetFieldWidget)
                {
                    PdfListBoxWidgetFieldWidget listBoxField = field as PdfListBoxWidgetFieldWidget;
                    switch (listBoxField.Name)
                    {
                        case "email_format":
                            int[] index = { 1 };
                            listBoxField.SelectedIndex = index;
                            break;
                    }
                }

                if (field is PdfComboBoxWidgetFieldWidget)
                {
                    PdfComboBoxWidgetFieldWidget comBoxField = field as PdfComboBoxWidgetFieldWidget;
                    switch (comBoxField.Name)
                    {
                        case "title":
                            int[] items = { 0 };
                            comBoxField.SelectedIndex = items;
                            break;
                    }
                }

                if (field is PdfRadioButtonListFieldWidget)
                {
                    PdfRadioButtonListFieldWidget radioBtnField = field as PdfRadioButtonListFieldWidget;
                    switch (radioBtnField.Name)
                    {
                        case "country":
                            radioBtnField.SelectedIndex = 1;
                            break;
                    }
                }

                if (field is PdfCheckBoxWidgetFieldWidget)
                {
                    PdfCheckBoxWidgetFieldWidget checkBoxField = field as PdfCheckBoxWidgetFieldWidget;
                    switch (checkBoxField.Name)
                    {
                        case "agreement_of_terms":
                            checkBoxField.Checked = true;
                            break;
                    }
                }

                if (field is PdfButtonWidgetFieldWidget)
                {
                    PdfButtonWidgetFieldWidget btnField = field as PdfButtonWidgetFieldWidget;
                    switch (btnField.Name)
                    {

                        case "submit":
                            btnField.Text = "Submit";
                            break;
                    }
                }
            }

            string output = "FillFormField.pdf";

            //Save pdf document
            doc.SaveToFile(output);

            //Launch the file
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
