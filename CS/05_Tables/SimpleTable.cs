using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Tables;


namespace SimpleTable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Load a PDF file
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\SimpleTable.pdf");

            //Get the first page
            PdfPageBase page = doc.Pages[0];
            float y = 320;

            // Add title to the page
            PdfBrush brush1 = PdfBrushes.Black;
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 16f, FontStyle.Bold));
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
              PdfTrueTypeFont font1 = new PdfTrueTypeFont("Arial", 16f, PdfFontStyle.Bold, true);
            */
            PdfStringFormat format1 = new PdfStringFormat(PdfTextAlignment.Center);
            page.Canvas.DrawString("Country List", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1);
            y = y + font1.MeasureString("Country List", format1).Height;
            y = y + 5;

            // Define data for the table
            String[] data
                = {
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

            // Convert data into a 2D array
            String[][] dataSource = new String[data.Length][];
            for (int i = 0; i < data.Length; i++)
            {
                dataSource[i] = data[i].Split(';');
            }
            // Create a new table and set its style
            PdfTable table = new PdfTable();
            table.Style.CellPadding = 2;
            table.Style.HeaderSource = PdfHeaderSource.Rows;
            table.Style.HeaderRowCount = 1;
            table.Style.ShowHeader = true;

            // Specify the data source for table
            table.DataSource = dataSource;

            // Draw the table on the page
            PdfLayoutResult result = table.Draw(page, new PointF(60, y));
            y = y + result.Bounds.Height + 5;

            // Add a note about the number of countries in the list
            PdfBrush brush2 = PdfBrushes.Gray;
            PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 9f));
            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
              PdfTrueTypeFont font2 = new PdfTrueTypeFont("Arial", 9f, PdfFontStyle.Regular, true);
            */
            page.Canvas.DrawString(String.Format("* {0} countries in the list.", data.Length - 1), font2, brush2, 65, y);

            //Save the document
            doc.SaveToFile("SimpleTable.pdf");
            doc.Close();

            //Launch the Pdf file
            PDFDocumentViewer("SimpleTable.pdf");
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
