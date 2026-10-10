using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Interactive.Annotations;

namespace AddInkAnnotation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a PDF document
            PdfDocument pdf = new PdfDocument();

            // Add a page to the document
            PdfPageBase pdfPage = pdf.Pages.Add();

            // Define the points for the ink annotation
            System.Collections.Generic.List<PointF[]> inkList = new System.Collections.Generic.List<PointF[]>();
            PointF[] points = new PointF[] { new PointF(140, 840), new PointF(240, 840), new PointF(240, 740) };
            inkList.Add(points);

            // Create an ink annotation using the defined points
            PdfInkAnnotation ia = new PdfInkAnnotation(pdfPage, new RectangleF(140, 740, 100, 100), inkList);

            // Set properties of the ink annotation such as color, border width, opacity, and text
            ia.Color = Color.Pink;
            ia.Border.Width = 12;
            ia.StrokingOpacity = 0.3f;
            ia.Contents = "e-iceblue";

            // Add the ink annotation to the page's annotation collection
            PdfAnnotationCollection.Create(pdfPage).Add(ia);

            // Save the document to PDF format
            string result = "AddInkAnnotation.pdf";
            pdf.SaveToFile(result);
            pdf.Close();

            //Launch the Pdf file
            PDFDocumentViewer(result);
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
