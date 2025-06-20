using Spire.Pdf;
using Spire.Pdf.Texts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GetFontInfoOfSearchedText
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

            //Load from file and get the first page
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\findText.pdf");
            PdfPageBase page = doc.Pages[0];

            // Create PdfTextFinder
            PdfTextFinder finds = new PdfTextFinder(page);
            // Set options to find
            finds.Options.Parameter = TextFindParameter.None;
            // Find the key word
            List<PdfTextFragment> result = finds.Find("science");
            StringBuilder str = new StringBuilder();
            // Iterate the results
            foreach (PdfTextFragment find in result)
            {
                // Get the line of keyword 
                string text = find.LineText;
                // Get the font name 
                string FontName = find.TextStates[0].FontName;
                // Get the fot size
                float FontSize = find.TextStates[0].FontSize;
                // Get font family
                string FontFamily = find.TextStates[0].FontFamily;
                // Get whether the keyword is bold
                bool IsBold = find.TextStates[0].IsBold;
                // Get whether the keyword is simulate bold
                bool IsSimulateBold = find.TextStates[0].IsSimulateBold;
                // Get whether the keyword is italic
                bool IsItalic = find.TextStates[0].IsItalic;
                // Get color
                Color color = find.TextStates[0].ForegroundColor;
                // Append informtion to str
                str.AppendLine(text);
                str.AppendLine("FontName: " + FontName);
                str.AppendLine("FontSize: " + FontSize);
                str.AppendLine("FontFamily: " + FontFamily);
                str.AppendLine("IsBold: " + IsBold);
                str.AppendLine("IsSimulateBold: " + IsSimulateBold);
                str.AppendLine("IsItalic: " + IsItalic);
                str.AppendLine("color: " + color);
                str.AppendLine(" ");
            }

            // Output the file
            String outputFile = "GetFindTextStates-result.txt";

            File.WriteAllText(outputFile, str.ToString());

            //Release Object
            doc.Dispose();

            //Launch the Pdf file
            PDFDocumentViewer(outputFile);

            this.Close();

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
