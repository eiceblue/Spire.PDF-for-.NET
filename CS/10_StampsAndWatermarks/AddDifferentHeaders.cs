using Spire.Pdf;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddDifferentHeaders
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Load the Pdf from disk
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile("../../../../../../../Data/MultipagePDF.pdf");

            string header1 = "Header 1";
            string header2 = "Header 2";

            //Define style
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 15f, FontStyle.Bold));
            PdfBrush brush=PdfBrushes.Red;
            RectangleF rect=new RectangleF(new PointF(0,20),new SizeF(doc.PageSettings.Size.Width,50f));
            PdfStringFormat format=new PdfStringFormat();
            format.Alignment= PdfTextAlignment.Center;
            doc.Pages[0].Canvas.DrawString(header1,font,brush,rect,format);

            font = new PdfTrueTypeFont(new Font("Aleo", 15f, FontStyle.Regular));
            brush = PdfBrushes.Black;
            format.Alignment = PdfTextAlignment.Left;
            doc.Pages[1].Canvas.DrawString(header2, font, brush, rect, format);

            //Save the document
            string output = "AddingDifferentHeaders_result.pdf";
            doc.SaveToFile(output, FileFormat.PDF);

            //Launch the Pdf
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
