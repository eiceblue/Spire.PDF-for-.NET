using System;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Actions;
using Spire.Pdf.Widget;
using System.IO;

namespace ReadBookmarkInfoOfButton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a PDF document
            PdfDocument pdf = new PdfDocument();

            // Load the PDF file from disk
            pdf.LoadFromFile("..\\..\\..\\..\\..\\..\\Data\\ReadBookmarkInfoOfButton.pdf");

            PdfFormWidget formWidget = (PdfFormWidget)pdf.Form;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("btnAction:");
            for (int i = 0; i < formWidget.FieldsWidget.Count; ++i)
            {
                if (formWidget.FieldsWidget[i] is PdfButtonWidgetFieldWidget)
                {
                    var field = formWidget.FieldsWidget[i] as PdfButtonWidgetFieldWidget;
                    if (field.Actions.MouseUp != null && field.Actions.MouseUp is PdfNamedAction)
                    {
                        var aaa = (PdfNamedAction)field.Actions.MouseUp;
                        stringBuilder.AppendLine(field.Name + "-MouseUp-" + aaa.Destination.ToString());
                    }
                    else if (field.Actions.MouseDown != null && field.Actions.MouseDown is PdfNamedAction)
                    {
                        var aaa = (PdfNamedAction)field.Actions.MouseDown;
                        stringBuilder.AppendLine(field.Name + "-MouseDown--" + aaa.Destination.ToString());
                    }
                    else if (field.Actions.MouseDown != null && field.Actions.MouseDown is PdfUriAction)
                    {
                        var aaa = (PdfUriAction)field.Actions.MouseDown;
                        stringBuilder.AppendLine(field.Name + "-MouseDown--" + aaa.Uri.ToString());
                    }
                    else if (field.Actions.MouseUp != null && field.Actions.MouseUp is PdfUriAction)
                    {
                        var aaa = (PdfUriAction)field.Actions.MouseUp;
                        stringBuilder.AppendLine(field.Name + "-MouseUp-" + aaa.Uri.ToString());
                    }
                    else if (field.Actions.MouseUp != null && field.Actions.MouseUp is PdfGotoNameAction)
                    {
                        var aaa = (PdfGotoNameAction)field.Actions.MouseUp;
                        stringBuilder.AppendLine(field.Name + "-MouseUp-" + aaa.Destination.ToString());
                    }
                    else if (field.Actions.MouseDown != null && field.Actions.MouseDown is PdfGotoNameAction)
                    {
                        var aaa = (PdfGotoNameAction)field.Actions.MouseDown;
                        stringBuilder.AppendLine(field.Name + "-MouseDown-" + aaa.Destination.ToString());
                    }
                }
            }       

            string result = "ReadBookmarkInfoOfButton_out.txt";

            File.WriteAllText(result, stringBuilder.ToString());
            
            // Close the PDF document
            pdf.Close();

            //Launch the Pdf file
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
