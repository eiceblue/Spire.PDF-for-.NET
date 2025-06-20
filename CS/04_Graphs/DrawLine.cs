using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.ColorSpace;
using Spire.Pdf.Graphics;

namespace DrawLine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Load a PDF file
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\DrawingTemplate.pdf");

            //Get the first page
            PdfPageBase page = pdf.Pages[0];

            //Save graphics state
            PdfGraphicsState state = page.Canvas.Save();

            //Set location and size
            float x = 95;
            float y = 95;
            float width = 400;
            float height = 500;

            //Create pens
            PdfPen pen = new PdfPen(Color.Black, 0.1f);
            PdfPen pen1 = new PdfPen(Color.Red, 0.1f);

            //Draw a rectangle
            page.Canvas.DrawRectangle(pen, x, y, width, height);

            //Draw two crossed lines
            page.Canvas.DrawLine(pen1, x, y, x + width, y + height);
            page.Canvas.DrawLine(pen1, x + width, y, x, y + height);

            //Restore graphics
            page.Canvas.Restore(state);

            String result = "DrawLine_out.pdf";

            //Save the document
            pdf.SaveToFile(result);

            //Launch the Pdf file
            PDFDocumentViewer(result);
        }
        private void PDFDocumentViewer(string filename)
        {
            try
            {
                System.Diagnostics.Process.Start(filename);
            }
            catch { }
        }

    }
}
