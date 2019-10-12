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

namespace CreatePdfLinkAnnotation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a new object of PdfDocument.
            PdfDocument doc = new PdfDocument();

            //Add a page to it.
            PdfPageBase page = doc.Pages.Add();

            //Declare two parameters that will be passed to the constructor of PdfFileLinkAnnotation class.
            RectangleF rect = new RectangleF(0, 40, 250, 35);
            string filePath = @"..\..\..\..\..\..\Data\Template_Pdf_3.pdf";

            //Create a file link annotation based on the two parameters and add the annotation to the new page.
            PdfFileLinkAnnotation link = new PdfFileLinkAnnotation(rect, filePath);
            page.AnnotationsWidget.Add(link);

            //Create a free text annotation based on the same RectangleF, specifying the content.
            PdfFreeTextAnnotation text = new PdfFreeTextAnnotation(rect);
            text.Text = "Click here! This is a link annotation.";
            PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 15);
            text.Font = font;
            page.AnnotationsWidget.Add(text);

            String result = "CreatePdfLinkAnnotation_out.pdf";

            //Save the document
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
