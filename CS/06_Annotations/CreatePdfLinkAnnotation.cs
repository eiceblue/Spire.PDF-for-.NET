using Spire.Pdf;
using Spire.Pdf.Interactive.Annotations;
using Spire.Pdf.Actions;
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
            RectangleF rect = new RectangleF(40, 80, 250, 35);
            string filePath = @"..\..\..\..\..\..\Data\Template_Pdf_3.pdf";

            //Create a file link annotation based on the two parameters and add the annotation to the new page.
            PdfLinkAnnotation link = new PdfLinkAnnotation(page, rect, new PdfLaunchAction(filePath,PdfFilePathType.Relative));
            PdfAnnotationCollection.Create(page).Add(link);
            PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 15);
            //Create a free text annotation based on the same RectangleF, specifying the content.
            PdfFreeTextAnnotation text = new PdfFreeTextAnnotation(page, rect, new PdfDefaultAppearance(font));
            text.Contents = "Click here! This is a link annotation.";

            PdfAnnotationCollection.Create(page).Add(text);

            string result = "CreatePdfLinkAnnotation.pdf";

            //Save the document
            doc.SaveToFile(result);
            doc.Close();

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
