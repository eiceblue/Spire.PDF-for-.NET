using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.General.Find;

namespace FindAndHighlightText
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Load the document from disk
            PdfDocument pdf = new PdfDocument();			
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\FindAndHighlightText.pdf");
            PdfTextFind[] result = null;
            foreach (PdfPageBase page in pdf.Pages)
            {
                //Find text
                result = page.FindText("science").Finds;
                foreach (PdfTextFind find in result)
                {
                    //Highlight searched text
                    find.ApplyHighLight();
                }
            }

            string result = "FindAndHighlightText_out.pdf";
            //Save the document
            pdf.SaveToFile(result, FileFormat.PDF);

            //Launch the result file
            PDFDocumentViewer(result);
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
