using Spire.Pdf;
using Spire.Pdf.Attachments;
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
            //Pdf file
            String input = @"..\..\..\..\..\..\Data\SampleB_2.pdf";

            //Open pdf document
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(input);
            PdfNewDocument newDoc = new PdfNewDocument();
            //Set Pdf_A1B
            newDoc.Conformance = PdfConformanceLevel.Pdf_A1B;
            foreach (PdfPageBase page in doc.Pages)
            {
                SizeF size = page.Size;
                PdfPageBase p = newDoc.Pages.Add(size, new Spire.Pdf.Graphics.PdfMargins(0));
                page.CreateTemplate().Draw(p, 0, 0);
            }

            //Load files and add in attachments
            byte[] data = File.ReadAllBytes(@"..\..\..\..\..\..\Data\SampleB_1.png");
            PdfAttachment attach1 = new PdfAttachment("attachment1.png", data);
            byte[] data2 = File.ReadAllBytes(@"..\..\..\..\..\..\Data\SampleB_1.pdf");
            PdfAttachment attach2 = new PdfAttachment("attachment2.pdf", data2);
            newDoc.Attachments.Add(attach1);
            newDoc.Attachments.Add(attach2);

            string output = "ToPDFAWithAttachments-result.pdf";

            newDoc.Save(output);
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
