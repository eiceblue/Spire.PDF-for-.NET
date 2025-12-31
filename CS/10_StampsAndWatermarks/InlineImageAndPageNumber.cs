using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace InlineImageAndPageNumber
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load the PDF from disk
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile("../../../../../../../Data/PDFTemplate_HF.pdf");

            // Get the first page
            PdfPageBase page = doc.Pages[0];

            // Define text and image
            string text1 = "Spire.Pdf is a robust component by";
            string text2 = "Technology Co., Ltd.";
            PdfImage image = PdfImage.FromFile("../../../../../../../Data/Top-logo.png");

            // Define font and brush
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Impact", 10f));
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
             PdfTrueTypeFont font = new PdfTrueTypeFont("Impact", 10f, PdfFontStyle.Regular, true);
            */
            PdfBrush brush = PdfBrushes.DarkGray;

            // Measure the size of the text
            SizeF s1 = font.MeasureString(text1);
            SizeF s2 = font.MeasureString(text2);

            float x = 10;
            float y = 10;

            // Define the size of the image
            SizeF imgSize = new SizeF(image.Width / 2, image.Height / 2);

            // Define the rectangle and string format
            SizeF size = new SizeF(s1.Width, imgSize.Width);
            RectangleF rect1 = new RectangleF(new PointF(x, y), size);
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);

            // Draw the text1
            page.Canvas.DrawString(text1, font, brush, rect1, format);

            // Draw the image
            x += s1.Width;
            page.Canvas.DrawImage(image, new PointF(x, y), imgSize);

            // Draw the text2
            x += imgSize.Width;
            size = new SizeF(s2.Width, imgSize.Height);
            rect1 = new RectangleF(new PointF(x, y), size);
            page.Canvas.DrawString(text2, font, brush, rect1, format);

            // Save the document
            string output = "ImageandPageNumberinHeaderFootersectionInline_out.pdf";
            doc.SaveToFile(output);
            doc.Close();

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
