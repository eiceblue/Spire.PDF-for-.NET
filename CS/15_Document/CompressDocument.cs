using Spire.Pdf;
using Spire.Pdf.Exporting;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompressDocument
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Load the pdf document
            PdfDocument doc = new PdfDocument();
	    doc.LoadFromFile(@"..\..\..\..\..\..\Data\CompressDocument.pdf");
            //Compress the content in document
            CompressContent(doc);

            //Compress the images in document
            CompressImage(doc);

            //Save the document
            doc.SaveToFile("CompressDocument_result.pdf");

            //View the pdf document
            PDFDocumentViewer("CompressDocument_result.pdf");
        }

        private void CompressContent(PdfDocument doc)
        {
            //Disable the incremental update
            doc.FileInfo.IncrementalUpdate = false;

            //Set the compression level to best
            doc.CompressionLevel = PdfCompressionLevel.Best;
        }

        private void CompressImage(PdfDocument doc)
        {
            //Disable the incremental update
            doc.FileInfo.IncrementalUpdate = false;

            //Traverse all pages
            foreach (PdfPageBase page in doc.Pages)
            {
                if (page != null)
                {
                    if (page.ImagesInfo != null)
                    {
                        foreach (PdfImageInfo info in page.ImagesInfo)
                        {
                            page.TryCompressImage(info.Index);
                        }
                    }
                }
            }
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
