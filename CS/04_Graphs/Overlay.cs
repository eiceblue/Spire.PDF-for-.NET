using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;


namespace Overlay
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Load two documents from disk
            PdfDocument doc1 = new PdfDocument();
            doc1.LoadFromFile(@"..\..\..\..\..\..\Data\Overlay1.pdf");

            PdfDocument doc2 = new PdfDocument();
            doc2.LoadFromFile(@"..\..\..\..\..\..\Data\Overlay2.pdf");

            //Create page template form the first page of doc1
            PdfTemplate template = doc1.Pages[0].CreateTemplate();

            //Iterate each page in doc2
            foreach (PdfPageBase page in doc2.Pages)
            {
                //Set transparency for page 
                page.Canvas.SetTransparency(0.25f, 0.25f, PdfBlendMode.Overlay);

                //Draw template
                page.Canvas.DrawTemplate(template, PointF.Empty);
            }

            //Save the document
            doc2.SaveToFile("Overlay.pdf");
            doc1.Close();
            doc2.Close();

            //Launch the Pdf file
            PDFDocumentViewer("Overlay.pdf");
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
