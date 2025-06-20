using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace SetHorizontalScalingFactorForText
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new PDF document object
            PdfDocument doc = new PdfDocument();

            // Add a new page to the document
            PdfPageBase page = doc.Pages.Add();

            // Create a solid brush with black color
            PdfSolidBrush solidBrush = new PdfSolidBrush(new PdfRGBColor(Color.Black));

            // Create a string format object
            PdfStringFormat format = new PdfStringFormat();

            // Set the horizontal scaling factor to 80%
            format.HorizontalScalingFactor = 80;

            // Create a font object
            PdfFont font = new PdfFont(PdfFontFamily.TimesRoman, 14f, PdfFontStyle.Regular);

            // Define the text to be displayed
            string text = "This is test string, The zoom ratio is 80%";

            // Draw the text on the page with the specified font, brush, position, and format
            page.Canvas.DrawString(text, font, solidBrush, 10, 50, format);

            // Define the second text
            string text2 = "This is test string, The zoom ratio is 100%";

            // Set the horizontal scaling factor to 100%
            format.HorizontalScalingFactor = 100;

            // Draw the second text on the page
            page.Canvas.DrawString(text2, font, solidBrush, 10, 80, format);

            // Define the third text
            string text3 = "This is test string, The zoom ratio is 120%";

            // Set the horizontal scaling factor to 120%
            format.HorizontalScalingFactor = 120;

            // Draw the third text on the page
            page.Canvas.DrawString(text3, font, solidBrush, 10, 110, format);

            // Output file path
            string outputFile = "SetHorizontalScalingFactorForText_result.pdf";

            // Save the document to the output file
            doc.SaveToFile(outputFile);

            // Close the document
            doc.Close();

            // Open the PDF document
            PDFDocumentViewer(outputFile);

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
