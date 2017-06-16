using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;


namespace Transition
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
            doc.ViewerPreferences.PageMode = PdfPageMode.FullScreen;

            //margin
            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
            PdfMargins margin = new PdfMargins();
            margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Bottom = margin.Top;
            margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Right = margin.Left;

            //create section
            PdfSection section = doc.Sections.Add();
            section.PageSettings.Size = PdfPageSize.A4;
            section.PageSettings.Margins = margin;
            section.PageSettings.Transition = new PdfPageTransition();
            section.PageSettings.Transition.Duration = 2;
            section.PageSettings.Transition.Style = PdfTransitionStyle.Fly;
            section.PageSettings.Transition.PageDuration = 1;

            PdfNewPage page = section.Pages.Add();
            page.BackgroundColor = Color.Red;
            DrawPage(page);

            page = section.Pages.Add();
            page.BackgroundColor = Color.Green;
            DrawPage(page);

            page = section.Pages.Add();
            page.BackgroundColor = Color.Blue;
            DrawPage(page);

            section = doc.Sections.Add();
            section.PageSettings.Size = PdfPageSize.A4;
            section.PageSettings.Margins = margin;
            section.PageSettings.Transition = new PdfPageTransition();
            section.PageSettings.Transition.Duration = 2;
            section.PageSettings.Transition.Style = PdfTransitionStyle.Box;
            section.PageSettings.Transition.PageDuration = 1;

            page = section.Pages.Add();
            page.BackgroundColor = Color.Orange;
            DrawPage(page);

            page = section.Pages.Add();
            page.BackgroundColor = Color.Brown;
            DrawPage(page);

            page = section.Pages.Add();
            page.BackgroundColor = Color.Navy;
            DrawPage(page);

            section = doc.Sections.Add();
            section.PageSettings.Size = PdfPageSize.A4;
            section.PageSettings.Margins = margin;
            section.PageSettings.Transition = new PdfPageTransition();
            section.PageSettings.Transition.Duration = 2;
            section.PageSettings.Transition.Style = PdfTransitionStyle.Split;
            section.PageSettings.Transition.Dimension = PdfTransitionDimension.Vertical;
            section.PageSettings.Transition.Motion = PdfTransitionMotion.Inward;
            section.PageSettings.Transition.PageDuration = 1;

            page = section.Pages.Add();
            page.BackgroundColor = Color.Orange;
            DrawPage(page);

            page = section.Pages.Add();
            page.BackgroundColor = Color.Brown;
            DrawPage(page);

            page = section.Pages.Add();
            page.BackgroundColor = Color.Navy;
            DrawPage(page);

            //Save pdf file.
            doc.SaveToFile("Transition.pdf");
            doc.Close();

            //Launching the Pdf file.
            PDFDocumentViewer("Transition.pdf");
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

    }
}
