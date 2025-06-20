using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Texts;
using System.IO;
namespace ExtractTextFromSpecificArea
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

         private void button1_Click(object sender, EventArgs e)
        {
            // Specifying the path to the source PDF file
            string input = @"..\..\..\..\..\..\Data\ExtractTextFromSpecificArea.pdf";

            // Load the PDF file
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(input);

            // Get the first page of the PDF
            PdfPageBase page = pdf.Pages[0];

            // Define options for text extraction
            PdfTextExtractOptions options = new PdfTextExtractOptions();
            options.ExtractArea = new RectangleF(80, 180, 500, 200);

            // Create a PdfTextExtractor object and extract text using the specified options
            PdfTextExtractor pdfTextExtractor = new PdfTextExtractor(page);
            string text = pdfTextExtractor.ExtractText(options);

            // Save the extracted text to a .txt file
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(text);
            string result = "ExtractText_result.txt";
            File.WriteAllText(result, sb.ToString());

            Viewer(result);
        }
        private void Viewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }
    }
}
