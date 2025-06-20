using System;
using System.Drawing;
using System.IO;
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
            // Create a new PDF document
            PdfDocument doc = new PdfDocument();
            doc.ViewerPreferences.PageMode = PdfPageMode.FullScreen;

            // Set the margins for the document
            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
            PdfMargins margin = new PdfMargins();
            margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Bottom = margin.Top;
            margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Right = margin.Left;

            // Create a section in the document
            PdfSection section = doc.Sections.Add();
            section.PageSettings.Size = PdfPageSize.A4;
            section.PageSettings.Margins = margin;

            // Configure the transition settings for the section's pages
            section.PageSettings.Transition = new PdfPageTransition();
            section.PageSettings.Transition.Duration = 2;
            section.PageSettings.Transition.Style = PdfTransitionStyle.Fly;
            section.PageSettings.Transition.PageDuration = 1;

            // Add a new page to the section with a red background color and draw its content
            PdfNewPage page = section.Pages.Add();
            page.BackgroundColor = Color.Red;
            DrawPage(page);

            // Add another page to the section with a green background color and draw its content
            page = section.Pages.Add();
            page.BackgroundColor = Color.Green;
            DrawPage(page);

            // Add a third page to the section with a blue background color and draw its content
            page = section.Pages.Add();
            page.BackgroundColor = Color.Blue;
            DrawPage(page);

            // Create a new section in the document with the same settings as the previous section
            section = doc.Sections.Add();
            section.PageSettings.Size = PdfPageSize.A4;
            section.PageSettings.Margins = margin;

            // Configure the transition settings for this section's pages
            section.PageSettings.Transition = new PdfPageTransition();
            section.PageSettings.Transition.Duration = 2;
            section.PageSettings.Transition.Style = PdfTransitionStyle.Box;
            section.PageSettings.Transition.PageDuration = 1;

            // Add a new page to the section with an orange background color and draw its content
            page = section.Pages.Add();
            page.BackgroundColor = Color.Orange;
            DrawPage(page);

            // Add another page to the section with a brown background color and draw its content
            page = section.Pages.Add();
            page.BackgroundColor = Color.Brown;
            DrawPage(page);

            // Add a third page to the section with a navy background color and draw its content
            page = section.Pages.Add();
            page.BackgroundColor = Color.Navy;
            DrawPage(page);

            // Create another section in the document with the same settings as before
            section = doc.Sections.Add();
            section.PageSettings.Size = PdfPageSize.A4;
            section.PageSettings.Margins = margin;

            // Configure the transition settings for this section's pages
            section.PageSettings.Transition = new PdfPageTransition();
            section.PageSettings.Transition.Duration = 2;
            section.PageSettings.Transition.Style = PdfTransitionStyle.Split;
            section.PageSettings.Transition.Dimension = PdfTransitionDimension.Vertical;
            section.PageSettings.Transition.Motion = PdfTransitionMotion.Inward;
            section.PageSettings.Transition.PageDuration = 1;

            // Add a new page to the section with an orange background color and draw its content
            page = section.Pages.Add();
            page.BackgroundColor = Color.Orange;
            DrawPage(page);

            // Add another page to the section with a brown background color and draw its content
            page = section.Pages.Add();
            page.BackgroundColor = Color.Brown;
            DrawPage(page);

            // Add a third page to the section with a navy background color and draw its content
            page = section.Pages.Add();
            page.BackgroundColor = Color.Navy;
            DrawPage(page);

            // Save the document to a file named "Transition.pdf" and close it
            doc.SaveToFile("Transition.pdf");
            doc.Close();

            //Launch the Pdf file
            PDFDocumentViewer("Transition.pdf");
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
