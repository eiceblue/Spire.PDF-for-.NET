using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.AutomaticFields;

namespace SuperScriptAndSubScript
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PdfDocument doc = new PdfDocument();
            //Add a page
            PdfPageBase page = doc.Pages.Add();

            //Set font and brush
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 20f));
            PdfSolidBrush brush = new PdfSolidBrush(Color.Black);

            string text = "Spire.PDF for .NET";

            //Draw Superscript
            DrawSuperscript(page, text, font, brush);

            //Draw Subscript
            DrawSubscript(page, text, font, brush);

            String result="SuperScriptAndSubScriptInPDF_out.pdf";   
            //Save the document
            doc.SaveToFile(result);
            doc.Close();

            //Launch the Pdf file
            PDFDocumentViewer(result);
        }
        private void DrawSuperscript(PdfPageBase page,string text,PdfTrueTypeFont font,PdfSolidBrush brush)
        {
            float x = 120f;
            float y = 100f;
            page.Canvas.DrawString(text, font, brush, new PointF(x, y));

            //Measure the string
            SizeF size = font.MeasureString(text);

            //Set the x coordinate of the superscript text
            x += size.Width;

            //Instantiate a PdfStringFormat instance
            PdfStringFormat format = new PdfStringFormat();

            //Set format as superscript
            format.SubSuperScript = PdfSubSuperScript.SuperScript;

            //Draw superscript text with format
            text = "Superscript";
            page.Canvas.DrawString(text, font, brush, new PointF(x, y), format);
        }

        private void DrawSubscript(PdfPageBase page, string text, PdfTrueTypeFont font,PdfSolidBrush brush)
        {
            float x = 120f;
            float y = 150f;
            page.Canvas.DrawString(text, font, brush, new PointF(x, y));

            //Measure the string
            SizeF size = font.MeasureString(text);

            //Set the x coordinate of the superscript text
            x += size.Width;

            //Instantiate a PdfStringFormat instance
            PdfStringFormat format = new PdfStringFormat();

            //Set format as superscript
            format.SubSuperScript = PdfSubSuperScript.SubScript;

            //Draw superscript text with format
            text = "SubScript";
            page.Canvas.DrawString(text, font, brush, new PointF(x, y), format);
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
