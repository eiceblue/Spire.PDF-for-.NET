using Spire.Pdf;
using Spire.Pdf.Annotations;
using Spire.Pdf.Fields;
using Spire.Pdf.Graphics;
using Spire.Pdf.Widget;
using System;
using System.Windows.Forms;

namespace FillImageInButtonField
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Load old PDF from disk.
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\ButtonField.pdf");

            //Get pdf forms
            PdfFormWidget form = pdf.Form as PdfFormWidget;

            //Traverse all the forms
            for (int i = 0; i < form.FieldsWidget.Count; i++)
            {
                //If it is Button field
                if (form.FieldsWidget[i] is PdfButtonWidgetFieldWidget)
                {
                    PdfButtonWidgetFieldWidget field = form.FieldsWidget[i] as PdfButtonWidgetFieldWidget;
                    if (field.Name == "Button1")
                    {
                        //Set "true" to fit bounds
                        field.IconLayout.IsFitBounds = true;

                        //Fill the annotation rectangle exactly without its original aspect ratio
                        field.IconLayout.ScaleMode = PdfButtonIconScaleMode.Anamorphic;

                        //Fill an image
                        field.SetButtonImage(PdfImage.FromFile(@"..\..\..\..\..\..\Data\E-logo.png"));
                    }
                }
            }
            //Save to a file
            String result = "FillImageInButtonField.pdf";
            pdf.SaveToFile(result, Spire.Pdf.FileFormat.PDF);

            //Launch the file
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
