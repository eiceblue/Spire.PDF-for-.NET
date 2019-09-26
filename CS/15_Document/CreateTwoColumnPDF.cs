using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Fields;
using Spire.Pdf.Annotations;
using Spire.Pdf.Graphics;
using Spire.Pdf.Actions;
using Spire.Pdf.General;
using Spire.Pdf.General.Find;
namespace CreateTwoColumnPDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Creates a pdf document
            PdfDocument doc = new PdfDocument();

            // Creates a new page
            PdfPageBase page = doc.Pages.Add();

            string s1 = "Spire.PDF for .NET is a professional PDF component applied to creating, writing, "
                        + "editing, handling and reading PDF files without any external dependencies within "
                        + ".NET application. Using this .NET PDF library, you can implement rich capabilities "
                        + "to create PDF files from scratch or process existing PDF documents entirely through "
                        + "C#/VB.NET without installing Adobe Acrobat.";
            string s2 = "Many rich features can be supported by the .NET PDF API, such as security setting "
                        + "(including digital signature), PDF text/attachment/image extract, PDF merge/split "
                        + ", metadata update, section, graph/image drawing and inserting, table creation and "
                        + "processing, and importing data etc.Besides, Spire.PDF for .NET can be applied to easily "
                        + "converting Text, Image and HTML to PDF with C#/VB.NET in high quality.";

            // Get width and height of page
            float pageWidth =page.GetClientSize().Width;
            float pageHeight=page.GetClientSize().Height;

            PdfBrush brush = PdfBrushes.Black;
            PdfFont font = new PdfFont(PdfFontFamily.TimesRoman, 12f);
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Justify);

            // Draw text
            page.Canvas.DrawString(s1, font, brush, new RectangleF(0, 20, pageWidth / 2 - 8f, pageHeight), format);
            page.Canvas.DrawString(s2, font, brush, new RectangleF(pageWidth / 2 + 8f, 20, pageWidth / 2 - 8f, pageHeight), format);


            String result = "CreateTwoColumnPDF_out.pdf";

            //Save the document
            doc.SaveToFile(result);
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
