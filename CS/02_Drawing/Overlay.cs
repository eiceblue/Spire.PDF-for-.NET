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
            //load two document
            PdfDocument doc1 = new PdfDocument();
            doc1.LoadFromFile(@"..\..\..\..\..\..\Data\Sample1.pdf");

            PdfDocument doc2 = new PdfDocument();
            doc2.LoadFromFile(@"..\..\..\..\..\..\Data\Sample3.pdf");

            //Create page template
            PdfTemplate template = doc1.Pages[0].CreateTemplate();

            foreach (PdfPageBase page in doc2.Pages)
            {
                page.Canvas.SetTransparency(0.25f, 0.25f, PdfBlendMode.Overlay);
                page.Canvas.DrawTemplate(template, PointF.Empty);
            }

            //Save pdf file.
            doc2.SaveToFile("Overlay.pdf");
            doc1.Close();
            doc2.Close();

            //Launching the Pdf file.
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
