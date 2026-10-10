using Spire.Pdf;
using Spire.Pdf.Actions;
using Spire.Pdf.Destinations;
using Spire.Pdf.General;
using Spire.Pdf.Graphics;
using Spire.Pdf.Interactive.Annotations;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

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
            y = AddDocumentLinkAnnotation(page, y, margin);
            y = y + 6;
            y = AddFileLinkAnnotation(page, y, margin);
            y = y + 6;
            y = AddFreeTextAnnotation(page, y, margin);
            y = y + 6;
            y = AddLineAnnotation(page, y, margin);
            y = y + 6;
            y = AddTextMarkupAnnotation(page, y, margin);
            y = y + 6;
            y = AddPopupAnnotation(page, y, margin);
            y = y + 6;
            y = AddRubberStampAnnotation(page, y,margin);

            // Save the PDF document to a file
            doc.SaveToFile("Annotation.pdf");
            doc.Close();

            //Launch the Pdf file
            PDFDocumentViewer("Annotation.pdf");
        }

        // Add a document link annotation to the page
        private float AddDocumentLinkAnnotation(PdfPageBase page, float y, PdfMargins margin)
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

            page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y);
            float x = font.MeasureString(prompt, format).Width;

            PdfXYZExplicitDestination dest = new PdfXYZExplicitDestination(page, 0, y, 2f);

            String label = "Click me, Zoom 200%";
            size = font.MeasureString(label);
            RectangleF bounds = new RectangleF(x, y, size.Width, size.Height);
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y);
            RectangleF rect = new RectangleF(bounds.X + margin.Left, bounds.Y + margin.Top, bounds.Width, bounds.Height);
            PdfLinkAnnotation annotation = new PdfLinkAnnotation(page, rect, dest);
            annotation.Color = Color.Blue;
            PdfAnnotationCollection.Create(page).Add(annotation);
            y = bounds.Bottom;

            return y;
        }

        // Add a file link annotation to the page
        private float AddFileLinkAnnotation(PdfPageBase page, float y, PdfMargins margin)
        {
            // Set up font and formatting
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f));
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
             PdfTrueTypeFont font1 = new PdfTrueTypeFont("Arial", 16f, PdfFontStyle.Bold, true);
            */
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
            RectangleF rect = new RectangleF(bounds.X + margin.Left, bounds.Y + margin.Top, bounds.Width, bounds.Height);
            PdfLaunchAction action = new PdfLaunchAction(@"C:\Windows\Notepad.exe");
            PdfLinkAnnotation annotation = new PdfLinkAnnotation(page, rect, action);

            annotation.Color = Color.Blue;
            PdfAnnotationCollection.Create(page).Add(annotation);
            y = bounds.Bottom;

            return y;
        }


        // Add a free text annotation to the page
        private float AddFreeTextAnnotation(PdfPageBase page, float y, PdfMargins margin)
        {
            // Set up font and formatting
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f));
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
             PdfTrueTypeFont font = new PdfTrueTypeFont("Arial", 12f, PdfFontStyle.Regular, true);
            */
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
            RectangleF rect = new RectangleF(location.X + margin.Left, location.Y + margin.Top, 80, 32);
            PdfDefaultAppearance defaultAppearance = new PdfDefaultAppearance(font, Color.Green);
            PdfFreeTextAnnotation annotation = new PdfFreeTextAnnotation(page, rect, defaultAppearance);
            annotation.Intent = PdfFreeTextIntent.FreeTextCallout;
            annotation.Border.Width = 0.5f;
            annotation.Border.Color = Color.Red;
            location = new PointF(bounds.Right + 16, bounds.Top - 16);
            annotation.CalloutLine
                = new PointF[] {
                    new PointF(bounds.Right + margin.Left, bounds.Top  + margin.Top),
                    new PointF(bounds.Right + 8 + margin.Left, bounds.Top - 8  + margin.Top),
                    new PointF(location.X + margin.Left, location.Y +  + margin.Top) };
            annotation.Color = Color.Yellow;
            annotation.Flags = PdfAnnotationFlags.Locked;
            annotation.CalloutLineEndingStyle = PdfLineEndingStyle.OpenArrow;
            annotation.Contents = "Just a joke.";
            annotation.StrokingOpacity = 0.75f;
            annotation.RefreshAppearances();
            PdfAnnotationCollection.Create(page).Add(annotation);
            y = bounds.Bottom;

            return y;
        }

        // Add a line annotation to the page
        private float AddLineAnnotation(PdfPageBase page, float y, PdfMargins margin)
        {
            // Set up font and formatting
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f));
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
             PdfTrueTypeFont font = new PdfTrueTypeFont("Arial", 12f, PdfFontStyle.Regular, true);
            */
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
            RectangleF rect = new RectangleF(bounds.X + margin.Left, bounds.Y + margin.Top, bounds.Width, bounds.Height);
            int[] linePoints = new int[]
            {
                (int)rect.Left, (int)rect.Top, (int)rect.Right, (int)rect.Bottom
            };
            PdfLineAnnotation annotation = new PdfLineAnnotation(page, rect, new PointF(linePoints[0], linePoints[1]), new PointF(linePoints[2], linePoints[3]));
            annotation.Contents = "Annotation";
            annotation.StartingStyle = PdfLineEndingStyle.ClosedArrow;
            annotation.EndingStyle = PdfLineEndingStyle.ClosedArrow;
            annotation.ShowCaption = true;
            annotation.Color = Color.Black;
            annotation.CaptionPosition = PdfCaptionPosition.Inline;
            PdfAnnotationCollection.Create(page).Add(annotation);
            y = bounds.Bottom;

            return y;
        }

        // Add a text markup annotation to the page
        private float AddTextMarkupAnnotation(PdfPageBase page, float y, PdfMargins margin)
        {
            // Set up font and formatting
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f));
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
             PdfTrueTypeFont font = new PdfTrueTypeFont("Arial", 12f, PdfFontStyle.Regular, true);
            */
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
            String markupText = "Should be 'annotation'";
            PdfHighlightAnnotation annotation = new PdfHighlightAnnotation(page, new RectangleF(x + margin.Left, y + margin.Top, 50f, 15f));
            annotation.Contents = "anotation";
            annotation.Title = markupText;
            annotation.Color = Color.LightSkyBlue;
            PdfAnnotationCollection.Create(page).Add(annotation);
            y = y + size.Height;

            return y;
        }

        // Add a popup annotation to the page
        private float AddPopupAnnotation(PdfPageBase page, float y, PdfMargins margin)
        {
            // Set up font and formatting
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f));
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
             PdfTrueTypeFont font = new PdfTrueTypeFont("Arial", 12f, PdfFontStyle.Regular, true);
            */
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
                = new PdfPopupAnnotation(page, new RectangleF(new PointF(x + margin.Left, y + margin.Top), SizeF.Empty));
            annotation.Contents = markupText;
            annotation.Open = true;
            annotation.Color = Color.Yellow;
            PdfAnnotationCollection.Create(page).Add(annotation);
            y = y + size.Height;

            return y;
        }

        // Add a rubber stamp annotation to the page
        private float AddRubberStampAnnotation(PdfPageBase page, float y,PdfMargins margin)
        {
            // Set up font and formatting
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f));
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
             PdfTrueTypeFont font = new PdfTrueTypeFont("Arial", 12f, PdfFontStyle.Bold, true);
            */
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
                = new PdfRubberStampAnnotation(page, new RectangleF(x + margin.Left, y + margin.Top, font.Height, font.Height));
            annotation.Contents = markupText;
            annotation.Icon = PdfStampIcon.Draft;
            annotation.Color = Color.Plum;
            PdfAnnotationCollection.Create(page).Add(annotation);
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
