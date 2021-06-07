using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;


namespace DrawShapeWithGradientFill
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

            //Create one page
            PdfPageBase page = doc.Pages.Add();

            //Create a PdfLinearGradientBrush
            PdfLinearGradientBrush brush1 = new PdfLinearGradientBrush(new Rectangle(new Point(100, 100), new Size(200, 120)), Color.BlueViolet, Color.DarkBlue, PdfLinearGradientMode.Horizontal);
            //Draw a rectangle
            page.Canvas.DrawRectangle(brush1, new Rectangle(new Point(100, 100), new Size(200, 120)));

            //Create a PdfRadialGradientBrush
            PdfRadialGradientBrush brush2 = new PdfRadialGradientBrush(new PointF(200f, 400f), 100f, new PointF(300f, 500f), 100f, Color.SkyBlue, Color.DarkBlue);
            //Draw a ellipse
            page.Canvas.DrawEllipse(brush2, new Rectangle(new Point(100, 300), new Size(200, 200)));

            string result = "DrawShapeWithGradientFill_out.pdf";
            doc.SaveToFile(result, FileFormat.PDF);

            //Launch the Pdf file
            PDFDocumentViewer(result);
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
