using Spire.Pdf;
using Spire.Pdf.Interactive.Annotations;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextAnnotationProperties
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Load old PDF from disk.
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\FreeTextAnnotation.pdf");

            //Get the first page.
            PdfPageBase firstPage = pdf.Pages[0];

            //Create a new PDF document.
            PdfDocument newPdf = new PdfDocument();

            //Traverse the annotations of the first page of old PDF
            foreach (PdfAnnotation annotation in PdfAnnotationCollection.Create(firstPage))
            {
                //If it is FreeTextAnnotation
                if (annotation is PdfFreeTextAnnotation)
                {
                    PdfFreeTextAnnotation textAnnotation = annotation as PdfFreeTextAnnotation;

                    //Get its bounds and text
                    var rect = textAnnotation.Rectangle;
                    var text = textAnnotation.Contents;

                    //Add new page for newPdf
                    PdfPageBase newPage = newPdf.Pages.Add(firstPage.Size);

                    //Add annotation with the same settings as the annotation of old PDF
                    PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 10);
                    PdfFreeTextAnnotation newAnnotation = new PdfFreeTextAnnotation(newPage, rect, new PdfDefaultAppearance(font));
                    newAnnotation.Contents = text;
                    newAnnotation.CalloutLine = textAnnotation.CalloutLine;
                    newAnnotation.CalloutLineEndingStyle = textAnnotation.CalloutLineEndingStyle;
                    newAnnotation.RectangleDifferences = textAnnotation.RectangleDifferences;
                    newAnnotation.Color = textAnnotation.Color;
                    newAnnotation.Intent = PdfFreeTextIntent.FreeTextCallout;
                    PdfAnnotationCollection.Create(newPage).Add(newAnnotation);
                }
            }

            //Save the document
            String result = "TextAnnotationProperties.pdf";
            newPdf.SaveToFile(result);
            newPdf.Close();

            //Launch the file.
            DocumentViewer(result);
        }

        private void DocumentViewer(string filename)
        {
            try
            {
                System.Diagnostics.Process.Start(filename);
            }
            catch { }
        }
    }
}
