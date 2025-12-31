using Spire.Pdf;
using Spire.Pdf.Actions;
using Spire.Pdf.General;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RotateNewPDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new PDF document
            PdfDocument doc = new PdfDocument();

            // Create a PdfUnitConvertor to convert units
            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();

            // Set the page margins using converted units (2.54 cm top and bottom, 2.0 cm left and right)
            PdfMargins margin = new PdfMargins();
            margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Bottom = margin.Top;
            margin.Left = unitCvtr.ConvertUnits(2.0f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Right = margin.Left;

            // Create a new section for the document
            PdfSection section = doc.Sections.Add();

            // Set the size of the PDF page to "A4"
            section.PageSettings.Size = PdfPageSize.A4;

            // Set the page margins for the section
            section.PageSettings.Margins = margin;

            // Set the rotation angle of the section to 90 degrees clockwise
            section.PageSettings.Rotate = PdfPageRotateAngle.RotateAngle90;

            // Add a new page to the section
            PdfPageBase page = section.Pages.Add();

            // Define a brush for drawing
            PdfBrush brush = PdfBrushes.Black;

            // Define a font for text
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 13f, FontStyle.Bold), true);
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
             PdfTrueTypeFont font = new PdfTrueTypeFont("Arial", 13f, PdfFontStyle.Bold, true);
            */

            // Set the string format for text alignment (left-aligned)
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Left);

            // Set the position for drawing the text on the page canvas
            float x = 0;
            float y = 50;

            // Define the text string to be drawn on the page
            string specification = "The sample demonstrates how to rotate a page when creating a PDF document.";

            // Draw the text string on the page canvas
            page.Canvas.DrawString(specification, font, brush, x, y, format);

            // Specify the output file name for the rotated PDF
            String result = "RotateNewPDF_out.pdf";

            // Save the document with the rotated page to disk
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
