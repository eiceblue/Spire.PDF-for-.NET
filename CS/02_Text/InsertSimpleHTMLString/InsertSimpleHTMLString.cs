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

namespace InsertSimpleHTMLString
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
            PdfNewPage page = doc.Pages.Add() as PdfNewPage;

            //HTML string
            string htmlText = "This demo shows how we can insert <u><i>HTML styled text</i></u> to PDF using "
                             + "<font color='#FF4500'>Spire.PDF for .NET</font>. ";

            //Render HTML text
            PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 25);
            PdfBrush brush = PdfBrushes.Black;
            PdfHTMLTextElement richTextElement = new PdfHTMLTextElement(htmlText, font, brush);
            richTextElement.TextAlign = TextAlign.Left;

            //Format Layout
            PdfMetafileLayoutFormat format = new PdfMetafileLayoutFormat();
            format.Layout = PdfLayoutType.Paginate;
            format.Break = PdfLayoutBreakType.FitPage;

            //Draw htmlString  
            richTextElement.Draw(page, new RectangleF(0, 20, page.GetClientSize().Width, page.GetClientSize().Height), format);
   

            String result = "InsertSimpleHTMLString-result.pdf";
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
