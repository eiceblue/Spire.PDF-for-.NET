using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
            // Create a new instance of a PDF document
            PdfDocument doc = new PdfDocument();

            // Set the margin for the document
            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
            PdfMargins margin = new PdfMargins();
            margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Bottom = margin.Top;
            margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Right = margin.Left;

            // Draw the cover page using specified margin and add it to the document
            DrawCover(doc, doc.Sections.Add(), margin);

            // Draw the content page using specified margin and add it to the document
            DrawContent(doc, doc.Sections.Add(), margin);

            // Draw the page number on the second section of the document using specified margin,
            // starting from page 1 and counting the total number of pages in the second section
            DrawPageNumber(doc.Sections[1], margin, 1, doc.Sections[1].Pages.Count);

            // Save the document to a file named "Pagination.pdf"
            doc.SaveToFile("Pagination.pdf");

            // Close the document
            doc.Close();

            //Launch the Pdf file
            PDFDocumentViewer("Pagination.pdf");
        }

        private void DrawCover(PdfDocument pdf, PdfSection section, PdfMargins margin)
        {
            // Set the page size of the section to A4
            section.PageSettings.Size = PdfPageSize.A4;

            // Set the margins of the section to zero
            section.PageSettings.Margins.All = 0;

            // Add a new page to the section
            PdfPageBase page = section.Pages.Add();

            // Create a new instance of PdfPageLabels for the document
            pdf.PageLabels = new PdfPageLabels();

            // Add page labels to the document starting from index 0 with lowercase Roman numerals and prefix "cover "
            pdf.PageLabels.AddRange(0, PdfPageLabels.Lowercase_Roman_Numerals_Style, "cover ");

            // Call a method to draw the header and footer on the page
            DrawPageHeaderAndFooter(page, margin, true);

            // Set up colors, fonts, and text format for the content
            PdfBrush brush1 = PdfBrushes.LightGray;
            PdfBrush brush2 = PdfBrushes.Blue;
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 8f));
            PdfStringFormat format = new PdfStringFormat();
            format.MeasureTrailingSpaces = true;
            String text1 = "(All text and picture from ";
            String text2 = "Wikipedia";
            String text3 = ", the free encyclopedia)";
            float x = 0, y = 10;

            // Adjust the starting position of drawing based on the margin
            x = x + margin.Left;
            y = y + margin.Top;

            // Draw the content strings on the page using the specified fonts, brushes, and format
            page.Canvas.DrawString(text1, font1, brush1, x, y, format);
            x = x + font1.MeasureString(text1, format).Width;
            page.Canvas.DrawString(text2, font1, brush2, x, y, format);
            x = x + font1.MeasureString(text2, format).Width;
            page.Canvas.DrawString(text3, font1, brush1, x, y, format);

            // Set up colors, image, and other parameters for the cover
            PdfBrush brush3 = PdfBrushes.Black;
            PdfBrush brush4 = new PdfSolidBrush(new PdfRGBColor(0xf9, 0xf9, 0xf9));
            PdfImage image = PdfImage.FromFile(@"..\..\..\..\..\..\Data\SciencePersonificationBoston.jpg");
            String text = "Personification of \"Science\" in front of the Boston Public Library";
            float r = image.PhysicalDimension.Height / image.Height;
            PdfPen pen = new PdfPen(brush1, r);
            SizeF size = font1.MeasureString(text, image.PhysicalDimension.Width - 2);
            PdfTemplate template = new PdfTemplate(image.PhysicalDimension.Width + 4 * r + 4, image.PhysicalDimension.Height + 4 * r + 7 + size.Height);

            // Draw a rectangle with border and fill on the template
            template.Graphics.DrawRectangle(pen, brush4, 0, 0, template.Width, template.Height);

            // Adjust the starting position of drawing based on the margin and radius
            x = y = r + 2;

            // Draw a rectangle on the template with a brush
            template.Graphics.DrawRectangle(brush1, x, y,
                image.PhysicalDimension.Width + 2 * r,
                image.PhysicalDimension.Height + 2 * r);

            // Adjust the starting position of drawing within the rectangle
            x = y = x + r;

            // Draw the image on the template
            template.Graphics.DrawImage(image, x, y);

            // Adjust the starting position of drawing for the text below the image
            x = x - 1;
            y = y + image.PhysicalDimension.Height + r + 2;

            // Draw the text on the template using specified font, brush, and rectangle
            template.Graphics.DrawString(text, font1, brush3,
                new RectangleF(new PointF(x, y), size));

            // Calculate the positioning of the template and draw it on the page canvas
            float x1 = (page.Canvas.ClientSize.Width - template.Width) / 2;
            float y1 = (page.Canvas.ClientSize.Height - margin.Top - margin.Bottom) * (1 - 0.618f) - template.Height / 2 + margin.Top;
            template.Draw(page.Canvas, x1, y1);

            // Set up alignment and font for the title text
            format.Alignment = PdfTextAlignment.Center;
            PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 24f, FontStyle.Bold));

            // Calculate the positioning of the title text and draw it on the page canvas
            x = page.Canvas.ClientSize.Width / 2;
            y = y1 + template.Height + 10;
            page.Canvas.DrawString("Science History and Etymology", font2, brush3, x, y, format);
        }

        private void DrawContent(PdfDocument pdf, PdfSection section, PdfMargins margin)
        {
            // Set the page size of the section to A4
            section.PageSettings.Size = PdfPageSize.A4;

            // Set the margins of the section to zero
            section.PageSettings.Margins.All = 0;

            // Add a new page to the section
            PdfPageBase page = section.Pages.Add();

            // Add page labels to the document starting from index 1 with decimal Arabic numerals and prefix "page "
            pdf.PageLabels.AddRange(1, PdfPageLabels.Decimal_Arabic_Numerals_Style, "page ");

            // Call a method to draw the header and footer on the page without cover information
            DrawPageHeaderAndFooter(page, margin, false);

            // Set up initial positions and dimensions
            float x = margin.Left;
            float y = margin.Top + 8;
            float width = page.Canvas.ClientSize.Width - margin.Left - margin.Right;

            // Set up font, brush, and pen for the title
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 16f), true);
            PdfBrush brush1 = PdfBrushes.Black;
            PdfPen pen1 = new PdfPen(brush1, 0.75f);

            // Draw the title text on the page canvas
            page.Canvas.DrawString("Science History and Etymology", font1, brush1, x, y);

            // Adjust the position and draw a horizontal line below the title
            y = y + font1.MeasureString("Science History and Etymology").Height + 6;
            page.Canvas.DrawLine(pen1, x, y, page.Canvas.ClientSize.Width - margin.Right, y);
            y = y + 1.75f;

            // Set up content strings and format options
            String content = "Main articles: History of science and Scientific revolution\r\nWhile descriptions of disciplined empirical investigations of the natural world exist from times at least as early as classical antiquity (for example, by Aristotle and Pliny the Elder), and scientific methods have been employed since the Middle Ages (for example, by Alhazen and Roger Bacon), the dawn of modern science is generally traced back to the early modern period during what is known as the Scientific Revolution of the 16th and 17th centuries. This period was marked by a new way of studying the natural world, by methodical experimentation aimed at defining \"laws of nature\" while avoiding concerns with metaphysical concerns such as Aristotle's theory of causation.\r\n\"Rapid accumulation of knowledge, which has characterized the development of science since the 17th century, had never occurred before that time. The new kind of scientific activity emerged only in a few countries of Western Europe, and it was restricted to that small area for about two hundred years. (Since the 19th century, scientific knowledge has been assimilated by the rest of the world).\" ¡ª Joseph Ben¨CDavid, 1971.\r\nThis modern science developed from an older and broader enterprise. The word \"science\" is from Old French, and in turn from Latin scientia which was one of several words for \"knowledge\" in that language. In philosophical contexts, scientia and \"science\" were used to translate the Greek word epistem¨¥, which had acquired a specific definition in Greek philosophy, especially Aristotle, as a type of reliable knowledge which is built up logically from strong premises, and can be communicated and taught. In contrast to modern science, Aristotle's influential emphasis was upon the \"theoretical\" steps of deducing universal rules from raw data, and did not treat the gathering of experience and raw data as part of science itself.\r\nFrom the Middle Ages to the Enlightenment, science or scientia continued to be used in this broad sense, which was still common until the 20th century. \"Science\" therefore had the same sort of very broad meaning that philosophy had at that time. In other Latin influenced languages, including French, Spanish, Portuguese, and Italian, the word corresponding to science also carried this meaning.\r\nPrior to the 18th century, the preferred term for the study of nature among English speakers was \"natural philosophy\", while other philosophical disciplines (e.g., logic, metaphysics, epistemology, ethics and aesthetics) were typically referred to as \"moral philosophy\". (Today, \"moral philosophy\" is more-or-less synonymous with \"ethics\".) Science only became more strongly associated with natural philosophy than other sciences gradually with the strong promotion of the importance of experimental scientific method, by people such as Francis Bacon. With Bacon, begins a more widespread and open criticism of Aristotle's influence which had emphasized theorizing and did not treat raw data collection as part of science itself. An opposed position became common: that what is critical to science at its best is methodical collecting of clear and useful raw data, something which is easier to do in some fields than others.\r\nThe word \"science\" in English was still however used in the 17th century to refer to the Aristotelian concept of knowledge which was secure enough to be used as a prescription for exactly how to accomplish a specific task. With respect to the transitional usage of the term \"natural philosophy\" in this period, the philosopher John Locke wrote in 1690 that \"natural philosophy is not capable of being made a science\". However, it may be that Locke was not using the word 'science' in the modern sense, but suggesting that 'natural philosophy' could not be deduced in the same way as mathematics and logic.\r\nLocke's assertion notwithstanding, by the early 19th century natural philosophy had begun to separate from philosophy, though it often retained a very broad meaning. In many cases, science continued to stand for reliable knowledge about any topic, in the same way it is still used today in the broad sense (see the introduction to this article) in modern terms such as library science, political science, and computer science. In the more narrow sense of science, as natural philosophy became linked to an expanding set of well-defined laws (beginning with Galileo's laws, Kepler's laws, and Newton's laws for motion), it became more popular to refer to natural philosophy as natural science. Over the course of the 19th century, moreover, there was an increased tendency to associate science with study of the natural world (that is, the non-human world). This move sometimes left the study of human thought and society (what would come to be called social science) in a linguistic limbo by the end of the century and into the next.\r\nThrough the 19th century, many English speakers were increasingly differentiating science (i.e., the natural sciences) from all other forms of knowledge in a variety of ways. The now-familiar expression ¡°scientific method,¡± which refers to the prescriptive part of how to make discoveries in natural philosophy, was almost unused until then, but became widespread after the 1870s, though there was rarely total agreement about just what it entailed. The word \"scientist,\" meant to refer to a systematically working natural philosopher, (as opposed to an intuitive or empirically minded one) was coined in 1833 by William Whewell. Discussion of scientists as a special group of people who did science, even if their attributes were up for debate, grew in the last half of the 19th century. Whatever people actually meant by these terms at first, they ultimately depicted science, in the narrow sense of the habitual use of the scientific method and the knowledge derived from it, as something deeply distinguished from all other realms of human endeavor.\r\nBy the 20th century, the modern notion of science as a special kind of knowledge about the world, practiced by a distinct group and pursued through a unique method, was essentially in place. It was used to give legitimacy to a variety of fields through such titles as \"scientific\" medicine, engineering, advertising, or motherhood. Over the 20th century, links between science and technology also grew increasingly strong. As Martin Rees explains, progress in scientific understanding and technology have been synergistic and vital to one another.\r\nRichard Feynman described science in the following way for his students: \"The principle of science, the definition, almost, is the following: The test of all knowledge is experiment. Experiment is the sole judge of scientific 'truth'. But what is the source of knowledge? Where do the laws that are to be tested come from? Experiment, itself, helps to produce these laws, in the sense that it gives us hints. But also needed is imagination to create from these hints the great generalizations ¡ª to guess at the wonderful, simple, but very strange patterns beneath them all, and then to experiment to check again whether we have made the right guess.\" Feynman also observed, \"...there is an expanding frontier of ignorance...things must be learned only to be unlearned again or, more likely, to be corrected.\"";
            String[] lines = content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 10f, FontStyle.Italic), true);
            PdfStringFormat format1 = new PdfStringFormat();
            format1.MeasureTrailingSpaces = true;
            format1.LineSpacing = font2.Height * 1.5f;
            format1.ParagraphIndent = font2.MeasureString("\t", format1).Width;

            // Adjust the starting position for the first line of content
            y = y + font2.Height * 0.5f;

            // Measure and draw the first line of content using the specified font, brush, rectangle, and format
            SizeF size = font2.MeasureString(lines[0], width, format1);
            page.Canvas.DrawString(lines[0], font2, brush1,
                new RectangleF(new PointF(x, y), size), format1);

            // Adjust the position for the next line
            y = y + size.Height;

            // Set up font and format options for the remaining lines of content
            PdfTrueTypeFont font3 = new PdfTrueTypeFont(new Font("Arial", 10f), true);
            PdfStringFormat format2 = new PdfStringFormat();
            format2.LineSpacing = font3.Height * 1.4f;
            format2.MeasureTrailingSpaces = true;

            // Measure and draw the second line of content using the specified font, brush, rectangle, and format
            size = font3.MeasureString(lines[1], width, format2);
            page.Canvas.DrawString(lines[1], font3, brush1,
                new RectangleF(new PointF(x, y), size), format2);

            // Adjust the position for the next line
            y = y + size.Height;

            // Adjust the position and indentation for the third line of content
            y = y + font3.Height * 0.75f;
            float indent = font3.MeasureString("\t\t", format2).Width;
            float x1 = x + indent;

            // Measure and draw the third line of content using the specified font, brush, rectangle, and format
            size = font3.MeasureString(lines[2], width - indent, format2);
            page.Canvas.DrawString(lines[2], font3, brush1,
                new RectangleF(new PointF(x1, y), size), format2);

            // Adjust the position for the next line
            y = y + size.Height + font3.Height * 0.75f;

            // Build a StringBuilder to concatenate the remaining lines of content
            StringBuilder buff = new StringBuilder();
            for (int i = 3; i < lines.Length; i++)
            {
                buff.AppendLine(lines[i]);
            }
            content = buff.ToString();

            // Create a PdfStringLayouter for arranging the remaining content
            // Instantiate a PdfStringLayouter object for arranging the remaining content
            PdfStringLayouter textLayouter = new PdfStringLayouter();

            // Use the textLayouter to layout the remaining content on the page with the specified font, format, and size
            PdfStringLayoutResult result = textLayouter.Layout(content, font3, format2, new SizeF(width, float.MaxValue));

            // Iterate through each line in the layout result
            foreach (LineInfo line in result.Lines)
            {
                // Check if the line is the first line of a paragraph
                if ((line.LineType & LineType.FirstParagraphLine) == LineType.FirstParagraphLine)
                {
                    // Adjust the vertical position to create some spacing before the paragraph
                    y = y + font3.Height * 0.75f;
                }

                // Check if the current position exceeds the available space on the current page
                if (y > (page.Canvas.ClientSize.Height - margin.Bottom - result.LineHeight))
                {
                    // Add a new page to the section
                    page = section.Pages.Add();

                    // Call a method to draw the header and footer on the newly added page without cover information
                    DrawPageHeaderAndFooter(page, margin, false);

                    // Reset the vertical position to the top margin
                    y = margin.Top;
                }

                // Draw the line of text on the page canvas using the specified font, brush, position, and format
                page.Canvas.DrawString(line.Text, font3, brush1, x, y, format2);

                // Adjust the vertical position for the next line
                y = y + result.LineHeight;
            }
        }

        private void DrawPageHeaderAndFooter(PdfPageBase page, PdfMargins margin, bool isCover)
        {
            // Set the transparency of the canvas to 0.5 (50% opacity)
            page.Canvas.SetTransparency(0.5f);

            // Load the header and footer images from files
            PdfImage headerImage = PdfImage.FromFile(@"..\..\..\..\..\..\Data\Header.png");
            PdfImage footerImage = PdfImage.FromFile(@"..\..\..\..\..\..\Data\Footer.png");

            // Draw the header image at the top-left corner of the page
            page.Canvas.DrawImage(headerImage, new PointF(0, 0));

            // Draw the footer image at the bottom-left corner of the page
            page.Canvas.DrawImage(footerImage, new PointF(0, page.Canvas.ClientSize.Height - footerImage.PhysicalDimension.Height));

            // Check if it is a cover page
            if (isCover)
            {
                // Set the transparency of the canvas to 1 (100% opacity) for the cover page
                page.Canvas.SetTransparency(1);
                return;
            }

            // Set up brush, pen, font, format, and spacing for the header and footer text
            PdfBrush brush = PdfBrushes.Black;
            PdfPen pen = new PdfPen(brush, 0.75f);
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 9f, FontStyle.Italic), true);
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Right);
            format.MeasureTrailingSpaces = true;
            float space = font.Height * 0.75f;

            // Set up initial positions and dimensions
            float x = margin.Left;
            float width = page.Canvas.ClientSize.Width - margin.Left - margin.Right;
            float y = margin.Top - space;

            // Draw a horizontal line below the header
            page.Canvas.DrawLine(pen, x, y, x + width, y);

            // Adjust the position for the header text
            y = y - 1 - font.Height;

            // Draw the header text "Demo of Spire.Pdf" on the right side of the page
            page.Canvas.DrawString("Demo of Spire.Pdf", font, brush, x + width, y, format);

            // Set the transparency of the canvas to 1 (100% opacity)
            page.Canvas.SetTransparency(1);
        }

        private void DrawPageNumber(PdfSection section, PdfMargins margin, int startNumber, int pageCount)
        {
            // Iterate through each page in the section
            foreach (PdfPageBase page in section.Pages)
            {
                // Set the transparency of the canvas to 0.5 (50% opacity)
                page.Canvas.SetTransparency(0.5f);

                // Set up brush, pen, font, format, and spacing for the page number text
                PdfBrush brush = PdfBrushes.Black;
                PdfPen pen = new PdfPen(brush, 0.75f);
                PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 9f, FontStyle.Italic), true);
                PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Right);
                format.MeasureTrailingSpaces = true;
                float space = font.Height * 0.75f;

                // Set up initial positions and dimensions
                float x = margin.Left;
                float width = page.Canvas.ClientSize.Width - margin.Left - margin.Right;
                float y = page.Canvas.ClientSize.Height - margin.Bottom + space;

                // Draw a horizontal line above the footer
                page.Canvas.DrawLine(pen, x, y, x + width, y);

                // Adjust the position for the page number text
                y = y + 1;

                // Create the page number label using the format "startNumber of pageCount"
                String numberLabel = String.Format("{0} of {1}", startNumber++, pageCount);

                // Draw the page number label on the right side of the page
                page.Canvas.DrawString(numberLabel, font, brush, x + width, y, format);

                // Set the transparency of the canvas to 1 (100% opacity)
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
