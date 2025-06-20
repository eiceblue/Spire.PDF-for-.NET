using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Utilities;
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
            // Disable the incremental update
            doc.FileInfo.IncrementalUpdate = false;

            // Set the compression level to best
            doc.CompressionLevel = PdfCompressionLevel.Best;
        }

        private void CompressImage(PdfDocument doc)
        {
            // Disable the incremental update
            doc.FileInfo.IncrementalUpdate = false;

            // Traverse all pages
            foreach (PdfPageBase page in doc.Pages)
            {
                if (page != null)
                {
                    // Create a helper for image processing
                    PdfImageHelper helper = new PdfImageHelper();

                    // Get the image information for the current page
                    Spire.Pdf.Utilities.PdfImageInfo[] pdfImageInfos = helper.GetImagesInfo(page);
                    if (pdfImageInfos != null)
                    {
                        // Process each image on the page
                        for (int i = 0; i < pdfImageInfos.Length; i++)
                        {
                            // Try to compress the image
                            pdfImageInfos[i].TryCompressImage();
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
