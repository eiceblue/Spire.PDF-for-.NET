using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace DrawFilledRectangles
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

            //save graphics state
            PdfGraphicsState state = page.Canvas.Save();

            //Set rectangle display location and size
            int x = 200;
            int y = 300;
            int width = 200;
            int height = 120;
            //Create one page and brush
            PdfPen pen = new PdfPen(Color.Black, 1f);
            PdfBrush brush = new PdfSolidBrush(Color.OrangeRed);
            //Draw a filled rectangle
            page.Canvas.DrawRectangle(pen, brush, new Rectangle(new Point(x, y), new Size(width, height)));

            //restor graphics
            page.Canvas.Restore(state);

            String result = "DrawFilledRectangles_out.pdf";

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
