using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text;
using Spire.Pdf;
using Spire.Pdf.Interactive.Annotations;
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
            PdfTextMarkupAnnotation textMarkupAnnotation;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Extracted hightlighted text:");
            //Get PdfTextMarkupAnnotationWidget objects
            for (int i = 0; i < page.Annotations.Count; i++)
            {
                if (PdfAnnotationCollection.Create(page)[i] is PdfTextMarkupAnnotation)
                {
                    textMarkupAnnotation = PdfAnnotationCollection.Create(page)[i] as PdfTextMarkupAnnotation;
                    //Get the highlighted text
                    PdfTextExtractor textExtractor = new PdfTextExtractor(page);
                    PdfTextExtractOptions option = new PdfTextExtractOptions();
                    option.ExtractArea = textMarkupAnnotation.Rectangle;
                    stringBuilder.AppendLine(textExtractor.ExtractText(option));

                    //Get the highlighted color
                    Color color = textMarkupAnnotation.Color;
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
