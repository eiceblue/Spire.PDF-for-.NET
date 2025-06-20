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
            // Create a new PDF document and load the file from disk
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"../../../../../../Data/PDFTemplate_N.pdf");

            // Get the first page of the document
            PdfPageBase page = doc.Pages[0];

            // Define a PDF pen with gray color
            PdfPen pen = new PdfPen(Color.Gray);

            // Save the current graphics state
            PdfGraphicsState state = page.Canvas.Save();

            // Rotate the page canvas by -20 degrees
            page.Canvas.RotateTransform(-20);

            // Create a PdfStringFormat object and set the character spacing to 5f
            PdfStringFormat format = new PdfStringFormat();
            format.CharacterSpacing = 5f;

            // Draw the string "E-ICEBLUE" on the page using a specified font, pen, position, and format
            page.Canvas.DrawString("E-ICEBLUE", new PdfFont(PdfFontFamily.Helvetica, 45f), pen, 0, 500f, format);

            // Restore the graphics state to its previous state
            page.Canvas.Restore(state);

            // Save the modified PDF document to the specified output file path
            string output = "FillStrokeText_out.pdf";
            doc.SaveToFile(output);

            // Close the PDF document
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
