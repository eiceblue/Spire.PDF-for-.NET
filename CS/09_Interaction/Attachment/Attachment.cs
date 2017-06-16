using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Annotations;
using Spire.Pdf.Attachments;
using Spire.Pdf.Graphics;

namespace Attachment
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

            //margin
            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
            PdfMargins margin = new PdfMargins();
            margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Bottom = margin.Top;
            margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Right = margin.Left;

            //create section
            PdfSection section = doc.Sections.Add();
            section.PageSettings.Size = PdfPageSize.A4;
            section.PageSettings.Margins = margin;

            // Create one page
            PdfPageBase page = section.Pages.Add();

            float y = 10;

            //title
            PdfBrush brush1 = PdfBrushes.Black;
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 16f, FontStyle.Bold));
            PdfStringFormat format1 = new PdfStringFormat(PdfTextAlignment.Center);
            page.Canvas.DrawString("Attachment", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1);
            y = y + font1.MeasureString("Attachment", format1).Height;
            y = y + 5;

            //attachment
            PdfAttachment attachment = new PdfAttachment("Header.png");
            attachment.Data = File.ReadAllBytes(@"..\..\..\..\..\..\..\Data\Header.png");
            attachment.Description = "Page header picture of demo.";
            attachment.MimeType = "image/png";
            doc.Attachments.Add(attachment);

            attachment = new PdfAttachment("Footer.png");
            attachment.Data = File.ReadAllBytes(@"..\..\..\..\..\..\..\Data\Footer.png");
            attachment.Description = "Page footer picture of demo.";
            attachment.MimeType = "image/png";
            doc.Attachments.Add(attachment);

            PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 12f, FontStyle.Bold));
            PointF location = new PointF(0, y);
            String label = "Sales Report Chart";
            byte[] data = File.ReadAllBytes(@"..\..\..\..\..\..\..\Data\SalesReportChart.png");
            SizeF size = font2.MeasureString(label);
            RectangleF bounds = new RectangleF(location, size);
            page.Canvas.DrawString(label, font2, PdfBrushes.DarkOrange, bounds);
            bounds = new RectangleF(bounds.Right + 3, bounds.Top, font2.Height / 2, font2.Height);
            PdfAttachmentAnnotation annotation1
                = new PdfAttachmentAnnotation(bounds, "SalesReportChart.png", data);
            annotation1.Color = Color.Teal;
            annotation1.Flags = PdfAnnotationFlags.ReadOnly;
            annotation1.Icon = PdfAttachmentIcon.Graph;
            annotation1.Text = "Sales Report Chart";
            (page as PdfNewPage).Annotations.Add(annotation1);
            y = y + size.Height + 2;

            location = new PointF(0, y);
            label = "Science Personification Boston";
            data = File.ReadAllBytes(@"..\..\..\..\..\..\..\Data\SciencePersonificationBoston.jpg");
            size = font2.MeasureString(label);
            bounds = new RectangleF(location, size);
            page.Canvas.DrawString(label, font2, PdfBrushes.DarkOrange, bounds);
            bounds = new RectangleF(bounds.Right + 3, bounds.Top, font2.Height / 2, font2.Height);
            PdfAttachmentAnnotation annotation2
                = new PdfAttachmentAnnotation(bounds, "SciencePersonificationBoston.jpg", data);
            annotation2.Color = Color.Orange;
            annotation2.Flags = PdfAnnotationFlags.NoZoom;
            annotation2.Icon = PdfAttachmentIcon.PushPin;
            annotation2.Text = "SciencePersonificationBoston.jpg, from Wikipedia, the free encyclopedia";
            (page as PdfNewPage).Annotations.Add(annotation2);
            y = y + size.Height + 2;

            location = new PointF(0, y);
            label = "Picture of Science";
            data = File.ReadAllBytes(@"..\..\..\..\..\..\..\Data\Wikipedia_Science.png");
            size = font2.MeasureString(label);
            bounds = new RectangleF(location, size);
            page.Canvas.DrawString(label, font2, PdfBrushes.DarkOrange, bounds);
            bounds = new RectangleF(bounds.Right + 3, bounds.Top, font2.Height / 2, font2.Height);
            PdfAttachmentAnnotation annotation3
                = new PdfAttachmentAnnotation(bounds, "Wikipedia_Science.png", data);
            annotation3.Color = Color.SaddleBrown;
            annotation3.Flags = PdfAnnotationFlags.Locked;
            annotation3.Icon = PdfAttachmentIcon.Tag;
            annotation3.Text = "Wikipedia_Science.png, from Wikipedia, the free encyclopedia";
            (page as PdfNewPage).Annotations.Add(annotation3);
            y = y + size.Height + 2;

            location = new PointF(0, y);
            label = "Hawaii Killer Font";
            data = File.ReadAllBytes(@"..\..\..\..\..\..\..\Data\Hawaii_Killer.ttf");
            size = font2.MeasureString(label);
            bounds = new RectangleF(location, size);
            page.Canvas.DrawString(label, font2, PdfBrushes.DarkOrange, bounds);
            bounds = new RectangleF(bounds.Right + 3, bounds.Top, font2.Height / 2, font2.Height);
            PdfAttachmentAnnotation annotation4
                = new PdfAttachmentAnnotation(bounds, "Hawaii_Killer.ttf", data);
            annotation4.Color = Color.CadetBlue;
            annotation4.Flags = PdfAnnotationFlags.NoRotate;
            annotation4.Icon = PdfAttachmentIcon.Paperclip;
            annotation4.Text = "Hawaii Killer Font, from http://www.1001freefonts.com";
            (page as PdfNewPage).Annotations.Add(annotation4);
            y = y + size.Height + 2;

            //Save pdf file.
            doc.SaveToFile("Attachment.pdf");
            doc.Close();

            //Launching the Pdf file.
            PDFDocumentViewer("Attachment.pdf");
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
