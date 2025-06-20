using System;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Utilities;
using System.Text;
using System.IO;

namespace ExtractTable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Input and output file paths
            string input = @"..\..\..\..\..\..\Data\ExtractTable.pdf";
            string output = "ExtractTable_result.txt";

            //Create a PdfDocument
            PdfDocument pdf = new PdfDocument();

            //Load the input file from disk
            pdf.LoadFromFile(input);

            //Create PdfTableExtractor object to extract tables from PDF
            PdfTableExtractor extractor = new PdfTableExtractor(pdf);
            PdfTable[] tableLists = null;
            StringBuilder builder = new StringBuilder();

            //Iterate each page of PDF file
            for (int pageIndex = 0; pageIndex < pdf.Pages.Count; pageIndex++)
            {
                //Extract tables in each page
                tableLists = extractor.ExtractTable(pageIndex);

                if (tableLists != null && tableLists.Length > 0)
                {
                    //Iterate each table from array
                    foreach (PdfTable table in tableLists)
                    {
                        int row = table.GetRowCount();
                        int column = table.GetColumnCount();
                        for (int i = 0; i < row; i++)
                        {
                            for (int j = 0; j < column; j++)
                            {
                                //Extract the text in each cell
                                string text = table.GetText(i, j);

                                //Append the text into StringBuilder
                                builder.Append(text + " ");
                            }

                            builder.Append("\r\n");
                        }
                    }
                }
            }
            //Write all text 
            File.WriteAllText(output, builder.ToString());

            //Launch the Pdf files
            FileViewer(output);
        }
        private void FileViewer(string filename)
        {
            try
            {
                System.Diagnostics.Process.Start(filename);
            }
            catch { }
        }
    }
}
