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
            //Create the PDF document
            PdfDocument doc = new PdfDocument();
            //Add the first page
            PdfPageBase page = doc.Pages.Add();
            //Create grid
            PdfGrid grid = new PdfGrid();
            //Add a row
            PdfGridRow row1 = grid.Rows.Add();
            grid.Columns.Add(2);

            //Set none border grid
            row1.Cells[0].Style.Borders.Bottom.DashStyle = PdfDashStyle.None;
            row1.Cells[0].Style.Borders.Top.DashStyle = PdfDashStyle.None;
            row1.Cells[0].Style.Borders.Right.DashStyle = PdfDashStyle.None;
            row1.Cells[0].Style.Borders.Left.DashStyle = PdfDashStyle.None;

            //Fill data
            string str = "Hello Word!";
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                row1.Cells[i].Value = str;
            }

            //Draw the grid on page
            grid.Draw(page, new PointF(0, 50));

            //Save pdf file
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
