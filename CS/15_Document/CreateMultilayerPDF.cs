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
using Spire.Pdf.General.Find;
namespace CreateMultilayerPDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PdfDocument doc = new PdfDocument();

            // Creates a page
            PdfPageBase page = doc.Pages.Add();

            //Create text
            String text = "Welcome to evaluate Spire.PDF for .NET !";

            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Left);

            PdfSolidBrush brush = new PdfSolidBrush(Color.Black);

            // Defines a font
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Calibri", 15f, FontStyle.Regular));

            float x = 50;
            float y = 50;

            // Draw text layer
            page.Canvas.DrawString(text, font, brush, new PointF(x, y), format);

            SizeF size = font.MeasureString("Welcome to  evaluate", format);

            SizeF size2 = font.MeasureString("Spire.PDF for .NET", format);

            // Loads an image 
            PdfImage image = PdfImage.FromFile("..\\..\\..\\..\\..\\..\\Data\\MultilayerImage.png");

            // Draw image layer
            page.Canvas.DrawImage(image, new PointF(x + size.Width, y),size2);

            String result = "CreateMultilayerPDF_out.pdf";
  
            //Save the document
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
