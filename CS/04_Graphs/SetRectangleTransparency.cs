using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;


namespace SetRectangleTransparency
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
            int x = 200;
            int y = 300;
            int width = 200;
            int height = 100;
            PdfPen pen = new PdfPen(Color.Black, 1f);
            PdfBrush brush = new PdfSolidBrush(Color.Red);
            PdfBlendMode mode = new PdfBlendMode();
            page.Canvas.SetTransparency(0.5f, 0.5f, mode);
            page.Canvas.DrawRectangle(pen, brush, new Rectangle(new Point(x, y), new Size(width, height)));

            x = x + width / 2;
            y = y - height / 2;
            page.Canvas.SetTransparency(0.2f, 0.2f, mode);
            page.Canvas.DrawRectangle(pen, brush, new Rectangle(new Point(x, y), new Size(width, height)));

            //Restor graphics
            page.Canvas.Restore(state);

            String result = "SetRectangleTransparency_out.pdf";

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
