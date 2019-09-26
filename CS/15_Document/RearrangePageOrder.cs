using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RearrangePageOrder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a pdf document
            PdfDocument doc = new PdfDocument();

            //Load from file
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\SampleB_3.pdf");

            //Rearrange the page order
            doc.Pages.ReArrange(new int[] { 1, 0});

            String result="RearrangePageOrder-result.pdf";
            //Save to file
            doc.SaveToFile(result, FileFormat.PDF);

            //Launch the Pdf file
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
