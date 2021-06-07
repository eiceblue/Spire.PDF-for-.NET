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
using Spire.Pdf.General.Find;
using System.IO;
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
            String input = @"..\..\..\..\..\..\Data\SearchReplaceTemplate.pdf";
            PdfDocument doc = new PdfDocument();

            // Read a pdf file
            doc.LoadFromFile(input);
            
            // Get the first page of pdf file
            PdfPageBase page = doc.Pages[0];

            // Create PdfTextFindCollection object to find all the matched phrases
            PdfTextFindCollection collection = page.FindText("Spire.PDF for .NET", TextFindParameter.IgnoreCase);

            // Create a StringBuilder object to put the details of the text searched
            StringBuilder builder = new StringBuilder();

            foreach (PdfTextFind find in collection.Finds)
            {
                builder.AppendLine("==================================================================================");
                builder.AppendLine("Match Text: " + find.MatchText);   
                builder.AppendLine("Text: " + find.SearchText);
                builder.AppendLine("Size: " + find.Size);
                builder.AppendLine("Position: " + find.Position);
                builder.AppendLine("The index of page which is including the searched text : " + find.SearchPageIndex);
                builder.AppendLine("The line that contains the searched text : " + find.LineText);
                builder.AppendLine("Match Text: " + find.MatchText);   

            }

            String result = "GetDetailsOfSearchedText_out.txt";

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
