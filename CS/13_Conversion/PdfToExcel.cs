using System;
using System.Windows.Forms;
using Spire.Pdf;

namespace PdfToExcel
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
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\PdfToExcel.pdf");

            string result = "PdfToExcel_result.xlsx";
            //Save the pdf file to excel 
            pdf.SaveToFile(result, FileFormat.XLSX);
            //View the excel document
            FileViewer(result);
        }

        private void FileViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }
    }
}
