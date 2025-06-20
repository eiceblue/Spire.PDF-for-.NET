using Spire.Pdf;
using Spire.Pdf.Actions;
using Spire.Pdf.Annotations;
using Spire.Pdf.General;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentLinkAnnotation
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
            PdfDocument doc = new PdfDocument();

            // Create a PdfUnitConvertor to convert units.
            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();

            // Set the page margins.
            PdfMargins margin = new PdfMargins();
            margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Bottom = margin.Top;
            margin.Left = unitCvtr.ConvertUnits(2.0f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Right = margin.Left;

            // Add the first page with specified size and margins.
            PdfPageBase page1 = doc.Pages.Add(PdfPageSize.A4, margin);

            // Define a brush for drawing.
            PdfBrush brush1 = PdfBrushes.Black;

            // Define a font for text.
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 12f, FontStyle.Bold), true);

            // Set the string format for text alignment.
            PdfStringFormat format1 = new PdfStringFormat(PdfTextAlignment.Left);

            // Set the position for drawing text.
            float x = 0;
            float y = 50;

            // Specify the text string.
            string specification = "The sample demonstrates how to create a local document link in a PDF document.";

            // Draw the text string on the first page.
            page1.Canvas.DrawString(specification, font1, brush1, x, y, format1);

            // Use MeasureString to get the height of the string.
            y = y + font1.MeasureString(specification, format1).Height + 10;

            // Add the second page with specified size and margins.
            PdfPageBase page2 = doc.Pages.Add(PdfPageSize.A4, margin);

            // Specify the text string for the second page.
            string pageContent = "This is the second page!";

            // Draw the text string on the second page.
            page2.Canvas.DrawString(pageContent, font1, brush1, x, y, format1);

            // Add a DocumentLinkAnnotation on the first page and link it to the second page.
            AddDocumentLinkAnnotation(doc, 0, 1, y);

            // Specify the output file name.
            string result = "DocumentLinkAnnotation_out.pdf";

            // Save the document to the output file.
            doc.SaveToFile(result);

            //Launch the Pdf file
            PDFDocumentViewer(result);
        }
        private static void AddDocumentLinkAnnotation(PdfDocument pdf, int AddPage, int DestinationPage, float y)
        {
            // Define a font for text.
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f));

            // Set the string format for text alignment.
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Left);

            // Specify the prompt text for the link.
            String prompt = "Local document Link: ";

            // Draw the prompt text on the page at the specified vertical position.
            pdf.Pages[AddPage].Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y);

            // Use MeasureString to get the width of the prompt string.
            float x = font.MeasureString(prompt, format).Width;

            // Create a PdfDestination with the specified destination page.
            PdfDestination dest = new PdfDestination(pdf.Pages[DestinationPage]);

            // Set the location of the destination.
            dest.Location = new PointF(0, y);

            // Set the zoom factor for the destination.
            dest.Zoom = 0.5f;

            // Specify the label string for the link.
            String label = "Click here to link the second page.";

            // Use MeasureString to get the SizeF of the label string.
            SizeF size = font.MeasureString(label);

            // Create a rectangle that defines the area for the link.
            RectangleF bounds = new RectangleF(x, y, size.Width, size.Height);

            // Draw the label string on the page.
            pdf.Pages[AddPage].Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y);

            // Create a PdfDocumentLinkAnnotation on the rectangle and link it to the destination.
            PdfDocumentLinkAnnotation annotation = new PdfDocumentLinkAnnotation(bounds, dest);

            // Set the color for the annotation.
            annotation.Color = Color.Blue;

            // Add the annotation to the page.
            (pdf.Pages[AddPage] as PdfNewPage).Annotations.Add(annotation);
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
