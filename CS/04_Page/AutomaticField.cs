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
            //Create a pdf document.
            PdfDocument doc = new PdfDocument();
            doc.DocumentInformation.Author = "Spire.Pdf";

            //margin
            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
            PdfMargins margin = new PdfMargins();
            margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Bottom = margin.Top;
            margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Right = margin.Left;

            for (int i = 1; i < 4; i++)
            {
                //create section
                PdfSection section = doc.Sections.Add();
                section.PageSettings.Size = PdfPageSize.A4;
                section.PageSettings.Margins = margin;

                for (int j = 0; j < i; j++)
                {
                    // Create one page
                    PdfPageBase page = section.Pages.Add();
                    DrawAutomaticField(page);
                }
            }

            //Save pdf file.
            doc.SaveToFile("AutomaticField.pdf");
            doc.Close();

            //Launching the Pdf file.
            PDFDocumentViewer("AutomaticField.pdf");
        }

        private void DrawAutomaticField(PdfPageBase page)
        {
            float y = 0;

            //title
            PdfBrush brush1 = PdfBrushes.CadetBlue;
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 16f, FontStyle.Bold));
            PdfStringFormat format1 = new PdfStringFormat(PdfTextAlignment.Center);
            page.Canvas.DrawString("Automatic Field List", font1, brush1,
                page.Canvas.ClientSize.Width / 2, y, format1);
            y = y + font1.MeasureString("Automatic Field List", format1).Height;
            y = y + 5;

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
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 9f));
            PdfStringFormat fieldNameFormat = new PdfStringFormat();
            fieldNameFormat.MeasureTrailingSpaces = true;
            foreach (String fieldName in fieldList)
            {
                //draw field name
                String text = String.Format("{0}: ", fieldName);
                page.Canvas.DrawString(text, font, PdfBrushes.DodgerBlue, 0, y);
                float x = font.MeasureString(text, fieldNameFormat).Width;
                RectangleF bounds = new RectangleF(x, y, 200, font.Height);
                DrawAutomaticField(fieldName, page, bounds);
                y = y + font.Height + 3;
            }
        }

        void DrawAutomaticField(String fieldName, PdfPageBase page, RectangleF bounds)
        {
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 9f, FontStyle.Italic));
            PdfBrush brush = PdfBrushes.OrangeRed;
            PdfStringFormat format
                = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);

            if ("DateTimeField" == fieldName)
            {
                PdfDateTimeField field = new PdfDateTimeField();
                field.Font = font;
                field.Brush = brush;
                field.StringFormat = format;
                field.Bounds = bounds;
                field.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                field.Draw(page.Canvas);
            }

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
