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

namespace AddBorderForText
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

            //Load from file
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\SampleB_1.pdf");

            //Get the first page
            PdfPageBase page = doc.Pages[0];

            string text = "Hello, World!";

            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Times New Roman", 11, FontStyle.Regular),true);
            SizeF size = font.MeasureString(text);            
            PdfSolidBrush brush = new PdfSolidBrush(Color.Black);
            int x = 60;
            int y = 300;

            //Draw the text on page
            page.Canvas.DrawString(text,
                                   font,
                                   new PdfSolidBrush(Color.Black),
                                   x, y);

            //Draw border for text          
            page.Canvas.DrawRectangle(new PdfPen(brush, 0.5f),new Rectangle(x, y, (int)size.Width, (int)size.Height));

            String result = "AddBorderForText-result.pdf";
            //save to file
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
