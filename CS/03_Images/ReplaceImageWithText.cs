using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReplaceImageWithText
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Create a pdf document
            PdfDocument doc = new PdfDocument();

            //Load file from disk.
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\ReplaceImage.pdf");

            //Get the first page.
            PdfPageBase page = doc.Pages[0];

            //Create PdfImageHelper object to get Images from page
            PdfImageHelper helper = new PdfImageHelper();
            Spire.Pdf.Utilities.PdfImageInfo[] images = helper.GetImagesInfo(page);

            //Get width and height of image
            float widthInPixel = images[0].Image.Width;
            float heightInPixel = images[0].Image.Height;

            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*            
            float widthInPixel = 100;
            float heightInPixel = 100;
            */

            //Convert unit from Pixel to Point
            PdfUnitConvertor convertor = new PdfUnitConvertor();
            float width = convertor.ConvertFromPixels(widthInPixel, PdfGraphicsUnit.Point);
            float height = convertor.ConvertFromPixels(heightInPixel, PdfGraphicsUnit.Point);

            //Get location of image
            float xPos = images[0].Bounds.X;
            float yPos = images[0].Bounds.Y;

            //Remove the image
            helper.DeleteImage(images[0]);

            //Define a rectangle
            RectangleF rect = new RectangleF(new PointF(xPos, yPos), new SizeF(width, height));

            //Define string format
            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Center;
            format.LineAlignment = PdfVerticalAlignment.Middle;

            //Draw a string at the location of the image
            page.Canvas.DrawString("ReplacedText", new PdfFont(PdfFontFamily.Helvetica, 18f), PdfBrushes.Purple, rect, format);

            String result = "ReplaceImageWithText_out.pdf";

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
