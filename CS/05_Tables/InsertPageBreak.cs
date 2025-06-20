using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Tables;


namespace InsertPageBreak
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

            //Add a page
            PdfPageBase page = doc.Pages.Add();

            float y = 10;

            //Title
            PdfBrush brush1 = PdfBrushes.Black;
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 16f, FontStyle.Bold));
            PdfStringFormat format1 = new PdfStringFormat(PdfTextAlignment.Center);
            page.Canvas.DrawString("Country List", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1);
            y = y + font1.MeasureString("Country List", format1).Height;
            y = y + 5;

            //Create a table
            PdfTable table = new PdfTable();
            table.Style.BorderPen = new PdfPen(brush1, 0.5f);

            //Set the cell style for header row 
            table.Style.HeaderSource = PdfHeaderSource.Rows;
            table.Style.HeaderRowCount = 1;
            table.Style.ShowHeader = true;
            table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.CadetBlue;
            table.Style.HeaderStyle.Font = new PdfTrueTypeFont(new Font("Arial", 14f, FontStyle.Bold));
            table.Style.HeaderStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);

            //Repeat header
            table.Style.RepeatHeader = true;

            //Set default style for cell
            table.Style.DefaultStyle.BackgroundBrush = PdfBrushes.SkyBlue;
            table.Style.DefaultStyle.Font = new PdfTrueTypeFont(new Font("Arial", 10f));
            table.Style.DefaultStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);

            //Set the cell style for odd row
            table.Style.AlternateStyle = new PdfCellStyle();
            table.Style.AlternateStyle.BackgroundBrush = PdfBrushes.LightYellow;
            table.Style.AlternateStyle.Font = new PdfTrueTypeFont(new Font("Arial", 10f));
            table.Style.AlternateStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);

            //Set data source for table
            table.DataSource = GetData();

            //Set the Pdf table layout and specify the paginate bounds
            PdfTableLayoutFormat tableLayout = new PdfTableLayoutFormat();
            tableLayout.Break = PdfLayoutBreakType.FitElement;
            tableLayout.Layout = PdfLayoutType.Paginate;
            tableLayout.PaginateBounds = new RectangleF(0, y, page.ActualSize.Width - 100, page.ActualSize.Height / 3);

            //Set the row height
            table.BeginRowLayout += new BeginRowLayoutEventHandler(table_BeginRowLayout);

            //Drow the table in page
            PdfLayoutResult result = table.Draw(page, new PointF(0, y), tableLayout);

            //Save the document
            string output = "InsertPageBreak_out.pdf";
            doc.SaveToFile(output);
            doc.Close();

            //Launch the Pdf file
            PDFDocumentViewer(output);
        }

        private String[][] GetData()
        {
            String[] data = {
                    "Name;Capital;Continent;Area;Population",
                    "Argentina;Buenos Aires;South America;2777815;32300003",
                    "Bolivia;La Paz;South America;1098575;7300000",
                    "Brazil;Brasilia;South America;8511196;150400000",
                    "Canada;Ottawa;North America;9976147;26500000",
                    "Chile;Santiago;South America;756943;13200000",
                    "Colombia;Bagota;South America;1138907;33000000",
                    "Cuba;Havana;North America;114524;10600000",
                    "Ecuador;Quito;South America;455502;10600000",
                    "El Salvador;San Salvador;North America;20865;5300000",
                    "Guyana;Georgetown;South America;214969;800000",
                    "Jamaica;Kingston;North America;11424;2500000",
                    "Mexico;Mexico City;North America;1967180;88600000",
                    "Nicaragua;Managua;North America;139000;3900000",
                    "Paraguay;Asuncion;South America;406576;4660000",
                    "Peru;Lima;South America;1285215;21600000",
                    "United States of America;Washington;North America;9363130;249200000",
                    "Uruguay;Montevideo;South America;176140;3002000",
                    "Venezuela;Caracas;South America;912047;19700000"
                };

            //Create 2d array to store data source for table
            String[][] dataSource = new String[data.Length][];
            for (int i = 0; i < data.Length; i++)
            {
                dataSource[i] = data[i].Split(';');
            }
            return dataSource;
        }
        void table_BeginRowLayout(object sender, BeginRowLayoutEventArgs args)
        {
            args.MinimalHeight = 50f;
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
