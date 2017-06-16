using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;


namespace Pagination
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

            //margin
            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
            PdfMargins margin = new PdfMargins();
            margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Bottom = margin.Top;
            margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Right = margin.Left;

            DrawCover(doc.Sections.Add(), margin);
            DrawContent(doc.Sections.Add(), margin);
            DrawPageNumber(doc.Sections[1], margin, 1, doc.Sections[1].Pages.Count);

            //Save pdf file.
            doc.SaveToFile("Pagination.pdf");
            doc.Close();

            //Launching the Pdf file.
            PDFDocumentViewer("Pagination.pdf");
        }

        private void DrawCover(PdfSection section, PdfMargins margin)
        {
            section.PageNumber = new PdfPageNumber();
            section.PageNumber.NumberStyle = PdfNumberStyle.LowerRoman;
            section.PageNumber.Prefix = "cover ";
            section.PageSettings.Size = PdfPageSize.A4;
            section.PageSettings.Margins.All = 0;
            PdfPageBase page = section.Pages.Add();
            DrawPageHeaderAndFooter(page, margin, true);

            //refenrence content
            PdfBrush brush1 = PdfBrushes.LightGray;
            PdfBrush brush2 = PdfBrushes.Blue;
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 8f));
            PdfStringFormat format = new PdfStringFormat();
            format.MeasureTrailingSpaces = true;
            String text1 = "(All text and picture from ";
            String text2 = "Wikipedia";
            String text3 = ", the free encyclopedia)";
            float x = 0, y = 10;
            x = x + margin.Left;
            y = y + margin.Top;
            page.Canvas.DrawString(text1, font1, brush1, x, y, format);
            x = x + font1.MeasureString(text1, format).Width;
            page.Canvas.DrawString(text2, font1, brush2, x, y, format);
            x = x + font1.MeasureString(text2, format).Width;
            page.Canvas.DrawString(text3, font1, brush1, x, y, format);

            //cover
            PdfBrush brush3 = PdfBrushes.Black;
            PdfBrush brush4 = new PdfSolidBrush(new PdfRGBColor(0xf9, 0xf9, 0xf9));
            PdfImage image
                = PdfImage.FromFile(@"..\..\..\..\..\..\Data\SciencePersonificationBoston.jpg");
            String text = Pagination.Properties.Resources.ImageDescription;
            float r = image.PhysicalDimension.Height / image.Height;
            PdfPen pen = new PdfPen(brush1, r);
            SizeF size = font1.MeasureString(text, image.PhysicalDimension.Width - 2);
            PdfTemplate template
                = new PdfTemplate(image.PhysicalDimension.Width + 4 * r + 4,
                    image.PhysicalDimension.Height + 4 * r + 7 + size.Height);
            template.Graphics.DrawRectangle(pen, brush4, 0, 0, template.Width, template.Height);
            x = y = r + 2;
            template.Graphics.DrawRectangle(brush1, x, y,
                image.PhysicalDimension.Width + 2 * r,
                image.PhysicalDimension.Height + 2 * r);
            x = y = x + r;
            template.Graphics.DrawImage(image, x, y);

            x = x - 1;
            y = y + image.PhysicalDimension.Height + r + 2;
            template.Graphics.DrawString(text, font1, brush3,
                new RectangleF(new PointF(x, y), size));

            float x1 = (page.Canvas.ClientSize.Width - template.Width) / 2;
            float y1 = (page.Canvas.ClientSize.Height - margin.Top - margin.Bottom) * (1 - 0.618f) - template.Height / 2 + margin.Top;
            template.Draw(page.Canvas, x1, y1);

            //title
            format.Alignment = PdfTextAlignment.Center;
            PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 24f, FontStyle.Bold));
            x = page.Canvas.ClientSize.Width / 2;
            y = y1 + template.Height + 10;
            page.Canvas.DrawString(Pagination.Properties.Resources.Title, font2, brush3, x, y, format);
        }

        private void DrawContent(PdfSection section, PdfMargins margin)
        {
            section.PageNumber = new PdfPageNumber();
            section.PageNumber.NumberStyle = PdfNumberStyle.Numeric;
            section.PageNumber.Prefix = "page ";
            section.PageSettings.Size = PdfPageSize.A4;
            section.PageSettings.Margins.All = 0;
            PdfPageBase page = section.Pages.Add();
            DrawPageHeaderAndFooter(page, margin, false);

            float x = margin.Left;
            float y = margin.Top + 8;
            float width = page.Canvas.ClientSize.Width - margin.Left - margin.Right;
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 16f), true);
            PdfBrush brush1 = PdfBrushes.Black;
            PdfPen pen1 = new PdfPen(brush1, 0.75f);
            page.Canvas.DrawString(Pagination.Properties.Resources.Title, font1, brush1, x, y);
            y = y + font1.MeasureString(Pagination.Properties.Resources.Title).Height + 6;
            page.Canvas.DrawLine(pen1, x, y, page.Canvas.ClientSize.Width - margin.Right, y);
            y = y + 1.75f;

            String content = Pagination.Properties.Resources.Content;
            String[] lines
                = content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 10f, FontStyle.Italic), true);
            PdfStringFormat format1 = new PdfStringFormat();
            format1.MeasureTrailingSpaces = true;
            format1.LineSpacing = font2.Height * 1.5f;
            format1.ParagraphIndent = font2.MeasureString("\t", format1).Width;
            y = y + font2.Height * 0.5f;
            SizeF size = font2.MeasureString(lines[0], width, format1);
            page.Canvas.DrawString(lines[0], font2, brush1,
                new RectangleF(new PointF(x, y), size), format1);
            y = y + size.Height;

            PdfTrueTypeFont font3 = new PdfTrueTypeFont(new Font("Arial", 10f), true);
            PdfStringFormat format2 = new PdfStringFormat();
            format2.LineSpacing = font3.Height * 1.4f;
            format2.MeasureTrailingSpaces = true;
            size = font3.MeasureString(lines[1], width, format2);
            page.Canvas.DrawString(lines[1], font3, brush1,
                new RectangleF(new PointF(x, y), size), format2);
            y = y + size.Height;

            y = y + font3.Height * 0.75f;
            float indent = font3.MeasureString("\t\t", format2).Width;
            float x1 = x + indent;
            size = font3.MeasureString(lines[2], width - indent, format2);
            page.Canvas.DrawString(lines[2], font3, brush1,
                new RectangleF(new PointF(x1, y), size), format2);
            y = y + size.Height + font3.Height * 0.75f;

            StringBuilder buff = new StringBuilder();
            for (int i = 3; i < lines.Length; i++)
            {
                buff.AppendLine(lines[i]);
            }
            content = buff.ToString();

            PdfStringLayouter textLayouter = new PdfStringLayouter();
            PdfStringLayoutResult result
                = textLayouter.Layout(content, font3, format2, new SizeF(width, float.MaxValue));
            foreach (LineInfo line in result.Lines)
            {
                if ((line.LineType & LineType.FirstParagraphLine) == LineType.FirstParagraphLine)
                {
                    y = y + font3.Height * 0.75f;
                }
                if (y > (page.Canvas.ClientSize.Height - margin.Bottom - result.LineHeight))
                {
                    page = section.Pages.Add();
                    DrawPageHeaderAndFooter(page, margin, false);
                    y = margin.Top;
                }
                page.Canvas.DrawString(line.Text, font3, brush1, x, y, format2);
                y = y + result.LineHeight;
            }
        }

        private void DrawPageHeaderAndFooter(PdfPageBase page, PdfMargins margin, bool isCover)
        {
            page.Canvas.SetTransparency(0.5f);
            PdfImage headerImage
                = PdfImage.FromFile(@"..\..\..\..\..\..\Data\Header.png");
            PdfImage footerImage
                = PdfImage.FromFile(@"..\..\..\..\..\..\Data\Footer.png");
            page.Canvas.DrawImage(headerImage, new PointF(0, 0));
            page.Canvas.DrawImage(footerImage, new PointF(0, page.Canvas.ClientSize.Height - footerImage.PhysicalDimension.Height));
            if (isCover)
            {
                page.Canvas.SetTransparency(1);
                return;
            }

            PdfBrush brush = PdfBrushes.Black;
            PdfPen pen = new PdfPen(brush, 0.75f);
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 9f, FontStyle.Italic), true);
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Right);
            format.MeasureTrailingSpaces = true;
            float space = font.Height * 0.75f;
            float x = margin.Left;
            float width = page.Canvas.ClientSize.Width - margin.Left - margin.Right;
            float y = margin.Top - space;
            page.Canvas.DrawLine(pen, x, y, x + width, y);
            y = y - 1 - font.Height;
            page.Canvas.DrawString("Demo of Spire.Pdf", font, brush, x + width, y, format);
            page.Canvas.SetTransparency(1);
        }

        private void DrawPageNumber(PdfSection section, PdfMargins margin, int startNumber, int pageCount)
        {
            foreach (PdfPageBase page in section.Pages)
            {
                page.Canvas.SetTransparency(0.5f);
                PdfBrush brush = PdfBrushes.Black;
                PdfPen pen = new PdfPen(brush, 0.75f);
                PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 9f, FontStyle.Italic), true);
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
