using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace PageLable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = @"..\..\..\..\..\..\Data\Sample.pdf";
            string output = "notExistLableAddNew.pdf";

            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(input);
            doc.PageLabels = new PdfPageLabels();
            doc.PageLabels.AddRange(0, PdfPageLabels.Decimal_Arabic_Numerals_Style, "label test ");
            doc.SaveToFile(output, FileFormat.PDF);

            PDFDocumentViewer(output);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string input = @"..\..\..\..\..\..\Data\hasLable.pdf";
            string output = "ChangeLable.pdf";

            PdfDocument newdoc = new PdfDocument();
            newdoc.LoadFromFile(input);
            PdfPageLabels pageLabels = newdoc.PageLabels;
            pageLabels.AddRange(0, PdfPageLabels.Decimal_Arabic_Numerals_Style, "new lable");
            newdoc.SaveToFile(output, FileFormat.PDF);

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
