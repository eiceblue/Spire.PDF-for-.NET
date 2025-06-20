using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Fields;
using Spire.Pdf.Annotations;
using Spire.Pdf.Graphics;
using Spire.Pdf.Actions;
using Spire.Pdf.General;
namespace CreateMultilayerPDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PdfDocument doc = new PdfDocument();

            // Creates a new page in the document
            PdfPageBase page = doc.Pages.Add();

            // Create text to be displayed
            String text = "Welcome to evaluate Spire.PDF for .NET !";

            // Define the formatting options for the text
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Left);

            // Create a solid brush with black color
            PdfSolidBrush brush = new PdfSolidBrush(Color.Black);

            // Defines a font to be used for the text
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Calibri", 15f, FontStyle.Regular));

            // Set the starting position for drawing the text
            float x = 50;
            float y = 50;

            // Draw the text on the page's canvas
            page.Canvas.DrawString(text, font, brush, new PointF(x, y), format);

            // Measure the size of the first part of the text
            SizeF size = font.MeasureString("Welcome to  evaluate", format);

            // Measure the size of the second part of the text
            SizeF size2 = font.MeasureString("Spire.PDF for .NET", format);

            // Load an image from file
            PdfImage image = PdfImage.FromFile("..\\..\\..\\..\\..\\..\\Data\\MultilayerImage.png");

            // Draw the image on the page's canvas, positioned to the right of the text
            page.Canvas.DrawImage(image, new PointF(x + size.Width, y), size2);

            // Specify the output file name
            String result = "CreateMultilayerPDF_out.pdf";

            // Save the document to the specified file
            doc.SaveToFile(result);

            //Launch the Pdf file
            PDFDocumentViewer(result);
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
