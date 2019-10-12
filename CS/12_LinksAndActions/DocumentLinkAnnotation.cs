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

namespace DocumentLinkAnnotation
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

            //Add the first page
            PdfPageBase page1 = doc.Pages.Add(PdfPageSize.A4, margin);

            //Define a PdfBrush
            PdfBrush brush1 = PdfBrushes.Black;

            //Define a font
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 12f, FontStyle.Bold), true);

            //Set the string format 
            PdfStringFormat format1 = new PdfStringFormat(PdfTextAlignment.Left);

            //Set the position for drawing 
            float x = 0;
            float y = 50;

            //Text string 
            string specification = "The sample demonstrates how to create a local document link in PDF document.";

            //Draw text string on first page 
            page1.Canvas.DrawString(specification, font1, brush1, x, y, format1);

            //Use MeasureString to get the height of string
            y = y + font1.MeasureString(specification, format1).Height +10;

            //Add the second page
            PdfPageBase page2 = doc.Pages.Add(PdfPageSize.A4, margin);

            //String text
            string PageContent = "This is the second page!";

            //Draw text string on second page 
            page2.Canvas.DrawString(PageContent, font1, brush1, x, y, format1);

            //Add DocumentLinkAnnotation on the first page and link to the second page
            AddDocumentLinkAnnotation(doc,0,1, y);


            String result = "DocumentLinkAnnotation_out.pdf";

            //Save the document
            doc.SaveToFile(result);
            //Launch the Pdf file
            PDFDocumentViewer(result);
        }
        private static void AddDocumentLinkAnnotation(PdfDocument pdf, int AddPage, int DestinationPage, float y)
        {
            //Define a font
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f));

            //Set the string format
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Left);

            //Text string
            String prompt = "Local document Link: ";

            //Draw text string on page that
            pdf.Pages[AddPage].Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y);

            //Use MeasureString to get the width of string
            float x = font.MeasureString(prompt, format).Width;

            //Create a PdfDestination with specific page
            PdfDestination dest = new PdfDestination(pdf.Pages[DestinationPage]);

            //Set the location of destination
            dest.Location = new PointF(0, y);

            //Set 50% zoom factor
            dest.Zoom = 0.5f;

            //Label string
            String label = "Click here to link the second page.";

            //Use MeasureString to get the SizeF of string
            SizeF size = font.MeasureString(label);

            //Create a rectangle
            RectangleF bounds = new RectangleF(x, y, size.Width, size.Height);

            //Draw label string
            pdf.Pages[AddPage].Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y);

            //Create PdfDocumentLinkAnnotation on the rectangle and link to the destination  
            PdfDocumentLinkAnnotation annotation = new PdfDocumentLinkAnnotation(bounds, dest);

            //Set color for annotation
            annotation.Color = Color.Blue;

            //Add annotation to the page
            (pdf.Pages[AddPage] as PdfNewPage).Annotations.Add(annotation);
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
