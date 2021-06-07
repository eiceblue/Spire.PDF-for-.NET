using Spire.Pdf;
using Spire.Pdf.Annotations;
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

namespace SetFreeTextAnnotationSubject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a new PDF document.
            PdfDocument doc = new PdfDocument();

            //Load the file from disk.
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\Template_Pdf_4.pdf");

            //Get the first page of PDF file.
            PdfPageBase page = doc.Pages[0];

            //Initialize a PdfFreeTextAnnotation.
            RectangleF rect = new RectangleF(150, 120, 150, 30);
            PdfFreeTextAnnotation textAnnotation = new PdfFreeTextAnnotation(rect);

            //Specify content.
            textAnnotation.Text = "\nSet free text annotation subject";

            //Set subject.
            textAnnotation.Subject = "SubjectTest";

            //Set free text annotation formatting and add it to page.
            PdfFont font = new PdfFont(PdfFontFamily.TimesRoman, 10);
            PdfAnnotationBorder border = new PdfAnnotationBorder(1f);
            textAnnotation.Font = font;
            textAnnotation.Border = border;
            textAnnotation.BorderColor = Color.Purple;
            textAnnotation.LineEndingStyle = PdfLineEndingStyle.Circle;
            textAnnotation.Color = Color.Green;
            textAnnotation.Opacity = 0.8f;
            page.AnnotationsWidget.Add(textAnnotation);

            //Save the document
            String result = "SetFreeTextAnnotationSubject_out.pdf";
            doc.SaveToFile(result);

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
