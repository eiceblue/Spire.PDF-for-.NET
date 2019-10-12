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
            //create a pdf document
            PdfDocument pdf = new PdfDocument();
            PdfPageBase page = pdf.Pages.Add();

            //add a GoToE in pdf 
            EmbeddedGoToAction(pdf, page);

            //creat a action that could jump to specific location
            JumpToSpecificLocationAction(pdf, page);

            //save and launch
            pdf.SaveToFile("GoToAction.pdf");
            PDFDocumentViewer("GoToAction.pdf");

        }

        /// <summary>
        /// GoToE action
        /// </summary>
        /// <param name="pdf"></param>
        private static void EmbeddedGoToAction(PdfDocument pdf, PdfPageBase page)
        {
            //add a attachment
            PdfAttachment attachment = new PdfAttachment(@"..\..\..\..\..\..\Data\GoToAction.pdf");
            pdf.Attachments.Add(attachment);

            string text = "Test embedded go-to action! Click this will open the attached PDF in a new window.";
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 13f));
            float width = 490f;
            float height = font.Height * 2.2f;
            RectangleF rect = new RectangleF(0, 100, width, height);
            page.Canvas.DrawString(text, font, PdfBrushes.Black, rect);

            //create a PdfDestination with specific page, location and 200% zoom factor
            PdfDestination dest = new PdfDestination(1, new PointF(0, 842), 2f);

            //create GoToE action with dest
            PdfEmbeddedGoToAction action = new PdfEmbeddedGoToAction(attachment.FileName, dest, true);
            PdfActionAnnotation annotation = new PdfActionAnnotation(rect, action);

            //add the annotation
            (page as PdfNewPage).Annotations.Add(annotation);
        }

        private static void JumpToSpecificLocationAction(PdfDocument pdf, PdfPageBase page)
        {
            //add a new page
            PdfPageBase pagetwo = pdf.Pages.Add();

            //draw text on the page
            pagetwo.Canvas.DrawString("This is Page Two.",
                                   new PdfFont(PdfFontFamily.Helvetica, 20f),
                                   new PdfSolidBrush(Color.Black),
                                   10, 10);

            //create PdfDestination instance and link to PdfGoToAction
            PdfDestination pageBottomDest = new PdfDestination(pagetwo);
            pageBottomDest.Location = new PointF(0, 5);
            pageBottomDest.Mode = PdfDestinationMode.Location;
            pageBottomDest.Zoom = 1f;
            PdfGoToAction action = new PdfGoToAction(pageBottomDest);

            PdfTrueTypeFont buttonFont = new PdfTrueTypeFont(new Font("Arial", 10f, FontStyle.Bold));
            float buttonWidth = 70;
            float buttonHeight = buttonFont.Height * 1.5f;
            PdfStringFormat format2 = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            RectangleF buttonBounds = new RectangleF(0, 200, buttonWidth, buttonHeight);

            //create a rectangle and draw text
            page.Canvas.DrawRectangle(PdfBrushes.DarkGray, buttonBounds);
            page.Canvas.DrawString("To Last Page", buttonFont, PdfBrushes.CadetBlue, buttonBounds, format2);

            //add the annotation
            PdfActionAnnotation annotation
                = new PdfActionAnnotation(buttonBounds, action);
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
