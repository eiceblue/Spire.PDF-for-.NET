using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
namespace WrapTextAroundImage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            // Creates a pdf document
            PdfDocument doc=new PdfDocument();

            // Creates a page 
            PdfPageBase page = doc.Pages.Add();

            //Gets page width
            float pageWidth = page.Canvas.ClientSize.Width;
            float y = 0;

            y = y + 8;

            // Creates a brush
            PdfBrush brush = new PdfSolidBrush(Color.Black);

            // Defines a font
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 20f, FontStyle.Bold));

            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
             PdfTrueTypeFont font1 = new PdfTrueTypeFont("Arial", 20f, PdfFontStyle.Bold, true);
            */

            // Defines a text center alignment format
            PdfStringFormat format1 = new PdfStringFormat(PdfTextAlignment.Center);
            format1.CharacterSpacing = 1f;

            String text = "Spire.PDF for .NET";
            // Draws text at the specified position
            page.Canvas.DrawString(text, font1, brush, pageWidth / 2, y, format1);
            // Get the size of text
            SizeF size = font1.MeasureString(text, format1);
            y = y + size.Height + 6;

            // Loads an image 
            PdfImage image = PdfImage.FromFile( @"..\..\..\..\..\..\Data\PdfImage.png");

            // Draws image at the specified position
            page.Canvas.DrawImage(image, new PointF(pageWidth - image.PhysicalDimension.Width, y));
            float imageLeftSpace = pageWidth - image.PhysicalDimension.Width - 2;
            float imageBottom = image.PhysicalDimension.Height + y;

            PdfStringFormat format2 = new PdfStringFormat();
            // Loads the text around the image
            text = System.IO.File.ReadAllText(@"..\..\..\..\..\..\Data\text.txt");

            PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 16f));

            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
             PdfTrueTypeFont font2 = new PdfTrueTypeFont("Arial", 16f, PdfFontStyle.Regular, true);
            */


            //Set line spacing
            format2.LineSpacing = font2.Size * 1.5f;

            PdfStringLayouter textLayouter = new PdfStringLayouter();
            float imageLeftBlockHeight = imageBottom - y;

            // Splits the text around into multiple lines based on the draw area
            PdfStringLayoutResult result
                = textLayouter.Layout(text, font2, format2, new SizeF(imageLeftSpace, imageLeftBlockHeight));
            if (result.ActualSize.Height < imageLeftBlockHeight)
            {
                imageLeftBlockHeight = imageLeftBlockHeight + result.LineHeight;
                result = textLayouter.Layout(text, font2, format2, new SizeF(imageLeftSpace, imageLeftBlockHeight));
            }
            // Draws all the lines onto the page
            foreach (LineInfo line in result.Lines)
            {
                page.Canvas.DrawString(line.Text, font2, brush, 0, y, format2);
                y = y + result.LineHeight;
            }

            // Draw the rest of the text onto the page
            PdfTextWidget textWidget = new PdfTextWidget(result.Remainder, font2, brush);
            PdfTextLayout textLayout = new PdfTextLayout();
            textLayout.Break = PdfLayoutBreakType.FitPage;
            textLayout.Layout = PdfLayoutType.Paginate;
            RectangleF bounds = new RectangleF(new PointF(0, y), page.Canvas.ClientSize);
            textWidget.StringFormat = format2;
            textWidget.Draw(page, bounds, textLayout);

            String output = "PlaceTextAroundImage_out.pdf";

            //Save the document
            doc.SaveToFile(output);

            //Launch the Pdf file
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
