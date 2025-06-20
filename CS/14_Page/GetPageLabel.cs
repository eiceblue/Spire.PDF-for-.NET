using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetPageLabel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a PdfDocument instance.
            PdfDocument pdf = new PdfDocument();

            // Load the PDF file from the specified file path.
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\PageLabel.pdf");

            // Create a StringBuilder instance to store page labels.
            StringBuilder sb = new StringBuilder();

            // Get the labels of the pages in the PDF file.
            for (int i = 0; i < pdf.Pages.Count; i++)
            {
                // Append the page label information to the StringBuilder.
                sb.AppendLine("The page label of page " + (i + 1) + " is \"" + pdf.Pages[i].PageLabel + "\"");
            }

            // Specify the output file name for saving the page label information.
            String result = "PageLabels.txt";

            // Save the page label information to a text file with the specified file name.
            File.WriteAllText(result, sb.ToString());

            //Launch file
            PDFDocumentViewer(result);

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
