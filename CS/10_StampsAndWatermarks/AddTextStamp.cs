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
            //Load a pdf document
            string input = "..\\..\\..\\..\\..\\..\\Data\\AddTextStamp.pdf";

            //Open a pdf document
            PdfDocument document = new PdfDocument();
	    document.LoadFromFile(input);
            //Get the first page
            PdfPageBase page = document.Pages[0];

            //Create a pdf template
            PdfTemplate template = new PdfTemplate(125, 55);
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Elephant", 10f, FontStyle.Italic), true);
            PdfSolidBrush brush = new PdfSolidBrush(Color.DarkRed);
            PdfPen pen = new PdfPen(brush);
            RectangleF rectangle = new RectangleF(new PointF(5, 5), template.Size);
            int CornerRadius = 20;
            PdfPath path = new PdfPath();
            path.AddArc(template.GetBounds().X, template.GetBounds().Y, CornerRadius, CornerRadius, 180, 90);
            path.AddArc(template.GetBounds().X + template.Width - CornerRadius, template.GetBounds().Y, CornerRadius, CornerRadius, 270, 90);
            path.AddArc(template.GetBounds().X + template.Width - CornerRadius, template.GetBounds().Y + template.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
            path.AddArc(template.GetBounds().X, template.GetBounds().Y + template.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
            path.AddLine(template.GetBounds().X, template.GetBounds().Y + template.Height - CornerRadius, template.GetBounds().X, template.GetBounds().Y + CornerRadius / 2);
            template.Graphics.DrawPath(pen, path);

            //Draw stamp text
            String s1 = "REVISED\n";
            String s2 = "by E-iceblue at " + DateTime.Now.ToString("MM dd, yyyy");
            template.Graphics.DrawString(s1, font1, brush, new PointF(5, 10));
            PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Lucida Sans Unicode", 9f, FontStyle.Bold), true);
            template.Graphics.DrawString(s2, font2, brush, new PointF(2, 30));

            //Create a rubber stamp
            PdfRubberStampAnnotation stamp = new PdfRubberStampAnnotation(rectangle);
            PdfAppearance apprearance = new PdfAppearance(stamp);
            apprearance.Normal = template;
            stamp.Appearance = apprearance;

            //Draw stamp into page
            page.AnnotationsWidget.Add(stamp);

            string output = "AddTextStamp.pdf";

            //Save pdf document
            document.SaveToFile(output);

            //Launch the file
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
