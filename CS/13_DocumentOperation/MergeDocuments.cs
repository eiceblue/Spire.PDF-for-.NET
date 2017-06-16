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
            //pdf document list
            String[] files = new String[]
            {
                @"..\..\..\..\..\..\Data\Sample3.pdf",
                @"..\..\..\..\..\..\Data\Sample2.pdf",
                @"..\..\..\..\..\..\Data\Sample1.pdf"
            };
            //open pdf documents            
            PdfDocument[] docs = new PdfDocument[files.Length];
            for(int i = 0; i < files.Length; i++)
            {
                docs[i] = new PdfDocument();
                docs[i].LoadFromFile(files[i]);
            }

            //append document
            docs[0].AppendPage(docs[1]);

            //import page
            for (int i = 0; i < docs[2].Pages.Count; i = i + 2)
            {
                docs[0].InsertPage(docs[2], i);
            }

            //Save pdf file.
            docs[0].SaveToFile("MergeDocuments.pdf");

            //close
            foreach (PdfDocument doc in docs)
            {
                doc.Close();
            }

            //Launching the Pdf file.
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
