using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Tables;
namespace TableBorder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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

            String[][] dataSource
                = new String[data.Length][];
            for (int i = 0; i < data.Length; i++)
            {
                dataSource[i] = data[i].Split(';');
            }

            //Create a pdf document
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\TableBorder.pdf");
          
            PdfPageBase page = doc.Pages[0];

            //Create a pdf table
            PdfTable table = new PdfTable();

            //Set data source of the pdf table
            table.DataSource = dataSource;

            //Set the color of table border
            PdfTableStyle style = new PdfTableStyle();
            style.CellPadding = 2;
            style.BorderPen = new PdfPen(Color.Gray, 1f);
            table.Style = style;

            //Add custom method to BeginRowLayout event
            table.BeginRowLayout += new BeginRowLayoutEventHandler(table_BeginRowLayout);

            //Draw the pdf table into pdf document
            table.Draw(page, new PointF(60, 320));

            string output = "TableBorder.pdf";

            //Save pdf document
            doc.SaveToFile(output);

            //Launch the Pdf file
            PDFDocumentViewer(output);
        }
        private void table_BeginRowLayout(object sender, BeginRowLayoutEventArgs args)
        {
            //Set the color of table cell border
            PdfCellStyle cellStyle = new PdfCellStyle();
            cellStyle.BorderPen = new PdfPen(Color.LightBlue, 0.9f);
            args.CellStyle = cellStyle;
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
