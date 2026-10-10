using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Interactive.Annotations;
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

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
            RectangleF rect = new RectangleF(40, 340, 200, 80);

            // Create a new PdfFont object using the Times Roman font family and a font size of 20
            PdfFont font = new PdfFont(PdfFontFamily.TimesRoman, 20);

            // Create a new PdfFreeTextAnnotation object and pass the rectangle as a parameter
            PdfFreeTextAnnotation textAnnotation = new PdfFreeTextAnnotation(page, rect, new PdfDefaultAppearance(font));

            // Set the text content of the free text annotation
            textAnnotation.Contents = "\n  Spire.PDF";

            // Assign the created border to the border property of the free text annotation
            textAnnotation.Border.Width = 1f;

            // Set the border color of the free text annotation to gray
            textAnnotation.Border.Color = Color.Gray;

            // Set the line ending style of the free text annotation to slash
            textAnnotation.CalloutLineEndingStyle = PdfLineEndingStyle.Slash;

            // Set the background color of the free text annotation to light blue
            textAnnotation.Color = Color.LightBlue;

            // Set the opacity of the free text annotation to 0.8
            textAnnotation.StrokingOpacity = 0.8f;

            // Set the alignment of the text within the free text annotation to center
            PdfFreeTextAppearanceBuilder builder = new PdfFreeTextAppearanceBuilder(textAnnotation);
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Center);
            builder.SetStringFormat(format);
            textAnnotation.Appearances.SetNormalAppearance(builder.Build());

            // Add the free text annotation to the annotations collection of the page
            PdfAnnotationCollection.Create(page).Add(textAnnotation);

            // Specify the output file path for the modified PDF document
            string result = "SetFreeTextAnnotationAlignment.pdf";

            // Save the modified document to the specified file path
            pdf.SaveToFile(result);
            pdf.Dispose();

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
