using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Tables;

namespace TextWaterMark
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a PDF document and load a file from the disk.
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\TextWaterMark.pdf");

            // Get the first page from the document.
            PdfPageBase page = doc.Pages[0];

            // Create a tiling brush for drawing a text watermark.
            PdfTilingBrush brush = new PdfTilingBrush(new SizeF(page.Canvas.ClientSize.Width / 2, page.Canvas.ClientSize.Height / 3));

            // Set transparency for the brush graphics.
            brush.Graphics.SetTransparency(0.3f);

            // Save the current state of the brush graphics.
            brush.Graphics.Save();

            // Translate and rotate the brush graphics to position the watermark.
            brush.Graphics.TranslateTransform(brush.Size.Width / 2, brush.Size.Height / 2);
            brush.Graphics.RotateTransform(-45);

            // Draw the text watermark using the brush graphics.
            brush.Graphics.DrawString("Spire.Pdf Demo",
                new PdfFont(PdfFontFamily.Helvetica, 24), PdfBrushes.Violet, 0, 0,
                new PdfStringFormat(PdfTextAlignment.Center));

            // Restore the previous state of the brush graphics.
            brush.Graphics.Restore();

            // Reset the transparency to fully opaque.
            brush.Graphics.SetTransparency(1);

            // Draw a rectangle filled with the tiling brush as the watermark on the page.
            page.Canvas.DrawRectangle(brush, new RectangleF(new PointF(0, 0), page.Canvas.ClientSize));

            // Save the modified PDF document to a file.
            doc.SaveToFile("TextWaterMark.pdf");

            // Close the PDF document.
            doc.Close();

            //Launch the Pdf file
            PDFDocumentViewer("TextWaterMark.pdf");
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
