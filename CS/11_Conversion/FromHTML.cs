using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Spire.Pdf;

namespace FromHTML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a pdf document.
            PdfDocument doc = new PdfDocument();

            String url = "http://www.e-iceblue.com/";
            doc.LoadFromHTML(url, false, true, true);

            //Save pdf file.
            doc.SaveToFile("FromHTML.pdf");
            doc.Close();

            //Launching the Pdf file.
            PDFDocumentViewer("FromHTML.pdf");
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
