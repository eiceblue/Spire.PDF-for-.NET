using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;

namespace ToPDFA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //pdf file
            String input = @"..\..\..\..\..\..\Data\Sample5.pdf";

            //open pdf document
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(input);
            PdfNewDocument newDoc = new PdfNewDocument();
            newDoc.Conformance = PdfConformanceLevel.Pdf_A1B;
            foreach (PdfPageBase page in doc.Pages)
            {
                SizeF size = page.Size;
                PdfPageBase p = newDoc.Pages.Add(size, new Spire.Pdf.Graphics.PdfMargins(0));
                page.CreateTemplate().Draw(p, 0, 0);
            }
            

            string output = "ToPDFA.pdf";

            newDoc.Save(output);
            newDoc.Close();

            //Launching the result file.
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
