using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Fields;
using Spire.Pdf.Annotations;
using Spire.Pdf.Graphics;
using Spire.Pdf.Actions;
using Spire.Pdf.General;
namespace AddPdfLaunchAction
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new PDF document 
            PdfDocument doc = new PdfDocument();

            // Add a page to the document
            PdfPageBase page = doc.Pages.Add();

            // Create a PDF Launch Action that will open a text file
            PdfLaunchAction launchAction = new PdfLaunchAction("..\\..\\..\\..\\..\\..\\Data\\text.txt");

            // Create a PDF Action Annotation with the PDF Launch Action
            string text = "Click here to open file";
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 13f));
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
             PdfTrueTypeFont font = new PdfTrueTypeFont("Arial", 13f ,PdfFontStyle.Regular, true);
            */

            RectangleF rect = new RectangleF(50, 50, 230, 15);
            page.Canvas.DrawString(text, font, PdfBrushes.ForestGreen, rect);
            PdfActionAnnotation annotation = new PdfActionAnnotation(rect, launchAction);

            // Add the PDF Action Annotation to the page
            (page as PdfNewPage).Annotations.Add(annotation);

            String result = "AddPdfLaunchAction_out.pdf";

            // Save the document
            doc.SaveToFile(result);

            //Launch the Pdf file
            PDFDocumentViewer(result);
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
