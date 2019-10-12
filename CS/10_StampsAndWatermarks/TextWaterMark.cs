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
            //Create a pdf document and load file from disk
            PdfDocument doc = new PdfDocument();
	    doc.LoadFromFile(@"..\..\..\..\..\..\Data\TextWaterMark.pdf");

            //Get the first page
            PdfPageBase page = doc.Pages[0];

            //Draw text watermark
            PdfTilingBrush brush
                = new PdfTilingBrush(new SizeF(page.Canvas.ClientSize.Width / 2, page.Canvas.ClientSize.Height / 3));
            brush.Graphics.SetTransparency(0.3f);
            brush.Graphics.Save();
            brush.Graphics.TranslateTransform(brush.Size.Width / 2, brush.Size.Height / 2);
            brush.Graphics.RotateTransform(-45);
            brush.Graphics.DrawString("Spire.Pdf Demo",
                new PdfFont(PdfFontFamily.Helvetica, 24), PdfBrushes.Violet, 0, 0,
                new PdfStringFormat(PdfTextAlignment.Center));
            brush.Graphics.Restore();
            brush.Graphics.SetTransparency(1);
            page.Canvas.DrawRectangle(brush, new RectangleF(new PointF(0, 0), page.Canvas.ClientSize));

            //Save pdf file
            doc.SaveToFile("TextWaterMark.pdf");
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
