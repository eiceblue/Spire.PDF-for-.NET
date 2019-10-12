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
            //Create a pdf document
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\AddFreeTextAnnotation.pdf");
           
            PdfPageBase page = doc.Pages[0];

            RectangleF rect = new RectangleF(0, 300, 100, 80);
            //Add free text annotation
            PdfFreeTextAnnotation textAnnotation = new PdfFreeTextAnnotation(rect);
            textAnnotation.Text = "\n  Spire.PDF";
            PdfAnnotationBorder border = new PdfAnnotationBorder(1f);
            PdfFont font = new PdfFont(PdfFontFamily.TimesRoman, 20);
            textAnnotation.Font = font;
            textAnnotation.Border = border;
            textAnnotation.BorderColor = Color.Gray;
            textAnnotation.LineEndingStyle = PdfLineEndingStyle.Slash;
            textAnnotation.Color = Color.LightBlue;
            textAnnotation.Opacity = 0.8f;
            page.AnnotationsWidget.Add(textAnnotation);

            rect = new RectangleF(150, 200, 150, 40);
            textAnnotation = new PdfFreeTextAnnotation(rect);
            textAnnotation.Text = "\nHigh Fidelity Pdf file Conversion";
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
            textAnnotation.Text = "\nEasily Manipulate document and Form fields";
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
            textAnnotation.Text = "\nSecurity features";
            border = new PdfAnnotationBorder(1f);
            font = new PdfFont(PdfFontFamily.Helvetica, 10);
            textAnnotation.Font = font;
            textAnnotation.Border = border;
            textAnnotation.BorderColor = Color.Pink;
            textAnnotation.LineEndingStyle = PdfLineEndingStyle.RClosedArrow;
            textAnnotation.Color = Color.LightGreen;
            textAnnotation.Opacity = 0.8f;
            page.AnnotationsWidget.Add(textAnnotation);

            rect = new RectangleF(150, 440, 200, 40);
            textAnnotation = new PdfFreeTextAnnotation(rect);
            textAnnotation.Text = "\nExtract data from Pdf documents";
            border = new PdfAnnotationBorder(1f);
            font = new PdfFont(PdfFontFamily.Helvetica, 10);
            textAnnotation.Font = font;
            textAnnotation.Border = border;
            textAnnotation.BorderColor = Color.OrangeRed;
            textAnnotation.LineEndingStyle = PdfLineEndingStyle.RClosedArrow;
            textAnnotation.Color = Color.LightGoldenrodYellow;
            textAnnotation.Opacity = 0.8f;
            page.AnnotationsWidget.Add(textAnnotation);

            string output = "AddFreeTextAnnotation.pdf";
            //Save pdf file
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
