using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Attachments;
using System.IO;

namespace DeleteAllAttachments
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = @"..\..\..\..\..\..\Data\DeleteAllAttachments.pdf";

            //Open pdf document
            PdfDocument doc = new PdfDocument();
	        doc.LoadFromFile(input);

            //Get all attachments
            PdfAttachmentCollection attachments = doc.Attachments;

            //Delete all attachments
            attachments.Clear();

            string output = "DeleteAllAttachments.pdf";

            //Save pdf document
            doc.SaveToFile(output);

            //Launch the Pdf file
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
