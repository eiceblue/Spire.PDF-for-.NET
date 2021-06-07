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

            // Create PdfTextFindCollection object to find all the phrases matching the regular expression
            PdfTextFindCollection collection = page.FindText("\\d{4}",TextFindParameter.Regex);

            String newText = "New Year";
         
            // Creates a brush
            PdfBrush brush = new PdfSolidBrush(Color.DarkBlue);

            // Defines a font
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 7f, FontStyle.Bold));

            // Defines text horizontal/vertical center format
            PdfStringFormat centerAlign = new PdfStringFormat(PdfTextAlignment.Center,PdfVerticalAlignment.Middle);

            RectangleF rec; 
            foreach (PdfTextFind find in collection.Finds)
            {
                // Gets the bound of the found text in page
                 rec = find.Bounds;

                 page.Canvas.DrawRectangle(PdfBrushes.GreenYellow, rec);
                 // Draws new text as defined font and color
                 page.Canvas.DrawString(newText, font, brush, rec,centerAlign);

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
