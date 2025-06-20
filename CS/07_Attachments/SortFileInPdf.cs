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
            //Create a pdf document
            PdfDocument doc = new PdfDocument();

            //Add a custom field with the name "No", the internal name "number", and the type NumberField to the document's collection
            doc.Collection.AddCustomField("No", "number", Spire.Pdf.Collections.CustomFieldType.NumberField);

            //Add a file-related field with the name "Desc", the internal name "desc", and the type Desc to the document's collection
            doc.Collection.AddFileRelatedField("Desc", "desc", Spire.Pdf.Collections.FileRelatedFieldType.Desc);

            //Sort the document's collection based on the fields "No" and "Desc" in ascending order
            doc.Collection.Sort(new string[] { "No", "Desc" }, new bool[] { true, true });

            //Create a PdfAttachment object with the path of "SampleB_1.pdf"
            PdfAttachment pdfAttachment = new PdfAttachment(@"..\..\..\..\..\..\Data\SampleB_1.pdf");

            //Add the PdfAttachment object to the document's collection
            doc.Collection.AddAttachment(pdfAttachment);

            //Create a PdfAttachment object with the path of "SampleB_2.pdf"
            pdfAttachment = new PdfAttachment(@"..\..\..\..\..\..\Data\SampleB_2.pdf");

            //Add the PdfAttachment object to the document's collection
            doc.Collection.AddAttachment(pdfAttachment);

            //Create a PdfAttachment object with the path of "SampleB_3.pdf"
            pdfAttachment = new PdfAttachment(@"..\..\..\..\..\..\Data\SampleB_3.pdf");

            //Add the PdfAttachment object to the document's collection
            doc.Collection.AddAttachment(pdfAttachment);

            //Initialize a counter variable with a value of 1
            int i = 1;

            //Iterate through each PdfAttachment object in the document's associated files
            foreach (PdfAttachment attachment in doc.Collection.AssociatedFiles)
            {
                //Set the value of the "No" field in the attachment to the current counter value
                attachment.SetFieldValue("No", i);

                //Set the value of the "Desc" field in the attachment to the file name of the attachment
                attachment.SetFieldValue("Desc", attachment.FileName);

                //Increment the counter variable
                i++;
            }

            //Specify the output file path as "SortFileInPdf.pdf"
            string output = "SortFileInPdf.pdf";

            //Save the modified document to the specified output file path in PDF format
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
