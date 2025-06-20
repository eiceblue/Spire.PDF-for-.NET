using Spire.Pdf;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TextToPDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get text from .txt file.
            string text = File.ReadAllText(@"..\..\..\..\..\..\Data\TextToPdf.txt");

            // Create a PDF document.
            PdfDocument doc = new PdfDocument();

            // Add a section to the document.
            PdfSection section = doc.Sections.Add();

            // Add a page to the section.
            PdfPageBase page = section.Pages.Add();

            // Create a PdfFont object using the Helvetica font with a size of 11.
            PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 11);

            // Create a PdfStringFormat object for text formatting.
            PdfStringFormat format = new PdfStringFormat();
            format.LineSpacing = 20f;

            // Create a PdfBrush object for text color.
            PdfBrush brush = PdfBrushes.Black;

            // Create a PdfTextLayout object for text layout options.
            PdfTextLayout textLayout = new PdfTextLayout();
            textLayout.Break = PdfLayoutBreakType.FitPage;
            textLayout.Layout = PdfLayoutType.Paginate;

            // Define the bounds of the text widget on the page.
            RectangleF bounds = new RectangleF(new PointF(10, 20), page.Canvas.ClientSize);

            // Create a PdfTextWidget object with the specified text, font, and brush.
            PdfTextWidget textWidget = new PdfTextWidget(text, font, brush);
            textWidget.StringFormat = format;

            // Draw the text widget on the page using the specified bounds and text layout options.
            textWidget.Draw(page, bounds, textLayout);

            // Specify the output file name as "TextToPdf.pdf".
            string output = "TextToPdf.pdf";

            // Save the document to a file in PDF format.
            doc.SaveToFile(output, FileFormat.PDF);

            //Launch the result file
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
