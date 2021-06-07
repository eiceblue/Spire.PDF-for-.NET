using System;
using System.Windows.Forms;
using Spire.Pdf;

namespace PdfToExcelOptions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {   //Load a pdf document
            PdfDocument pdf = new PdfDocument();
            string PDFFile = @"..\..\..\..\..\..\Data\PdfToXlsxOptions.pdf";
            pdf.LoadFromFile(PDFFile);

            pdf.ConvertOptions.SetPdfToXlsxOptions(PdfToXlsxLayout.Line);
            string ExcelFile = "PdfToXlsxOptions_results.xlsx";
            //Save the pdf file to excel
            pdf.SaveToFile(ExcelFile, FileFormat.XLSX);
            //View the excel document
            FileViewer(ExcelFile);
        }

        private void FileViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
