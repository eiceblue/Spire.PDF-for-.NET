using Spire.Pdf;
using Spire.Pdf.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToXlsxSpecialTableLayoutOptions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Specify the file path of the PDF document to be converted
            string filePath = @"../../../../../../Data/toXlsxOptions.pdf";

            // Create a new PdfDocument object to work with PDF files
            PdfDocument document = new PdfDocument();

            // Load the PDF document from the specified file path
            document.LoadFromFile(filePath);

            // Create a new XlsxSpecialTableLayoutOptions object with specified layout options
            XlsxSpecialTableLayoutOptions options = new XlsxSpecialTableLayoutOptions(false, false, false);

            // Set the XlsxSpecialTableLayoutOptions as the conversion options for PDF to XLSX conversion
            document.ConvertOptions.SetPdfToXlsxOptions(options);

            // Save the converted document as an XLSX file with the name "Result.xlsx"
            document.SaveToFile("Result.xlsx", FileFormat.XLSX);

            // Dispose of system resources associated with the PdfDocument object
            document.Dispose();
        }
    }
}
