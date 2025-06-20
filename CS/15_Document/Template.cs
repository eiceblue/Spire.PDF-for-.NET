using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.AutomaticFields;
using System.IO;

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
            //Create a pdf document
            PdfDocument doc = new PdfDocument();
            doc.ViewerPreferences.PageLayout = PdfPageLayout.TwoColumnLeft;

            //Set the margin
            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
            PdfMargins margin = new PdfMargins();
            margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Bottom = margin.Top;
            margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Right = margin.Left;

            SetDocumentTemplate(doc, PdfPageSize.A4, margin);

            //Create one section
            PdfSection section = doc.Sections.Add();
            section.PageSettings.Size = PdfPageSize.A4;
            section.PageSettings.Margins = new PdfMargins(0);
            SetSectionTemplate(section, PdfPageSize.A4, margin, "Section 1");

            //Create one page
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

            //Save the document
            doc.SaveToFile("Template.pdf");
            doc.Close();

            //Launch the Pdf file
            PDFDocumentViewer("Template.pdf");
        }

        private void SetSectionTemplate(PdfSection section, SizeF pageSize, PdfMargins margin, String label)
        {
            // Create an element for the left blank space with the width of the left margin and the height of the page
            PdfPageTemplateElement leftSpace = new PdfPageTemplateElement(margin.Left, pageSize.Height);

            // Set the element as a foreground element
            leftSpace.Foreground = true;

            // Set the element as the left template for odd pages
            section.Template.OddLeft = leftSpace;

            // Create an Arial font object with a size of 9f and an italic style
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 9f, FontStyle.Italic));

            // Create a string format object with centered text alignment and vertically centered alignment
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);

            // Calculate the y-coordinate value to center the text on the page
            float y = (pageSize.Height - margin.Top - margin.Bottom) * (1 - 0.618f);

            // Create a rectangle object with the top-left corner at (10, y), and the bottom-right corner at (left margin - 20, font height + 6)
            RectangleF bounds = new RectangleF(10, y, margin.Left - 20, font.Height + 6);

            // Draw an orange-red rectangle within the left blank space element
            leftSpace.Graphics.DrawRectangle(PdfBrushes.OrangeRed, bounds);

            // Draw the label text within the rectangle using the Arial font created earlier, white color, and the previously created string format object
            leftSpace.Graphics.DrawString(label, font, PdfBrushes.White, bounds, format);

            // Create an element for the right blank space with the width of the right margin and the height of the page
            PdfPageTemplateElement rightSpace = new PdfPageTemplateElement(margin.Right, pageSize.Height);

            // Set the element as a foreground element
            rightSpace.Foreground = true;

            // Set the element as the right template for even pages
            section.Template.EvenRight = rightSpace;

            // Recalculate the bottom-right corner of the rectangle
            bounds = new RectangleF(10, y, margin.Right - 20, font.Height + 6);

            // Draw a brown rectangle within the right blank space element
            rightSpace.Graphics.DrawRectangle(PdfBrushes.SaddleBrown, bounds);

            // Draw the label text within the rectangle using the Arial font created earlier, white color, and the previously created string format object
            rightSpace.Graphics.DrawString(label, font, PdfBrushes.White, bounds, format);
        }


        // SetDocumentTemplate method for configuring document template with specified page size and margins
        private void SetDocumentTemplate(PdfDocument doc, SizeF pageSize, PdfMargins margin)
        {
            // Create a template element for the left space on the page
            PdfPageTemplateElement leftSpace = new PdfPageTemplateElement(margin.Left, pageSize.Height);
            doc.Template.Left = leftSpace;

            // Create a template element for the top space on the page
            PdfPageTemplateElement topSpace = new PdfPageTemplateElement(pageSize.Width, margin.Top);
            topSpace.Foreground = true;
            doc.Template.Top = topSpace;

            // Draw a header label
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

            // Create a template element for the right space on the page
            PdfPageTemplateElement rightSpace = new PdfPageTemplateElement(margin.Right, pageSize.Height);
            doc.Template.Right = rightSpace;

            // Create a template element for the bottom space on the page
            PdfPageTemplateElement bottomSpace = new PdfPageTemplateElement(pageSize.Width, margin.Bottom);
            bottomSpace.Foreground = true;
            doc.Template.Bottom = bottomSpace;

            // Draw a footer label
            y = font.Height + 1;
            bottomSpace.Graphics.SetTransparency(0.5f);
            bottomSpace.Graphics.DrawLine(pen, margin.Left, y, pageSize.Width - margin.Right, y);
            y = y + 1;
            PdfPageNumberField pageNumber = new PdfPageNumberField();
            PdfPageCountField pageCount = new PdfPageCountField();
            PdfCompositeField pageNumberLabel = new PdfCompositeField();
            pageNumberLabel.AutomaticFields = new PdfAutomaticField[] { pageNumber, pageCount };
            pageNumberLabel.Brush = PdfBrushes.Black;
            pageNumberLabel.Font = font;
            pageNumberLabel.StringFormat = format;
            pageNumberLabel.Text = "page {0} of {1}";
            pageNumberLabel.Draw(bottomSpace.Graphics, pageSize.Width - margin.Right, y);

            // Load and add a header image to the template as a stamp
            PdfImage headerImage = PdfImage.FromFile(@"..\..\..\..\..\..\Data\Header.png");
            PointF pageLeftTop = new PointF(-margin.Left, -margin.Top);
            PdfPageTemplateElement header = new PdfPageTemplateElement(pageLeftTop, headerImage.PhysicalDimension);
            header.Foreground = false;
            header.Graphics.SetTransparency(0.5f);
            header.Graphics.DrawImage(headerImage, 0, 0);
            doc.Template.Stamps.Add(header);

            // Load and add a footer image to the template as a stamp
            PdfImage footerImage = PdfImage.FromFile(@"..\..\..\..\..\..\Data\Footer.png");
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
            // Get the width of the page
            float pageWidth = page.Canvas.ClientSize.Width;
            float y = 0;

            // Title
            y = y + 5;

            // Create a black brush for drawing text
            PdfBrush brush2 = new PdfSolidBrush(Color.Black);

            // Set the font to Arial, size 16, and bold style
            PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 16f, FontStyle.Bold));

            // Create a string format for center alignment
            PdfStringFormat format2 = new PdfStringFormat(PdfTextAlignment.Center);

            // Set character spacing to 1
            format2.CharacterSpacing = 1f;

            // Set the text content
            String text = "Summary of Science";

            // Draw the text on the page using the specified format
            page.Canvas.DrawString(text, font2, brush2, pageWidth / 2, y, format2);

            // Measure the size of the text
            SizeF size = font2.MeasureString(text, format2);

            // Update the y position for the next element
            y = y + size.Height + 6;

            // Icon
            // Load the image from file
            PdfImage image = PdfImage.FromFile(@"..\..\..\..\..\..\Data\Wikipedia_Science.png");

            // Draw the image on the page at the specified position
            page.Canvas.DrawImage(image, new PointF(pageWidth - image.PhysicalDimension.Width, y));

            // Calculate the left space for the icon
            float imageLeftSpace = pageWidth - image.PhysicalDimension.Width - 2;

            // Calculate the bottom position for the icon
            float imageBottom = image.PhysicalDimension.Height + y;

            // Reference content
            // Set the font to Arial, size 9
            PdfTrueTypeFont font3 = new PdfTrueTypeFont(new Font("Arial", 9f));

            // Create a string format with no paragraph indentation
            PdfStringFormat format3 = new PdfStringFormat();

            // Set paragraph indentation to twice the size of the font
            format3.ParagraphIndent = font3.Size * 2;

            // Enable trailing spaces measurement
            format3.MeasureTrailingSpaces = true;

            // Set line spacing to 1.5 times the size of the font
            format3.LineSpacing = font3.Size * 1.5f;

            // Set the text content for the first line
            String text1 = "(All text and picture from ";

            // Set the text content for the second line
            String text2 = "Wikipedia";

            // Set the text content for the third line
            String text3 = ", the free encyclopedia)";

            // Draw the first line of text on the page using the specified format
            page.Canvas.DrawString(text1, font3, brush2, 0, y, format3);

            // Measure the size of the first line of text
            size = font3.MeasureString(text1, format3);

            // Update the x position for the second line of text
            float x1 = size.Width;

            // Reset paragraph indentation to zero
            format3.ParagraphIndent = 0;

            // Set the font to Arial, size 9, and underlined style
            PdfTrueTypeFont font4 = new PdfTrueTypeFont(new Font("Arial", 9f, FontStyle.Underline));

            // Set the brush color to blue
            PdfBrush brush3 = PdfBrushes.Blue;

            // Draw the second line of text on the page using the specified format
            page.Canvas.DrawString(text2, font4, brush3, x1, y, format3);

            // Measure the size of the second line of text
            size = font4.MeasureString(text2, format3);

            // Update the x position for the third line of text
            x1 = x1 + size.Width;

            // Draw the third line of text on the page using the specified format
            page.Canvas.DrawString(text3, font3, brush2, x1, y, format3);

            // Update the y position for the next element
            y = y + size.Height;

            // Content
            // Read all text from a file
            PdfStringFormat format4 = new PdfStringFormat();
            text = System.IO.File.ReadAllText(@"..\..\..\..\..\..\Data\Summary_of_Science.txt");

            // Set the font to Arial, size 10
            PdfTrueTypeFont font5 = new PdfTrueTypeFont(new Font("Arial", 10f));

            // Set line spacing to 1.5 times the size of the font
            format4.LineSpacing = font5.Size * 1.5f;

            // Create a string layouter for measuring and arranging text
            PdfStringLayouter textLayouter = new PdfStringLayouter();

            // Calculate the height of the content block based on the image bottom position and y position
            float imageLeftBlockHeight = imageBottom - y;

            // Layout the text content using the specified format and size
            PdfStringLayoutResult result = textLayouter.Layout(text, font5, format4, new SizeF(imageLeftSpace, imageLeftBlockHeight));
            if (result.ActualSize.Height < imageBottom - y)
            {
                // If the content is too tall for the available space, increase the height by the line height
                imageLeftBlockHeight = imageLeftBlockHeight + result.LineHeight;
                result = textLayouter.Layout(text, font5, format4, new SizeF(imageLeftSpace, imageLeftBlockHeight));
            }

            // Iterate through each line of text in the layout result
            foreach (LineInfo line in result.Lines)
            {
                // Draw the text on the page using the specified format and y position
                page.Canvas.DrawString(line.Text, font5, brush2, 0, y, format4);

                // Update the y position for the next line of text
                y = y + result.LineHeight;
            }
            // Create a text widget for rendering the remaining text content
            PdfTextWidget textWidget = new PdfTextWidget(result.Remainder, font5, brush2);

            // Create a text layout for specifying how to arrange the text content
            PdfTextLayout textLayout = new PdfTextLayout();

            // Set the break type to fit the page width
            textLayout.Break = PdfLayoutBreakType.FitPage;

            // Set the layout type to paginate the text content
            textLayout.Layout = PdfLayoutType.Paginate;

            // Define the bounds of the text content area on the page
            RectangleF bounds = new RectangleF(new PointF(0, y), page.Canvas.ClientSize);

            // Set the string format for the text widget
            textWidget.StringFormat = format4;

            // Draw the text content on the page using the specified format and layout
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
