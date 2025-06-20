using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace DrawText
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a pdf instance
            PdfDocument doc = new PdfDocument();

            //Create one page
            PdfPageBase page = doc.Pages.Add();

            //Draw the text - brush
            DrawText(page);

            // Draw the text - alignment
            AlignText(page);

            //Draw the text - align in rectangle
            AlignTextInRectangle(page);

            // Draw the text - transform
            TransformText(page);
            RotateText(page);

            //Save the document
            doc.SaveToFile("DrawText.pdf");
            doc.Close();

        }

        //Draw the text - alignment
        private void AlignText(PdfPageBase page)
        {
            PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 20f);
            PdfSolidBrush brush = new PdfSolidBrush(Color.Blue);

            //Draws left-aligned text
            PdfStringFormat leftAlignment = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
            page.Canvas.DrawString("Left!", font, brush, 0, 20, leftAlignment);
            page.Canvas.DrawString("Left!", font, brush, 0, 50, leftAlignment);

            //Draws right-aligned text
            PdfStringFormat rightAlignment = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);
            page.Canvas.DrawString("Right!", font, brush, page.Canvas.ClientSize.Width, 20, rightAlignment);
            page.Canvas.DrawString("Right!", font, brush, page.Canvas.ClientSize.Width, 50, rightAlignment);

            //Draws center-aligned text
            PdfStringFormat centerAlignment = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            page.Canvas.DrawString("Go! Turn Around! Go! Go! Go!", font, brush, page.Canvas.ClientSize.Width / 2, 40, centerAlignment);

        }
        //Draw the text - align in rectangle
        private void AlignTextInRectangle(PdfPageBase page)
        {
            //Create the font to use and set the font style 
            PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 10f);
            PdfSolidBrush brush = new PdfSolidBrush(Color.Blue);


            RectangleF rctg1 = new RectangleF(0, 70, page.Canvas.ClientSize.Width / 2, 100);
            RectangleF rctg2 = new RectangleF(page.Canvas.ClientSize.Width / 2, 70, page.Canvas.ClientSize.Width / 2, 100);

            //Draw rectangle and specifies its fill color and position
            page.Canvas.DrawRectangle(new PdfSolidBrush(Color.LightBlue), rctg1);
            page.Canvas.DrawRectangle(new PdfSolidBrush(Color.LightSkyBlue), rctg2);

            //Draws left-aligned text
            PdfStringFormat leftAlignment = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Top);
            page.Canvas.DrawString("Left! Left!", font, brush, rctg1, leftAlignment);
            page.Canvas.DrawString("Left! Left!", font, brush, rctg2, leftAlignment);

            //Draws right-aligned text
            PdfStringFormat rightAlignment = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);
            page.Canvas.DrawString("Right! Right!", font, brush, rctg1, rightAlignment);
            page.Canvas.DrawString("Right! Right!", font, brush, rctg2, rightAlignment);

            //Draws center-aligned text
            PdfStringFormat centerAlignment = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Bottom);
            page.Canvas.DrawString("Go! Turn Around! Go! Go! Go!", font, brush, rctg1, centerAlignment);
            page.Canvas.DrawString("Go! Turn Around! Go! Go! Go!", font, brush, rctg2, centerAlignment);
        }

        private void RotateText(PdfPageBase page)
        {
            //Save graphics state
            PdfGraphicsState state = page.Canvas.Save();

            //Draw the text - transform           
            PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 10f);
            PdfSolidBrush brush = new PdfSolidBrush(Color.Blue);

            PdfStringFormat centerAlignment = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
            float x = page.Canvas.ClientSize.Width / 2;
            float y = 380;

            page.Canvas.TranslateTransform(x, y);
            for (int i = 0; i < 12; i++)
            {
                //Rotate Canvas
                page.Canvas.RotateTransform(30);
                //Draw text 
                page.Canvas.DrawString("Go! Turn Around! Go! Go! Go!", font, brush, 20, 0, centerAlignment);
            }

            //Restore graphics
            page.Canvas.Restore(state);
        }

        private void TransformText(PdfPageBase page)
        {
            //Save graphics state
            PdfGraphicsState state = page.Canvas.Save();

            //Draw the text - transform           
            PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 18f);
            PdfSolidBrush brush1 = new PdfSolidBrush(Color.DeepSkyBlue);
            PdfSolidBrush brush2 = new PdfSolidBrush(Color.CadetBlue);

            page.Canvas.TranslateTransform(20, 200);
            page.Canvas.ScaleTransform(1f, 0.6f);
            page.Canvas.SkewTransform(-10, 0);
            page.Canvas.DrawString("Go! Turn Around! Go! Go! Go!", font, brush1, 0, 0);

            page.Canvas.SkewTransform(10, 0);
            page.Canvas.DrawString("Go! Turn Around! Go! Go! Go!", font, brush2, 0, 0);

            page.Canvas.ScaleTransform(1f, -1f);
            page.Canvas.DrawString("Go! Turn Around! Go! Go! Go!", font, brush2, 0, -2 * 18);

            //Restore graphics
            page.Canvas.Restore(state);
        }

        private void DrawText(PdfPageBase page)
        {
            //Save graphics state
            PdfGraphicsState state = page.Canvas.Save();

            //Draw text - brush
            String text = "Go! Turn Around! Go! Go! Go!";
            PdfPen pen = PdfPens.DeepSkyBlue;
            PdfSolidBrush brush = new PdfSolidBrush(Color.White);
            PdfStringFormat format = new PdfStringFormat();
            PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 18f, PdfFontStyle.Italic);
            SizeF size = font.MeasureString(text, format);
            RectangleF rctg
                = new RectangleF(page.Canvas.ClientSize.Width / 2 + 10, 180,
                size.Width / 3 * 2, size.Height * 2);
            page.Canvas.DrawString(text, font, pen, brush, rctg, format);

            //Restore graphics
            page.Canvas.Restore(state);
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
