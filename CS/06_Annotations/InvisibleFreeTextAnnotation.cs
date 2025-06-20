using Spire.Pdf;
using Spire.Pdf.Annotations;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvisibleFreeTextAnnotation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new PDF document.
            PdfDocument doc = new PdfDocument();

            // Load the PDF file from the specified path.
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\Template_Pdf_4.pdf");

            // Get the first page of the PDF document.
            PdfPageBase page = doc.Pages[0];

            // Define a rectangle with specific coordinates and dimensions.
            RectangleF rect = new RectangleF(100, 120, 150, 30);

            // Create a new free text annotation using the defined rectangle.
            PdfFreeTextAnnotation FreetextAnnotation = new PdfFreeTextAnnotation(rect);

            // Set the text content of the free text annotation.
            FreetextAnnotation.Text = "Invisible Free Text Annotation";

            // Specify the font for the free text annotation.
            PdfFont font = new PdfFont(PdfFontFamily.TimesRoman, 10);

            // Specify the border width for the free text annotation.
            PdfAnnotationBorder border = new PdfAnnotationBorder(1f);

            // Set various properties for the free text annotation.
            FreetextAnnotation.Font = font;
            FreetextAnnotation.Border = border;
            FreetextAnnotation.BorderColor = Color.Purple;
            FreetextAnnotation.LineEndingStyle = PdfLineEndingStyle.Circle;
            FreetextAnnotation.Color = Color.Green;
            FreetextAnnotation.Opacity = 0.8f;

            // Set flags to make the free text annotation invisible.
            FreetextAnnotation.Flags = PdfAnnotationFlags.Print | PdfAnnotationFlags.NoView;

            // Add the free text annotation to the page's annotations collection.
            page.Annotations.Add(FreetextAnnotation);

            // Define a new rectangle for the next free text annotation.
            rect = new RectangleF(100, 180, 150, 30);

            // Create another free text annotation using the new rectangle.
            FreetextAnnotation = new PdfFreeTextAnnotation(rect);

            // Set properties for the second free text annotation.
            FreetextAnnotation.Text = "Show Free Text Annotation";
            FreetextAnnotation.Font = font;
            FreetextAnnotation.Border = border;
            FreetextAnnotation.BorderColor = Color.LightPink;
            FreetextAnnotation.LineEndingStyle = PdfLineEndingStyle.Circle;
            FreetextAnnotation.Color = Color.LightGreen;
            FreetextAnnotation.Opacity = 0.8f;

            // Add the second free text annotation to the page's annotations collection.
            page.Annotations.Add(FreetextAnnotation);

            // Specify the filename for the output PDF document.
            String result = "InvisibleFreeTextAnnotation_out.pdf";

            // Save the document with the specified filename.
            doc.SaveToFile(result);

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
