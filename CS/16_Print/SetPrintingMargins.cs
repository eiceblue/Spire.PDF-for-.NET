using Spire.Pdf;
using Spire.Pdf.Print;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SetPrintingMargins
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Specify the file path of the PDF document to be printed
            string filePath = "../../../../../../Data/SetPrintingMargins.pdf";

            // Create a new PdfDocument object to work with PDF files
            PdfDocument doc = new PdfDocument();

            // Load the PDF document from the specified file path
            doc.LoadFromFile(filePath);

            // Set the multi-page layout for printing, with 2 rows and 2 columns, without duplex printing,
            // with horizontal page order, and a margin of 10 points
            doc.PrintSettings.SelectMultiPageLayout(2, 2, false, PdfMultiPageOrder.Horizontal, 10);

            // Select the page range to be printed, from page 1 to page 4
            doc.PrintSettings.SelectPageRange(1, 4);

            // Set the orientation of the print to portrait (non-landscape)
            doc.PrintSettings.Landscape = false;

            // Print the document using the selected settings
            doc.Print();

            // Close the document after printing
            doc.Close();
        }
    }
}
