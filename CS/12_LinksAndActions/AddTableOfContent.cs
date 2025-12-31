using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using System.IO;
using Spire.Pdf.General;
using Spire.Pdf.Annotations;
using Spire.Pdf.Actions;

namespace AddTableOfContent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Specify the path to the input PDF file.
            string input = "..\\..\\..\\..\\..\\..\\Data\\AddTableOfContent.pdf";

            // Open a PDF document.
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(input);

            // Get the total number of pages in the document.
            int pageCount = doc.Pages.Count;

            // Insert a blank page at the beginning of the PDF document.
            PdfPageBase tocPage = doc.Pages.Insert(0);

            // Set the title for the table of contents.
            string title = "Table Of Contents";
            PdfTrueTypeFont titleFont = new PdfTrueTypeFont(new Font("Arial", 20, FontStyle.Bold));
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
             PdfTrueTypeFont titleFont = new PdfTrueTypeFont("Arial", 20, PdfFontStyle.Bold, true);
            */

            PdfStringFormat centerAlignment = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            PointF location = new PointF(tocPage.Canvas.ClientSize.Width / 2, titleFont.MeasureString(title).Height);
            tocPage.Canvas.DrawString(title, titleFont, PdfBrushes.CornflowerBlue, location, centerAlignment);

            // Draw the table of contents entries.
            PdfTrueTypeFont titlesFont = new PdfTrueTypeFont(new Font("Arial", 14));
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
              PdfTrueTypeFont titlesFont = new PdfTrueTypeFont("Arial", 14, PdfFontStyle.Regular, true);
            */
            String[] titles = new String[pageCount];
            for (int i = 0; i < titles.Length; i++)
            {
                titles[i] = string.Format("This is page {0}", i + 1);
            }
            float y = titleFont.MeasureString(title).Height + 10;
            float x = 0;

            for (int i = 1; i <= pageCount; i++)
            {
                string text = titles[i - 1];
                SizeF titleSize = titlesFont.MeasureString(text);

                // Get the page that the table of contents entry will navigate to.
                PdfPageBase navigatedPage = doc.Pages[i];

                string pageNumText = (i + 1).ToString();
                SizeF pageNumTextSize = titlesFont.MeasureString(pageNumText);

                // Draw the entry text.
                tocPage.Canvas.DrawString(text, titlesFont, PdfBrushes.CadetBlue, 0, y);

                float dotLocation = titleSize.Width + 2 + x;
                float pageNumlocation = tocPage.Canvas.ClientSize.Width - pageNumTextSize.Width;

                // Draw dots between the entry text and page number.
                for (float j = dotLocation; j < pageNumlocation; j++)
                {
                    if (dotLocation >= pageNumlocation)
                    {
                        break;
                    }
                    tocPage.Canvas.DrawString(".", titlesFont, PdfBrushes.Gray, dotLocation, y);
                    dotLocation += 3;
                }

                // Draw the page number.
                tocPage.Canvas.DrawString(pageNumText, titlesFont, PdfBrushes.CadetBlue, pageNumlocation, y);

                // Add the table of contents action.
                location = new PointF(0, y);
                RectangleF titleBounds = new RectangleF(location, new SizeF(tocPage.Canvas.ClientSize.Width, titleSize.Height));
                PdfDestination Dest = new PdfDestination(navigatedPage, new PointF(-doc.PageSettings.Margins.Top, -doc.PageSettings.Margins.Left));
                PdfActionAnnotation action = new PdfActionAnnotation(titleBounds, new PdfGoToAction(Dest));
                action.Border = new PdfAnnotationBorder(0);
                (tocPage as PdfNewPage).Annotations.Add(action);
                y += titleSize.Height + 10;
            }

            string output = "AddTableOfContent.pdf";

            // Save the PDF document.
            doc.SaveToFile(output);

            //Launching the Pdf file
            PDFDocumentViewer(output);
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
