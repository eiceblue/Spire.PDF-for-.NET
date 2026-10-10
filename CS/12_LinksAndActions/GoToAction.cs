using Spire.Pdf;
using Spire.Pdf.Interactive.Annotations;
using Spire.Pdf.Attachments;
using Spire.Pdf.Graphics;
using Spire.Pdf.Actions;
using Spire.Pdf.Destinations;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GoToAction
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new PDF document.
            PdfDocument pdf = new PdfDocument();

            // Add a page to the document.
            PdfPageBase page = pdf.Pages.Add();

            // Add an embedded GoToE (Go-To Embedded) action to the PDF.
            EmbeddedGoToAction(pdf, page);

            // Create an action that jumps to a specific location.
            JumpToSpecificLocationAction(pdf, page);

            // Save and launch the PDF document.
            pdf.SaveToFile("GoToAction.pdf");

            PDFDocumentViewer("GoToAction.pdf");

        }

        /// <summary>
        /// GoToE action
        /// </summary>
        /// <param name="pdf"></param>
        private static void EmbeddedGoToAction(PdfDocument pdf, PdfPageBase page)
        {
            // Add an attachment to the PDF.
            PdfAttachment attachment = new PdfAttachment(@"..\..\..\..\..\..\Data\GoToAction.pdf");
            pdf.Attachments.Add(attachment);

            // Specify the text to be displayed on the page.
            string text = "Test embedded go-to action! Clicking this will open the attached PDF in a new window.";

            // Define the font and dimensions of the text box.
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 13f));
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
              PdfTrueTypeFont font = new PdfTrueTypeFont("Arial", 13f, PdfFontStyle.Regular, true);
            */
            float width = 490f;
            float height = font.Height * 2.2f;
            RectangleF rect = new RectangleF(0, 100, width, height);

            // Draw the text on the page.
            page.Canvas.DrawString(text, font, PdfBrushes.Black, rect);

            //create a PdfDestination with specific page, location and 200% zoom factor
            //PdfXYZExplicitDestination dest = new PdfXYZExplicitDestination(1, new PointF(0, 842), 2f);

            //create GoToE action with dest
            PdfGoToEmbeddedAction action = new PdfGoToEmbeddedAction(attachment.FileName, 1, 2f);
            action.NewWindow = true;
            RectangleF annotationRect = new RectangleF(rect.X + 40, rect.Y + 40, rect.Width, rect.Height);
            PdfLinkAnnotation annotation = new PdfLinkAnnotation(page, annotationRect, action);
            //add the annotation
            PdfAnnotationCollection.Create(page).Add(annotation);

        }

        private static void JumpToSpecificLocationAction(PdfDocument pdf, PdfPageBase page)
        {
            // Add a new page to the PDF document.
            PdfPageBase pagetwo = pdf.Pages.Add();

            // Draw text on the second page.
            pagetwo.Canvas.DrawString("This is Page Two.",
                                       new PdfFont(PdfFontFamily.Helvetica, 20f),
                                       new PdfSolidBrush(Color.Black),
                                       10, 10);

            //create PdfDestination instance and link to PdfGoToAction
            PdfXYZExplicitDestination pageBottomDest = new PdfXYZExplicitDestination(pagetwo, 0, 5, 1f);
            PdfGoToAction action = new PdfGoToAction(pageBottomDest);

            // Define the font, dimensions, and formatting for a button.
            PdfTrueTypeFont buttonFont = new PdfTrueTypeFont(new Font("Arial", 10f, FontStyle.Bold));
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
             PdfTrueTypeFont buttonFont = new PdfTrueTypeFont("Arial", 10f, PdfFontStyle.Bold, true);
            */
            float buttonWidth = 70;
            float buttonHeight = buttonFont.Height * 1.5f;
            PdfStringFormat format2 = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            RectangleF buttonBounds = new RectangleF(0, 200, buttonWidth, buttonHeight);

            // Create a rectangle and draw text on the first page.
            page.Canvas.DrawRectangle(PdfBrushes.DarkGray, buttonBounds);
            page.Canvas.DrawString("To Last Page", buttonFont, PdfBrushes.CadetBlue, buttonBounds, format2);

            // Add the annotation to the first page.
            RectangleF annotationRect = new RectangleF(buttonBounds.X + 40, buttonBounds.Y + 40, buttonBounds.Width, buttonBounds.Height);
            PdfLinkAnnotation annotation = new PdfLinkAnnotation(page, annotationRect, action);
            annotation.Border.Width = 0.75f;
            annotation.Color = Color.LightGray;
            PdfAnnotationCollection.Create(page).Add(annotation);

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
