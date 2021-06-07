using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.ColorSpace;
using Spire.Pdf.Graphics;

namespace DrawRectangles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\DrawingTemplate.pdf");
            //Create one page
            PdfPageBase page = pdf.Pages[0];

            //Save graphics state
            PdfGraphicsState state = page.Canvas.Save();

            //Draw rectangles
	        //Set rectangle display location and size
            int x = 130;
            int y = 100;
            int width = 300;
            int height = 400;

            //Create one page
            PdfPen pen = new PdfPen(Color.Black, 0.1f);
            page.Canvas.DrawRectangle(pen, new Rectangle(new Point(x, y), new Size(width, height)));

            y = y + height - 50;
            width = 100;
            height = 50;
            //Initialize an instance of PdfSeparationColorSpace
            PdfSeparationColorSpace cs = new PdfSeparationColorSpace("MyColor", Color.FromArgb(0, 100, 0, 0));
            PdfPen pen1 = new PdfPen(Color.Red, 1f);
            //Create a brush with spot color
            PdfBrush brush = new PdfSolidBrush(new PdfSeparationColor(cs, 0.1f));
            page.Canvas.DrawRectangle(pen1, brush, new Rectangle(new Point(x, y), new Size(width, height)));

            //Restore graphics
            page.Canvas.Restore(state);

            String result = "DrawRectangles_out.pdf";

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
