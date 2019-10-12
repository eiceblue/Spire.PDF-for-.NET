using Spire.Pdf;
using Spire.Pdf.Actions;
using Spire.Pdf.Fields;
using Spire.Pdf.Widget;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ExtractJavaScript
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
            PdfDocument pdf = new PdfDocument();

            //Load a pdf document
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\ExtractJavaScript.pdf");

            string js = null;

            PdfFormWidget form = pdf.Form as PdfFormWidget;
            for (int i = 0; i < form.FieldsWidget.List.Count; i++)
            {
                PdfField field = form.FieldsWidget.List[i] as PdfField;
                if (field is PdfTextBoxFieldWidget)
                {
                    PdfTextBoxFieldWidget textbox = field as PdfTextBoxFieldWidget;

                    //Find the textbox named total
                    if (textbox.Name == "total")
                    {
                        //Get the action
                        PdfJavaScriptAction jsa = textbox.Actions.Calculate;

                        if (jsa != null)
                        {
                            //Get JavaScript
                            js = jsa.Script;
                        }                       
                    }
                }
            }

            //Save and launch the result file
            File.WriteAllText("ExtractJavaScript.txt", js);
            System.Diagnostics.Process.Start("ExtractJavaScript.txt");
        }

    }
}
