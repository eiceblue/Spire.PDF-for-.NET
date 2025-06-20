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

            // Open the document from disk
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(input);

            // Define the brush for text drawing
            PdfBrush brush = PdfBrushes.Black;

            // Define the pen for line drawing
            PdfPen pen = new PdfPen(brush, 0.75f);

            // Define the font for text drawing
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 10f, FontStyle.Italic), true);

            // Define the string format for right-aligned text
            PdfStringFormat rightAlign = new PdfStringFormat(PdfTextAlignment.Right);

            // Define the string format for left-aligned text
            PdfStringFormat leftAlign = new PdfStringFormat(PdfTextAlignment.Left);

            rightAlign.MeasureTrailingSpaces = true;
            leftAlign.MeasureTrailingSpaces = true;

            // Get the page margins of the document
            PdfMargins margin = doc.PageSettings.Margins;

            // Calculate the spacing between lines
            float space = font.Height * 0.75f;

            // Initialize variables for position and width calculation
            float x = 0;
            float y = 0;
            float width = 0;

            // Create a new PDF document
            PdfDocument newPdf = new PdfDocument();
            PdfPageBase newPage;

            foreach (PdfPageBase page in doc.Pages)
            {
                // Add a new page to the new PDF document
                newPage = newPdf.Pages.Add(page.Size, new PdfMargins(0));

                // Set transparency for the canvas
                newPage.Canvas.SetTransparency(0.5f);

                // Calculate the position and width for header elements
                x = margin.Left;
                width = page.Canvas.ClientSize.Width - margin.Left - margin.Right;
                y = margin.Top - space;

                // Draw a line as a header separator
                newPage.Canvas.DrawLine(pen, x, y + 15, x + width, y + 15);
                y = y + 10 - font.Height;

                // Load the header image
                PdfImage headerImage = PdfImage.FromFile(@"..\..\..\..\..\..\..\Data\Header.png");

                // Draw the header image on the new page
                newPage.Canvas.DrawImage(headerImage, new PointF(0, 0));

                // Draw the header text on the new page with right alignment
                newPage.Canvas.DrawString("Demo of Spire.Pdf", font, brush, x + width, y, rightAlign);

                // Load the footer image
                PdfImage footerImage = PdfImage.FromFile(@"..\..\..\..\..\..\..\Data\Footer.png");

                // Draw the footer image on the new page
                newPage.Canvas.DrawImage(footerImage, new PointF(0, newPage.Canvas.ClientSize.Height - footerImage.PhysicalDimension.Height));

                // Change the font and brush for the footer text
                brush = PdfBrushes.DarkBlue;
                font = new PdfTrueTypeFont(new Font("Arial", 12f, FontStyle.Bold), true);
                y = newPage.Canvas.ClientSize.Height - margin.Bottom - font.Height;

                // Draw the footer text on the new page with left alignment
                newPage.Canvas.DrawString("Created by E-iceblue Co,.Ltd", font, brush, x, y, leftAlign);

                // Reset the transparency of the canvas
                newPage.Canvas.SetTransparency(1);

                // Draw the original page content onto the new page
                page.CreateTemplate().Draw(newPage.Canvas, new PointF(0, 0));
            }

            string output = "Output.pdf";

            // Save and close the new PDF document
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
