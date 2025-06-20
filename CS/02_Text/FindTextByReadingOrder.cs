using Spire.Pdf;
using Spire.Pdf.Texts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindTextByReadingOrder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Specify the file path of the PDF file to be loaded
            string filePath = @"../../../../../../Data/ColumnarText.pdf";

            // Create a new PdfDocument object to work with PDF files
            PdfDocument doc = new PdfDocument();

            // Load the PDF file from the specified file path
            doc.LoadFromFile(filePath);

            // Get the first page of the loaded document
            PdfPageBase pdfPageBase = doc.Pages[0];

            // Create a PdfTextFinder object 'finder' with the first page for searching text
            PdfTextFinder finder = new PdfTextFinder(pdfPageBase);

            // Set the search strategy as Simple
            finder.Options.Strategy = PdfTextStrategy.Simple;

            // Find all occurrences of the text "knowledge" on the page
            List<PdfTextFragment> pdfTextFragments = finder.Find("knowledge");

            // Create a StringBuilder object 'builder' to store the extracted information
            StringBuilder builder = new StringBuilder();

            // Iterate over each found text fragment
            foreach (PdfTextFragment find in pdfTextFragments)
            {
                // Append separator line to the string builder
                builder.AppendLine("==================================================================================");

                // Append the found text to the string builder
                builder.AppendLine("Text: " + find.Text);

                // Append the sizes of the text to the string builder
                foreach (SizeF size in find.Sizes)
                {
                    builder.AppendLine("Size: " + size);
                }

                // Append the positions of the text to the string builder
                foreach (PointF point in find.Positions)
                {
                    builder.AppendLine("Position: " + point);
                }

                // Append the line that contains the searched text to the string builder
                builder.AppendLine("The line that contains the searched text : " + find.LineText);
            }

            // Specify the result file name
            string result = "FindTextByReadingOrder_out.txt";

            // Write the contents of the string builder to the result file
            File.WriteAllText(result, builder.ToString());

            // Dispose of system resources associated with the PdfDocument object
            doc.Dispose();
        }
    }
}
