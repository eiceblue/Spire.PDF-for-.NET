using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.AutomaticFields;
using Spire.Pdf.Graphics;
using Spire.Pdf.Tables;

namespace AutomaticField
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Create a new PdfDocument object
            PdfDocument doc = new PdfDocument();

            // Set the author for the document
            doc.DocumentInformation.Author = "Spire.Pdf";

            // Set the margin for the pages
            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
            PdfMargins margin = new PdfMargins();
            margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Bottom = margin.Top;
            margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Right = margin.Left;

            // Create a section in the document
            PdfSection section = doc.Sections.Add();
            section.PageSettings.Size = PdfPageSize.A4;
            section.PageSettings.Margins = margin;

            // Create a page in the section
            PdfPageBase page = section.Pages.Add();

            // Draw automatic fields on the page
            DrawAutomaticField(page);

            // Save the document to a file named "AutomaticField.pdf"
            doc.SaveToFile("AutomaticField.pdf");
            doc.Close();

            //Launch the Pdf file
            PDFDocumentViewer("AutomaticField.pdf");
        }

        // Method to draw automatic fields on a PDF page
        private void DrawAutomaticField(PdfPageBase page)
        {
            float y = 20;

            // Draw the title for the field list
            PdfBrush brush1 = PdfBrushes.CadetBlue;
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 16f, FontStyle.Bold));
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
             PdfTrueTypeFont font1 = new PdfTrueTypeFont("Arial", 16f, PdfFontStyle.Bold, true);
            */
            PdfStringFormat format1 = new PdfStringFormat(PdfTextAlignment.Center);
            page.Canvas.DrawString("Automatic Field List", font1, brush1,
                page.Canvas.ClientSize.Width / 2, y, format1);
            y = y + font1.MeasureString("Automatic Field List", format1).Height;
            y = y + 15;

            // Define an array of field names
            String[] fieldList = new String[]
            {
        "DateTimeField",
        "CreationDateField",
        "DocumentAuthorField",
        "SectionNumberField",
        "SectionPageNumberField",
        "SectionPageCountField",
        "PageNumberField",
        "PageCountField",
        "DestinationPageNumberField",
        "CompositeField"
            };

            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f));
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
             PdfTrueTypeFont font = new PdfTrueTypeFont("Arial", 12f, PdfFontStyle.Italic, true);
            */
            PdfStringFormat fieldNameFormat = new PdfStringFormat();
            fieldNameFormat.MeasureTrailingSpaces = true;

            // Iterate through each field name in the list
            foreach (String fieldName in fieldList)
            {
                // Draw the field name
                String text = String.Format("{0}: ", fieldName);
                page.Canvas.DrawString(text, font, PdfBrushes.DodgerBlue, 0, y);
                float x = font.MeasureString(text, fieldNameFormat).Width;
                RectangleF bounds = new RectangleF(x, y, 200, font.Height);
                DrawAutomaticField(fieldName, page, bounds);
                y = y + font.Height + 8;
            }
        }

        // Method to draw a specific automatic field on a PDF page
        void DrawAutomaticField(String fieldName, PdfPageBase page, RectangleF bounds)
        {
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f, FontStyle.Italic));
            PdfBrush brush = PdfBrushes.OrangeRed;
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);

            if ("DateTimeField" == fieldName)
            {
                // Create and draw a DateTime field
                PdfDateTimeField field = new PdfDateTimeField();
                field.Font = font;
                field.Brush = brush;
                field.StringFormat = format;
                field.Bounds = bounds;
                field.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                field.Draw(page.Canvas);
            }

            // Repeat the above code block for other field names
            if ("CreationDateField" == fieldName)
            {
                PdfCreationDateField field = new PdfCreationDateField();
                field.Font = font;
                field.Brush = brush;
                field.StringFormat = format;
                field.Bounds = bounds;
                field.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                field.Draw(page.Canvas);
            }

            if ("DocumentAuthorField" == fieldName)
            {
                PdfDocumentAuthorField field = new PdfDocumentAuthorField();
                field.Font = font;
                field.Brush = brush;
                field.StringFormat = format;
                field.Bounds = bounds;
                field.Draw(page.Canvas);
            }


            if ("SectionNumberField" == fieldName)
            {
                PdfSectionNumberField field = new PdfSectionNumberField();
                field.Font = font;
                field.Brush = brush;
                field.StringFormat = format;
                field.Bounds = bounds;
                field.Draw(page.Canvas);
            }

            if ("SectionPageNumberField" == fieldName)
            {
                PdfSectionPageNumberField field = new PdfSectionPageNumberField();
                field.Font = font;
                field.Brush = brush;
                field.StringFormat = format;
                field.Bounds = bounds;
                field.Draw(page.Canvas);
            }

            if ("SectionPageCountField" == fieldName)
            {
                PdfSectionPageCountField field = new PdfSectionPageCountField();
                field.Font = font;
                field.Brush = brush;
                field.StringFormat = format;
                field.Bounds = bounds;
                field.Draw(page.Canvas);
            }

            if ("PageNumberField" == fieldName)
            {
                PdfPageNumberField field = new PdfPageNumberField();
                field.Font = font;
                field.Brush = brush;
                field.StringFormat = format;
                field.Bounds = bounds;
                field.Draw(page.Canvas);
            }

            if ("PageCountField" == fieldName)
            {
                PdfPageCountField field = new PdfPageCountField();
                field.Font = font;
                field.Brush = brush;
                field.StringFormat = format;
                field.Bounds = bounds;
                field.Draw(page.Canvas);
            }

            if ("DestinationPageNumberField" == fieldName)
            {
                PdfDestinationPageNumberField field = new PdfDestinationPageNumberField();
                field.Font = font;
                field.Brush = brush;
                field.StringFormat = format;
                field.Bounds = bounds;
                field.Page = page as PdfNewPage;
                field.Draw(page.Canvas);
            }

            if ("CompositeField" == fieldName)
            {
                PdfSectionPageNumberField field1 = new PdfSectionPageNumberField();
                field1.NumberStyle = PdfNumberStyle.LowerRoman;
                PdfSectionPageCountField field2 = new PdfSectionPageCountField();
                PdfCompositeField fields = new PdfCompositeField();
                fields.Font = font;
                fields.Brush = brush;
                fields.StringFormat = format;
                fields.Bounds = bounds;
                fields.AutomaticFields = new PdfAutomaticField[] { field1, field2 };
                fields.Text = "section page {0} of {1}";
                fields.Draw(page.Canvas);
            }
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
