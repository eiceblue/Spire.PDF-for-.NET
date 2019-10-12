using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Grid;
using Spire.Pdf.Tables;

namespace AddContinuousTables
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a Pdf document
            PdfDocument doc = new PdfDocument();

            //Add a Pdf page
            PdfPageBase page = doc.Pages.Add();

            float y = 20;

            //Draw the table 1
            string title1 = "Table 1";
            PdfLayoutResult result = DrawPDFTable(title1, y, page, "parts");

            //Get the current Y coordinate and page
            y = result.Bounds.Height+10;
            page = result.Page;

            //Draw the table 2
            string title2 = "Table 2";
            result = DrawPDFTable(title2, y, page, "country");

            //Save the Pdf document
            string output = "AddContinuousTables_out.pdf";
            doc.SaveToFile(output);
            doc.Close();

            //Launch the Pdf file
            PDFDocumentViewer(output);
        }
        private PdfLayoutResult DrawPDFTable(string title,float y, PdfPageBase page,string dataName)
        {
            //Draw Title
            PdfBrush brush = PdfBrushes.Black;
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 16f, FontStyle.Bold));
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Center);
            string title1 = title;
            page.Canvas.DrawString(title1, font, brush, page.Canvas.ClientSize.Width / 2, y, format);
            y = y + font.MeasureString(title1, format).Height;
            y = y + 10;

            //Create PDF table and define table style
            PdfTable table = new PdfTable();
            table.Style.CellPadding = 3;
            table.Style.BorderPen = new PdfPen(brush, 0.75f);
            table.Style.DefaultStyle.BackgroundBrush = PdfBrushes.SkyBlue;
            table.Style.DefaultStyle.Font = new PdfTrueTypeFont(new Font("Arial", 10f));
            table.Style.DefaultStyle.StringFormat = format;
            table.Style.AlternateStyle = new PdfCellStyle();
            table.Style.AlternateStyle.BackgroundBrush = PdfBrushes.LightYellow;
            table.Style.AlternateStyle.Font = new PdfTrueTypeFont(new Font("Arial", 10f));
            table.Style.AlternateStyle.StringFormat = format;
            table.Style.HeaderSource = PdfHeaderSource.ColumnCaptions;
            table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.CadetBlue;
            table.Style.HeaderStyle.Font = new PdfTrueTypeFont(new Font("Arial", 14f, FontStyle.Bold));
            table.Style.HeaderStyle.StringFormat = format;
            table.Style.ShowHeader = true;

            //Fill data in table
            table.DataSource = GetData(dataName);

            //Draw the table on Pdf page
            PdfLayoutResult result = table.Draw(page, new PointF(0, y));

            return result;
        }
        private DataTable GetData(string name)
        {
            OleDbConnection conn = new OleDbConnection();

            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\..\..\..\..\Data\demo.mdb";
            OleDbCommand command = new OleDbCommand();
            command.CommandText
                = " select * from "+name;
            command.Connection = conn;
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);

            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            return dataTable;
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
