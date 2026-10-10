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
            PdfFont font = new PdfFont(PdfFontFamily.TimesRoman, 10);
            PdfFreeTextAnnotation textAnnotation = new PdfFreeTextAnnotation(page, rect, new PdfDefaultAppearance(font));

            //Specify content.
            textAnnotation.Contents = "\nFree Text Annotation Formatting";
            //Set free text annotation formatting and add it to page.
            textAnnotation.Border.Width = 1f;
            textAnnotation.Border.Color = Color.Purple;
            textAnnotation.CalloutLineEndingStyle = PdfLineEndingStyle.Circle;
            textAnnotation.Color = Color.Green;
            textAnnotation.StrokingOpacity = 0.8f;
            textAnnotation.RefreshAppearances();
            PdfAnnotationCollection.Create(page).Add(textAnnotation);

            rect = new RectangleF(150, 200, 150, 40);
            font = new PdfFont(PdfFontFamily.Helvetica, 10);
            textAnnotation = new PdfFreeTextAnnotation(page, rect, new PdfDefaultAppearance(font));
            textAnnotation.Contents = "\nFree Text Annotation Formatting";
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
            textAnnotation.Contents = "\noHow to Set Free Text Annotation Formatting in Pdf file";
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
            textAnnotation.Contents = "\nFree Text Annotation Formatting";
            textAnnotation.Border.Width = 1f;
            textAnnotation.Border.Color = Color.Pink;
            textAnnotation.CalloutLineEndingStyle = PdfLineEndingStyle.RClosedArrow;
            textAnnotation.Color = Color.LightGreen;
            textAnnotation.StrokingOpacity = 0.8f;
            textAnnotation.RefreshAppearances();
            PdfAnnotationCollection.Create(page).Add(textAnnotation);

            String result = "SetFreeTextAnnotationStyle.pdf";

            //Save the document
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
