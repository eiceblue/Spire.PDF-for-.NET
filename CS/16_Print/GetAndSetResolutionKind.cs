using Spire.Pdf;
using Spire.Pdf.Print;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GetAndSetResolutionKind
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Define the input file path for the PDF document
            String input = "..\\..\\..\\..\\..\\..\\Data\\CustomDocumentProperties.pdf";

            // Create a new PDF document object
            PdfDocument doc = new PdfDocument();

            // Load the PDF document from the specified input file path
            doc.LoadFromFile(input);

            // Set the PrinterResolutionKind property of the PDF document's PrintSettings to High
            doc.PrintSettings.PrinterResolutionKind = PdfPrinterResolutionKind.High;

            // Get the current value of the PrinterResolutionKind property of the PDF document's PrintSettings
            PdfPrinterResolutionKind kind = doc.PrintSettings.PrinterResolutionKind;

            // Create a StringBuilder object to build the output string
            StringBuilder builder = new StringBuilder();

            // Use a switch statement to determine the value of the PrinterResolutionKind and append it to the StringBuilder
            switch (kind)
            {
                case PdfPrinterResolutionKind.High:
                    builder.AppendLine("High");
                    break;
                case PdfPrinterResolutionKind.Medium:
                    builder.AppendLine("Medium");
                    break;
                case PdfPrinterResolutionKind.Low:
                    builder.AppendLine("Low");
                    break;
                case PdfPrinterResolutionKind.Draft:
                    builder.AppendLine("Draft");
                    break;
                case PdfPrinterResolutionKind.Custom:
                    builder.AppendLine("Custom");
                    break;
            }

            // Define the output file path for the text file
            string result = "GetAndSetResolutionKind_out.txt";

            // Write the contents of the StringBuilder to the specified text file
            File.WriteAllText(result, builder.ToString());

            //Launch the file
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
