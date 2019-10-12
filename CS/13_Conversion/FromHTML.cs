using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Spire.Pdf;
using System.IO;
using Spire.Pdf.HtmlConverter;

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
            PdfPageSettings pgSt = new PdfPageSettings();
            pgSt.Size = PdfPageSize.A4;

            PdfHtmlLayoutFormat htmlLayoutFormat = new PdfHtmlLayoutFormat();
            htmlLayoutFormat.IsWaiting = false;

            String htmlpath = @"..\..\..\..\..\..\Data\FromHTML.htm";
            string source = File.ReadAllText(htmlpath);
            doc.LoadFromHTML(source, true, pgSt, htmlLayoutFormat);

            //Save pdf file.
            doc.SaveToFile("FromHTML.pdf");
            doc.Close();

            //Launch the file.
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
