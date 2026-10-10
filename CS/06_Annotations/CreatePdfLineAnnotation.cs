using Spire.Pdf;
using Spire.Pdf.Interactive.Annotations;
using Spire.Pdf.Fields;
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

namespace CreatePdfLineAnnotation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a PDF document.
            PdfDocument document = new PdfDocument();

            //Add a new page.
            PdfPageBase page = document.Pages.Add();

            //Create a line annotation.
            int[] linePoints = new int[] { 140, 690, 180, 650 };
            RectangleF rect = new RectangleF(140, 689, 80, 1);
            PdfLineAnnotation lineAnnotation = new PdfLineAnnotation(page, rect, new PointF(140, 690), new PointF(220, 690));
            lineAnnotation.Contents = "This is the first line annotation";

            //Set the line border.
            lineAnnotation.Border.Style = Spire.Pdf.Interactive.Annotations.PdfBorderStyle.Solid;
            lineAnnotation.Border.Width = 1;

            //Set the line intent.
            lineAnnotation.Intent = PdfLineIntent.LineDimension;

            //Set the line style.
            lineAnnotation.StartingStyle = PdfLineEndingStyle.Butt;
            lineAnnotation.EndingStyle = PdfLineEndingStyle.Diamond;

            //Set the line flag.
            lineAnnotation.Flags = PdfAnnotationFlags.None;

            //Set the line color.
            lineAnnotation.InteriorColor = new PdfRGBColor(Color.Green);
            lineAnnotation.Color = new PdfRGBColor(Color.Green);

            //Set the leader line.
            lineAnnotation.LeaderLineExtension = 0;
            lineAnnotation.LeaderLine = 0;

            //Add the line annotation to the page.
            PdfAnnotationCollection.Create(page).Add(lineAnnotation);

            //Create another line annotation.
            linePoints = new int[] { 140, 590, 280, 550 };
            rect = new RectangleF(140, 589, 180, 2);
            lineAnnotation = new PdfLineAnnotation(page, rect, new PointF(140, 590), new PointF(320, 590));
            lineAnnotation.Contents = "This is the second line annotation";
            lineAnnotation.Border.Style = Spire.Pdf.Interactive.Annotations.PdfBorderStyle.Solid;
            lineAnnotation.Border.Width = 2;
            lineAnnotation.Intent = PdfLineIntent.LineArrow;
            lineAnnotation.StartingStyle = PdfLineEndingStyle.Circle;
            lineAnnotation.EndingStyle = PdfLineEndingStyle.Diamond;
            lineAnnotation.Flags = PdfAnnotationFlags.None;
            lineAnnotation.InteriorColor = new PdfRGBColor(Color.Pink);
            lineAnnotation.Color = new PdfRGBColor(Color.Pink);
            lineAnnotation.LeaderLineExtension = 0;
            lineAnnotation.LeaderLine = 0;
            PdfAnnotationCollection.Create(page).Add(lineAnnotation);

            //Create yet another line annotation.
            linePoints = new int[] { 140, 490, 280, 450 };
            rect = new RectangleF(140, 489, 180, 2);
            lineAnnotation = new PdfLineAnnotation(page, rect, new PointF(140, 490), new PointF(320, 490));
            lineAnnotation.Contents = "This is the third line annotation";
            lineAnnotation.Border.Style = Spire.Pdf.Interactive.Annotations.PdfBorderStyle.Solid;
            lineAnnotation.Border.Width = 2;
            lineAnnotation.Intent = PdfLineIntent.LineDimension;
            lineAnnotation.StartingStyle = PdfLineEndingStyle.None;
            lineAnnotation.EndingStyle = PdfLineEndingStyle.None;
            lineAnnotation.Flags = PdfAnnotationFlags.None;
            lineAnnotation.InteriorColor = new PdfRGBColor(Color.Blue);
            lineAnnotation.Color = new PdfRGBColor(Color.Blue);
            lineAnnotation.LeaderLineExtension = 1;
            lineAnnotation.LeaderLine = 1;
            PdfAnnotationCollection.Create(page).Add(lineAnnotation);

            string result = "CreatePdfLineAnnotation.pdf";

            //Save the document.
            document.SaveToFile(result);
            document.Close();

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
