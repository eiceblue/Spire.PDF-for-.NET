using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Interactive.Annotations;
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
            // Load the existing PDF document
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\AddFreeTextAnnotation.pdf");

            // Get the first page of the document
            PdfPageBase page = doc.Pages[0];

            // Define a rectangle for the free text annotation
            RectangleF rect = new RectangleF(0, 300, 100, 80);
            PdfFont font = new PdfFont(PdfFontFamily.TimesRoman, 20);

            //Add free text annotation
            PdfFreeTextAnnotation textAnnotation = new PdfFreeTextAnnotation(page, rect, new PdfDefaultAppearance(font));
            textAnnotation.Contents = "\n  Spire.PDF";
            textAnnotation.Border.Width = 1f;

            textAnnotation.Border.Color = Color.Gray;
            textAnnotation.CalloutLineEndingStyle = PdfLineEndingStyle.Slash;
            textAnnotation.Color = Color.LightBlue;
            textAnnotation.StrokingOpacity = 0.8f;
            textAnnotation.RefreshAppearances();
            PdfAnnotationCollection.Create(page).Add(textAnnotation);

            rect = new RectangleF(150, 200, 150, 40);
            font = new PdfFont(PdfFontFamily.Helvetica, 10);
            textAnnotation = new PdfFreeTextAnnotation(page, rect, new PdfDefaultAppearance(font));
            textAnnotation.Contents = "\nHigh Fidelity Pdf file Conversion";
            textAnnotation.Border.Width = 1f;

            textAnnotation.Border.Color = Color.LightGoldenrodYellow;
            textAnnotation.CalloutLineEndingStyle = PdfLineEndingStyle.RClosedArrow;
            textAnnotation.Color = Color.LightPink;
            textAnnotation.StrokingOpacity = 0.8f;
            textAnnotation.RefreshAppearances();
            PdfAnnotationCollection.Create(page).Add(textAnnotation);

            rect = new RectangleF(150, 280, 280, 40);
            font = new PdfFont(PdfFontFamily.Helvetica, 10);
            textAnnotation = new PdfFreeTextAnnotation(page, rect, new PdfDefaultAppearance(font));
            textAnnotation.Contents = "\nEasily Manipulate document and Form fields";
            textAnnotation.Border.Width = 1f;
            textAnnotation.Border.Color = Color.Gray;
            textAnnotation.CalloutLineEndingStyle = PdfLineEndingStyle.Circle;
            textAnnotation.Color = Color.LightSkyBlue;
            textAnnotation.StrokingOpacity = 0.8f;
            textAnnotation.RefreshAppearances();
            PdfAnnotationCollection.Create(page).Add(textAnnotation);

            rect = new RectangleF(150, 360, 200, 40);
            font = new PdfFont(PdfFontFamily.Helvetica, 10);
            textAnnotation = new PdfFreeTextAnnotation(page, rect, new PdfDefaultAppearance(font));
            textAnnotation.Contents = "\nSecurity features";

            textAnnotation.Border.Width = 1f;
            textAnnotation.Border.Color = Color.Pink;
            textAnnotation.CalloutLineEndingStyle = PdfLineEndingStyle.RClosedArrow;
            textAnnotation.Color = Color.LightGreen;
            textAnnotation.StrokingOpacity = 0.8f;
            textAnnotation.RefreshAppearances();
            PdfAnnotationCollection.Create(page).Add(textAnnotation);

            rect = new RectangleF(150, 440, 200, 40);
            font = new PdfFont(PdfFontFamily.Helvetica, 10);
            textAnnotation = new PdfFreeTextAnnotation(page, rect, new PdfDefaultAppearance(font));
            textAnnotation.Contents = "\nExtract data from Pdf documents";

            textAnnotation.Border.Width = 1f;
            textAnnotation.Border.Color = Color.OrangeRed;
            textAnnotation.CalloutLineEndingStyle = PdfLineEndingStyle.RClosedArrow;
            textAnnotation.Color = Color.LightGoldenrodYellow;
            textAnnotation.StrokingOpacity = 0.8f;
            textAnnotation.RefreshAppearances();
            PdfAnnotationCollection.Create(page).Add(textAnnotation);


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
