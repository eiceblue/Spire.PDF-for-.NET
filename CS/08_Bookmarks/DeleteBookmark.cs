using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;

namespace DeleteBookmark
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Load a pdf document
            string input = @"..\..\..\..\..\..\Data\DeleteBookmark.pdf";
            PdfDocument doc = new PdfDocument();
	    doc.LoadFromFile(input);

            //Delete the first bookmark
            doc.Bookmarks.RemoveAt(0);
			
            //Save the pdf document
            string output = "DeleteBookmark.pdf";
            doc.SaveToFile(output);

            //Launch the file
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
