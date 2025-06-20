using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Fields;
using Spire.Pdf.Annotations;
using Spire.Pdf.Graphics;
using Spire.Pdf.Actions;
using Spire.Pdf.General;
using Spire.Pdf.Texts;

namespace SearchWithRegularExpression
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String input = @"..\..\..\..\..\..\Data\SearchReplaceTemplate.pdf";
            PdfDocument doc = new PdfDocument();

            // Read a pdf file
            doc.LoadFromFile(input);

            // Get the first page of pdf file
            PdfPageBase page = doc.Pages[0];

            // Create a PdfTextFinder object for searching text within the first page
            PdfTextFinder finder = new PdfTextFinder(page);
            finder.Options.Parameter = Spire.Pdf.Texts.TextFindParameter.Regex;

            // Find occurrences of the specified text within the first page
            List<PdfTextFragment> finds = finder.Find("\\d{4}");

            String newText = "New Year";

            // Creates a brush
            PdfBrush brush = new PdfSolidBrush(Color.DarkBlue);

            // Defines a font
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 7f, FontStyle.Bold));

            // Defines text horizontal/vertical center format
            PdfStringFormat centerAlign = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);

            RectangleF rec;

            // Iterate through each found text fragment
            foreach (PdfTextFragment find in finds)
            {
                // Gets the bound of the found text in page
                rec = find.Bounds[0];

                page.Canvas.DrawRectangle(PdfBrushes.GreenYellow, rec);
                // Draws new text as defined font and color
                page.Canvas.DrawString(newText, font, brush, rec, centerAlign);

                // This method can directly replace old text with newText,but it just can set the background color, can not set font/forecolor
                // find.ApplyRecoverString(newText, Color.Gray);
            }

            String result = "ReplaceTextWithRegularExpression_out.pdf";

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
