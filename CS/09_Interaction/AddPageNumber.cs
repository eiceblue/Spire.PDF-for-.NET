using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace AddPageNumber
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //pdf file 
            string input = "..\\..\\..\\..\\..\\..\\Data\\Sample8.pdf";

            //open a pdf document
            PdfDocument document = new PdfDocument(input);

            //get pdf margins
            PdfMargins margin = document.PageSettings.Margins;

            int startNumber = 1;

            //get the count of pages
            int pageCount = document.Pages.Count;

            //set page number
            foreach (PdfPageBase page in document.Pages)
            {
                page.Canvas.SetTransparency(0.5f);
                PdfBrush brush = PdfBrushes.Black;
                PdfPen pen = new PdfPen(brush, 0.75f);
                PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 9f, FontStyle.Italic), true);
                PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Right);
                format.MeasureTrailingSpaces = true;
                float space = font.Height * 0.75f;
                float x = margin.Left;
                float width = page.Canvas.ClientSize.Width - margin.Left - margin.Right;
                float y = page.Canvas.ClientSize.Height - margin.Bottom + space;
                page.Canvas.DrawLine(pen, x, y, x + width, y);
                y = y + 1;
                String numberLabel
                    = String.Format("{0} of {1}", startNumber++, pageCount);
                page.Canvas.DrawString(numberLabel, font, brush, x + width, y, format);
                page.Canvas.SetTransparency(1);
            }

            string output = "AddPageNumber.pdf";

            //save pdf document
            document.SaveToFile(output);

            //Launching the Pdf file
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
