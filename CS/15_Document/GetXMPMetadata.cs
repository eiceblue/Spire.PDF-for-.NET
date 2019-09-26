using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Xmp;
using System.IO;

namespace GetXMPMetadata
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String input = "..\\..\\..\\..\\..\\..\\Data\\GetXMPMetadata.pdf";
            PdfDocument doc = new PdfDocument();
            // Read a pdf file
            doc.LoadFromFile(input);

            XmpMetadata xmpMetadata = doc.XmpMetaData;

            // Create a StringBuilder object to put the details
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("Author:" + xmpMetadata.GetAuthor());
            builder.AppendLine("Title: " + xmpMetadata.GetTitle());
            builder.AppendLine("Creation Date: " + xmpMetadata.GetCreateDate());
            builder.AppendLine("Subject: " + xmpMetadata.GetSubject());
            builder.AppendLine("Producer: " + xmpMetadata.GetProducer());
            builder.AppendLine("Creator: " + xmpMetadata.GetCreator());
            builder.AppendLine("Keywords: " + xmpMetadata.GetKeywords());
            builder.AppendLine("Modify Date: " + xmpMetadata.GetModifyDate());
            builder.AppendLine("Customed Property's value: " + xmpMetadata.GetCustomProperty("Field1"));

            String result = "GetXMPMetadata_out.txt";

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
