using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PrintPdfDocument
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new PDF document
            PdfDocument doc = new PdfDocument();

            // Load an existing PDF file into the document
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\PrintPdfDocument.pdf");

            // Create a print dialog to select the printer and pages to print
            PrintDialog dialogPrint = new PrintDialog();
            dialogPrint.AllowPrintToFile = true;
            dialogPrint.AllowSomePages = true;
            dialogPrint.PrinterSettings.FromPage = 1;
            dialogPrint.PrinterSettings.ToPage = doc.Pages.Count;

            // If the user clicks OK in the print dialog, proceed with printing
            if (dialogPrint.ShowDialog() == DialogResult.OK)
            {
                // Configure the print settings based on the selected printer and page range
                doc.PrintSettings.SelectPageRange(dialogPrint.PrinterSettings.FromPage, dialogPrint.PrinterSettings.ToPage);
                doc.PrintSettings.PrinterName = dialogPrint.PrinterSettings.PrinterName;

                // Print the document using the specified settings
                doc.Print();
            }
        }
    }
}
