using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.General.Find;

namespace FindTextInDefineArea
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string input = @"..\..\..\..\..\..\Data\SampleB_1.pdf";
            string output = "FindTextInDefinePlace.pdf";
            //Load document from disk
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(input);

            //Define a rectangle
            RectangleF rctg = new RectangleF(0, 0, 300, 300);

            //Find text in the rectangle
            PdfTextFindCollection findCollection = doc.Pages[0].FindText(rctg, "Spire", TextFindParameter.WholeWord);
            PdfTextFindCollection findCollectionOut = doc.Pages[0].FindText(rctg, "PDF", TextFindParameter.WholeWord);

            //Highlight the found text
            foreach (PdfTextFind find in findCollection.Finds)
            { find.ApplyHighLight(Color.Green); }

            foreach (PdfTextFind findOut in findCollectionOut.Finds)
            { findOut.ApplyHighLight(Color.Yellow); }

            //Save the document
            doc.SaveToFile(output, FileFormat.PDF);
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
