using Spire.Pdf;
using Spire.Pdf.Interactive.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreatePdfPolygonAnnotation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a Pdf document.
            PdfDocument pdf = new PdfDocument();

            //Add a new page to it.
            PdfPageBase page = pdf.Pages.Add();

            //Initialize an instance of PdfPolygonAnnotation, specifying a rectangle and all vertex coordinates which can form a complete shape.
            PointF[] points = new PointF[] { new PointF(40, 70), new PointF(70, 55), new PointF(100, 70), new PointF(85, 90), new PointF(55, 90), new PointF(40, 70) };
            PdfPolygonAnnotation polygon = new PdfPolygonAnnotation(page, new RectangleF(40, 55, 60, 35), points);

            //Set the border color, text, border effect and other properties of polygon annotation.
            polygon.Color = Color.PaleVioletRed;
            polygon.Contents = "This is a polygon annotation";
            polygon.Title = "E-ICEBLUE";
            polygon.Subject = "polygon annotation demo";
            polygon.Border.Effect = PdfBorderEffect.Cloudy;
            polygon.Border.EffectIntensity = 2;
            polygon.ModifiedDate = DateTime.Now;

            //Add the annotation to Pdf page and save the document.
            PdfAnnotationCollection.Create(page).Add(polygon);

            String result = "CreatePdfPolygonAnnotation.pdf";

            //Save the document
            pdf.SaveToFile(result);
            pdf.Close();

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
