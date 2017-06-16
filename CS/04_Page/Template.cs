using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.AutomaticFields;

namespace Template
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
            doc.ViewerPreferences.PageLayout = PdfPageLayout.TwoColumnLeft;

            //margin
            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
            PdfMargins margin = new PdfMargins();
            margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Bottom = margin.Top;
            margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Right = margin.Left;

            SetDocumentTemplate(doc, PdfPageSize.A4, margin);

            //create section
            PdfSection section = doc.Sections.Add();
            section.PageSettings.Size = PdfPageSize.A4;
            section.PageSettings.Margins = new PdfMargins(0);
            SetSectionTemplate(section, PdfPageSize.A4, margin, "Section 1");

            // Create one page
            PdfNewPage page = section.Pages.Add();

            //Draw page
            DrawPage(page); 

            page = section.Pages.Add();
            DrawPage(page);

            page = section.Pages.Add();
            DrawPage(page);

            page = section.Pages.Add();
            DrawPage(page);

            page = section.Pages.Add();
            DrawPage(page);

            //Save pdf file.
            doc.SaveToFile("Template.pdf");
            doc.Close();

            //Launching the Pdf file.
            PDFDocumentViewer("Template.pdf");
        }

        private void SetSectionTemplate(PdfSection section, SizeF pageSize, PdfMargins margin, String label)
        {
            PdfPageTemplateElement leftSpace
                = new PdfPageTemplateElement(margin.Left, pageSize.Height);
            leftSpace.Foreground = true;
            section.Template.OddLeft = leftSpace;

            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 9f, FontStyle.Italic));
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            float y = (pageSize.Height - margin.Top - margin.Bottom) * (1 - 0.618f);
            RectangleF bounds
                = new RectangleF(10, y, margin.Left - 20, font.Height + 6);
            leftSpace.Graphics.DrawRectangle(PdfBrushes.OrangeRed, bounds);
            leftSpace.Graphics.DrawString(label, font, PdfBrushes.White, bounds, format);

            PdfPageTemplateElement rightSpace
                = new PdfPageTemplateElement(margin.Right, pageSize.Height);
            rightSpace.Foreground = true;
            section.Template.EvenRight = rightSpace;
            bounds
                = new RectangleF(10, y, margin.Right - 20, font.Height + 6);
            rightSpace.Graphics.DrawRectangle(PdfBrushes.SaddleBrown, bounds);
            rightSpace.Graphics.DrawString(label, font, PdfBrushes.White, bounds, format);
        }

        private void SetDocumentTemplate(PdfDocument doc, SizeF pageSize, PdfMargins margin)
        {
            PdfPageTemplateElement leftSpace
                = new PdfPageTemplateElement(margin.Left, pageSize.Height);
            doc.Template.Left = leftSpace;

            PdfPageTemplateElement topSpace
                = new PdfPageTemplateElement(pageSize.Width, margin.Top);
            topSpace.Foreground = true;
            doc.Template.Top = topSpace;

            //draw header label
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 9f, FontStyle.Italic));
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Right);
            String label = "Demo of Spire.Pdf";
            SizeF size = font.MeasureString(label, format);
            float y = topSpace.Height - font.Height - 1;
            PdfPen pen = new PdfPen(Color.Black, 0.75f);
            topSpace.Graphics.SetTransparency(0.5f);
            topSpace.Graphics.DrawLine(pen, margin.Left, y, pageSize.Width - margin.Right, y);
            y = y - 1 - size.Height;
            topSpace.Graphics.DrawString(label, font, PdfBrushes.Black, pageSize.Width - margin.Right, y, format);

            PdfPageTemplateElement rightSpace
                = new PdfPageTemplateElement(margin.Right, pageSize.Height);
            doc.Template.Right = rightSpace;

            PdfPageTemplateElement bottomSpace
                = new PdfPageTemplateElement(pageSize.Width, margin.Bottom);
            bottomSpace.Foreground = true;
            doc.Template.Bottom = bottomSpace;

            //draw footer label
            y = font.Height + 1;
            bottomSpace.Graphics.SetTransparency(0.5f);
            bottomSpace.Graphics.DrawLine(pen, margin.Left, y, pageSize.Width - margin.Right, y);
            y = y + 1;
            PdfPageNumberField pageNumber = new PdfPageNumberField();
            PdfPageCountField pageCount = new PdfPageCountField();
            PdfCompositeField pageNumberLabel = new PdfCompositeField();
            pageNumberLabel.AutomaticFields
                = new PdfAutomaticField[] { pageNumber, pageCount };
            pageNumberLabel.Brush = PdfBrushes.Black;
            pageNumberLabel.Font = font;
            pageNumberLabel.StringFormat = format;
            pageNumberLabel.Text = "page {0} of {1}";
            pageNumberLabel.Draw(bottomSpace.Graphics, pageSize.Width - margin.Right, y);

            PdfImage headerImage
                = PdfImage.FromFile(@"..\..\..\..\..\..\Data\Header.png");
            PointF pageLeftTop = new PointF(-margin.Left, -margin.Top);
            PdfPageTemplateElement header = new PdfPageTemplateElement(pageLeftTop, headerImage.PhysicalDimension);
            header.Foreground = false;
            header.Graphics.SetTransparency(0.5f);
            header.Graphics.DrawImage(headerImage, 0, 0);
            doc.Template.Stamps.Add(header);

            PdfImage footerImage
                = PdfImage.FromFile(@"..\..\..\..\..\..\Data\Footer.png");
            y = pageSize.Height - footerImage.PhysicalDimension.Height;
            PointF footerLocation = new PointF(-margin.Left, y);
            PdfPageTemplateElement footer = new PdfPageTemplateElement(footerLocation, footerImage.PhysicalDimension);
            footer.Foreground = false;
            footer.Graphics.SetTransparency(0.5f);
            footer.Graphics.DrawImage(footerImage, 0, 0);
            doc.Template.Stamps.Add(footer);
        }

        private void DrawPage(PdfPageBase page)
        {
            float pageWidth = page.Canvas.ClientSize.Width;
            float y = 0;

            //title
            y = y + 5;
            PdfBrush brush2 = new PdfSolidBrush(Color.Black);
            PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 16f, FontStyle.Bold));
            PdfStringFormat format2 = new PdfStringFormat(PdfTextAlignment.Center);
            format2.CharacterSpacing = 1f;
            String text = "Summary of Science";
            page.Canvas.DrawString(text, font2, brush2, pageWidth / 2, y, format2);
            SizeF size = font2.MeasureString(text, format2);
            y = y + size.Height + 6;

            //icon
            PdfImage image = PdfImage.FromFile(@"..\..\..\..\..\..\Data\Wikipedia_Science.png");
            page.Canvas.DrawImage(image, new PointF(pageWidth - image.PhysicalDimension.Width, y));
            float imageLeftSpace = pageWidth - image.PhysicalDimension.Width - 2;
            float imageBottom = image.PhysicalDimension.Height + y;

            //refenrence content
            PdfTrueTypeFont font3 = new PdfTrueTypeFont(new Font("Arial", 9f));
            PdfStringFormat format3 = new PdfStringFormat();
            format3.ParagraphIndent = font3.Size * 2;
            format3.MeasureTrailingSpaces = true;
            format3.LineSpacing = font3.Size * 1.5f;
            String text1 = "(All text and picture from ";
            String text2 = "Wikipedia";
            String text3 = ", the free encyclopedia)";
            page.Canvas.DrawString(text1, font3, brush2, 0, y, format3);

            size = font3.MeasureString(text1, format3);
            float x1 = size.Width;
            format3.ParagraphIndent = 0;
            PdfTrueTypeFont font4 = new PdfTrueTypeFont(new Font("Arial", 9f, FontStyle.Underline));
            PdfBrush brush3 = PdfBrushes.Blue;
            page.Canvas.DrawString(text2, font4, brush3, x1, y, format3);
            size = font4.MeasureString(text2, format3);
            x1 = x1 + size.Width;

            page.Canvas.DrawString(text3, font3, brush2, x1, y, format3);
            y = y + size.Height;

            //content
            PdfStringFormat format4 = new PdfStringFormat();
            text = System.IO.File.ReadAllText(@"..\..\..\..\..\..\Data\Summary_of_Science.txt");
            PdfTrueTypeFont font5 = new PdfTrueTypeFont(new Font("Arial", 10f));
            format4.LineSpacing = font5.Size * 1.5f;
            PdfStringLayouter textLayouter = new PdfStringLayouter();
            float imageLeftBlockHeight = imageBottom - y;
            PdfStringLayoutResult result
                = textLayouter.Layout(text, font5, format4, new SizeF(imageLeftSpace, imageLeftBlockHeight));
            if (result.ActualSize.Height < imageBottom - y)
            {
                imageLeftBlockHeight = imageLeftBlockHeight + result.LineHeight;
                result = textLayouter.Layout(text, font5, format4, new SizeF(imageLeftSpace, imageLeftBlockHeight));
            }
            foreach (LineInfo line in result.Lines)
            {
                page.Canvas.DrawString(line.Text, font5, brush2, 0, y, format4);
                y = y + result.LineHeight;
            }
            PdfTextWidget textWidget = new PdfTextWidget(result.Remainder, font5, brush2);
            PdfTextLayout textLayout = new PdfTextLayout();
            textLayout.Break = PdfLayoutBreakType.FitPage;
            textLayout.Layout = PdfLayoutType.Paginate;
            RectangleF bounds = new RectangleF(new PointF(0, y), page.Canvas.ClientSize);
            textWidget.StringFormat = format4;
            textWidget.Draw(page, bounds, textLayout);
        }

        private void PDFDocumentViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
