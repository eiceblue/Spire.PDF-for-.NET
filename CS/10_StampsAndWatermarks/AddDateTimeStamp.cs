using Spire.Pdf;
using Spire.Pdf.Annotations;
using Spire.Pdf.Annotations.Appearance;
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

namespace AddDateTimeStamp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Load a Pdf document from disk
            PdfDocument document = new PdfDocument();
            document.LoadFromFile("../../../../../../Data/PDFTemplate_N.pdf");

            //Get the first page
            PdfPageBase page = document.Pages[0];

            //Set the font and brush
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f, FontStyle.Regular), true);
            PdfSolidBrush brush = new PdfSolidBrush(Color.Blue);

            //Time text
            String timeString = DateTime.Now.ToString("MM/dd/yy hh:mm:ss tt ");

            //Create a template and rectangle, draw the string
            PdfTemplate template = new PdfTemplate(140, 15);
            RectangleF rect = new RectangleF(new PointF(page.ActualSize.Width - template.Width - 10, page.ActualSize.Height - template.Height - 10), template.Size);
            template.Graphics.DrawString(timeString, font, brush, new PointF(0, 0));

            //Create stamp annoation
            PdfRubberStampAnnotation stamp = new PdfRubberStampAnnotation(rect);
            PdfAppearance apprearance = new PdfAppearance(stamp);
            apprearance.Normal = template;
            stamp.Appearance = apprearance;
            page.AnnotationsWidget.Add(stamp);

            //Sabe the document
            string output = "AddDateTimeStamp_result.pdf";
            document.SaveToFile(output, FileFormat.PDF);

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
