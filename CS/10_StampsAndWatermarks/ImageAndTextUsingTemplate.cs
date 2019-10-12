using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace ImageAndTextUsingTemplate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Load Pdf document from disk
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile("../../../../../../../Data/PDFTemplate_HF.pdf");

            //Get the first page
            PdfPageBase page = doc.Pages[0];

            //Get the margins of Pdf
            PdfMargins margin = doc.PageSettings.Margins;

            //Define font and brush
            PdfTrueTypeFont font=new PdfTrueTypeFont(new Font("Impact",14f,FontStyle.Regular));
            PdfSolidBrush brush=new PdfSolidBrush(Color.Gray);

            //Load an image
            PdfImage image = PdfImage.FromFile("../../../../../../../Data/E-iceblueLogo.png");

            //Specify the image size
            SizeF imageSize=new SizeF(image.Width/2,image.Height/2);

            //Create a header template
            PdfTemplate headerTemplate = new PdfTemplate(page.ActualSize.Width - margin.Left - margin.Right, imageSize.Height);

            //Draw the image in the template
            headerTemplate.Graphics.DrawImage(image, new PointF(0, 0),imageSize);

            //Create a retangle
            RectangleF rect = headerTemplate.GetBounds();

            //string format
            PdfStringFormat format1=new PdfStringFormat(PdfTextAlignment.Right,PdfVerticalAlignment.Middle);

            //Draw a string in the template
            headerTemplate.Graphics.DrawString("Header", font, brush, rect, format1);

            //Create a footer template and draw a text
            PdfTemplate footerTemplate = new PdfTemplate(page.ActualSize.Width - margin.Left - margin.Right, imageSize.Height);
            PdfStringFormat format2=new PdfStringFormat(PdfTextAlignment.Center,PdfVerticalAlignment.Middle);
            footerTemplate.Graphics.DrawString("Footer", font, brush, rect, format2);

            float x = margin.Left;
            float y = 0;

            //Draw the header template on page at specified location
            page.Canvas.DrawTemplate(headerTemplate, new PointF(x,y));

            //Draw the footer template on page at specified location
            y = page.ActualSize.Height - footerTemplate.Height - 10;
            page.Canvas.DrawTemplate(footerTemplate, new PointF(x, y));

            //Save the document
            string output = "ImageAndTextInHeaderFooterUsingTemplate_out.pdf";
            doc.SaveToFile(output, FileFormat.PDF);

            //Launch the Pdf document
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
