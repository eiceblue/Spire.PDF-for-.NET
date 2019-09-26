using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace AddTransparentText
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PdfDocument doc = new PdfDocument();

            //Create one A4 page
            PdfPageBase page = doc.Pages.Add(PdfPageSize.A4,new PdfMargins(0));

            page.Canvas.Save();
            //Set alpha value
            float alpha = 0.25f;
            page.Canvas.SetTransparency(alpha, alpha, PdfBlendMode.Normal);

            //Create rectangle with specified dimensions      
            RectangleF rect = new RectangleF(50, 50, 450,page.Size.Height);

            //Create transparent text
            String text = "Spire.PDF for .NET,a professional PDF library applied to"+
                " creating, writing, editing, handling and reading PDF files"+
                " without any external dependencies within .NET"+
                "( C#, VB.NET, ASP.NET, .NET Core) application.";
            text += "\n\n\n\n\n";
            text += "Spire.PDF for Java,a PDF Java API that enables"+
                "developers to read, write, convert and print PDF documents"+
                "in Java applications without using Adobe Acrobat.";

            //Create brush from color channel
            PdfSolidBrush brush = new PdfSolidBrush(Color.FromArgb(30, 0, 255, 0));
                
            //Draw the text
            page.Canvas.DrawString(text,
                                   new PdfFont(PdfFontFamily.Helvetica, 14f),
                                   brush,
                                   rect);
            page.Canvas.Restore();

            String result = "AddTransparentText_out.pdf";

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
