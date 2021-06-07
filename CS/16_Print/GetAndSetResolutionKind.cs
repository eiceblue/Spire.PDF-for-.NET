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
             String input = "..\\..\\..\\..\\..\\..\\Data\\CustomDocumentProperties.pdf";
            //Create a document
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(input);
            //Set PrinterResolutionKind
            doc.PrintSettings.PrinterResolutionKind = PdfPrinterResolutionKind.High;

            //Get PrinterResolutionKind
            PdfPrinterResolutionKind kind = doc.PrintSettings.PrinterResolutionKind;
            StringBuilder builder = new StringBuilder();
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

            //Write information to a txt file
            string result = "GetAndSetResolutionKind_out.txt";
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
