using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace SetLineBreak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a pdf document
            PdfDocument doc = new PdfDocument();

            // Create one A4 page
            PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, new PdfMargins(40));

            // Create brush from color channel
            PdfSolidBrush brush = new PdfSolidBrush(Color.Black);

            // Create text
            String text = "Spire.PDF for .NET" +
                "\n" +
                "A professional PDF library applied to" +
                " creating, writing, editing, handling and reading PDF files" +
                " without any external dependencies within .NET" +
                "( C#, VB.NET, ASP.NET, .NET Core) application.";

            text += "\n\rSpire.PDF for Java" +
                 "\n" +
                "A PDF Java API that enables developers to read, " +
                "write, convert and print PDF documents" +
                "in Java applications without using Adobe Acrobat.";
            text += "\n\r";
            text += "Welcome to evaluate Spire.PDF!";

            // Create rectangle with specified dimensions  
            RectangleF rect = new RectangleF(50, 50, page.Size.Width - 150, page.Size.Height);

            // Draw the text
            page.Canvas.DrawString(text,
                                   new PdfFont(PdfFontFamily.Helvetica, 13f),
                                   brush,
                                   rect);

            String result = "SetLineBreak_out.pdf";

            // Save the document
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
