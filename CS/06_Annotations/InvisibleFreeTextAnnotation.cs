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
            //Create a new PDF document.
            PdfDocument doc = new PdfDocument();

            //Load the file from disk.
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\Template_Pdf_4.pdf");

            //Get the first page of PDF file.
            PdfPageBase page = doc.Pages[0];

            //Add a free text annotation to the page and set it invisible.
            RectangleF rect = new RectangleF(100, 120, 150, 30);
            PdfFreeTextAnnotation FreetextAnnotation = new PdfFreeTextAnnotation(rect);
            FreetextAnnotation.Text = "Invisible Free Text Annotation";
            PdfFont font = new PdfFont(PdfFontFamily.TimesRoman, 10);
            PdfAnnotationBorder border = new PdfAnnotationBorder(1f);
            FreetextAnnotation.Font = font;
            FreetextAnnotation.Border = border;
            FreetextAnnotation.BorderColor = Color.Purple;
            FreetextAnnotation.LineEndingStyle = PdfLineEndingStyle.Circle;
            FreetextAnnotation.Color = Color.Green;
            FreetextAnnotation.Opacity = 0.8f;
            //Invisible free text annotation.
            FreetextAnnotation.Flags = PdfAnnotationFlags.Print | PdfAnnotationFlags.NoView;
            page.AnnotationsWidget.Add(FreetextAnnotation);

            //Add a free text annotation show it on the page.
            rect = new RectangleF(100, 180, 150, 30);
            FreetextAnnotation = new PdfFreeTextAnnotation(rect);
            FreetextAnnotation.Text = "Show Free Text Annotation";
            FreetextAnnotation.Font = font;
            FreetextAnnotation.Border = border;
            FreetextAnnotation.BorderColor = Color.LightPink;
            FreetextAnnotation.LineEndingStyle = PdfLineEndingStyle.Circle;
            FreetextAnnotation.Color = Color.LightGreen;
            FreetextAnnotation.Opacity = 0.8f;
            page.AnnotationsWidget.Add(FreetextAnnotation);

            String result = "InvisibleFreeTextAnnotation_out.pdf";

            //Save the document
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
