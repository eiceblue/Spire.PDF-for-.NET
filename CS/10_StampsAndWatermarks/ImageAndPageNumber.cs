using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.AutomaticFields;

namespace ImageAndPageNumber
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //create a PDF document
            PdfDocument doc = new PdfDocument();
            doc.PageSettings.Size = PdfPageSize.A4;

            //reset the default margins to 0
            doc.PageSettings.Margins = new PdfMargins(0);

            //create a PdfMargins object, the parameters indicate the page margins you want to set
            PdfMargins margins = new PdfMargins(50, 50, 50, 50);

            //get page size
            SizeF pageSize = doc.PageSettings.Size;

            //create a header template with content and apply it to page template
            doc.Template.Top = CreateHeaderTemplate(doc, margins, pageSize);

            //create a footer template with content and apply it to page template
            doc.Template.Bottom = CreateFooterTemplate(doc, margins, pageSize);

            //apply blank templates to other parts of page template
            doc.Template.Left = new PdfPageTemplateElement(margins.Left, doc.PageSettings.Size.Height);
            doc.Template.Right = new PdfPageTemplateElement(margins.Right, doc.PageSettings.Size.Height);

           //Create one page
            PdfPageBase page = doc.Pages.Add();            

            //Draw the text
            page.Canvas.DrawString("Hello, World!",
                                   new PdfFont(PdfFontFamily.Helvetica, 30f),
                                   new PdfSolidBrush(Color.Black),
                                   10, 10);

            //save the file
            string output = "ImageandPageNumberinHeaderFootersection_out.pdf";
            doc.SaveToFile(output,FileFormat.PDF);
            PDFDocumentViewer(output);
        }
        private PdfPageTemplateElement CreateHeaderTemplate(PdfDocument doc, PdfMargins margins, SizeF pageSize)
        {
            //create a PdfPageTemplateElement object as header space
            PdfPageTemplateElement headerSpace = new PdfPageTemplateElement(pageSize.Width, margins.Top);
            headerSpace.Foreground = false;

            //declare two float variables
            float x = margins.Left;
            float y = 0;

            //draw image in header space 
            PdfImage headerImage = PdfImage.FromFile("../../../../../../../Data/E-iceblueLogo.png");
            float width = headerImage.Width/2;
            float height = headerImage.Height/2;
            headerSpace.Graphics.DrawImage(headerImage, x, margins.Top - height - 5, width, height);

            //draw line in header space
            PdfPen pen = new PdfPen(PdfBrushes.LightGray, 1);
            headerSpace.Graphics.DrawLine(pen, x, y + margins.Top - 2, pageSize.Width - x, y + margins.Top - 2);

            //return headerSpace
            return headerSpace;
        }

        private PdfPageTemplateElement CreateFooterTemplate(PdfDocument doc, PdfMargins margins, SizeF pageSize)
        {
            //create a PdfPageTemplateElement object which works as footer space
            PdfPageTemplateElement footerSpace = new PdfPageTemplateElement(pageSize.Width, margins.Bottom);
            footerSpace.Foreground = false;

            //declare two float variables
            float x = margins.Left;
            float y = 0;

            //draw line in footer space
            PdfPen pen = new PdfPen(PdfBrushes.Gray, 1);
            footerSpace.Graphics.DrawLine(pen, x, y, pageSize.Width - x, y);

            //draw text in footer space
            y = y + 5;
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 10f), true);
            //draw dynamic field in footer space
            PdfPageNumberField number = new PdfPageNumberField();
            PdfPageCountField count = new PdfPageCountField();
            PdfCompositeField compositeField = new PdfCompositeField(font, PdfBrushes.Black, "Page {0} of {1}", number, count);
            compositeField.StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Top);
            SizeF size = font.MeasureString(compositeField.Text);
            compositeField.Bounds = new RectangleF(x, y, size.Width, size.Height);
            compositeField.Draw(footerSpace.Graphics);

            //return footerSpace
            return footerSpace;
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
