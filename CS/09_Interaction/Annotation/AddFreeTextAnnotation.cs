using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Annotations;
using Spire.Pdf.Graphics;

namespace AddFreeTextAnnotation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //create a pdf document
            PdfDocument doc = new PdfDocument();

            //add a new page
            PdfPageBase page = doc.Pages.Add();

            RectangleF rect = new RectangleF(0, 40, 100, 50);

            //add free text annotations
            PdfFreeTextAnnotation textAnnotation = new PdfFreeTextAnnotation(rect);
            textAnnotation.Text = "Spire.PDF";
            PdfAnnotationBorder border = new PdfAnnotationBorder(1f);
            PdfFont font = new PdfFont(PdfFontFamily.TimesRoman, 10);
            textAnnotation.Font = font;
            textAnnotation.Border = border;
            textAnnotation.BorderColor = Color.LightGreen;
            textAnnotation.LineEndingStyle = PdfLineEndingStyle.Circle;
            textAnnotation.Color = Color.LightPink;
            textAnnotation.Opacity = 0.8f;
            page.AnnotationsWidget.Add(textAnnotation);

            rect = new RectangleF(50, 100, 150, 50);
            textAnnotation = new PdfFreeTextAnnotation(rect);
            textAnnotation.Text = "Spire.Office";
            border = new PdfAnnotationBorder(1f);
            font = new PdfFont(PdfFontFamily.Courier, 10);
            textAnnotation.Font = font;
            textAnnotation.Border = border;
            textAnnotation.BorderColor = Color.Pink;
            textAnnotation.LineEndingStyle = PdfLineEndingStyle.RClosedArrow;
            textAnnotation.Color = Color.LightGreen;
            textAnnotation.Opacity = 0.8f;
            page.AnnotationsWidget.Add(textAnnotation);

            string output = "AddFreeTextAnnotation.pdf";
            //Save pdf file.
            doc.SaveToFile(output);
            doc.Close();

            //Launching the Pdf file.
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
