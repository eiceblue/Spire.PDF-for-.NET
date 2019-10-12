using System;
using System.Windows.Forms;
using Spire.Pdf;

namespace XPSToPDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Xps file
            String file = @"..\..\..\..\..\..\Data\XPStoPDF.xps";

            //Open xps document
            PdfDocument doc = new PdfDocument();
            doc.LoadFromXPS(file);

            //Convert to pdf file
            doc.SaveToFile("XPStoPDF-result.pdf");
            doc.Close();

            //Launch the Pdf file
            PDFDocumentViewer("XPStoPDF-result.pdf");
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
