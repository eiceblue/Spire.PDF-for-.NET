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
            //Load a pdf document
            string input = "..\\..\\..\\..\\..\\..\\Data\\AddImageStamp.pdf";
            PdfDocument document = new PdfDocument();
	    document.LoadFromFile(input);
            //Get the first page
            PdfPageBase page = document.Pages[0];

            //Create a rubber stamp annotation
            PdfRubberStampAnnotation loStamp = new PdfRubberStampAnnotation(new RectangleF(new PointF(0, 0), new SizeF(60, 60)));

            //Create an instance of PdfAppearance 
            PdfAppearance loApprearance = new PdfAppearance(loStamp);
            PdfImage image = PdfImage.FromFile("..\\..\\..\\..\\..\\..\\Data\\image stamp.jpg");
            PdfTemplate template = new PdfTemplate(210, 210);

            //Draw a pdf image into pdf template
            template.Graphics.DrawImage(image, 60, 60);
            loApprearance.Normal = template;
            loStamp.Appearance = loApprearance;

            //Add the rubber stamp annotation into pdf
            page.AnnotationsWidget.Add(loStamp);

            string output = "AddImageStamp.pdf";

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
