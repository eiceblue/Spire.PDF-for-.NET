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
            // Create a PDF document
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile("../../../../../../../Data/MultipagePDF.pdf");

            // Set the margin
            PdfMargins margin = doc.PageSettings.Margins;

            // Draw page numbers
            DrawPageNumber(doc, margin, 1, doc.Pages.Count);

            // Specify the output file name
            String result = "PageNumberStamp_out.pdf";

            // Save the document
            doc.SaveToFile(result);
            doc.Close(); ;

            //Launch the Pdf file
            PDFDocumentViewer(result);
        }
        private void DrawPageNumber(PdfDocument doc, PdfMargins margin, int startNumber, int pageCount)
        {
            // Iterate through each page in the document
            foreach (PdfPageBase page in doc.Pages)
            {
                // Set transparency for the canvas
                page.Canvas.SetTransparency(0.5f);

                // Define brush, pen, font, and string format for drawing the page number
                PdfBrush brush = PdfBrushes.Black;
                PdfPen pen = new PdfPen(brush, 0.75f);
                PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f, FontStyle.Italic), true);
                //////////////////Use the following code for netstandard dlls/////////////////////////
                /*
                 PdfTrueTypeFont font = new PdfTrueTypeFont("Arial", 12f, PdfFontStyle.Italic, true);
                */
                PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Right);
                format.MeasureTrailingSpaces = true;

                // Calculate the spacing between lines
                float space = font.Height * 0.75f;

                // Define the initial position
                float x = margin.Left;
                float width = page.Canvas.ClientSize.Width - margin.Left - margin.Right;
                float y = page.Canvas.ClientSize.Height - margin.Bottom + space;

                // Draw a line above the page number
                page.Canvas.DrawLine(pen, x, y, x + width, y);

                // Adjust the position and draw the page number label
                y = y + 1;
                String numberLabel = String.Format("{0} of {1}", startNumber++, pageCount);
                page.Canvas.DrawString(numberLabel, font, brush, x + width, y, format);

                // Reset the transparency for the canvas
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
