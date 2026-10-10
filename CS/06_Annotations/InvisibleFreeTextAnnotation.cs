using Spire.Pdf;
using Spire.Pdf.Interactive.Annotations;
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

            // Specify the font for the free text annotation.
            PdfFont font = new PdfFont(PdfFontFamily.TimesRoman, 10);

            // Specify a default appearance for the free text annotation.
            PdfDefaultAppearance defaultAppearance = new PdfDefaultAppearance(font);

            // Create a new free text annotation using the page, the rectangle and the default appearance.
            PdfFreeTextAnnotation FreetextAnnotation = new PdfFreeTextAnnotation(page, rect, defaultAppearance);

            // Set the text content of the free text annotation.
            FreetextAnnotation.Contents = "Invisible Free Text Annotation";

            // Set various properties for the free text annotation.
            FreetextAnnotation.Border.Width = 1f;
            FreetextAnnotation.Border.Color = Color.Purple;
            FreetextAnnotation.CalloutLineEndingStyle = PdfLineEndingStyle.Circle;
            FreetextAnnotation.Color = Color.Green;
            FreetextAnnotation.StrokingOpacity = 0.8f;

            // Set flags to make the free text annotation invisible.
            FreetextAnnotation.Flags = PdfAnnotationFlags.Print | PdfAnnotationFlags.NoView;

            // Add the free text annotation to the page's annotations collection.
            PdfAnnotationCollection.Create(page).Add(FreetextAnnotation);

            // Refresh the appearance of the free text annotation.
            FreetextAnnotation.RefreshAppearances();

            // Define a new rectangle for the next free text annotation.
            rect = new RectangleF(100, 180, 150, 30);

            // Create another free text annotation using the new rectangle.
            FreetextAnnotation = new PdfFreeTextAnnotation(page, rect, new PdfDefaultAppearance(font));

            // Set properties for the second free text annotation.
            FreetextAnnotation.Contents = "Show Free Text Annotation";
            FreetextAnnotation.Border.Width = 1f;
            FreetextAnnotation.Border.Color = Color.LightPink;
            FreetextAnnotation.CalloutLineEndingStyle = PdfLineEndingStyle.Circle;
            FreetextAnnotation.Color = Color.LightGreen;
            FreetextAnnotation.StrokingOpacity = 0.8f;

            // Add the second free text annotation to the page's annotations collection.
            PdfAnnotationCollection.Create(page).Add(FreetextAnnotation);

            // Refresh the appearance of the second free text annotation.
            FreetextAnnotation.RefreshAppearances();

            // Specify the filename for the output PDF document.
            String result = "InvisibleFreeTextAnnotation.pdf";

            // Save the document with the specified filename.
            doc.SaveToFile(result);

            doc.Close();

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
