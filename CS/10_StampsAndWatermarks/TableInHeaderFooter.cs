using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TableInHeaderFooter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a pdf document.
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile("../../../../../../../Data/PDFTemplate_HF.pdf");

            //Draw table in header
            DrawTableInHeaderFooter(doc);

            //Save the document
            doc.SaveToFile("TableInHeaderFooter_out.pdf");

            //Launch the Pdf file
            PDFDocumentViewer("TableInHeaderFooter_out.pdf");
        }
        private void DrawTableInHeaderFooter(PdfDocument doc)
        {
            // Define the data for the table.
            String[] data = {
                                "Column1;Column2",
                                "Spire.PDF for .NET;Spire.PDF for JAVA",
                            };

            float y = 20;
            PdfBrush brush = PdfBrushes.Black;

            // Iterate through each page in the document.
            foreach (PdfPageBase page in doc.Pages)
            {
                // Prepare the data source for the table.
                String[][] dataSource = new String[data.Length][];
                for (int i = 0; i < data.Length; i++)
                {
                    dataSource[i] = data[i].Split(';');
                }

                // Create a PDF table.
                PdfTable table = new PdfTable();
                table.Style.CellPadding = 2;
                table.Style.BorderPen = new PdfPen(brush, 0.1f);
                table.Style.HeaderStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center);
                table.Style.HeaderSource = PdfHeaderSource.Rows;
                table.Style.HeaderRowCount = 1;
                table.Style.ShowHeader = true;
                table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.CadetBlue;
                table.DataSource = dataSource;

                // Set the string format for each column.
                foreach (PdfColumn column in table.Columns)
                {
                    column.StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
                }

                // Draw the table on the page.
                table.Draw(page, new PointF(0, y));
            }
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
