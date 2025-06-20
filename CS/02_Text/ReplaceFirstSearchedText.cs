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

namespace ReplaceFirstSearchedText
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
            finder.Options.Parameter = Spire.Pdf.Texts.TextFindParameter.IgnoreCase;

            // Find occurrences of the specified text within the first page
            List<PdfTextFragment> finds = finder.Find("Spire.PDF for .NET");

            String newText = "Spire.PDF API";

            // Gets the first found object
            PdfTextFragment find = finds[0];

            // Creates a brush
            PdfBrush brush = new PdfSolidBrush(Color.DarkBlue);

            // Defines a font
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 15f, FontStyle.Bold));

            // Gets the bound of the first found text in page
            RectangleF rec = find.Bounds[0];

            page.Canvas.DrawRectangle(PdfBrushes.White, rec);

            // Draws new text as defined font and color
            page.Canvas.DrawString(newText, font, brush, rec);

            // This method can directly replace old text with newText,but it just can set the background color, can not set font/forecolor
            // find.ApplyRecoverString(newText, Color.Gray);

            String result = "ReplaceFirstSearchedText_out.pdf";

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
