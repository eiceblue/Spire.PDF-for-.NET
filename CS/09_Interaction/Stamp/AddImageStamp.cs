using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Annotations;
using Spire.Pdf.Graphics;
using Spire.Pdf.Annotations.Appearance;

namespace AddImageStamp
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

            //create a rubber stamp annotation
            PdfRubberStampAnnotation loStamp = new PdfRubberStampAnnotation(new RectangleF(new PointF(0, 0), new SizeF(60, 60)));

            //create an instance of PdfAppearance 
            PdfAppearance loApprearance = new PdfAppearance(loStamp);

            PdfImage image = PdfImage.FromFile("..\\..\\..\\..\\..\\..\\..\\Data\\image stamp.jpg");

            PdfTemplate template = new PdfTemplate(160, 160);

            //draw a pdf image into pdf template
            template.Graphics.DrawImage(image, 0, 0);

            loApprearance.Normal = template;
            loStamp.Appearance = loApprearance;

            //add the rubber stamp annotation into pdf
            page.AnnotationsWidget.Add(loStamp);

            string output = "AddImageStamp.pdf";

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
