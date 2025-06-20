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
using Spire.Pdf.Interchange.Metadata;

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
            // Define the input file path for the PDF document
            String input = "..\\..\\..\\..\\..\\..\\Data\\GetXMPMetadata.pdf";

            // Create a PdfDocument object to load the PDF file
            PdfDocument doc = new PdfDocument();
            // Read a pdf file
            doc.LoadFromFile(input);

            // Get the XMP metadata from the loaded PDF document
            PdfXmpMetadata xmpMetadata = doc.Metadata;

            // Create a StringBuilder object to put the details of the XMP metadata
            StringBuilder builder = new StringBuilder();
            const string NsPdf = "http://ns.adobe.com/pdf/1.3/"; // Define the namespace for PDF metadata properties

            // Check if the XMP metadata has the "Author" property and append it to the StringBuilder
            if (xmpMetadata.ExistProperty(NsPdf, "Author"))
            {
                builder.AppendLine("Author:" + xmpMetadata.GetPropertyString(NsPdf, "Author"));
            }

            // Check if the XMP metadata has the "Title" property and append it to the StringBuilder
            if (xmpMetadata.ExistProperty(NsPdf, "Title"))
            {
                builder.AppendLine("Title: " + xmpMetadata.GetPropertyString(NsPdf, "Title"));
            }

            // Check if the XMP metadata has the "Subject" property and append it to the StringBuilder
            if (xmpMetadata.ExistProperty(NsPdf, "Subject"))
            {
                builder.AppendLine("Subject: " + xmpMetadata.GetPropertyString(NsPdf, "Subject"));
            }

            // Check if the XMP metadata has the "Producer" property and append it to the StringBuilder
            if (xmpMetadata.ExistProperty(NsPdf, "Producer"))
            {
                builder.AppendLine("Producer: " + xmpMetadata.GetPropertyString(NsPdf, "Producer"));
            }

            // Check if the XMP metadata has the "Creator" property and append it to the StringBuilder
            if (xmpMetadata.ExistProperty(NsPdf, "Creator"))
            {
                builder.AppendLine("Creator: " + xmpMetadata.GetPropertyString(NsPdf, "Creator"));
            }

            // Check if the XMP metadata has the "Keywords" property and append it to the StringBuilder
            if (xmpMetadata.ExistProperty(NsPdf, "Keywords"))
            {
                builder.AppendLine("Keywords: " + xmpMetadata.GetPropertyString(NsPdf, "Keywords"));
            }

            // Define the output file path for the text file containing the XMP metadata details
            String result = "GetXMPMetadata_out.txt";

            // Write the XMP metadata details to a text file
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
