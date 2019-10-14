using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Actions;
using Spire.Pdf.Annotations;
using System.Text;
using System.IO;

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
            //Create a pdf document
            PdfDocument doc = new PdfDocument();

            //Load a pdf file
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\ExtractHighlightedText.pdf");

            PdfPageBase page = doc.Pages[0];
            PdfTextMarkupAnnotationWidget textMarkupAnnotation;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Extracted hightlighted text:");
            //Get PdfTextMarkupAnnotationWidget objects
            for (int i = 0; i < page.AnnotationsWidget.Count; i++)
            {
                if (page.AnnotationsWidget[i] is PdfTextMarkupAnnotationWidget)
                {
                    textMarkupAnnotation = page.AnnotationsWidget[i] as PdfTextMarkupAnnotationWidget;
                    //Get the highlighted text
                    stringBuilder.AppendLine(page.ExtractText(textMarkupAnnotation.Bounds));

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
