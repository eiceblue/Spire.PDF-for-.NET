using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Interchange.TaggedPdf;
using Spire.Pdf.Tables;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CreateStructureTaggedPDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Create a PdfDocument
            PdfDocument doc = new PdfDocument();

            // Add a new page 
            PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, new PdfMargins(20));
            page.SetTabOrder(TabOrder.Structure);

            // Create a PdfTaggedContent
            PdfTaggedContent taggedContent = new PdfTaggedContent(doc);
            taggedContent.SetLanguage("en-US");
            taggedContent.SetTitle("test");
            taggedContent.SetPdfUA1Identification();

            // Create a true type font with size 14f, underline style
            PdfTrueTypeFont font = new PdfTrueTypeFont(new System.Drawing.Font("Times New Roman", 14), true);
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
             PdfTrueTypeFont font = new PdfTrueTypeFont("Times New Roman", 14,PdfFontStyle.Regular,true);
            */

            // Create a brush with black
            PdfSolidBrush brush = new PdfSolidBrush(Color.Black);

            // Create a pdf structure child element
            PdfStructureElement document = taggedContent.StructureTreeRoot.AppendChildElement(PdfStandardStructTypes.Document);
            PdfStructureElement heading1 = document.AppendChildElement(PdfStandardStructTypes.HeadingLevel1);
            heading1.BeginMarkedContent(page);
            string headingText = "What is a Tagged PDF?";

            // Draw text
            page.Canvas.DrawString(headingText, font, brush, new PointF(0, 50));
            heading1.EndMarkedContent(page);

            // Create a pdf structure child element
            PdfStructureElement paragraph = document.AppendChildElement(PdfStandardStructTypes.Paragraph);
            paragraph.BeginMarkedContent(page);
            string paragraphText = "“Tagged PDF” doesn’t seem like a life-changing term. But for some, it is. For people who are " +
                "blind or have low vision and use assistive technology (such as screen readers and connected Braille displays) to " +
                "access information, an untagged PDF means they are missing out on information contained in the document because assistive " +
                "technology cannot “read” untagged PDFs.  Digital accessibility has opened up so many avenues to information that were once " +
                "closed to people with visual disabilities, but PDFs often get left out of the equation.";

            // Create a Rectangle
            RectangleF rect = new RectangleF(0, 80, page.Canvas.ClientSize.Width, page.Canvas.ClientSize.Height);

            // Draw text
            page.Canvas.DrawString(paragraphText, font, brush, rect);
            paragraph.EndMarkedContent(page);

            // Create a pdf structure child element
            PdfStructureElement figure = document.AppendChildElement(PdfStandardStructTypes.Figure);
            figure.BeginMarkedContent(page);
            PdfImage image = PdfImage.FromFile(@"..\..\..\..\..\..\Data\E-logo.png");
            page.Canvas.DrawImage(image, new PointF(350, 200));
            figure.EndMarkedContent(page);

            // Create a pdf structure child element
            PdfStructureElement table = document.AppendChildElement(PdfStandardStructTypes.Table);

            // Create a table
            PdfTable pdfTable = new PdfTable();
            pdfTable.Style.DefaultStyle.Font = font;
            System.Data.DataTable dataTable = new System.Data.DataTable();

            // Add columns
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Age");
            dataTable.Columns.Add("Sex");

            // Add rows
            dataTable.Rows.Add(new string[] { "John", "22", "Male" });
            dataTable.Rows.Add(new string[] { "Katty", "25", "Female" });
            pdfTable.DataSource = dataTable;
            pdfTable.Style.ShowHeader = true;
            pdfTable.StructureElement = table;

            // Draw the table
            pdfTable.Draw(page.Canvas, new PointF(0, 300), 300);

            // Save the file
            doc.SaveToFile("structuredTagged.pdf");
            doc.Dispose();

            //Launch the pdf file
            PDFDocumentViewer("structuredTagged.pdf");
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
