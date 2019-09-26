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
            //Create a pdf document
            PdfDocument doc = new PdfDocument();

            //Create PdfUnitConvertor to convert the unit
            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();

            //Setting for page margin
            PdfMargins margin = new PdfMargins();
            margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Bottom = margin.Top;
            margin.Left = unitCvtr.ConvertUnits(2.0f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Right = margin.Left;

            //Create PdfSection
            PdfSection section = doc.Sections.Add();

            //Set "A4" for Pdf page
            section.PageSettings.Size = PdfPageSize.A4;
         
            //Set page margin
            section.PageSettings.Margins = margin;

            //Set rotating angle
            section.PageSettings.Rotate = PdfPageRotateAngle.RotateAngle90;

            //Add the page
            PdfPageBase page = section.Pages.Add();

            //Define a PdfBrush
            PdfBrush brush = PdfBrushes.Black;

            //Define a font
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 13f, FontStyle.Bold), true);

            //Set the string format 
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Left);

            //Set the position for drawing 
            float x = 0;
            float y = 50;

            //Text string 
            string specification = "The sample demonstrates how to rotate page when creating a PDF document.";

            //Draw text string on page canvas
            page.Canvas.DrawString(specification, font, brush, x, y, format);

            String result = "RotateNewPDF_out.pdf";

            //Save the document
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
