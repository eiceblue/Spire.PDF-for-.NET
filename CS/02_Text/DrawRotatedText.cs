using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace DrawRotatedText
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {   //Create a PDF instance
            PdfDocument doc = new PdfDocument();

            //Create a page
            PdfPageBase page = doc.Pages.Add();

            //Define the text and its style
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f), true);
            PdfSolidBrush brush = new PdfSolidBrush(Color.Blue);
            string text = "This is a text";

            //Draw text before rotating Canvas
            page.Canvas.DrawString(text, font, brush, 20, 30);

            //Draw text before rotating Canvas
            page.Canvas.DrawString(text, font, brush, 20, 150);

            //Create PdfGraphicsState instance to save the state of page Canvas
            PdfGraphicsState state = page.Canvas.Save();

            PointF point1 = new PointF(20, 30);

            //Rotate Canvas 90 degrees clockwise
            page.Canvas.RotateTransform(90, point1);

            //Draw text in rotated Canvas
            page.Canvas.DrawString(text, font, brush, point1);

            //Restores the state of this page Canvas to the state represented by a PdfGraphicsState.
            page.Canvas.Restore(state);

            //Redrawing a new text requires initializing a new state
            PdfGraphicsState state2 = page.Canvas.Save();

            PointF point2 = new PointF(20, 150);

            //Rotate Canvas 90 degrees counterclockwise
            page.Canvas.RotateTransform(-90, point2);

            //Draw text in rotated Canvas
            page.Canvas.DrawString(text, font, brush, point2);

            //Restores the state of this page Canvas to the state represented by a PdfGraphicsState.
            page.Canvas.Restore(state2);

            string output = "DrawText.pdf";
            doc.SaveToFile(output);

            //View the excel document
            FileViewer(output);
        }

        private void FileViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
