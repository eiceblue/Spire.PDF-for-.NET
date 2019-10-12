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

namespace FileLinkAnnotation
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
            margin.Left = unitCvtr.ConvertUnits(3f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Right = margin.Left;

            //Add one page
            PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, margin);

            //Define a PdfBrush
            PdfBrush brush1 = PdfBrushes.Black;

            //Define a font
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 13f, FontStyle.Bold), true);

            //Set the string format 
            PdfStringFormat format1 = new PdfStringFormat(PdfTextAlignment.Left);

            //Set the position for drawing 
            float x = 0;
            float y = 50;

            //Text string 
            string specification = "The sample demonstrates how to create a file link in PDF document.";

            //Draw text string on page canvas
            page.Canvas.DrawString(specification, font1, brush1, x, y, format1);

            //Use MeasureString to get the height of string
            y = y + font1.MeasureString(specification, format1).Height + 10;

            //Add file link annotation
            AddFileLinkAnnotation(page, y);

            String result = "FileLinkAnnotation_out.pdf";

            //Save the document
            doc.SaveToFile(result);
            //Launch the Pdf file
            PDFDocumentViewer(result);
        }
        private static void AddFileLinkAnnotation(PdfPageBase page, float y)
        {
            //Define a font
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f));

            //Set the string format 
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Left);

            //Text string
            String prompt = "Launch a File: ";

            //Draw text string on page canvas
            page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y);

            //Use MeasureString to get the width of string
            float x = font.MeasureString(prompt, format).Width;

            //String of file name
            String label = "Sample.pdf";

            //Use MeasureString to get the SizeF of string
            SizeF size = font.MeasureString(label);

            //Create a rectangle
            RectangleF bounds = new RectangleF(x, y, size.Width, size.Height);

            //Draw label string
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y);

            //Create PdfFileLinkAnnotation on the rectangle and link file "Sample.pdf"
            PdfFileLinkAnnotation annotation = new PdfFileLinkAnnotation(bounds, @"..\..\..\..\..\..\Data\Sample.pdf");
           
            //Set color for annotation
            annotation.Color = Color.Blue;

            //Add annotation to the page
            (page as PdfNewPage).Annotations.Add(annotation);

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
