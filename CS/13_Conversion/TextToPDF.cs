using Spire.Pdf;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TextToPDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Get text from .txt file
            string text = File.ReadAllText(@"..\..\..\..\..\..\Data\TextToPdf.txt");

            //Create a pdf document
            PdfDocument doc = new PdfDocument();

            PdfSection section = doc.Sections.Add();
            PdfPageBase page = section.Pages.Add();

            //Create a PdfFont
            PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 11);

            //Set string format
            PdfStringFormat format = new PdfStringFormat();
            format.LineSpacing = 20f;

            PdfBrush brush = PdfBrushes.Black;

            //Set text layout
            PdfTextLayout textLayout = new PdfTextLayout();
            textLayout.Break = PdfLayoutBreakType.FitPage;
            textLayout.Layout = PdfLayoutType.Paginate;
            
            RectangleF bounds = new RectangleF(new PointF(10, 20), page.Canvas.ClientSize);

            PdfTextWidget textWidget = new PdfTextWidget(text, font, brush);
            textWidget.StringFormat = format;
            textWidget.Draw(page, bounds, textLayout);

            string output ="TextToPdf.pdf";

            //Save to file
            doc.SaveToFile(output, FileFormat.PDF);

            //Launch the result file
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
