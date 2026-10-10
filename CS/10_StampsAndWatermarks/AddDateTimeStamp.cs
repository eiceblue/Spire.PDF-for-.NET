using Spire.Pdf;
using Spire.Pdf.Interactive.Annotations;
using Spire.Pdf.Graphics;
using System;
using System.Drawing;
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
            String timeString = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");

            //Create a template and rectangle, draw the string
            PdfTemplate template = new PdfTemplate(140, 15);
            RectangleF rect = new RectangleF(new PointF(page.ActualSize.Width - template.Width - 10, page.ActualSize.Height - template.Height - 10), template.Size);
            template.Graphics.DrawString(timeString, font, brush, new PointF(0, 0));

            //Create stamp annoation
            PdfRubberStampAnnotation stamp = new PdfRubberStampAnnotation(page, rect);
            stamp.Appearances.SetNormalAppearance(new PdfAppearance(template));

            //Draw stamp into page
            PdfAnnotationCollection.Create(page).Add(stamp);

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
