using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Interactive.Annotations;

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
            string output = "CreatePolylineAnnotation.pdf";
            //Create a pdf document
            PdfDocument pdf = new PdfDocument();
            //Add a new page
            PdfPageBase page = pdf.Pages.Add();
            //Create a polyline annotation
            PointF[] points = new PointF[] { new PointF(40, 100), new PointF(70, 85), new PointF(100, 130), new PointF(130, 120) };
            PdfPolylineAnnotation polyline = new PdfPolylineAnnotation(page, new RectangleF(40, 85, 90, 45), points);
            //Set properties of polyline
            polyline.Color = Color.PaleVioletRed;
            polyline.Contents = "This is a polygon annotation";
            polyline.Title = "E-ICEBLUE";
            polyline.Subject = "polygon annotation demo";
            polyline.Name = "Test Annotation";
            polyline.Border.Width = 1f;
            polyline.Intent = PdfPolyIntent.PolyLineDimension;
            polyline.ModifiedDate = DateTime.Now;
            //Add the annotation into page
            PdfAnnotationCollection.Create(page).Add(polyline);
            polyline.RefreshAppearances();
            //Save pdf
            pdf.SaveToFile(output, FileFormat.PDF);
            pdf.Close();
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
