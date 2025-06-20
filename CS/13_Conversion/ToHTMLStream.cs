using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToHTMLStream
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new PDF document
            PdfDocument pdf = new PdfDocument();

            // Load a PDF file from disk
            pdf.LoadFromFile(@"..\..\..\..\..\..\..\Data\SampleB_1.pdf");

            // Create a new memory stream
            MemoryStream ms = new MemoryStream();

            // Save the PDF document to an HTML stream
            pdf.SaveToStream(ms, FileFormat.HTML);

            // Write the content of the memory stream to an HTML file
            File.WriteAllBytes("ToHtml.html", ms.ToArray());
            
            PDFDocumentViewer("ToHtml.html");
            
            pdf.Close();
            ms.Close();
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
