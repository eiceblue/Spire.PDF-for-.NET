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

            // Create a new PdfFont object using the Times Roman font family and a font size of 20
            PdfFont font = new PdfFont(PdfFontFamily.TimesRoman, 10);

            // Create a new PdfAnnotationBorder object with a specified width
            PdfAnnotationBorder border = new PdfAnnotationBorder(1f);

            // Assign the created font to the font property of the free text annotation
            textAnnotation.Font = font;

            // Assign the created border to the border property of the free text annotation
            textAnnotation.Border = border;

            // Set the border color of the free text annotation to gray
            textAnnotation.BorderColor = Color.Purple;

            // Set the line ending style of the free text annotation to slash
            textAnnotation.LineEndingStyle = PdfLineEndingStyle.Circle;

            // Set the background color of the free text annotation to light blue
            textAnnotation.Color = Color.Green;

            // Set the opacity of the free text annotation to 0.8
            textAnnotation.Opacity = 0.8f;
            page.Annotations.Add(textAnnotation);

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
