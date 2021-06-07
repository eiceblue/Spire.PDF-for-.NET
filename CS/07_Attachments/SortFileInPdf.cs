using System;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Attachments;

namespace SortFileInPdf
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

            doc.Collection.AddCustomField("No", "number", Spire.Pdf.Collections.CustomFieldType.NumberField);
            doc.Collection.AddFileRelatedField("Desc", "desc", Spire.Pdf.Collections.FileRelatedFieldType.Desc);
            doc.Collection.Sort(new string[] { "No", "Desc" }, new bool[] { true, true });

            PdfAttachment pdfAttachment = new PdfAttachment(@"..\..\..\..\..\..\Data\SampleB_1.pdf");
            doc.Collection.AddAttachment(pdfAttachment);
            pdfAttachment = new PdfAttachment(@"..\..\..\..\..\..\Data\SampleB_2.pdf");
            doc.Collection.AddAttachment(pdfAttachment);
            pdfAttachment = new PdfAttachment(@"..\..\..\..\..\..\Data\SampleB_3.pdf");
            doc.Collection.AddAttachment(pdfAttachment);

            int i = 1;
            foreach (PdfAttachment attachment in doc.Collection.AssociatedFiles)
            {
                attachment.SetFieldValue("No", i);
                attachment.SetFieldValue("Desc", attachment.FileName);
                i++;
            }

            string output = "SortFileInPdf.pdf";
            doc.SaveToFile(output, FileFormat.PDF);
            PDFDocumentViewer(output); ;
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
