using Spire.Pdf;
using Spire.Pdf.Conversion;
using System;
using System.Windows.Forms;


namespace ToXlsxOptions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load a PDF document from the specified file path.
            PdfDocument document = new PdfDocument();
            document.LoadFromFile(@"../../../../../../Data/ToXlsxOptions.pdf");

            // Create an XlsxLineLayoutOptions object with four parameters: convertToMultipleSheet, showRotatedText, splitCell, wrapText.
            // These parameters determine various options for converting PDF to Excel.
            XlsxLineLayoutOptions options = new XlsxLineLayoutOptions(false, false, false, false);

            // Set the PDF to Excel conversion options of the document.
            document.ConvertOptions.SetPdfToXlsxOptions(options);

            // Specify the output file name for saving as Excel.
            string output = "ToXlsxOptions.xlsx";

            // Save the document as Excel with the specified output file name and format (XLSX).
            document.SaveToFile(output, FileFormat.XLSX);

            //Launch the Pdf file
            PDFDocumentViewer(output);
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
