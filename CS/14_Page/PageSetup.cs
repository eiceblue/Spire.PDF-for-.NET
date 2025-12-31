using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;


namespace PageSetup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a pdf document
            PdfDocument doc = new PdfDocument();

            // Set the margin
            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
            PdfMargins margin = new PdfMargins();
            margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Bottom = margin.Top;
            margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Right = margin.Left;

            // Create one page with A4 size and specified margin
            PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, margin);
            page.BackgroundColor = Color.Chocolate;

            // Draw content on the page
            DrawPage(page);

            // Add another page with A4 size and specified margin
            page = doc.Pages.Add(PdfPageSize.A4, margin);
            page.BackgroundColor = Color.Coral;

            // Draw content on the page
            DrawPage(page);

            // Add a page with A3 size, rotated 180 degrees, and landscape orientation
            page = doc.Pages.Add(PdfPageSize.A3, margin, PdfPageRotateAngle.RotateAngle180, PdfPageOrientation.Landscape);
            page.BackgroundColor = Color.LightPink;

            // Draw content on the page
            DrawPage(page);

            // Create a section and add a page to it
            PdfSection section = doc.Sections.Add();
            page = section.Pages.Add();
            section.PageSettings.Size = PdfPageSize.A4;
            section.PageSettings.Margins = margin;

            // Draw content on the page
            DrawPage(page);

            // Set background color for the page
            page = section.Pages.Add();
            page.BackgroundColor = Color.LightSkyBlue;

            // Draw content on the page
            DrawPage(page);

            // Add a landscape-oriented section
            section = doc.Sections.Add();
            section.PageSettings.Orientation = PdfPageOrientation.Landscape;
            page = section.Pages.Add();
            section.PageSettings.Size = PdfPageSize.A4;
            section.PageSettings.Margins = margin;

            // Draw content on the page
            DrawPage(page);

            // Add a section with 90-degree rotation
            section = doc.Sections.Add();
            page = section.Pages.Add();
            section.PageSettings.Size = PdfPageSize.A4;
            section.PageSettings.Margins = margin;
            section.PageSettings.Rotate = PdfPageRotateAngle.RotateAngle90;

            // Draw content on the page
            DrawPage(page);

            // Add a section with 180-degree rotation
            section = doc.Sections.Add();
            page = section.Pages.Add();
            section.PageSettings.Size = PdfPageSize.A4;
            section.PageSettings.Margins = margin;
            section.PageSettings.Rotate = PdfPageRotateAngle.RotateAngle180;

            // Draw content on the page
            DrawPage(page);

            // Save the document to a file
            doc.SaveToFile("PageSetup.pdf");
            doc.Close();

            //Launch the Pdf file
            PDFDocumentViewer("PageSetup.pdf");
        }

        private void DrawPage(PdfPageBase page)
        {
            // Get the width of the page
            float pageWidth = page.Canvas.ClientSize.Width;

            // Set the initial value of y
            float y = 0;

            // Title
            // Adjust the starting position of y
            y = y + 5;

            // Create a brush and font for the title
            PdfBrush brush2 = new PdfSolidBrush(Color.Black);
            PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 16f, FontStyle.Bold));
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
              PdfTrueTypeFont font2 = new PdfTrueTypeFont("Arial", 16f, PdfFontStyle.Bold, true);
            */

            // Set the format for the title text
            PdfStringFormat format2 = new PdfStringFormat(PdfTextAlignment.Center);
            format2.CharacterSpacing = 1f;

            // Define the text for the title
            String text = "Summary of Science";

            // Draw the title on the page
            page.Canvas.DrawString(text, font2, brush2, pageWidth / 2, y, format2);

            // Measure the size of the title text
            SizeF size = font2.MeasureString(text, format2);

            // Update the value of y based on the size of the title text
            y = y + size.Height + 6;

            // Icon
            // Load an image from a file
            PdfImage image = PdfImage.FromFile(@"..\..\..\..\..\..\Data\Wikipedia_Science.png");

            // Draw the image on the page
            page.Canvas.DrawImage(image, new PointF(pageWidth - image.PhysicalDimension.Width, y));

            // Calculate the position of the image
            float imageLeftSpace = pageWidth - image.PhysicalDimension.Width - 2;
            float imageBottom = image.PhysicalDimension.Height + y;

            // Reference content
            // Create a font and format for the reference text
            PdfTrueTypeFont font3 = new PdfTrueTypeFont(new Font("Arial", 9f));
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
              PdfTrueTypeFont font3 = new PdfTrueTypeFont("Arial", 9f, PdfFontStyle.Regular, true);
            */
            PdfStringFormat format3 = new PdfStringFormat();

            // Set the paragraph indentation and line spacing for the reference text
            format3.ParagraphIndent = font3.Size * 2;
            format3.MeasureTrailingSpaces = true;
            format3.LineSpacing = font3.Size * 1.5f;

            // Define the reference text
            String text1 = "(All text and picture from ";
            String text2 = "Wikipedia";
            String text3 = ", the free encyclopedia)";

            // Draw the reference text on the page
            page.Canvas.DrawString(text1, font3, brush2, 0, y, format3);

            // Measure the size of the first part of the reference text
            size = font3.MeasureString(text1, format3);
            float x1 = size.Width;

            // Reset the paragraph indentation
            format3.ParagraphIndent = 0;

            // Create a font and brush for the underlined text
            PdfTrueTypeFont font4 = new PdfTrueTypeFont(new Font("Arial", 9f, FontStyle.Underline));
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
             PdfTrueTypeFont font4 = new PdfTrueTypeFont("Arial", 9f, PdfFontStyle.Underline, true);
            */
            PdfBrush brush3 = PdfBrushes.Blue;

            // Draw the underlined text on the page
            page.Canvas.DrawString(text2, font4, brush3, x1, y, format3);

            // Measure the size of the underlined text
            size = font4.MeasureString(text2, format3);
            x1 = x1 + size.Width;

            // Draw the remaining part of the reference text on the page
            page.Canvas.DrawString(text3, font3, brush2, x1, y, format3);

            // Update the value of y based on the height of the reference text
            y = y + size.Height;

            // Content
            // Set the format for the content text
            PdfStringFormat format4 = new PdfStringFormat();

            // Read the content text from a file
            text = System.IO.File.ReadAllText(@"..\..\..\..\..\..\Data\Summary_of_Science.txt");

            // Create a font for the content text
            PdfTrueTypeFont font5 = new PdfTrueTypeFont(new Font("Arial", 10f));
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
             PdfTrueTypeFont font5 = new PdfTrueTypeFont("Arial", 10f, PdfFontStyle.Regular, true);
            */

            // Set the line spacing for the content text
            format4.LineSpacing = font5.Size * 1.5f;

            // Create a layouter to arrange the content text
            PdfStringLayouter textLayouter = new PdfStringLayouter();

            // Calculate the available space for the content text
            float imageLeftBlockHeight = imageBottom - y;

            // Layout the content text within the available space
            PdfStringLayoutResult result = textLayouter.Layout(text, font5, format4, new SizeF(imageLeftSpace, imageLeftBlockHeight));

            // Check if the height of the remaining text is less than the available space
            if (result.ActualSize.Height < imageBottom - y)
            {
                // Increase the available space by the height of a line
                imageLeftBlockHeight = imageLeftBlockHeight + result.LineHeight;

                // Re-layout the content text within the updated available space
                result = textLayouter.Layout(text, font5, format4, new SizeF(imageLeftSpace, imageLeftBlockHeight));
            }

            // Iterate through each line of the layout result
            foreach (LineInfo line in result.Lines)
            {
                // Draw the line of text on the page
                page.Canvas.DrawString(line.Text, font5, brush2, 0, y, format4);

                // Update the vertical position (y) based on the height of the line
                y = y + result.LineHeight;
            }

            // Create a PDF text widget for the remaining text
            PdfTextWidget textWidget = new PdfTextWidget(result.Remainder, font5, brush2);

            // Create a PDF text layout configuration
            PdfTextLayout textLayout = new PdfTextLayout();
            textLayout.Break = PdfLayoutBreakType.FitPage;
            textLayout.Layout = PdfLayoutType.Paginate;

            // Define the bounds for the text widget
            RectangleF bounds = new RectangleF(new PointF(0, y), page.Canvas.ClientSize);

            // Set the string format for the text widget
            textWidget.StringFormat = format4;

            // Draw the remaining text on the page using the text widget and layout configuration
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
