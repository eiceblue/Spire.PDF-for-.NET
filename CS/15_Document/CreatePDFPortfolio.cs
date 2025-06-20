using Spire.Pdf;
using Spire.Pdf.Annotations;
using Spire.Pdf.Collections;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreatePDFPortfolio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // The folder path for files
            string[] files = Directory.GetFiles(@"..\..\..\..\..\..\Data\CreatePDFPortfolio");

            // The target file path
            string targetFile = @"..\..\..\..\..\..\Data\Sample.pdf";

            // Create a PDF document with the target file path
            PdfDocument doc = new PdfDocument(targetFile);

            // Iterate through the files array and add each file to the document's collection
            for (int i = 0; i < files.Length; i++)
            {
                doc.Collection.Folders.AddFile(files[i]);

                // Create a subfolder named "SubFolder" followed by the current index
                PdfFolder folder = doc.Collection.Folders.CreateSubfolder("SubFolder" + (i + 1));

                // Add the current file to the subfolder
                folder.AddFile(files[i]);
            }

            // Save the document to a file named "CreatePDFPortfolio_out.pdf"
            String result = "CreatePDFPortfolio_out.pdf";
            doc.SaveToFile(result);

            // Dispose of the document to release any resources
            doc.Dispose();

            //Launch the Pdf file
            PDFDocumentViewer(result);
        }

        private void PDFDocumentViewer(string filename)
        {
            try
            {
                System.Diagnostics.Process.Start(filename);
            }
            catch { }
        }
    }
}
