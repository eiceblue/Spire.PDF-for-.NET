using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;

namespace MergeDocuments
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Pdf document list
            String[] files = new String[]
            {
                @"..\..\..\..\..\..\Data\MergePdfsTemplate_1.pdf",
                @"..\..\..\..\..\..\Data\MergePdfsTemplate_2.pdf",
                @"..\..\..\..\..\..\Data\MergePdfsTemplate_3.pdf"
            };

            // Create an array of PdfDocument
            PdfDocument[] docs = new PdfDocument[files.Length];

            // Loop through the documents
            for (int i = 0; i < files.Length; i++)
            {
                // Load a specific document
                docs[i] = new PdfDocument(files[i]);
            }

            // Create a PdfDocument object for generating a new PDF document
            PdfDocument doc = new PdfDocument();

            // Insert the selected pages from different documents to the new document
            doc.InsertPage(docs[0], 0);
            doc.InsertPageRange(docs[1], 0, 2);
            doc.InsertPage(docs[2], 0);

            // Save the document to a PDF file
            doc.SaveToFile("MergeDocuments.pdf");

            // Close the document
            doc.Close();

            // Close all the loaded documents
            foreach (PdfDocument docf in docs)
            {
                docf.Close();
            }

            //Launching the Pdf file
            PDFDocumentViewer("MergeDocuments.pdf");
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
