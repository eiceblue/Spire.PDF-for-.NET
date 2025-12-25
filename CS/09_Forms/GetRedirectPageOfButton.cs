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

namespace GetRedirectPageOfButton
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
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\ButtonJump.pdf");
            //Retrieve form objects from PDF document
            PdfFormWidget formWidget = (PdfFormWidget)doc.Form;
            //Create a StringBuilder object
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("btnAction:");
            //Traverse the fields in the form
            for (int i = 0; i < formWidget.FieldsWidget.Count; ++i)
            {
                //Attempt to convert the current field to PdfButtonWidgetFieldWidget type
                var field = formWidget.FieldsWidget[i] as PdfButtonWidgetFieldWidget;
                //Obtain the actions triggered by mouse up and mouse down events
                if (field.Actions.MouseUp != null && field.Actions.MouseUp is PdfNamedAction)
                {
                    var aaa = (PdfNamedAction)field.Actions.MouseUp;
                    //Append button names, event types, and operation information to the StringBuilder based on different event and action types
                    stringBuilder.AppendLine(formWidget.FieldsWidget[i].Name + "-MouseUp-" + aaa.Destination.ToString());
                }
                else if (field.Actions.MouseDown != null && field.Actions.MouseDown is PdfNamedAction)
                {

                    var aaa = (PdfNamedAction)field.Actions.MouseDown;
                    stringBuilder.AppendLine(formWidget.FieldsWidget[i].Name + "-MouseDown--" + aaa.Destination.ToString());
                }
                else if (field.Actions.MouseDown != null && field.Actions.MouseDown is PdfUriAction)
                {

                    var aaa = (PdfUriAction)field.Actions.MouseDown;
                    stringBuilder.AppendLine(formWidget.FieldsWidget[i].Name + "-MouseDown--" + aaa.Uri.ToString());
                }
                else if (field.Actions.MouseUp != null && field.Actions.MouseUp is PdfUriAction)
                {
                    var aaa = (PdfUriAction)field.Actions.MouseUp;
                    stringBuilder.AppendLine(formWidget.FieldsWidget[i].Name + "-MouseUp-" + aaa.Uri.ToString());
                }

            }
            string outputFile = "out.txt";
            File.WriteAllText(outputFile, stringBuilder.ToString());
            doc.Dispose();

            //Launch the txt file
            PDFDocumentViewer(outputFile);
        }
        private void PDFDocumentViewer(string filename)
        {
            try
            {
                System.Diagnostics.Process.Start(filename);
            }
            catch { }
        }
    }
}
