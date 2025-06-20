using Spire.Pdf;
using Spire.Pdf.Attachments;
using Spire.Pdf.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AddAttachmentsToPDFA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Path to the input PDF file
            string input = @"..\..\..\..\..\..\Data\SampleB_2.pdf";

            // Create a new memory stream
            MemoryStream ms = new MemoryStream();

            // Convert the input PDF file to PDF/A-1b standard and save it to the memory stream
            PdfStandardsConverter converter = new PdfStandardsConverter(input);
            converter.ToPdfA1B(ms);

            // Create a new PDF document
            PdfDocument newDoc = new PdfDocument();

            // Load the converted PDF document from the memory stream
            newDoc.LoadFromStream(ms);

            // Read the data of the first attachment file ("SampleB_1.png") into a byte array
            byte[] data = File.ReadAllBytes(@"..\..\..\..\..\..\Data\SampleB_1.png");

            // Create a PdfAttachment object with the attachment file name and data
            PdfAttachment attach1 = new PdfAttachment("attachment1.png", data);

            // Read the data of the second attachment file ("SampleB_1.pdf") into a byte array
            byte[] data2 = File.ReadAllBytes(@"..\..\..\..\..\..\Data\SampleB_1.pdf");

            // Create a PdfAttachment object with the attachment file name and data
            PdfAttachment attach2 = new PdfAttachment("attachment2.pdf", data2);

            // Add the attachments to the new PDF document
            newDoc.Attachments.Add(attach1);
            newDoc.Attachments.Add(attach2);

            // Specify the output file path for saving the modified document
            string output = "ToPDFAWithAttachments-result.pdf";

            // Save the modified document to the specified file
            newDoc.SaveToFile(output);

            // Close the PDF document
            newDoc.Close();

            //Launch the reuslt file
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
