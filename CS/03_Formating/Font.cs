using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;


namespace Font
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a pdf document.
            PdfDocument doc = new PdfDocument();            

            // Create one page
            PdfPageBase page = doc.Pages.Add();

            //Draw the text
            float l = page.Canvas.ClientSize.Width / 2;
            PointF center = new PointF(l, l);
            float r = (float)Math.Sqrt(2 * l * l);
            PdfRadialGradientBrush brush
                = new PdfRadialGradientBrush(center, 0f, center, r, Color.Blue, Color.Red);
            PdfFontFamily[] fontFamilies
                = (PdfFontFamily[])Enum.GetValues(typeof(PdfFontFamily));
            float y = 10;
            for(int i = 0; i < fontFamilies.Length; i++)
            {
                String text = String.Format("Font Family: {0}", fontFamilies[i]);
                float x1 = 0;
                y = 10 + i * 16;
                PdfFont font1 = new PdfFont(PdfFontFamily.Courier, 14f);
                PdfFont font2 = new PdfFont(fontFamilies[i], 14f);
                float x2 = x1 + 10 + font1.MeasureString(text).Width;
                page.Canvas.DrawString(text, font1, brush, x1, y);
                page.Canvas.DrawString(text, font2, brush, x2, y);
            }
            
            //true type font - embedded.
            System.Drawing.Font font = new System.Drawing.Font("Arial", 14f, FontStyle.Bold);
            PdfTrueTypeFont trueTypeFont = new PdfTrueTypeFont(font);
            page.Canvas.DrawString("Font Family: Arial - Embedded", trueTypeFont, brush, 0, (y = y + 16f));

            //right to left
            String arabicText
                = "\u0627\u0644\u0630\u0647\u0627\u0628\u0021\u0020"
                + "\u0628\u062F\u0648\u0631\u0647\u0020\u062D\u0648\u0644\u0647\u0627\u0021\u0020"
                + "\u0627\u0644\u0630\u0647\u0627\u0628\u0021\u0020"
                + "\u0627\u0644\u0630\u0647\u0627\u0628\u0021\u0020"
                + "\u0627\u0644\u0630\u0647\u0627\u0628\u0021";
            trueTypeFont = new PdfTrueTypeFont(font, true);
            RectangleF rctg = new RectangleF(new PointF(0, (y = y + 16f)), page.Canvas.ClientSize);
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Right);
            format.RightToLeft = true;
            page.Canvas.DrawString(arabicText, trueTypeFont, brush, rctg, format);

            //true type font - not embedded
            font = new System.Drawing.Font("Batang", 14f, FontStyle.Italic);
            trueTypeFont = new PdfTrueTypeFont(font);
            page.Canvas.DrawString("Font Family: Batang - Not Embedded", trueTypeFont, brush, 0, (y = y + 16f));

            //font file
            String fontFileName = @"..\..\..\..\..\..\Data\Hawaii_Killer.ttf";
            trueTypeFont = new PdfTrueTypeFont(fontFileName, 20f);
            page.Canvas.DrawString("Hawaii Killer Font", trueTypeFont, brush, 0, (y = y + 16f));
            page.Canvas.DrawString("Hawaii Killer Font, from http://www.1001freefonts.com", new PdfFont(PdfFontFamily.Helvetica, 8f), brush, 10, (y = y + 20f));

            //cjk font
            PdfCjkStandardFont cjkFont = new PdfCjkStandardFont(PdfCjkFontFamily.MonotypeHeiMedium, 14f);
            page.Canvas.DrawString("How to say 'Font' in Chinese? \u5B57\u4F53", cjkFont, brush, 0, (y = y + 16f));

            cjkFont = new PdfCjkStandardFont(PdfCjkFontFamily.HanyangSystemsGothicMedium, 14f);
            page.Canvas.DrawString("How to say 'Font' in Japanese? \u30D5\u30A9\u30F3\u30C8", cjkFont, brush, 0, (y = y + 16f));

            cjkFont = new PdfCjkStandardFont(PdfCjkFontFamily.HanyangSystemsShinMyeongJoMedium, 14f);
            page.Canvas.DrawString("How to say 'Font' in Korean? \uAE00\uAF34", cjkFont, brush, 0, (y = y + 16f));

            //Save pdf file.
            doc.SaveToFile("Font.pdf");
            doc.Close();

            //Launching the Pdf file.
            PDFDocumentViewer("Font.pdf");

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
