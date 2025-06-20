using Spire.Pdf;
using Spire.Pdf.Actions;
using Spire.Pdf.Annotations;
using Spire.Pdf.Attachments;
using Spire.Pdf.General;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
            float width = 490f;
            float height = font.Height * 2.2f;
            RectangleF rect = new RectangleF(0, 100, width, height);

            // Draw the text on the page.
            page.Canvas.DrawString(text, font, PdfBrushes.Black, rect);

            // Create a PdfDestination with a specific page, location, and zoom factor.
            PdfDestination dest = new PdfDestination(page, new PointF(0, 842));

            // Create a GoToE (Go-To Embedded) action with the specified destination.
            PdfEmbeddedGoToAction action = new PdfEmbeddedGoToAction(attachment.FileName, dest, true);

            // Create a PdfActionAnnotation with the action and the annotation rectangle.
            PdfActionAnnotation annotation = new PdfActionAnnotation(rect, action);

            // Add the annotation to the page.
            (page as PdfNewPage).Annotations.Add(annotation);
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

            // Create a PdfDestination instance and link it to a PdfGoToAction.
            PdfDestination pageBottomDest = new PdfDestination(pagetwo);
            pageBottomDest.Location = new PointF(0, 5);
            pageBottomDest.Mode = PdfDestinationMode.Location;
            pageBottomDest.Zoom = 1f;
            PdfGoToAction action = new PdfGoToAction(pageBottomDest);

            // Define the font, dimensions, and formatting for a button.
            PdfTrueTypeFont buttonFont = new PdfTrueTypeFont(new Font("Arial", 10f, FontStyle.Bold));
            float buttonWidth = 70;
            float buttonHeight = buttonFont.Height * 1.5f;
            PdfStringFormat format2 = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            RectangleF buttonBounds = new RectangleF(0, 200, buttonWidth, buttonHeight);

            // Create a rectangle and draw text on the first page.
            page.Canvas.DrawRectangle(PdfBrushes.DarkGray, buttonBounds);
            page.Canvas.DrawString("To Last Page", buttonFont, PdfBrushes.CadetBlue, buttonBounds, format2);

            // Add the annotation to the first page.
            PdfActionAnnotation annotation = new PdfActionAnnotation(buttonBounds, action);
            annotation.Border = new PdfAnnotationBorder(0.75f);
            annotation.Color = Color.LightGray;
            (page as PdfNewPage).Annotations.Add(annotation);
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
