using Spire.Pdf;
using Spire.Pdf.Annotations;
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

            //Initialize an instance of PdfPolygonAnnotation, specifying all vertex coordinates which can form a complete shape.
            PdfPolygonAnnotation polygon = new PdfPolygonAnnotation(page, new PointF[] { new PointF(0, 30), new PointF(30, 15), new PointF(60, 30), new PointF(45, 50), new PointF(15, 50), new PointF(0, 30)});

            //Set the border color, text, border effect and other properties of polygon annotation.
            polygon.Color = Color.PaleVioletRed;
            polygon.Text = "This is a polygon annotation";
            polygon.Author = "E-ICEBLUE";
            polygon.Subject = "polygon annotation demo";
            polygon.BorderEffect = PdfBorderEffect.BigCloud;
            polygon.ModifiedDate = DateTime.Now;

            //Add the annotation to Pdf page and save the document.
            page.AnnotationsWidget.Add(polygon);

            String result = "CreatePdfPolygonAnnotation_out.pdf";

            //Save the document
            pdf.SaveToFile(result);
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
