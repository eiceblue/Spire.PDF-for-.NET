using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using System.IO;

namespace GetDocumentProperties
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String input = "..\\..\\..\\..\\..\\..\\Data\\PDFTemplate-Az.pdf";
            PdfDocument doc = new PdfDocument();
            // Read a pdf file
            doc.LoadFromFile(input);
            // Get document information
            PdfDocumentInformation  docInfo = doc.DocumentInformation;

            // Create a StringBuilder object to put the details
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Author:"+docInfo.Author);
            builder.AppendLine("Creation Date: "+ docInfo.CreationDate);
            builder.AppendLine("Keywords: "+ docInfo.Keywords);
            builder.AppendLine("Modify Date: "+ docInfo.ModificationDate);
            builder.AppendLine("Subject: "+ docInfo.Subject);
            builder.AppendLine("Title: "+ docInfo.Title);

            String result = "GetDocumentProperties_out.txt";

            File.WriteAllText(result, builder.ToString());
            //Launch the result file
            DocumentViewer(result);
        }

        private void DocumentViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }
    }
}
