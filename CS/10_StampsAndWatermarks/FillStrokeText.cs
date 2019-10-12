using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Tables;

namespace FillStrokeText
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a pdf document and load file from disk
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"../../../../../../Data/PDFTemplate_N.pdf");

            //Get the first page
            PdfPageBase page = doc.Pages[0];

            //Define Pdf pen
            PdfPen pen = new PdfPen(Color.Gray);

            //Save graphics state
            PdfGraphicsState state = page.Canvas.Save();

            //Rotate page canvas
            page.Canvas.RotateTransform(-20);

            PdfStringFormat format = new PdfStringFormat();
            format.CharacterSpacing = 5f;

            //Draw the string on page
            page.Canvas.DrawString("E-ICEBLUE", new PdfFont(PdfFontFamily.Helvetica, 45f), pen, 0, 500f,format);

            //Restore graphics
            page.Canvas.Restore(state);

            //Save the Pdf file
            string output = "FillStrokeText_out.pdf";
            doc.SaveToFile(output);
            doc.Close();

            //Launch the Pdf file
            PDFDocumentViewer(output);
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
