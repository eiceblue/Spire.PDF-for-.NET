using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Annotations;
using Spire.Pdf.Annotations.Appearance;
namespace AddTextStamp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Specify the file path for the input PDF document
            string input = "..\\..\\..\\..\\..\\..\\Data\\AddTextStamp.pdf";

            // Create a new instance of PdfDocument
            PdfDocument document = new PdfDocument();

            // Load the PDF document from the specified file path
            document.LoadFromFile(input);

            // Get the first page of the document
            PdfPageBase page = document.Pages[0];

            // Create a template with specific dimensions to hold the stamp
            PdfTemplate template = new PdfTemplate(125, 55);

            // Set the font, brush, and pen for drawing the stamp
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Elephant", 10f, FontStyle.Italic), true);
            PdfSolidBrush brush = new PdfSolidBrush(Color.DarkRed);
            PdfPen pen = new PdfPen(brush);

            // Define a rectangle that represents the bounds of the stamp
            RectangleF rectangle = new RectangleF(new PointF(5, 5), template.Size);

            // Define the corner radius for the stamp's rounded corners
            int CornerRadius = 20;

            // Create a path for the stamp shape using arcs and lines
            PdfPath path = new PdfPath();
            path.AddArc(template.GetBounds().X, template.GetBounds().Y, CornerRadius, CornerRadius, 180, 90);
            path.AddArc(template.GetBounds().X + template.Width - CornerRadius, template.GetBounds().Y, CornerRadius, CornerRadius, 270, 90);
            path.AddArc(template.GetBounds().X + template.Width - CornerRadius, template.GetBounds().Y + template.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
            path.AddArc(template.GetBounds().X, template.GetBounds().Y + template.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
            path.AddLine(template.GetBounds().X, template.GetBounds().Y + template.Height - CornerRadius, template.GetBounds().X, template.GetBounds().Y + CornerRadius / 2);

            // Draw the stamp shape on the template
            template.Graphics.DrawPath(pen, path);

            // Draw the stamp text on the template
            String s1 = "REVISED\n";
            String s2 = "by E-iceblue at " + DateTime.Now.ToString("MM dd, yyyy");
            template.Graphics.DrawString(s1, font1, brush, new PointF(5, 10));
            PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Lucida Sans Unicode", 9f, FontStyle.Bold), true);
            template.Graphics.DrawString(s2, font2, brush, new PointF(2, 30));

            // Create a rubber stamp annotation with the specified rectangle for its size and position
            PdfRubberStampAnnotation stamp = new PdfRubberStampAnnotation(rectangle);

            // Create an appearance object for the rubber stamp annotation
            PdfAppearance apprearance = new PdfAppearance(stamp);

            // Set the normal appearance of the stamp to use the created template
            apprearance.Normal = template;

            // Assign the custom appearance to the rubber stamp annotation
            stamp.Appearance = apprearance;

            // Add the rubber stamp annotation to the page's annotations widget
            page.Annotations.Add(stamp);

            // Specify the file name for the modified PDF document
            string output = "AddTextStamp.pdf";

            // Save the modified PDF document
            document.SaveToFile(output);

            //Launch the file
            PDFDocumentViewer(output);
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
