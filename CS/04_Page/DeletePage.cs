using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
namespace DeletePage
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
            string input = "..\\..\\..\\..\\..\\..\\Data\\Sample3.pdf";

            //open pdf document
            PdfDocument doc = new PdfDocument(input);

            //delete the fifth page
            doc.Pages.RemoveAt(4);

            string output = "DeletePage.pdf";

            //save pdf document
            doc.SaveToFile(output);
            doc.Close();
            //Launch the Pdf file.
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
