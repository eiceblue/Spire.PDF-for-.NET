using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Annotations;
using Spire.Pdf.General;
using Spire.Pdf.Graphics;

namespace Annotation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a PDF document
            PdfDocument doc = new PdfDocument();

            // Set margins for the page
            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
            PdfMargins margin = new PdfMargins();
            margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Bottom = margin.Top;
            margin.Left = unitCvtr.ConvertUnits(3f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Right = margin.Left;

            // Create a page with specified size and margins
            PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, margin);

            // Add a title to the page
            PdfBrush brush1 = PdfBrushes.Black;
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 13f, FontStyle.Bold | FontStyle.Italic), true);
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
             PdfTrueTypeFont font1 = new PdfTrueTypeFont("Arial", 13f, PdfFontStyle.Bold|PdfFontStyle.Italic, true);
            */
            PdfStringFormat format1 = new PdfStringFormat(PdfTextAlignment.Left);
            float y = 50;
            string s = "The sample demonstrates how to add annotations in PDF document.";

            page.Canvas.DrawString(s, font1, brush1, 0, y - 5, format1);
            y = y + font1.MeasureString(s, format1).Height;
            y = y + 15;

            // Add various types of annotations to the page
            y = AddDocumentLinkAnnotation(page, y);
            y = y + 6;
            y = AddFileLinkAnnotation(page, y);
            y = y + 6;
            y = AddFreeTextAnnotation(page, y);
            y = y + 6;
            y = AddLineAnnotation(page, y);
            y = y + 6;
            y = AddTextMarkupAnnotation(page, y);
            y = y + 6;
            y = AddPopupAnnotation(page, y);
            y = y + 6;
            y = AddRubberStampAnnotation(page, y);

            // Save the PDF document to a file
            doc.SaveToFile("Annotation.pdf");
            doc.Close();

            //Launch the Pdf file
            PDFDocumentViewer("Annotation.pdf");
        }

        // Add a document link annotation to the page
        private float AddDocumentLinkAnnotation(PdfPageBase page, float y)
        {
            // Set up font and formatting
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f));
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
             PdfTrueTypeFont font = new PdfTrueTypeFont("Arial", 12f, PdfFontStyle.Regular, true);
            */
            PdfStringFormat format = new PdfStringFormat();
            format.MeasureTrailingSpaces = true;

            String prompt = "Document Link: ";
            SizeF size = font.MeasureString(prompt);

            // Draw the prompt text
            page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y);
            float x = font.MeasureString(prompt, format).Width;

            // Set up the destination for the link annotation
            PdfDestination dest = new PdfDestination(page);
            dest.Mode = PdfDestinationMode.Location;
            dest.Location = new PointF(0, y);
            dest.Zoom = 2f;

            String label = "Click me, Zoom 200%";
            size = font.MeasureString(label);

            // Draw the label text
            RectangleF bounds = new RectangleF(x, y, size.Width, size.Height);
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y);

            // Create a document link annotation and set its properties
            PdfDocumentLinkAnnotation annotation = new PdfDocumentLinkAnnotation(bounds, dest);
            annotation.Color = Color.Blue;

            // Add the annotation to the page's annotation collection
            (page as PdfNewPage).Annotations.Add(annotation);
            y = bounds.Bottom;

            return y;
        }

        // Add a file link annotation to the page
        private float AddFileLinkAnnotation(PdfPageBase page, float y)
        {
            // Set up font and formatting
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f));
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
             PdfTrueTypeFont font1 = new PdfTrueTypeFont("Arial", 16f, PdfFontStyle.Bold, true);
            */
            PdfStringFormat format = new PdfStringFormat();
            format.MeasureTrailingSpaces = true;

            // Draw the prompt text
            String prompt = "Launch File: ";
            SizeF size = font.MeasureString(prompt);
            page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y);
            float x = font.MeasureString(prompt, format).Width;

            // Draw the label text
            String label = @"Launch Notepad.exe";
            size = font.MeasureString(label);
            RectangleF bounds = new RectangleF(x, y, size.Width, size.Height);
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y);

            // Create a file link annotation and set its properties
            PdfFileLinkAnnotation annotation = new PdfFileLinkAnnotation(bounds, @"C:\Windows\Notepad.exe");
            annotation.Color = Color.Blue;

            // Add the annotation to the page's annotation collection
            (page as PdfNewPage).Annotations.Add(annotation);
            y = bounds.Bottom;

            return y;
        }


        // Add a free text annotation to the page
        private float AddFreeTextAnnotation(PdfPageBase page, float y)
        {
            // Set up font and formatting
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f));
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
             PdfTrueTypeFont font = new PdfTrueTypeFont("Arial", 12f, PdfFontStyle.Regular, true);
            */
            PdfStringFormat format = new PdfStringFormat();
            format.MeasureTrailingSpaces = true;

            // Draw the prompt text
            String prompt = "Text Markup: ";
            SizeF size = font.MeasureString(prompt);
            page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y);
            float x = font.MeasureString(prompt, format).Width;

            // Draw the label text and bounding rectangle
            String label = @"I'm a text box, not a TV";
            size = font.MeasureString(label);
            RectangleF bounds = new RectangleF(x, y, size.Width, size.Height);
            page.Canvas.DrawRectangle(new PdfPen(Color.Blue, 0.1f), bounds);
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y);

            // Set up the free text annotation with its properties
            PointF location = new PointF(bounds.Right + 16, bounds.Top - 16);
            RectangleF annotaionBounds = new RectangleF(location, new SizeF(80, 32));
            PdfFreeTextAnnotation annotation = new PdfFreeTextAnnotation(annotaionBounds);
            annotation.AnnotationIntent = PdfAnnotationIntent.FreeTextCallout;
            annotation.Border = new PdfAnnotationBorder(0.5f);
            annotation.BorderColor = Color.Red;
            location = new PointF(bounds.Right + 16, bounds.Top - 16);
            annotation.CalloutLines = new PointF[] {
                    new PointF(bounds.Right, bounds.Top),
                    new PointF(bounds.Right+8, bounds.Top - 8),
                    location
                };
            annotation.Color = Color.Yellow;
            annotation.Flags = PdfAnnotationFlags.Locked;
            annotation.Font = font;
            annotation.LineEndingStyle = PdfLineEndingStyle.OpenArrow;
            annotation.MarkupText = "Just a joke.";
            annotation.Opacity = 0.75f;
            annotation.TextMarkupColor = Color.Green;

            // Add the free text annotation to the page's annotation collection
            (page as PdfNewPage).Annotations.Add(annotation);
            y = bounds.Bottom;

            return y;
        }

        // Add a line annotation to the page
        private float AddLineAnnotation(PdfPageBase page, float y)
        {
            // Set up font and formatting
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f));
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
             PdfTrueTypeFont font = new PdfTrueTypeFont("Arial", 12f, PdfFontStyle.Regular, true);
            */
            PdfStringFormat format = new PdfStringFormat();
            format.MeasureTrailingSpaces = true;

            // Draw the prompt text
            String prompt = "Line Annotation: ";
            SizeF size = font.MeasureString(prompt);
            page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y);
            float x = font.MeasureString(prompt, format).Width;

            // Draw the label text and bounding rectangle
            String label = @"Line Annotation";
            size = font.MeasureString(label);
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y);
            RectangleF bounds = new RectangleF(x, y, size.Width, size.Height);
            int[] linePoints = new int[]
            {
                 (int)bounds.Left, (int)bounds.Top, (int)bounds.Right, (int)bounds.Bottom
            };

            // Create a line annotation and set its properties
            PdfLineAnnotation annotation = new PdfLineAnnotation(linePoints, "Annotation");
            annotation.BeginLineStyle = PdfLineEndingStyle.ClosedArrow;
            annotation.EndLineStyle = PdfLineEndingStyle.ClosedArrow;
            annotation.LineCaption = true;
            annotation.BackColor = Color.Black;
            annotation.CaptionType = PdfLineCaptionType.Inline;

            // Add the line annotation to the page's annotation collection
            (page as PdfNewPage).Annotations.Add(annotation);
            y = bounds.Bottom;

            return y;
        }

        // Add a text markup annotation to the page
        private float AddTextMarkupAnnotation(PdfPageBase page, float y)
        {
            // Set up font and formatting
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f));
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
             PdfTrueTypeFont font = new PdfTrueTypeFont("Arial", 12f, PdfFontStyle.Regular, true);
            */
            PdfStringFormat format = new PdfStringFormat();
            format.MeasureTrailingSpaces = true;

            // Draw the prompt text
            String prompt = "Highlight incorrect spelling: ";
            SizeF size = font.MeasureString(prompt, format);
            page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y);
            float x = size.Width;

            // Draw the label text and bounding rectangle
            String label = "demo of anotation";
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y);
            size = font.MeasureString("demo of ", format);
            x = x + size.Width;
            PointF incorrectWordLocation = new PointF(x, y);
            String markupText = "Should be 'annotation'";

            // Create a text markup annotation and set its properties
            PdfTextMarkupAnnotation annotation = new PdfTextMarkupAnnotation(markupText, "anotation", new RectangleF(x, y, 100f, 100f), font);
            annotation.TextMarkupAnnotationType = PdfTextMarkupAnnotationType.Highlight;
            annotation.TextMarkupColor = Color.LightSkyBlue;

            // Add the text markup annotation to the page's annotation collection
            (page as PdfNewPage).Annotations.Add(annotation);
            y = y + size.Height;

            return y;
        }

        // Add a popup annotation to the page
        private float AddPopupAnnotation(PdfPageBase page, float y)
        {
            // Set up font and formatting
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f));
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
             PdfTrueTypeFont font = new PdfTrueTypeFont("Arial", 12f, PdfFontStyle.Regular, true);
            */
            PdfStringFormat format = new PdfStringFormat();
            format.MeasureTrailingSpaces = true;

            // Draw the prompt text
            String prompt = "Markup incorrect spelling: ";
            SizeF size = font.MeasureString(prompt, format);
            page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y);
            float x = size.Width;

            // Draw the label text and bounding rectangle
            String label = "demo of annotation";
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y);
            x = x + font.MeasureString(label, format).Width;
            String markupText = "All words were spelled correctly";
            size = font.MeasureString(markupText);

            // Create a popup annotation and set its properties
            PdfPopupAnnotation annotation = new PdfPopupAnnotation(new RectangleF(new PointF(x, y), SizeF.Empty), markupText);
            annotation.Icon = PdfPopupIcon.Paragraph;
            annotation.Open = true;
            annotation.Color = Color.Yellow;

            // Add the popup annotation to the page's annotation collection
            (page as PdfNewPage).Annotations.Add(annotation);
            y = y + size.Height;

            return y;
        }

        // Add a rubber stamp annotation to the page
        private float AddRubberStampAnnotation(PdfPageBase page, float y)
        {
            // Set up font and formatting
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f));
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
             PdfTrueTypeFont font = new PdfTrueTypeFont("Arial", 12f, PdfFontStyle.Bold, true);
            */
            PdfStringFormat format = new PdfStringFormat();
            format.MeasureTrailingSpaces = true;

            // Draw the prompt text
            String prompt = "Markup incorrect spelling: ";
            SizeF size = font.MeasureString(prompt, format);
            page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y);
            float x = size.Width;

            // Draw the label text and bounding rectangle
            String label = "demo of annotation";
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y);
            x = x + font.MeasureString(label, format).Width;
            String markupText = "Just a draft, not checked.";
            size = font.MeasureString(markupText);

            // Create a rubber stamp annotation and set its properties
            PdfRubberStampAnnotation annotation = new PdfRubberStampAnnotation(new RectangleF(x, y, font.Height, font.Height), markupText);
            annotation.Icon = PdfRubberStampAnnotationIcon.Draft;
            annotation.Color = Color.Plum;

            // Add the rubber stamp annotation to the page's annotation collection
            (page as PdfNewPage).Annotations.Add(annotation);
            y = y + size.Height;

            return y;
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
