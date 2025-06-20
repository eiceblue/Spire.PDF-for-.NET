using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Grid;

namespace NoneBorderGrid
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

            // Add a page to the document
            PdfPageBase page = doc.Pages.Add();

            // Create a new grid
            PdfGrid grid = new PdfGrid();

            // Add a row to the grid
            PdfGridRow row1 = grid.Rows.Add();

            // Add 2 columns to the grid
            grid.Columns.Add(2);

            // Set border dash style for specific cell in the row
            row1.Cells[0].Style.Borders.Bottom.DashStyle = PdfDashStyle.None;
            row1.Cells[0].Style.Borders.Top.DashStyle = PdfDashStyle.None;
            row1.Cells[0].Style.Borders.Right.DashStyle = PdfDashStyle.None;
            row1.Cells[0].Style.Borders.Left.DashStyle = PdfDashStyle.None;

            // Set cell values in the row
            string str = "Hello Word!";
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                row1.Cells[i].Value = str;
            }

            // Draw the grid on the page at the specified position
            grid.Draw(page, new PointF(0, 50));

            // Save the document as a PDF file with no borders in the grid
            string result = "PDFNoneBorderGrid.pdf";
            doc.SaveToFile(result, FileFormat.PDF);

            //Launch the Pdf file
            PDFDocumentViewer(result);
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
