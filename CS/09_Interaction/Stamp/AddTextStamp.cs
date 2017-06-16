using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Annotations;
using Spire.Pdf.Annotations.Appearance;
namespace AddTextStamp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //pdf file 
            string input = "..\\..\\..\\..\\..\\..\\..\\Data\\Sample5.pdf";

            //open a pdf document
            PdfDocument document = new PdfDocument(input);

            //get the first page
            PdfPageBase page = document.Pages[0];

            //create a pdf template
            PdfTemplate template = new PdfTemplate(200, 50);
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Elephant", 16f, FontStyle.Italic), true);
            PdfSolidBrush brush = new PdfSolidBrush(Color.DarkRed);
            PdfPen pen = new PdfPen(brush);
            RectangleF rectangle = new RectangleF(new PointF(0, 0), template.Size);
            int CornerRadius = 20;
            PdfPath path = new PdfPath();
            path.AddArc(template.GetBounds().X, template.GetBounds().Y, CornerRadius, CornerRadius, 180, 90);
            path.AddArc(template.GetBounds().X + template.Width - CornerRadius, template.GetBounds().Y, CornerRadius, CornerRadius, 270, 90);
            path.AddArc(template.GetBounds().X + template.Width - CornerRadius, template.GetBounds().Y + template.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
            path.AddArc(template.GetBounds().X, template.GetBounds().Y + template.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
            path.AddLine(template.GetBounds().X, template.GetBounds().Y + template.Height - CornerRadius, template.GetBounds().X, template.GetBounds().Y + CornerRadius / 2);
            template.Graphics.DrawPath(pen, path);

            //draw stamp text
            String s1 = "REVISED\n";
            String s2 = "By Jack at " + DateTime.Now.ToString("HH:mm, MM dd, yyyy");
            template.Graphics.DrawString(s1, font1, brush, new PointF(5, 5));
            PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Gadugi", 12f, FontStyle.Bold), true);
            template.Graphics.DrawString(s2, font2, brush, new PointF(2, 28));

            //create a rubber stamp
            PdfRubberStampAnnotation stamp = new PdfRubberStampAnnotation(rectangle);
            PdfAppearance apprearance = new PdfAppearance(stamp);
            apprearance.Normal = template;
            stamp.Appearance = apprearance;

            //draw stamp into page
            page.AnnotationsWidget.Add(stamp);

            string output = "AddTextStamp.pdf";

            //save pdf document
            document.SaveToFile(output);

            //Launching the Pdf file
            PDFDocumentViewer(output);
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
