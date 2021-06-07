using Spire.Pdf;
using Spire.Pdf.Annotations;
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
            foreach (PdfAnnotation annotation in firstPage.AnnotationsWidget.List)
            {
                //If it is FreeTextAnnotation
                if (annotation is PdfFreeTextAnnotationWidget)
                {
                    PdfFreeTextAnnotationWidget textAnnotation = annotation as PdfFreeTextAnnotationWidget;

                    //Get its bounds and text
                    var rect = textAnnotation.Bounds;
                    var text = textAnnotation.Text;

                    //Add new page for newPdf
                    PdfPageBase newPage = newPdf.Pages.Add(firstPage.Size);

                    //Add annotation with the same settings as the annotation of old PDF
                    PdfFreeTextAnnotation newAnnotation = new PdfFreeTextAnnotation(rect);
                    newAnnotation.Text = text;
                    newAnnotation.CalloutLines = textAnnotation.CalloutLines;
                    newAnnotation.LineEndingStyle = textAnnotation.LineEndingStyle;
                    newAnnotation.AnnotationIntent=PdfAnnotationIntent.FreeTextCallout;
                    newAnnotation.RectangleDifferences = textAnnotation.RectangularDifferenceArray;
                    newAnnotation.Color = textAnnotation.Color;
                    newPage.AnnotationsWidget.Add(newAnnotation);
                }
            }
            //Save the file
            String result = "CopyTextAnnotationProperties.pdf";
            newPdf.SaveToFile(result);
            
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
