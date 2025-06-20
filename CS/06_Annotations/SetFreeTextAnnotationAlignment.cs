using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Annotations;
using Spire.Pdf.ColorSpace;
using Spire.Pdf.Graphics;


namespace SetFreeTextAnnotationAlignment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new PdfDocument object
            PdfDocument pdf = new PdfDocument();

            // Add a new page to the document and assign it to the 'page' variable
            PdfPageBase page = pdf.Pages.Add();

            // Define a rectangle with specific coordinates and dimensions
            RectangleF rect = new RectangleF(0, 300, 200, 80);

            // Create a new PdfFreeTextAnnotation object and pass the rectangle as a parameter
            PdfFreeTextAnnotation textAnnotation = new PdfFreeTextAnnotation(rect);

            // Set the text content of the free text annotation
            textAnnotation.Text = "\n  Spire.PDF";

            // Create a new PdfAnnotationBorder object with a specified width
            PdfAnnotationBorder border = new PdfAnnotationBorder(1f);

            // Create a new PdfFont object using the Times Roman font family and a font size of 20
            PdfFont font = new PdfFont(PdfFontFamily.TimesRoman, 20);

            // Assign the created font to the font property of the free text annotation
            textAnnotation.Font = font;

            // Assign the created border to the border property of the free text annotation
            textAnnotation.Border = border;

            // Set the border color of the free text annotation to gray
            textAnnotation.BorderColor = Color.Gray;

            // Set the line ending style of the free text annotation to slash
            textAnnotation.LineEndingStyle = PdfLineEndingStyle.Slash;

            // Set the background color of the free text annotation to light blue
            textAnnotation.Color = Color.LightBlue;

            // Set the opacity of the free text annotation to 0.8
            textAnnotation.Opacity = 0.8f;

            // Set the alignment of the text within the free text annotation to center
            textAnnotation.TextAlignment = PdfAnnotationTextAlignment.Center;

            // Add the free text annotation to the annotations collection of the page
            page.Annotations.Add(textAnnotation);

            // Specify the output file path for the modified PDF document
            string output = "SetFreeTextAnnotationAlignment.pdf";

            // Save the modified document to the specified file path
            pdf.SaveToFile(output);

            //Launch the Pdf file
            PDFDocumentViewer(output);
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
