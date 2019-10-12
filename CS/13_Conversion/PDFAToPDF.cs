using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PDFAToPDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Pdf file
            String input = @"..\..\..\..\..\..\Data\SamplePDFA.pdf";

            //Open pdf document
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(input);

            //Create a new pdf and draw content on new file
            PdfNewDocument newDoc = new PdfNewDocument();
            newDoc.CompressionLevel = PdfCompressionLevel.None;

            foreach (PdfPageBase page in doc.Pages)
            {
                SizeF size = page.Size;
                PdfPageBase p = newDoc.Pages.Add(size, new Spire.Pdf.Graphics.PdfMargins(0));
                page.CreateTemplate().Draw(p, 0, 0);
            }


            string output = "PDFAToPdf-result.pdf";

            newDoc.Save(output);
            newDoc.Close();

            //Launch the Pdf file
            PDFDocumentViewer(output);
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
