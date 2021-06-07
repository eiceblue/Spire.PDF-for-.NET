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
using System.IO;
namespace GetStyleOfRadioButton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = @"..\..\..\..\..\..\Data\GetStyleOfRadioButton.pdf";

            //Open pdf document
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(input);

            //Get the first page
            PdfPageBase page = pdf.Pages[0];

            //Get all form fields
            PdfFormWidget formWidget = pdf.Form as PdfFormWidget;

            StringBuilder builder = new StringBuilder();

            int num = 0;

            //Loop through all fields
            for (int i = 0; i < formWidget.FieldsWidget.List.Count; i++)
            {
                PdfField field = formWidget.FieldsWidget.List[i] as PdfField;

                //Find the radio button field
                if (field is PdfRadioButtonListFieldWidget)
                {
                    num++;
                    PdfRadioButtonListFieldWidget radio = field as PdfRadioButtonListFieldWidget;

                    //Get the button style
                    PdfCheckBoxStyle buttonStyle = radio.ButtonStyle;
                    builder.AppendLine(String.Format("The button style of Radio button {0} is: "+buttonStyle.ToString(),num));
                }
            }

            String result = "GetStyleOfRadioButton_out.txt";

            //Save the document
            File.WriteAllText(result, builder.ToString());

            //Launch the txt file
            DocumentViewer(result);
        }
        private void DocumentViewer(string filename)
        {
            try
            {
                System.Diagnostics.Process.Start(filename);
            }
            catch { }
        }
    }
}
