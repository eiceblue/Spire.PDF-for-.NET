using Spire.Pdf;
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

namespace AddDifferentHeaders
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load the PDF document from disk
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"../../../../../../../Data/MultipagePDF.pdf");

            // Define header texts
            string header1 = "Header 1";
            string header2 = "Header 2";

            // Define the font style for the headers
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 15f, FontStyle.Bold));

            // Define the brush color for the headers
            PdfBrush brush = PdfBrushes.Red;

            // Define the rectangle to position the header on the first page
            RectangleF rect = new RectangleF(new PointF(0, 20), new SizeF(doc.PageSettings.Size.Width, 50f));

            // Define the string format for the headers, aligning them in the center
            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Center;

            // Draw the first header with the defined font, brush, rectangle, and format on the first page of the document
            doc.Pages[0].Canvas.DrawString(header1, font, brush, rect, format);

            // Change the font style and brush color for the second header
            font = new PdfTrueTypeFont(new Font("Aleo", 15f, FontStyle.Regular));
            brush = PdfBrushes.Black;

            // Change the alignment of the string format to left alignment for the second header
            format.Alignment = PdfTextAlignment.Left;

            // Draw the second header with the updated font, brush, rectangle, and format on the second page of the document
            doc.Pages[1].Canvas.DrawString(header2, font, brush, rect, format);

            // Save the modified PDF document to the specified output file path in PDF format
            string output = "AddingDifferentHeaders_result.pdf";
            doc.SaveToFile(output, FileFormat.PDF);

            //Launch the Pdf
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
