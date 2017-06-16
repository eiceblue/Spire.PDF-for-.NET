using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace AddTextInHeaderAndFooter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = "..\\..\\..\\..\\..\\..\\Data\\";
            //pdf file 
            string input = path + "Sample4.pdf";

            //open pdf document
            PdfDocument doc = new PdfDocument(input);

            PdfBrush brush = PdfBrushes.Black;
            PdfPen pen = new PdfPen(brush, 0.75f);
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 9f, FontStyle.Italic), true);
            PdfStringFormat leftAlign = new PdfStringFormat(PdfTextAlignment.Left);
            PdfStringFormat rightAlign = new PdfStringFormat(PdfTextAlignment.Right);
            leftAlign.MeasureTrailingSpaces = true;
            rightAlign.MeasureTrailingSpaces = true;
            PdfMargins margin = doc.PageSettings.Margins;

            float space = font.Height * 0.75f;
            float x = 0;
            float y = 0;
            float width = 0;

            foreach (PdfPageBase page in doc.Pages)
            {
                page.Canvas.SetTransparency(0.5f);
                x = margin.Left;
                width = page.Canvas.ClientSize.Width - margin.Left - margin.Right;
                y = margin.Top - space;
                page.Canvas.DrawLine(pen, x, y, x + width, y);
                y = y - 1 - font.Height;

                //draw header text into page
                page.Canvas.DrawString("Demo of Spire.Pdf", font, brush, x, y, leftAlign);

                brush = PdfBrushes.Blue;
                font = new PdfTrueTypeFont(new Font("Arial", 8f, FontStyle.Regular), true);
                y = page.Canvas.ClientSize.Height - margin.Bottom - font.Height;
               
                //draw footer text into page
                page.Canvas.DrawString("Created by E-iceblue Co,.Ltd", font, brush, x + width, y, rightAlign);

                page.Canvas.SetTransparency(1);
            }

            string output = "AddTextInHeaderAndFooter.pdf";

            //Save pdf file.
            doc.SaveToFile(output);
            doc.Close();

            //Launching the Pdf file.
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
