using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Actions;
using Spire.Pdf.Fields;
using Spire.Pdf.Graphics;
using Spire.Pdf.Widget;

namespace GetJavaScriptFromCheckBoxField
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Load the PDF file
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\GetJavaScriptFromCheckBox.pdf");


            //Get Pdf forms
            PdfFormWidget fw = doc.Form as PdfFormWidget;

            //Create StringBuilder
            StringBuilder sb = new StringBuilder();

            //Loop forms fields
            for (int i = 0; i < fw.FieldsWidget.Count; i++)
            {
                PdfField pdfField = fw.FieldsWidget[i];

                //Get PdfCheckBoxWidgetFieldWidget objects
                if (pdfField is PdfCheckBoxWidgetFieldWidget)
                {
                    PdfCheckBoxWidgetFieldWidget checkBoxField = pdfField as PdfCheckBoxWidgetFieldWidget;
                    PdfJavaScriptAction mousedown = (PdfJavaScriptAction)checkBoxField.Actions.MouseDown;

                    //Get the JavaScript text
                    sb.Append(mousedown.Script.ToString());
                }
            }

            //Write to a .txt file
            string result = @"js-out.txt";
            File.WriteAllText(result, sb.ToString());

            MessageBox.Show("The obtained JavaScript: " + sb.ToString());
        }
    }
}
