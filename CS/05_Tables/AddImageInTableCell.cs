using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Tables;
using System.Data;


namespace AddImageInTableCell
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a Pdf documemt
            PdfDocument doc = new PdfDocument();
            PdfPageBase page = doc.Pages.Add();

            //Create a table
            PdfTable table = new PdfTable();
            PdfSolidBrush brush = new PdfSolidBrush(Color.Black);

            //Set the border color for table
            table.Style.BorderPen = new PdfPen(brush, 0.5f);

            //Set the header row cell style
            table.Style.HeaderStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center);
            table.Style.HeaderSource = PdfHeaderSource.Rows;

            //Set the header rows count.
            table.Style.HeaderRowCount = 1;
            table.Style.ShowHeader = true;
            PdfTrueTypeFont fontHeader = new PdfTrueTypeFont(new Font("Arial", 14f));

            //Set font for header row cell
            table.Style.HeaderStyle.Font = fontHeader;

            //Set back color for header
            table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.CadetBlue;

            //Create a font
            PdfTrueTypeFont fontBody = new PdfTrueTypeFont(new Font("Arial", 12f));

            //Set the odd row cell style
            table.Style.AlternateStyle.Font = fontBody;
            table.Style.AlternateStyle.Font = fontBody;

            //Set data source for table
            table.DataSource = GetData();

            // Iterate each column of table
            foreach (PdfColumn column in table.Columns)
            {
                column.StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            }

            //Set the row height
            table.BeginRowLayout += new BeginRowLayoutEventHandler(table_BeginRowLayout);

            //Draw an image in a cell
            table.EndCellLayout += new EndCellLayoutEventHandler(table_EndCellLayout);

            //Draw the table in the page
            table.Draw(page, new PointF(0, 100));

            //Save the Pdf document
            doc.SaveToFile("AddImageinATableCell_out.pdf", FileFormat.PDF);

            //Launch the Pdf file
            PDFDocumentViewer("AddImageinATableCell_out.pdf");
        }

        private DataTable GetData()
        {
            //Create a DataTable object to add data source
            DataTable dt = new DataTable();
            dt.Columns.Add("column1", typeof(string));
            dt.Columns.Add("column2", typeof(string));
            DataRow row1 = dt.NewRow();
            DataRow row2 = dt.NewRow();
            row1[0] = "Column1";
            row1[1] = "Column2";
            row2[0] = "Insert an image in table cell";
            row2[1] = "";
            dt.Rows.Add(row1);
            dt.Rows.Add(row2);
            return dt;
        }

        void table_EndCellLayout(object sender, EndCellLayoutEventArgs args)
        {
            if (args.RowIndex==1&&args.CellIndex == 1)
            {
                //Load an image
                PdfImage image = PdfImage.FromFile("../../../../../../Data/E-iceblueLogo.png");
                float x = (args.Bounds.Width - image.PhysicalDimension.Width) / 2 + args.Bounds.X;
                float y = (args.Bounds.Height - image.PhysicalDimension.Height) / 2 + args.Bounds.Y;

                //Draw Image
                args.Graphics.DrawImage(image, x, y);
            }
        }
        void table_BeginRowLayout(object sender, BeginRowLayoutEventArgs args)
        {
            if (args.RowIndex == 1)
            {
                //Load an image
                PdfImage image = PdfImage.FromFile("../../../../../../Data/E-iceblueLogo.png");
                args.MinimalHeight = image.PhysicalDimension.Height + 4;
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
