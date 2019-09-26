using Spire.Pdf;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DrawTextWithGradient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a pdf document
            PdfDocument doc = new PdfDocument();

            //Add a new page
            PdfPageBase page = doc.Pages.Add();

            //Create a rectangle
            Rectangle rect = new Rectangle(new Point(0, 0), new Size(300, 100));

            //Create a brush with gradient
            PdfLinearGradientBrush brush = new PdfLinearGradientBrush(rect, Color.Red, Color.Blue, PdfLinearGradientMode.Horizontal);

            //Create a true type font with size 20f, underline style
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 20, FontStyle.Underline));
           
            //Draw text
            page.Canvas.DrawString("Welcome to E-iceblue!", font, brush, new Point(0, 100));

            String result="DrawWithGradient-result.pdf";
            //Save to file
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
