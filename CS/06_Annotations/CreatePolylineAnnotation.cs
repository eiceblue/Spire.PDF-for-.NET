using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Annotations;

namespace CreatePolylineAnnotation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Output file
            string output = "CreatePolylineAnnotation_result.pdf";
            //Create a pdf document
            PdfDocument pdf = new PdfDocument();
            //Add a new page
            PdfPageBase page = pdf.Pages.Add();
            //Create a polyline annotation
            PdfPolyLineAnnotation polyline = new PdfPolyLineAnnotation(page, new PointF[] { new PointF(0, 60), new PointF(30, 45), new PointF(60, 90), new PointF(90, 80) });
            //Set properties of polyline
            polyline.Color = Color.PaleVioletRed;
            polyline.Text = "This is a polygon annotation";
            polyline.Author = "E-ICEBLUE";
            polyline.Subject = "polygon annotation demo";
            polyline.Name = "Test Annotation";
            polyline.Border = new PdfAnnotationBorder(1f);
            polyline.ModifiedDate = DateTime.Now;
            //Add the annotation into page
            page.Annotations.Add(polyline);
            //Save pdf
            pdf.SaveToFile(output, FileFormat.PDF);
            //Launch the Pdf file
            FileViewer(output);
        }
        private void FileViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }

    }
}
