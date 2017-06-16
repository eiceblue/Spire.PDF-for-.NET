using System;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Lists;

namespace List
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

            //margin
            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
            PdfMargins margin = new PdfMargins();
            margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Bottom = margin.Top;
            margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Right = margin.Left;

            // Create one page
            PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, margin);

            float y = 10;

            //title
            PdfBrush brush1 = PdfBrushes.Black;
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 16f, FontStyle.Bold), true);
            PdfStringFormat format1 = new PdfStringFormat(PdfTextAlignment.Center);
            page.Canvas.DrawString("Categories List", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1);
            y = y + font1.MeasureString("Categories List", format1).Height;
            y = y + 5;

            RectangleF rctg = new RectangleF(new PointF(0, 0), page.Canvas.ClientSize);
            PdfLinearGradientBrush brush2
                = new PdfLinearGradientBrush(rctg, Color.Navy, Color.OrangeRed, PdfLinearGradientMode.Vertical);
            PdfLinearGradientBrush brush3
                = new PdfLinearGradientBrush(rctg, Color.OrangeRed, Color.Navy, PdfLinearGradientMode.Vertical);
            PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 10f), true);
            PdfTrueTypeFont font3 = new PdfTrueTypeFont(new Font("Arial", 8f), true);

            PdfOrderedMarker marker1
                = new PdfOrderedMarker(PdfNumberStyle.LowerRoman, new PdfFont(PdfFontFamily.Helvetica, 10f));
            PdfOrderedMarker marker2
                = new PdfOrderedMarker(PdfNumberStyle.Numeric, new PdfFont(PdfFontFamily.Helvetica, 8f));

            PdfSortedList vendorList = new PdfSortedList(font2);
            vendorList.Indent = 0;
            vendorList.TextIndent = 5;
            vendorList.Brush = brush2;
            vendorList.Marker = marker1;
            using (OleDbConnection conn = new OleDbConnection())
            {
                conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\..\..\..\..\Data\demo.mdb";
                OleDbCommand command = new OleDbCommand();
                command.CommandText
                    = " select VendorNo, VendorName from vendors ";
                command.Connection = conn;

                OleDbCommand command2 = new OleDbCommand();
                command2.CommandText
                    = " select Description from parts where VendorNo = @VendorNo";
                command2.Connection = conn;
                OleDbParameter param = new OleDbParameter("@VendorNo", OleDbType.Double);
                command2.Parameters.Add(param);

                conn.Open();

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    double id = reader.GetDouble(0);
                    PdfListItem item = vendorList.Items.Add(reader.GetString(1));
                    PdfSortedList subList = new PdfSortedList(font3);
                    subList.Marker = marker2;
                    subList.Brush = brush3;
                    item.SubList = subList;
                    subList.TextIndent = 20;
                    command2.Parameters[0].Value = id;
                    using (OleDbDataReader reader2 = command2.ExecuteReader())
                    {
                        while (reader2.Read())
                        {
                            subList.Items.Add(reader2.GetString(0));
                        }
                    }
                    String maxNumberLabel = Convert.ToString(subList.Items.Count);
                    subList.Indent = 30 - font3.MeasureString(maxNumberLabel).Width;
                }
            }

            PdfTextLayout textLayout = new PdfTextLayout();
            textLayout.Break = PdfLayoutBreakType.FitPage;
            textLayout.Layout = PdfLayoutType.Paginate;
            vendorList.Draw(page, new PointF(0, y), textLayout);

            //Save pdf file.
            doc.SaveToFile("List.pdf");
            doc.Close();

            //Launching the Pdf file.
            PDFDocumentViewer("List.pdf");
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
