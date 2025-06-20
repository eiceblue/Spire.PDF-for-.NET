using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace MergePdfsByStream
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Open the first PDF file as a read-only stream
            FileStream stream1 = File.OpenRead(@"..\..\..\..\..\..\Data\MergePdfsTemplate_1.pdf");

            // Open the second PDF file as a read-only stream
            FileStream stream2 = File.OpenRead(@"..\..\..\..\..\..\Data\MergePdfsTemplate_2.pdf");

            // Open the third PDF file as a read-only stream
            FileStream stream3 = File.OpenRead(@"..\..\..\..\..\..\Data\MergePdfsTemplate_3.pdf");

            // Array of PDF document streams
            Stream[] streams = new Stream[] { stream1, stream2, stream3 };

            // Merge the PDF files using the streams
            PdfDocumentBase doc = PdfDocument.MergeFiles(streams);

            // Save the merged document to a PDF file named "MergeFilesByStream_result.pdf"
            doc.Save("MergeFilesByStream_result.pdf", FileFormat.PDF);

            PDFDocumentViewer("MergeFilesByStream_result.pdf");
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
