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
            //Load a PDF file
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\DrawingTemplate.pdf");

            //Get the first page
            PdfPageBase page = pdf.Pages[0];

            //Save graphics state
            PdfGraphicsState state = page.Canvas.Save();

            //Set location and size for line
            float x = 150;
            float y = 200;
            float width = 300;

            //Create pens and set syle for it
            PdfPen pen = new PdfPen(Color.Red, 3f);

            //Set dash style and pattern
            pen.DashStyle = PdfDashStyle.Dash;
            pen.DashPattern = new float[] { 1, 4, 1 };

            //Draw dashed lines
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
