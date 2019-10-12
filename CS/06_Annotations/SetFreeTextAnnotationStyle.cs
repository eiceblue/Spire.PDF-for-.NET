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

namespace SetFreeTextAnnotationStyle
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

            //Initialize a PdfFreeTextAnnotation.
            RectangleF rect = new RectangleF(150, 120, 150, 30);
            PdfFreeTextAnnotation textAnnotation = new PdfFreeTextAnnotation(rect);
            //Specify content.
            textAnnotation.Text = "\nFree Text Annotation Formatting";
            //Set free text annotation formatting and add it to page.
            PdfFont font = new PdfFont(PdfFontFamily.TimesRoman, 10);
            PdfAnnotationBorder border = new PdfAnnotationBorder(1f);
            textAnnotation.Font = font;
            textAnnotation.Border = border;
            textAnnotation.BorderColor = Color.Purple;
            textAnnotation.LineEndingStyle = PdfLineEndingStyle.Circle;
            textAnnotation.Color = Color.Green;
            textAnnotation.Opacity = 0.8f;
            page.AnnotationsWidget.Add(textAnnotation);

            rect = new RectangleF(150, 200, 150, 40);
            textAnnotation = new PdfFreeTextAnnotation(rect);
            textAnnotation.Text = "\nFree Text Annotation Formatting";
            border = new PdfAnnotationBorder(1f);
            font = new PdfFont(PdfFontFamily.Helvetica, 10);
            textAnnotation.Font = font;
            textAnnotation.Border = border;
            textAnnotation.BorderColor = Color.LightGoldenrodYellow;
            textAnnotation.LineEndingStyle = PdfLineEndingStyle.RClosedArrow;
            textAnnotation.Color = Color.LightPink;
            textAnnotation.Opacity = 0.8f;
            page.AnnotationsWidget.Add(textAnnotation);

            rect = new RectangleF(150, 280, 280, 40);
            textAnnotation = new PdfFreeTextAnnotation(rect);
            textAnnotation.Text = "\noHow to Set Free Text Annotation Formatting in Pdf file";
            border = new PdfAnnotationBorder(1f);
            font = new PdfFont(PdfFontFamily.Helvetica, 10);
            textAnnotation.Font = font;
            textAnnotation.Border = border;
            textAnnotation.BorderColor = Color.Gray;
            textAnnotation.LineEndingStyle = PdfLineEndingStyle.Circle;
            textAnnotation.Color = Color.LightSkyBlue;
            textAnnotation.Opacity = 0.8f;
            page.AnnotationsWidget.Add(textAnnotation);

            rect = new RectangleF(150, 360, 200, 40);
            textAnnotation = new PdfFreeTextAnnotation(rect);
            textAnnotation.Text = "\nFree Text Annotation Formatting";
            border = new PdfAnnotationBorder(1f);
            font = new PdfFont(PdfFontFamily.Helvetica, 10);
            textAnnotation.Font = font;
            textAnnotation.Border = border;
            textAnnotation.BorderColor = Color.Pink;
            textAnnotation.LineEndingStyle = PdfLineEndingStyle.RClosedArrow;
            textAnnotation.Color = Color.LightGreen;
            textAnnotation.Opacity = 0.8f;
            page.AnnotationsWidget.Add(textAnnotation);

            String result = "SetFreeTextAnnotationFormatting_out.pdf";

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
