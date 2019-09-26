using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
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
            FileStream stream1 = File.OpenRead(@"..\..\..\..\..\..\Data\MergePdfsTemplate_1.pdf");
            FileStream stream2 = File.OpenRead(@"..\..\..\..\..\..\Data\MergePdfsTemplate_2.pdf");
            FileStream stream3 = File.OpenRead(@"..\..\..\..\..\..\Data\MergePdfsTemplate_3.pdf");

            //Pdf document streams 
            Stream[] streams = new Stream[] { stream1, stream2, stream3 };

            //Also can merge files by filename
            //Merge files by stream
            PdfDocumentBase doc = PdfDocument.MergeFiles(streams);

            //Save and launch
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
