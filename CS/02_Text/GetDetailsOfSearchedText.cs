using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Fields;
using Spire.Pdf.Annotations;
using Spire.Pdf.Graphics;
using Spire.Pdf.Actions;
using Spire.Pdf.General;
using System.IO;
using Spire.Pdf.Texts;

namespace GetDetailsOfSearchedText
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Specify the path of the input PDF file
            String input = @"..\..\..\..\..\..\Data\SearchReplaceTemplate.pdf";
            PdfDocument doc = new PdfDocument();

            // Load the PDF document from the specified file
            doc.LoadFromFile(input);

            // Get the first page of the PDF document
            PdfPageBase page = doc.Pages[0];

            // Create a PdfTextFinder object for searching text within the page
            PdfTextFinder finder = new PdfTextFinder(page);
            finder.Options.Parameter = Spire.Pdf.Texts.TextFindParameter.IgnoreCase;

            // Find occurrences of the specified text within the page
            List<PdfTextFragment> finds = finder.Find("Spire.PDF for .NET");

            // Create a StringBuilder object to store the details of the searched text
            StringBuilder builder = new StringBuilder();

            // Iterate through each found text fragment
            foreach (PdfTextFragment find in finds)
            {
                builder.AppendLine("==================================================================================");
                // Append the matched text and the detail of matched text to the StringBuilder
                builder.AppendLine("Match Text: " + find.Text);
                builder.AppendLine("Size: " + find.Sizes[0]);
                builder.AppendLine("Position: " + find.Positions[0]);
                builder.AppendLine("The line that contains the searched text: " + find.LineText);
            }

            // Specify the output file path for storing the search result
            String result = "GetDetailsOfSearchedText_out.txt";

            // Write the contents of the StringBuilder to the output file
            File.WriteAllText(result, builder.ToString());

            //Launch the result file
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
