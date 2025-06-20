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
            // Create a pdf document
            PdfDocument doc = new PdfDocument();

            // Load the PDF document from a file
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\Attachment.pdf");

            // Get the first page of the PDF document
            PdfPageBase page = doc.Pages[0];

            // Set the initial y-coordinate for positioning elements on the page
            float y = 320;

            // Add a title to the page
            PdfBrush brush1 = PdfBrushes.CornflowerBlue;
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 18f, FontStyle.Bold));
            PdfStringFormat format1 = new PdfStringFormat(PdfTextAlignment.Center);
            page.Canvas.DrawString("Attachment", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1);

            // Update the y-coordinate
            y = y + font1.MeasureString("Attachment", format1).Height;
            y = y + 10;

            // Add an attachment to the PDF document
            PdfAttachment attachment = new PdfAttachment("Header.png");
            attachment.Data = File.ReadAllBytes(@"..\..\..\..\..\..\Data\Header.png");
            attachment.Description = "Page header picture of demo.";
            attachment.MimeType = "image/png";
            doc.Attachments.Add(attachment);

            // Add another attachment to the PDF document
            attachment = new PdfAttachment("Footer.png");
            attachment.Data = File.ReadAllBytes(@"..\..\..\..\..\..\Data\Footer.png");
            attachment.Description = "Page footer picture of demo.";
            attachment.MimeType = "image/png";
            doc.Attachments.Add(attachment);

            // Set the initial x-coordinate and font for the labels
            float x = 50;
            PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 14f, FontStyle.Bold));

            // Add a label and annotation for the Sales Report Chart attachment
            PointF location = new PointF(x, y);
            String label = "Sales Report Chart";
            byte[] data = File.ReadAllBytes(@"..\..\..\..\..\..\Data\SalesReportChart.png");
            SizeF size = font2.MeasureString(label);
            RectangleF bounds = new RectangleF(location, size);
            page.Canvas.DrawString(label, font2, PdfBrushes.DarkOrange, bounds);
            bounds = new RectangleF(bounds.Right + 3, bounds.Top, font2.Height / 2, font2.Height);

            // Create a PdfAttachmentAnnotation for the Sales Report Chart attachment
            PdfAttachmentAnnotation annotation1 = new PdfAttachmentAnnotation(bounds, "SalesReportChart.png", data);
            annotation1.Color = Color.Teal;
            annotation1.Flags = PdfAnnotationFlags.ReadOnly;
            annotation1.Icon = PdfAttachmentIcon.Graph;
            annotation1.Text = "Sales Report Chart";

            // Add the annotation to the page
            page.Annotations.Add(annotation1);

            // Update the y-coordinate
            y = y + size.Height + 3;

            // Repeat the above steps for the remaining attachments and annotations
            location = new PointF(x, y);
            label = "Science Personification Boston";
            data = File.ReadAllBytes(@"..\..\..\..\..\..\Data\SciencePersonificationBoston.jpg");
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
            page.Annotations.Add(annotation2);
            y = y + size.Height + 2;

            location = new PointF(x, y);
            label = "Picture of Science";
            data = File.ReadAllBytes(@"..\..\..\..\..\..\Data\Wikipedia_Science.png");
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
            page.Annotations.Add(annotation3);
            y = y + size.Height + 2;

            location = new PointF(x, y);
            label = "PT_Serif-Caption-Web-Regular Font";
            data = File.ReadAllBytes(@"..\..\..\..\..\..\Data\PT_Serif-Caption-Web-Regular.ttf");
            size = font2.MeasureString(label);
            bounds = new RectangleF(location, size);
            page.Canvas.DrawString(label, font2, PdfBrushes.DarkOrange, bounds);
            bounds = new RectangleF(bounds.Right + 3, bounds.Top, font2.Height / 2, font2.Height);
            PdfAttachmentAnnotation annotation4
                = new PdfAttachmentAnnotation(bounds, "PT_Serif-Caption-Web-Regular.ttf", data);
            annotation4.Color = Color.CadetBlue;
            annotation4.Flags = PdfAnnotationFlags.NoRotate;
            annotation4.Icon = PdfAttachmentIcon.Paperclip;
            annotation4.Text = "PT_Serif-Caption-Web-Regular, from https://company.paratype.com";
            page.Annotations.Add(annotation4);
            y = y + size.Height + 2;

            // Save the PDF document
            doc.SaveToFile("Attachment.pdf");

            // Close the PDF document
            doc.Close();


            //Launch the Pdf file
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
