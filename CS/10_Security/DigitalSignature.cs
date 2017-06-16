using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Security;
using Spire.Pdf.Fields;
using Spire.Pdf.Widget;

namespace DigitalSignature
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a pdf document.
            PdfDocument doc = new PdfDocument();

            //Create one page.
            PdfPageBase page = doc.Pages.Add();

            //Draw the page.
            DrawPage(page);

            String pfxPath = @"..\..\..\..\..\..\Data\Demo.pfx";
            PdfCertificate cert = new PdfCertificate(pfxPath, "e-iceblue");

            //signature fully.
            PdfSignature signature = new PdfSignature(doc, page, cert, "signature0");
            //invisible signature.
            //signature.Bounds = new RectangleF(new PointF(20, 350), new SizeF(200, 100));
            //display signature picture.
            //signature.ConfiguerGraphicPath =  @"\signature.jpg";
            //signature.ConfigGraphicType = ConfiguerGraphicType.Picture;
            //display signature text.
            signature.IsTag = true;
            signature.DigitalSignerLable = "Firmado Por:";
            signature.DigitalSigner = "Alex Alvarado";
            signature.ContactInfo = "Harry";
            signature.Date = DateTime.Now;

            signature.Certificated = true;
            signature.DocumentPermissions = PdfCertificationFlags.AllowFormFill | PdfCertificationFlags.ForbidChanges;

            //create empty signature field.
            PdfSignatureField signature1Field = new PdfSignatureField(page, "signature1");
            signature1Field.Bounds = new RectangleF(new PointF(300, 350), new SizeF(200, 100));
            signature1Field.BorderWidth = 1.0f;
            signature1Field.BorderStyle = PdfBorderStyle.Solid;
            signature1Field.BorderColor = new PdfRGBColor(System.Drawing.Color.Black);
            signature1Field.HighlightMode = PdfHighlightMode.Outline;
            // display picture.
            //signature1Field.DrawImage(new PdfBitmap(m_DataDirectory + @"\SpirePdf-815.jpg"), 0, 0);
            doc.Form.Fields.Add(signature1Field);

            doc.SaveToFile("DigitalSignature.pdf");
            doc.Close();

            /* --------------------------------------------------------------------------------------- */

            doc = new PdfDocument("DigitalSignature.pdf");

            //signature empty signature field.
            PdfSignatureFieldWidget signature1FieldWidget =
               (doc.Form as PdfFormWidget).FieldsWidget["signature1"] as PdfSignatureFieldWidget;
            PdfSignature signature1 =
                new PdfSignature(doc, signature1FieldWidget.Page, cert, signature1FieldWidget.Name, signature1FieldWidget);
            signature1.IsTag = true;
            signature1.DigitalSignerLable = "Firmado Por:";
            signature1.DigitalSigner = "Alex Alvarado";
            signature1.ContactInfo = "Harry";
            signature1.Date = DateTime.Now;

            //Save pdf file.
            doc.SaveToFile("DigitalSignature.pdf");
            doc.Close();

            //Launching the Pdf file.
            PDFDocumentViewer("DigitalSignature.pdf");
        }

        private void DrawPage(PdfPageBase page)
        {
            float pageWidth = page.Canvas.ClientSize.Width;
            float y = 0;

            //page header
            PdfPen pen1 = new PdfPen(Color.LightGray, 1f);
            PdfBrush brush1 = new PdfSolidBrush(Color.LightGray);
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 8f, FontStyle.Italic));
            PdfStringFormat format1 = new PdfStringFormat(PdfTextAlignment.Right);
            String text = "Demo of Spire.Pdf";
            page.Canvas.DrawString(text, font1, brush1, pageWidth, y, format1);
            SizeF size = font1.MeasureString(text, format1);
            y = y + size.Height + 1;
            page.Canvas.DrawLine(pen1, 0, y, pageWidth, y);

            //title
            y = y + 5;
            PdfBrush brush2 = new PdfSolidBrush(Color.Black);
            PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 16f, FontStyle.Bold));
            PdfStringFormat format2 = new PdfStringFormat(PdfTextAlignment.Center);
            format2.CharacterSpacing = 1f;
            text = "Summary of Science";
            page.Canvas.DrawString(text, font2, brush2, pageWidth / 2, y, format2);
            size = font2.MeasureString(text, format2);
            y = y + size.Height + 6;

            //icon
            PdfImage image = PdfImage.FromFile(@"..\..\..\..\..\..\Data\Wikipedia_Science.png");
            page.Canvas.DrawImage(image, new PointF(pageWidth - image.PhysicalDimension.Width, y));
            float imageLeftSpace = pageWidth - image.PhysicalDimension.Width - 2;
            float imageBottom = image.PhysicalDimension.Height + y;

            //refenrence content
            PdfTrueTypeFont font3 = new PdfTrueTypeFont(new Font("Arial", 9f));
            PdfStringFormat format3 = new PdfStringFormat();
            format3.ParagraphIndent = font3.Size * 2;
            format3.MeasureTrailingSpaces = true;
            format3.LineSpacing = font3.Size * 1.5f;
            String text1 = "(All text and picture from ";
            String text2 = "Wikipedia";
            String text3 = ", the free encyclopedia)";
            page.Canvas.DrawString(text1, font3, brush2, 0, y, format3);

            size = font3.MeasureString(text1, format3);
            float x1 = size.Width;
            format3.ParagraphIndent = 0;
            PdfTrueTypeFont font4 = new PdfTrueTypeFont(new Font("Arial", 9f, FontStyle.Underline));
            PdfBrush brush3 = PdfBrushes.Blue;
            page.Canvas.DrawString(text2, font4, brush3, x1, y, format3);
            size = font4.MeasureString(text2, format3);
            x1 = x1 + size.Width;

            page.Canvas.DrawString(text3, font3, brush2, x1, y, format3);
            y = y + size.Height;

            //content
            PdfStringFormat format4 = new PdfStringFormat();
            text = System.IO.File.ReadAllText(@"..\..\..\..\..\..\Data\Summary_of_Science.txt");
            PdfTrueTypeFont font5 = new PdfTrueTypeFont(new Font("Arial", 10f));
            format4.LineSpacing = font5.Size * 1.5f;
            PdfStringLayouter textLayouter = new PdfStringLayouter();
            float imageLeftBlockHeight = imageBottom - y;
            PdfStringLayoutResult result
                = textLayouter.Layout(text, font5, format4, new SizeF(imageLeftSpace, imageLeftBlockHeight));
            if (result.ActualSize.Height < imageBottom - y)
            {
                imageLeftBlockHeight = imageLeftBlockHeight + result.LineHeight;
                result = textLayouter.Layout(text, font5, format4, new SizeF(imageLeftSpace, imageLeftBlockHeight));
            }
            foreach (LineInfo line in result.Lines)
            {
                page.Canvas.DrawString(line.Text, font5, brush2, 0, y, format4);
                y = y + result.LineHeight;
            }
            PdfTextWidget textWidget = new PdfTextWidget(result.Remainder, font5, brush2);
            PdfTextLayout textLayout = new PdfTextLayout();
            textLayout.Break = PdfLayoutBreakType.FitPage;
            textLayout.Layout = PdfLayoutType.Paginate;
            RectangleF bounds = new RectangleF(new PointF(0, y), page.Canvas.ClientSize);
            textWidget.StringFormat = format4;
            textWidget.Draw(page, bounds, textLayout);
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
