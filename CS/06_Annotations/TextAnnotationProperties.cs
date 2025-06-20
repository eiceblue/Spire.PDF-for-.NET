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
            
            // Create a new PDF document object.
            PdfDocument pdf = new PdfDocument();

            // Load an existing PDF document from a file.
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\FreeTextAnnotation.pdf");

            // Get the first page of the loaded document.
            PdfPageBase firstPage = pdf.Pages[0];

            // Create a new PDF document object to store the copied annotations.
            PdfDocument newPdf = new PdfDocument();

            // Iterate through each annotation in the first page's annotation list.
            foreach (PdfAnnotation annotation in firstPage.Annotations.List)
            {

                // Check if the annotation is a free text annotation.
                if (annotation is PdfFreeTextAnnotationWidget)
                {

                    // Convert the annotation to a free text annotation object.
                    PdfFreeTextAnnotationWidget textAnnotation = annotation as PdfFreeTextAnnotationWidget;

                    // Retrieve the rectangle bounds of the annotation.
                    var rect = textAnnotation.Bounds;

                    // Retrieve the text content of the annotation.
                    var text = textAnnotation.Text;

                    // Create a new page in the new PDF document with the same size as the first page.
                    PdfPageBase newPage = newPdf.Pages.Add(firstPage.Size);

                    // Create a new free text annotation with the same rectangle bounds.
                    PdfFreeTextAnnotation newAnnotation = new PdfFreeTextAnnotation(rect);

                    // Set the text content of the new annotation.
                    newAnnotation.Text = text;

                    // Copy the callout lines information from the original annotation.
                    newAnnotation.CalloutLines = textAnnotation.CalloutLines;

                    // Copy the line ending style from the original annotation.
                    newAnnotation.LineEndingStyle = textAnnotation.LineEndingStyle;

                    // Set the annotation intent to indicate it's a free text callout.
                    newAnnotation.AnnotationIntent = PdfAnnotationIntent.FreeTextCallout;

                    // Copy the rectangular differences information from the original annotation.
                    newAnnotation.RectangleDifferences = textAnnotation.RectangularDifferenceArray;

                    // Set the color of the new annotation to match the original annotation.
                    newAnnotation.Color = textAnnotation.Color;

                    // Add the new annotation to the annotations widget of the new page.
                    newPage.Annotations.Add(newAnnotation);

                }
            }
            // Save the new PDF document with copied annotation properties to a file.
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
