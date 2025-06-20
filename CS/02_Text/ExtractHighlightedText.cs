using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Actions;
using Spire.Pdf.Annotations;
using System.Text;
using System.IO;
using Spire.Pdf.Texts;

namespace ExtractHighlightedText
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a pdf instance
            PdfDocument doc = new PdfDocument();

            //Load a pdf file
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\ExtractHighlightedText.pdf");

            PdfPageBase page = doc.Pages[0];
            PdfTextMarkupAnnotationWidget textMarkupAnnotation;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Extracted hightlighted text:");
            PdfTextExtractor pdfTextExtractor = new PdfTextExtractor(page);
            //Get PdfTextMarkupAnnotationWidget objects
            for (int i = 0; i < page.Annotations.Count; i++)
            {
                if (page.Annotations[i] is PdfTextMarkupAnnotationWidget)
                {
                    textMarkupAnnotation = page.Annotations[i] as PdfTextMarkupAnnotationWidget;
                    //Get the highlighted text
                    PdfTextExtractOptions pdfTextExtractOptions = new PdfTextExtractOptions();
                    pdfTextExtractOptions.ExtractArea = textMarkupAnnotation.Bounds;
                    stringBuilder.AppendLine(pdfTextExtractor.ExtractText(pdfTextExtractOptions));

                    //Get the highlighted color
                    Color color = textMarkupAnnotation.TextMarkupColor;
                }
            }
            String result="ExtractHighlightedText.txt";
            File.WriteAllText(result, stringBuilder.ToString());
            DocumentViewer(result);
        }
        private void DocumentViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }

    }
}
