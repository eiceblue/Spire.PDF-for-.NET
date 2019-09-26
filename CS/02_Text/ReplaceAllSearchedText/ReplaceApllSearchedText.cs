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
using Spire.Pdf.General.Find;
namespace ReplaceAllSearchedText
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

            // Searches "Spire.PDF for .NET" by ignoring case
            PdfTextFindCollection collection = page.FindText("Spire.PDF for .NET",TextFindParameter.IgnoreCase);

            String newText = "E-iceblue Spire.PDF";
         
            // Creates a brush
            PdfBrush brush = new PdfSolidBrush(Color.DarkBlue);

            // Defines a font
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f, FontStyle.Regular));

            RectangleF rec; 
            foreach (PdfTextFind find in collection.Finds)
            {
                // Gets the bound of the found text in page
                 rec = find.Bounds;

                 page.Canvas.DrawRectangle(PdfBrushes.White, rec);
                 // Draws new text as defined font and color
                 page.Canvas.DrawString(newText, font, brush, rec);

                // This method can directly replace old text with newText,but it just can set the background color, can not set font/forecolor
                // find.ApplyRecoverString(newText, Color.Gray);
            }

            String result = "ReplaceAllSearchedText_out.pdf";
  
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
