using Spire.Pdf;
using Spire.Pdf.Annotations;
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
            int[] linePoints = new int[] { 100, 650, 180, 650 };
            PdfLineAnnotation lineAnnotation = new PdfLineAnnotation(linePoints, "This is the first line annotation");

            //Set the line border.
            lineAnnotation.lineBorder.BorderStyle = PdfBorderStyle.Solid;
            lineAnnotation.lineBorder.BorderWidth = 1;

            //Set the line intent.
            lineAnnotation.LineIntent = PdfLineIntent.LineDimension;

            //Set the line style.
            lineAnnotation.BeginLineStyle = PdfLineEndingStyle.Butt;
            lineAnnotation.EndLineStyle = PdfLineEndingStyle.Diamond;

            //Set the line flag.
            lineAnnotation.Flags = PdfAnnotationFlags.Default;

            //Set the line color.
            lineAnnotation.InnerLineColor = new PdfRGBColor(Color.Green);
            lineAnnotation.BackColor = new PdfRGBColor(Color.Green);

            //Set the leader line.
            lineAnnotation.LeaderLineExt = 0;
            lineAnnotation.LeaderLine = 0;

            //Add the line annotation to the page.
            page.Annotations.Add(lineAnnotation);

            //Create another line annotation.
            linePoints = new int[] { 100, 550, 280, 550 };
            lineAnnotation = new PdfLineAnnotation(linePoints, "This is the second line annotation");
            lineAnnotation.lineBorder.BorderStyle = PdfBorderStyle.Underline;
            lineAnnotation.lineBorder.BorderWidth = 2;
            lineAnnotation.LineIntent = PdfLineIntent.LineArrow;
            lineAnnotation.BeginLineStyle = PdfLineEndingStyle.Circle;
            lineAnnotation.EndLineStyle = PdfLineEndingStyle.Diamond;
            lineAnnotation.Flags = PdfAnnotationFlags.Default;
            lineAnnotation.InnerLineColor = new PdfRGBColor(Color.Pink);
            lineAnnotation.BackColor = new PdfRGBColor(Color.Pink);
            lineAnnotation.LeaderLineExt = 0;
            lineAnnotation.LeaderLine = 0;
            page.Annotations.Add(lineAnnotation);

            //Create yet another line annotation.
            linePoints = new int[] { 100, 450, 280, 450 };
            lineAnnotation = new PdfLineAnnotation(linePoints, "This is the third line annotation");
            lineAnnotation.lineBorder.BorderStyle = PdfBorderStyle.Beveled;
            lineAnnotation.lineBorder.BorderWidth = 2;
            lineAnnotation.LineIntent = PdfLineIntent.LineDimension;
            lineAnnotation.BeginLineStyle = PdfLineEndingStyle.None;
            lineAnnotation.EndLineStyle = PdfLineEndingStyle.None;
            lineAnnotation.Flags = PdfAnnotationFlags.Default;
            lineAnnotation.InnerLineColor = new PdfRGBColor(Color.Blue);
            lineAnnotation.BackColor = new PdfRGBColor(Color.Blue);
            lineAnnotation.LeaderLineExt = 1;
            lineAnnotation.LeaderLine = 1;
            page.Annotations.Add(lineAnnotation);

            String result = "CreatePdfLineAnnotation_out.pdf";

            //Save the document.
            document.SaveToFile(result);

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
