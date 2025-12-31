using Spire.Pdf;
using Spire.Pdf.Annotations;
using Spire.Pdf.Annotations.Appearance;
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

namespace AddDateTimeStamp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load a PDF document from disk
            PdfDocument document = new PdfDocument();
            document.LoadFromFile("../../../../../../Data/PDFTemplate_N.pdf");

            // Get the first page of the document
            PdfPageBase page = document.Pages[0];

            // Set the font and brush for the text
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f, FontStyle.Regular), true);
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
             PdfTrueTypeFont font = new PdfTrueTypeFont("Arial", 12f, PdfFontStyle.Regular, true);
            */

            PdfSolidBrush brush = new PdfSolidBrush(Color.Blue);

            // Generate a string representing the current date and time
            String timeString = DateTime.Now.ToString("MM/dd/yy hh:mm:ss tt ");

            // Create a template with specified dimensions
            PdfTemplate template = new PdfTemplate(140, 15);

            // Define a rectangle to position the template on the page
            RectangleF rect = new RectangleF(new PointF(page.ActualSize.Width - template.Width - 10, page.ActualSize.Height - template.Height - 10), template.Size);

            // Draw the time string onto the template
            template.Graphics.DrawString(timeString, font, brush, new PointF(0, 0));

            // Create a rubber stamp annotation
            PdfRubberStampAnnotation stamp = new PdfRubberStampAnnotation(rect);

            // Create a custom appearance for the stamp annotation
            PdfAppearance appearance = new PdfAppearance(stamp);
            appearance.Normal = template;

            // Assign the custom appearance to the stamp annotation
            stamp.Appearance = appearance;

            // Add the stamp annotation to the page's annotations widget
            page.Annotations.Add(stamp);

            // Specify the file name for the modified PDF document
            string output = "AddDateTimeStamp_result.pdf";

            // Save the modified document to the specified file path in PDF format
            document.SaveToFile(output, FileFormat.PDF);

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
