using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;


namespace PageNumberInFooter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a pdf document
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile("../../../../../../../Data/MultipagePDF.pdf");

            //Set the margin
            PdfMargins margin = doc.PageSettings.Margins;

            //Draw Page number
            DrawPageNumber(doc, margin, 1, doc.Pages.Count);
            
            String result="PageNumberStamp_out.pdf"; 
            //Save the document
            doc.SaveToFile(result);
            doc.Close();

            //Launch the Pdf file
            PDFDocumentViewer(result);
        }
        private void DrawPageNumber(PdfDocument doc, PdfMargins margin, int startNumber, int pageCount)
        {
            foreach (PdfPageBase page in doc.Pages)
            {
                page.Canvas.SetTransparency(0.5f);
                PdfBrush brush = PdfBrushes.Black;
                PdfPen pen = new PdfPen(brush, 0.75f);
                PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f, FontStyle.Italic), true);
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
