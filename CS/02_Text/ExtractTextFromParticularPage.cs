using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Texts;
using System.IO;

namespace ExtractTextFromParticularPage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String input = @"..\..\..\..\..\..\Data\PDFTemplate-Az.pdf";
            PdfDocument doc = new PdfDocument();
            // Read a pdf file
            doc.LoadFromFile(input);

            // Get the first page
            PdfPageBase page = doc.Pages[0];

            // Extract text from page keeping white space
            PdfTextExtractOptions options = new PdfTextExtractOptions();
            options.IsExtractAllText = true; //false->Extract text from page without keeping white space
            PdfTextExtractor pdfTextExtractor = new PdfTextExtractor(page);
            String text = pdfTextExtractor.ExtractText(options);

            String result = Path.GetFullPath("ExtractTextFromParticularPage_out.txt");
            // Create a writer to put the extracted text
            TextWriter tw = new StreamWriter(result);

            // Write a line of text to the file
            tw.WriteLine(text);

            // Close the stream
            tw.Close();

            MessageBox.Show("\nText extracted successfully from particular pages of PDF Document.\nFile saved at " + result);
        }
    }
}
