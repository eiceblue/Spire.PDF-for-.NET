using System;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Attachments;

namespace PdfAttachmentRelationship
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string input = @"..\..\..\..\..\..\Data\Attachment.pdf";
            string attachmentPath = @"..\..\..\..\..\..\Data\E-iceblueLogo.png";
            string output = "addAttachments.pdf";
            //Load document from disk
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(input);
            //Define PdfAttachment
            PdfAttachment attachment = new PdfAttachment(attachmentPath);
            //Add addachment
            doc.Attachments.Add(attachment, doc, Spire.Pdf.General.PdfAttachmentRelationship.Alternative);
            //Save the document
            doc.SaveToFile(output, FileFormat.PDF);
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
