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
            //Create a pdf document.
            PdfDocument doc = new PdfDocument();

            //margin
            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
            PdfMargins margin = new PdfMargins();
            margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Bottom = margin.Top;
            margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Right = margin.Left;

            // Create one page
            PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, margin);

            float y = 10;
            y = AddDocumentLinkAnnotation(page, y);

            y = y + 2;
            y = AddFileLinkAnnotation(page, y);

            y = y + 2;
            y = AddFreeTextAnnotation(page, y);

            y = y + 2;
            y = AddLineAnnotation(page, y);

            y = y + 2;
            y = AddTextMarkupAnnotation(page, y);

            y = y + 2;
            y = AddPopupAnnotation(page, y);

            y = y + 2;
            y = AddRubberStampAnnotation(page, y);


            //Save pdf file.
            doc.SaveToFile("Annotation.pdf");
            doc.Close();

            //Launching the Pdf file.
            PDFDocumentViewer("Annotation.pdf");
        }

        private float AddDocumentLinkAnnotation(PdfPageBase page, float y)
        {
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 9f));
            PdfStringFormat format = new PdfStringFormat();
            format.MeasureTrailingSpaces = true;
            String prompt = "Document Link: ";
            SizeF size = font.MeasureString(prompt);

            page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y);
            float x = font.MeasureString(prompt, format).Width;

            PdfDestination dest = new PdfDestination(page);
            dest.Mode = PdfDestinationMode.Location;
            dest.Location = new PointF(0, y);
            dest.Zoom = 2f;

            String label = "Click me, Zoom 200%";
            size = font.MeasureString(label);
            RectangleF bounds = new RectangleF(x, y, size.Width, size.Height);
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y);
            PdfDocumentLinkAnnotation annotation = new PdfDocumentLinkAnnotation(bounds, dest);
            annotation.Color = Color.Blue;
            (page as PdfNewPage).Annotations.Add(annotation);
            y = bounds.Bottom;

            return y;
        }

        private float AddFileLinkAnnotation(PdfPageBase page, float y)
        {
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 9f));
            PdfStringFormat format = new PdfStringFormat();
            format.MeasureTrailingSpaces = true;
            String prompt = "Launch File: ";
            SizeF size = font.MeasureString(prompt);

            page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y);
            float x = font.MeasureString(prompt, format).Width;

            String label = @"Launch Notepad.exe";
            size = font.MeasureString(label);
            RectangleF bounds = new RectangleF(x, y, size.Width, size.Height);
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y);
            PdfFileLinkAnnotation annotation = new PdfFileLinkAnnotation(bounds, @"C:\Windows\Notepad.exe");
            annotation.Color = Color.Blue;
            (page as PdfNewPage).Annotations.Add(annotation);
            y = bounds.Bottom;

            return y;
        }

        private float AddFreeTextAnnotation(PdfPageBase page, float y)
        {
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 9f));
            PdfStringFormat format = new PdfStringFormat();
            format.MeasureTrailingSpaces = true;
            String prompt = "Text Markup: ";
            SizeF size = font.MeasureString(prompt);

            page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y);
            float x = font.MeasureString(prompt, format).Width;

            String label = @"I'm a text box, not a TV";
            size = font.MeasureString(label);
            RectangleF bounds = new RectangleF(x, y, size.Width, size.Height);
            page.Canvas.DrawRectangle(new PdfPen(Color.Blue, 0.1f), bounds);
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y);
            PointF location = new PointF(bounds.Right + 16, bounds.Top - 16);
            RectangleF annotaionBounds = new RectangleF(location, new SizeF(80, 32));
            PdfFreeTextAnnotation annotation = new PdfFreeTextAnnotation(annotaionBounds);
            annotation.AnnotationIntent = PdfAnnotationIntent.FreeTextCallout;
            annotation.Border = new PdfAnnotationBorder(0.5f);
            annotation.BorderColor = Color.Red;
            annotation.CalloutLines
                = new PointF[] { 
                    new PointF(bounds.Right, bounds.Top),
                    new PointF(bounds.Right + 8, bounds.Top - 8), 
                    location };
            annotation.Color = Color.Yellow;
            annotation.Flags = PdfAnnotationFlags.Locked;
            annotation.Font = font;
            annotation.LineEndingStyle = PdfLineEndingStyle.OpenArrow;
            annotation.MarkupText = "Just a joke.";
            annotation.Opacity = 0.75f;
            annotation.TextMarkupColor = Color.Green;

            (page as PdfNewPage).Annotations.Add(annotation);
            y = bounds.Bottom;

            return y;
        }

        private float AddLineAnnotation(PdfPageBase page, float y)
        {
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 9f));
            PdfStringFormat format = new PdfStringFormat();
            format.MeasureTrailingSpaces = true;
            String prompt = "Line Annotation: ";
            SizeF size = font.MeasureString(prompt);

            page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y);
            float x = font.MeasureString(prompt, format).Width;

            String label = @"Line Anotation";
            size = font.MeasureString(label);
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y);
            RectangleF bounds = new RectangleF(x, y, size.Width, size.Height);
            int[] linePoints = new int[]
            {
                (int)bounds.Left, (int)bounds.Top, (int)bounds.Right, (int)bounds.Bottom
            };
            PdfLineAnnotation annotation = new PdfLineAnnotation(linePoints, "Annotation");
            annotation.BeginLineStyle = PdfLineEndingStyle.ClosedArrow;
            annotation.EndLineStyle = PdfLineEndingStyle.ClosedArrow;
            annotation.LineCaption = true;
            annotation.BackColor = Color.Black;
            annotation.CaptionType = PdfLineCaptionType.Inline;
            (page as PdfNewPage).Annotations.Add(annotation);
            y = bounds.Bottom;

            return y;
        }

        private float AddTextMarkupAnnotation(PdfPageBase page, float y)
        {
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 9f));
            PdfStringFormat format = new PdfStringFormat();
            format.MeasureTrailingSpaces = true;
            String prompt = "Highlight incorrect spelling: ";
            SizeF size = font.MeasureString(prompt, format);
            page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y);
            float x = size.Width;

            String label = "demo of anotation";
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y);
            size = font.MeasureString("demo of ", format);
            x = x + size.Width;
            PointF incorrectWordLocation = new PointF(x, y);
            String markupText = "Should be 'annotation'";
            PdfTextMarkupAnnotation annotation
                = new PdfTextMarkupAnnotation("Harry", markupText, "anotation", incorrectWordLocation, font);
            annotation.TextMarkupAnnotationType = PdfTextMarkupAnnotationType.Highlight;
            annotation.TextMarkupColor = Color.LightSkyBlue;
            (page as PdfNewPage).Annotations.Add(annotation);
            y = y + size.Height;

            return y;
        }

        private float AddPopupAnnotation(PdfPageBase page, float y)
        {
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 9f));
            PdfStringFormat format = new PdfStringFormat();
            format.MeasureTrailingSpaces = true;
            String prompt = "Markup incorrect spelling: ";
            SizeF size = font.MeasureString(prompt, format);
            page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y);
            float x = size.Width;

            String label = "demo of annotation";
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y);
            x = x + font.MeasureString(label, format).Width;
            String markupText = "All words were spelled correctly";
            size = font.MeasureString(markupText);
            PdfPopupAnnotation annotation
                = new PdfPopupAnnotation(new RectangleF(new PointF(x, y), SizeF.Empty), markupText);
            annotation.Icon = PdfPopupIcon.Paragraph;
            annotation.Open = true;
            annotation.Color = Color.Yellow;
            (page as PdfNewPage).Annotations.Add(annotation);
            y = y + size.Height;

            return y;
        }

        private float AddRubberStampAnnotation(PdfPageBase page, float y)
        {
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 9f));
            PdfStringFormat format = new PdfStringFormat();
            format.MeasureTrailingSpaces = true;
            String prompt = "Markup incorrect spelling: ";
            SizeF size = font.MeasureString(prompt, format);
            page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y);
            float x = size.Width;

            String label = "demo of annotation";
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y);
            x = x + font.MeasureString(label, format).Width;
            String markupText = "Just a draft, not checked.";
            size = font.MeasureString(markupText);
            PdfRubberStampAnnotation annotation
                = new PdfRubberStampAnnotation(new RectangleF(x, y, font.Height, font.Height), markupText);
            annotation.Icon = PdfRubberStampAnnotationIcon.Draft;
            annotation.Color = Color.Plum;
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
