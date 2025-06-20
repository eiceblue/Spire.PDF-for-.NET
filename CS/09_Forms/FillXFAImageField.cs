using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Actions;
using Spire.Pdf.Fields;
using Spire.Pdf.Graphics;
using Spire.Pdf.Widget;

namespace FillXFAImageField
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a PdfDocument object
            PdfDocument pdfDocument = new PdfDocument();

            //Load PDF document
            pdfDocument.LoadFromFile(@"..\..\..\..\..\..\Data\XFAImageField.pdf");

            PdfFormWidget form = pdfDocument.Form as PdfFormWidget;
            if (form.XFAForm != null)
            {
                //Get the xfa Fields  
                List<XfaField> xFields = form.XFAForm.XfaFields;
                for (int i = 0; i < xFields.Count; i++)
                {
                    if (xFields[i] is XfaImageField)
                    {
                        //add image to ImageFiled
                        XfaImageField xImageField = xFields[i] as XfaImageField;
                        FileStream fileStream = new FileStream(@"..\..\..\..\..\..\Data\E-logo.png", FileMode.Open, FileAccess.Read, FileShare.Read);
                        xImageField.Image = Image.FromStream(fileStream);
                    }
                }

            }

            //Save the PDF document
            String result = "XFAImageField_output.pdf";
            pdfDocument.SaveToFile(result);

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
