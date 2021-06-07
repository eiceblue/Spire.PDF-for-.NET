using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.ColorSpace;
using Spire.Pdf.Graphics;

namespace DrawDashedLine
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

            //Draw line
            //Set location and size
            float x = 150;
            float y = 200;
            float width = 300;

            //Create pens
            PdfPen pen = new PdfPen(Color.Red, 3f);
            //Set dash style and pattern
            pen.DashStyle = PdfDashStyle.Dash;
            pen.DashPattern = new float[] { 1, 4, 1 };
            //Draw a rectangle
            //Draw two crossed lines
            page.Canvas.DrawLine(pen, x, y, x + width, y);

            //Restore graphics
            page.Canvas.Restore(state);

            String result = "DrawDashedLine_out.pdf";

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
