using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace HeaderAndFooter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = @"..\..\..\..\..\..\..\Data\HeaderAndFooter.pdf";

            //Open the document from disk
            PdfDocument doc = new PdfDocument();
			doc.LoadFromFile(input);
            PdfBrush brush = PdfBrushes.Black;
            PdfPen pen = new PdfPen(brush, 0.75f);
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 10f, FontStyle.Italic), true);
            PdfStringFormat rightAlign = new PdfStringFormat(PdfTextAlignment.Right);
            PdfStringFormat leftAlign = new PdfStringFormat(PdfTextAlignment.Left);
            rightAlign.MeasureTrailingSpaces = true;
            rightAlign.MeasureTrailingSpaces = true;
            PdfMargins margin = doc.PageSettings.Margins;

            float space = font.Height * 0.75f;
            float x = 0;
            float y = 0;
            float width=0;

            //Create a new pdf document
            PdfDocument newPdf = new PdfDocument();
            PdfPageBase newPage;

            foreach (PdfPageBase page in doc.Pages)
            {
                //Add new page
                newPage = newPdf.Pages.Add(page.Size,new PdfMargins(0));

                newPage.Canvas.SetTransparency(0.5f);
                x = margin.Left;
                width = page.Canvas.ClientSize.Width - margin.Left - margin.Right;
                y = margin.Top - space;

                //Draw header line
                newPage.Canvas.DrawLine(pen, x, y + 15, x + width, y + 15);
                y = y+10 - font.Height;

                //Draw header image into newPage
                newPage.Canvas.SetTransparency(0.5f);
                PdfImage headerImage= PdfImage.FromFile(@"..\..\..\..\..\..\Data\Header.png");
                newPage.Canvas.DrawImage(headerImage, new PointF(0, 0));

                //Draw header text into newPage
                newPage.Canvas.DrawString("Demo of Spire.Pdf", font, brush, x + width, y, rightAlign);

                //Draw footer image into newPage
                PdfImage footerImage = PdfImage.FromFile(@"..\..\..\..\..\..\Data\Footer.png");
                newPage.Canvas.DrawImage(footerImage, new PointF(0, newPage.Canvas.ClientSize.Height - footerImage.PhysicalDimension.Height));

                brush = PdfBrushes.DarkBlue;
                font = new PdfTrueTypeFont(new Font("Arial", 12f, FontStyle.Bold), true);
                y = newPage.Canvas.ClientSize.Height - margin.Bottom - font.Height;

                //Draw footer text into newPage
                newPage.Canvas.DrawString("Created by E-iceblue Co,.Ltd", font, brush, x, y, leftAlign);

                newPage.Canvas.SetTransparency(1);

                //Draw the page into newPage
                page.CreateTemplate().Draw(newPage.Canvas, new PointF(0, 0));
            }

            string output = "Output.pdf";

            //Save the document
            newPdf.SaveToFile(output);
            newPdf.Close();

            //Launch the Pdf file
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
