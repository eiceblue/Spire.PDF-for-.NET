using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Interchange.TaggedPdf;

namespace CreateTaggedPDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new instance of PdfDocument
            PdfDocument doc = new PdfDocument();

            // Add a new page to the document
            doc.Pages.Add();

            // Set the tab order for the first page in the document
            doc.Pages[0].SetTabOrder(TabOrder.Structure);

            // Create a PdfTaggedContent object associated with the document
            PdfTaggedContent taggedContent = new PdfTaggedContent(doc);
            taggedContent.SetLanguage("en-US");
            taggedContent.SetTitle("test");

            // Set PDF/UA1 identification for accessibility
            taggedContent.SetPdfUA1Identification();

            // Set the font and brush for text rendering
            PdfTrueTypeFont font = new PdfTrueTypeFont(new System.Drawing.Font("Times New Roman", 10), true);
            PdfSolidBrush brush = new PdfSolidBrush(Color.Black);

            // Append structure elements to the document's structure tree
            PdfStructureElement article = taggedContent.StructureTreeRoot.AppendChildElement(PdfStandardStructTypes.Document);
            PdfStructureElement paragraph1 = article.AppendChildElement(PdfStandardStructTypes.Paragraph);
            PdfStructureElement span1 = paragraph1.AppendChildElement(PdfStandardStructTypes.Span);
            span1.BeginMarkedContent(doc.Pages[0]);

            // Set the format for text alignment
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Justify);

            // Draw text on the page canvas within a specified rectangle
            doc.Pages[0].Canvas.DrawString("Spire.PDF for .NET is a professional PDF API applied to creating, writing, editing, handling, and reading PDF files.",
                font, brush, new Rectangle(40, 0, 480, 80), format);
            span1.EndMarkedContent(doc.Pages[0]);

            // Append more structure elements and draw additional text
            PdfStructureElement paragraph2 = article.AppendChildElement(PdfStandardStructTypes.Paragraph);
            paragraph2.BeginMarkedContent(doc.Pages[0]);
            doc.Pages[0].Canvas.DrawString("Spire.PDF for .NET can be applied to easily convert Text, Image, SVG, HTML to PDF and convert PDF to Excel with C#/VB.NET in high quality.",
                font, brush, new Rectangle(40, 80, 480, 60), format);
            paragraph2.EndMarkedContent(doc.Pages[0]);

            // Append a figure element and draw an image
            PdfStructureElement figure1 = article.AppendChildElement(PdfStandardStructTypes.Figure);

            // Set alternate text for the image
            figure1.Alt = "replacement text1";
            figure1.BeginMarkedContent(doc.Pages[0], null);
            PdfImage image = PdfImage.FromFile(@"..\..\..\..\..\..\Data\E-logo.png");
            doc.Pages[0].Canvas.DrawImage(image, new PointF(40, 200), new SizeF(100, 100));
            figure1.EndMarkedContent(doc.Pages[0]);

            // Append another figure element and draw a rectangle
            PdfStructureElement figure2 = article.AppendChildElement(PdfStandardStructTypes.Figure);

            // Set alternate text for the rectangle
            figure2.Alt = "replacement text2";
            figure2.BeginMarkedContent(doc.Pages[0], null);
            doc.Pages[0].Canvas.DrawRectangle(PdfPens.Black, new Rectangle(300, 200, 100, 100));
            figure2.EndMarkedContent(doc.Pages[0]);

            // Save the document to a file
            String result = "CreateTaggedFile_result.pdf";
            doc.SaveToFile(result);

            // Close the document, releasing resources
            doc.Close();

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
