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

            // Initialize a new instance of PdfPageLabels to manage page labels
            doc.PageLabels = new PdfPageLabels();

            // Add a new label starting from page 0 with Decimal_Arabic_Numerals_Style style and text "label test"
            doc.PageLabels.AddRange(0, PdfPageLabels.Decimal_Arabic_Numerals_Style, "label test ");

            // Save the modified document to the specified output file format (PDF)
            doc.SaveToFile(output, FileFormat.PDF);

            PDFDocumentViewer(output);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string input = @"..\..\..\..\..\..\Data\hasLable.pdf";
            string output = "ChangeLable.pdf";

            PdfDocument newdoc = new PdfDocument();
            newdoc.LoadFromFile(input);

            // Get the PageLabels of the provided document
            PdfPageLabels pageLabels = newdoc.PageLabels;

            // Add a new label starting from page 0 with Decimal_Arabic_Numerals_Style style and text "new lable"
            pageLabels.AddRange(0, PdfPageLabels.Decimal_Arabic_Numerals_Style, "new lable");

            // Save the modified document to the specified output file format (PDF)
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
